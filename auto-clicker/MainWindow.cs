using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.System.SystemServices;
using Windows.Win32.UI.Input.KeyboardAndMouse;
using Timer = System.Timers.Timer;

namespace auto_clicker
{
    public partial class MainWindow : Form
    {
        public event EventHandler? HandleSelected;
        public event EventHandler? ClickTimerChanged;

        private static readonly uint[,] BUTTONS =
        {
            { PInvoke.WM_LBUTTONDOWN, PInvoke.WM_LBUTTONUP, (uint)MODIFIERKEYS_FLAGS.MK_LBUTTON },
            { PInvoke.WM_MBUTTONDOWN, PInvoke.WM_MBUTTONUP, (uint)MODIFIERKEYS_FLAGS.MK_MBUTTON },
            { PInvoke.WM_RBUTTONDOWN, PInvoke.WM_RBUTTONUP, (uint)MODIFIERKEYS_FLAGS.MK_RBUTTON },
        };

        private static readonly HOT_KEY_MODIFIERS START_STOP_MODIFIER = HOT_KEY_MODIFIERS.MOD_NOREPEAT;
        private static readonly VIRTUAL_KEY START_STOP_HOT_KEY = VIRTUAL_KEY.VK_F6;

        private bool isSelecting;
        private HWND selectedHandle = new();
        private string selectedHandleText = string.Empty;
        private string selectedHandleTitle = string.Empty;

        private int clickButton = 0;
        private int clickInterval = 1000;
        private int xCoordinate = 0;
        private int yCoordinate = 0;

        private Timer clickTimer = new();
        private GlobalHotKey? startStopHotKey;

        public MainWindow()
        {
            try
            {
                startStopHotKey = new(START_STOP_MODIFIER, START_STOP_HOT_KEY);
                startStopHotKey.HotKeyPressed += OnHotKeyPressed;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            InitializeComponent();

            HandleSelected += OnHandleSelected;
            ClickTimerChanged += OnClickTimerChanged;

            buttonComboBox.SelectedIndex = clickButton;
            intervalTextBox.Value = clickInterval;
            xPosTextBox.Value = xCoordinate;
            yPosTextBox.Value = yCoordinate;

            clickTimer.Interval = clickInterval;
            clickTimer.Elapsed += OnClickTimerElapsed;
        }

        private static unsafe bool IsRelativeWindow(HWND aHandle, HWND bHandle)
        {
            if (aHandle.IsNull || bHandle.IsNull)
            {
                return false;
            }
            if (aHandle == bHandle)
            {
                return true;
            }

            uint aPID, bPID;
            PInvoke.GetWindowThreadProcessId(aHandle, &aPID);
            PInvoke.GetWindowThreadProcessId(bHandle, &bPID);

            return aPID == bPID;
        }

        private static unsafe string GetWindowText(HWND handle)
        {
            if (handle.IsNull)
            {
                return string.Empty;
            }

            int length = PInvoke.GetWindowTextLength(handle);
            Span<char> title = stackalloc char[length + 1];
            fixed (char* titlePtr = title)
            {
                PInvoke.GetWindowText(handle, titlePtr, length + 1);
            }

            return title.ToString();
        }

        private void OnHandleSelected(object? sender, EventArgs e)
        {
            windowHandleTextBox.Text = selectedHandleText;
            windowTitleTextBox.Text = selectedHandleTitle;
            xPosTextBox.Value = xCoordinate;
            yPosTextBox.Value = yCoordinate;

            startButton.Enabled = !selectedHandle.IsNull;
            stopButton.Enabled = false;
        }

        private void OnClickTimerChanged(object? sender, EventArgs e)
        {
            windowSelectToolGroupBox.Enabled = !clickTimer.Enabled;
            clickOptionsGroupBox.Enabled = !clickTimer.Enabled;
            clickPositionGroupBox.Enabled = !clickTimer.Enabled;
            startButton.Enabled = !clickTimer.Enabled;
            stopButton.Enabled = clickTimer.Enabled;
        }

        private void OnClickTimerElapsed(object? sender, EventArgs e)
        {
            if (selectedHandle.IsNull)
            {
                return;
            }

            nint lParam = xCoordinate | (yCoordinate << 16);
            PInvoke.SendMessage(selectedHandle, BUTTONS[clickButton, 0], BUTTONS[clickButton, 2], lParam);
            PInvoke.SendMessage(selectedHandle, BUTTONS[clickButton, 1], BUTTONS[clickButton, 2], lParam);
        }

        private void OnHotKeyPressed(object? sender, EventArgs e)
        {
            if (selectedHandle.IsNull)
            {
                return;
            }

            if (!clickTimer.Enabled)
            {
                clickTimer.Start();
            }
            else
            {
                clickTimer.Stop();
            }

            ClickTimerChanged?.Invoke(this, EventArgs.Empty);
        }

        private void SetHandle(HWND handle, Point cursorPos)
        {
            if (handle.IsNull || IsRelativeWindow(handle, new(Handle)))
            {
                selectedHandle = new();
                selectedHandleText = string.Empty;
                selectedHandleTitle = string.Empty;
                xCoordinate = 0;
                yCoordinate = 0;
            }
            else
            {
                selectedHandle = handle;
                selectedHandleText = Convert.ToString(selectedHandle.Value.ToInt64(), 16).ToUpper().PadLeft(8, '0');
                selectedHandleTitle = GetWindowText(handle);
                xCoordinate = cursorPos.X;
                yCoordinate = cursorPos.Y;
            }

            HandleSelected?.Invoke(this, EventArgs.Empty);
        }

        private void selectWindowButton_MouseDown(object sender, MouseEventArgs e)
        {
            isSelecting = true;
            selectWindowButton.Enabled = false;
            selectWindowButton.Cursor = Cursors.Cross;

            HWND handle = new(selectWindowButton.Handle);
            PInvoke.SetCapture(handle);
        }

        private void selectWindowButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isSelecting)
            {
                return;
            }

            Point cursorPos = new(e.X, e.Y);
            PInvoke.ClientToScreen(new(selectWindowButton.Handle), ref cursorPos);

            HWND handle = PInvoke.WindowFromPoint(cursorPos);
            PInvoke.ScreenToClient(handle, ref cursorPos);

            SetHandle(handle, cursorPos);
        }

        private void selectWindowButton_MouseUp(object sender, MouseEventArgs e)
        {
            isSelecting = false;
            selectWindowButton.Enabled = true;
            selectWindowButton.Cursor = Cursors.Default;

            PInvoke.ReleaseCapture();
        }

        private void intervalTextBox_TextChanged(object sender, EventArgs e)
        {
            clickInterval = intervalTextBox.Value;
            clickTimer.Interval = clickInterval;
        }

        private void xPosTextBox_TextChanged(object sender, EventArgs e)
        {
            xCoordinate = xPosTextBox.Value;
        }

        private void yPosTextBox_TextChanged(object sender, EventArgs e)
        {
            yCoordinate = yPosTextBox.Value;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            clickTimer.Start();

            ClickTimerChanged?.Invoke(this, EventArgs.Empty);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            clickTimer.Stop();

            ClickTimerChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}