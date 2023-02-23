using Windows.Win32;
using Windows.Win32.UI.Input.KeyboardAndMouse;

namespace auto_clicker
{
    internal class GlobalHotKey : IDisposable
    {
        private class Window : NativeWindow, IDisposable
        {
            public EventHandler? HotKeyPressed;

            public Window()
            {
                CreateHandle(new());
            }

            public void Dispose()
            {
                DestroyHandle();
            }

            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);

                if (m.Msg == PInvoke.WM_HOTKEY)
                {
                    HotKeyPressed?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public EventHandler? HotKeyPressed;

        private static int currentHotKeyId = 0;

        private Window window = new();
        private int hotKeyId;

        public GlobalHotKey(HOT_KEY_MODIFIERS modifiers, VIRTUAL_KEY virtualKey)
        {
            window.HotKeyPressed += OnHotKeyPressed;
            hotKeyId = currentHotKeyId++;
            if (!PInvoke.RegisterHotKey(new(window.Handle), hotKeyId, modifiers, (uint)virtualKey))
            {
                throw new InvalidOperationException("Unable to register the hot key. Please try again.");
            }
        }

        public void Dispose()
        {
            PInvoke.UnregisterHotKey(new(window.Handle), hotKeyId);
            window.Dispose();
        }

        private void OnHotKeyPressed(object? sender, EventArgs e)
        {
            HotKeyPressed?.Invoke(this, EventArgs.Empty);
        }
    }
}
