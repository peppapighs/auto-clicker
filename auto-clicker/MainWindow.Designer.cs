namespace auto_clicker
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            windowSelectToolGroupBox = new GroupBox();
            selectWindowButton = new Button();
            windowTitleTextBox = new TextBox();
            windowHandleTextBox = new TextBox();
            windowTitleLabel = new Label();
            windowHandleLabel = new Label();
            clickOptionsGroupBox = new GroupBox();
            intervalTextBox = new NumericTextBox();
            intervalLabel = new Label();
            buttonComboBox = new ComboBox();
            buttonLabel = new Label();
            clickPositionGroupBox = new GroupBox();
            yPosTextBox = new NumericTextBox();
            xPosTextBox = new NumericTextBox();
            yPosLabel = new Label();
            xPosLabel = new Label();
            startButton = new Button();
            stopButton = new Button();
            windowSelectToolGroupBox.SuspendLayout();
            clickOptionsGroupBox.SuspendLayout();
            clickPositionGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // windowSelectToolGroupBox
            // 
            windowSelectToolGroupBox.Controls.Add(selectWindowButton);
            windowSelectToolGroupBox.Controls.Add(windowTitleTextBox);
            windowSelectToolGroupBox.Controls.Add(windowHandleTextBox);
            windowSelectToolGroupBox.Controls.Add(windowTitleLabel);
            windowSelectToolGroupBox.Controls.Add(windowHandleLabel);
            windowSelectToolGroupBox.Location = new Point(12, 12);
            windowSelectToolGroupBox.Name = "windowSelectToolGroupBox";
            windowSelectToolGroupBox.Size = new Size(280, 120);
            windowSelectToolGroupBox.TabIndex = 0;
            windowSelectToolGroupBox.TabStop = false;
            windowSelectToolGroupBox.Text = "Window select tool";
            // 
            // selectWindowButton
            // 
            selectWindowButton.Location = new Point(6, 80);
            selectWindowButton.Name = "selectWindowButton";
            selectWindowButton.Size = new Size(268, 34);
            selectWindowButton.TabIndex = 4;
            selectWindowButton.Text = "Select window";
            selectWindowButton.UseVisualStyleBackColor = true;
            selectWindowButton.MouseDown += selectWindowButton_MouseDown;
            selectWindowButton.MouseMove += selectWindowButton_MouseMove;
            selectWindowButton.MouseUp += selectWindowButton_MouseUp;
            // 
            // windowTitleTextBox
            // 
            windowTitleTextBox.Location = new Point(105, 51);
            windowTitleTextBox.Name = "windowTitleTextBox";
            windowTitleTextBox.ReadOnly = true;
            windowTitleTextBox.Size = new Size(169, 23);
            windowTitleTextBox.TabIndex = 3;
            // 
            // windowHandleTextBox
            // 
            windowHandleTextBox.Location = new Point(105, 22);
            windowHandleTextBox.Name = "windowHandleTextBox";
            windowHandleTextBox.ReadOnly = true;
            windowHandleTextBox.Size = new Size(169, 23);
            windowHandleTextBox.TabIndex = 2;
            // 
            // windowTitleLabel
            // 
            windowTitleLabel.AutoSize = true;
            windowTitleLabel.Location = new Point(6, 54);
            windowTitleLabel.Name = "windowTitleLabel";
            windowTitleLabel.Size = new Size(77, 15);
            windowTitleLabel.TabIndex = 1;
            windowTitleLabel.Text = "Window title:";
            // 
            // windowHandleLabel
            // 
            windowHandleLabel.AutoSize = true;
            windowHandleLabel.Location = new Point(6, 25);
            windowHandleLabel.Name = "windowHandleLabel";
            windowHandleLabel.Size = new Size(93, 15);
            windowHandleLabel.TabIndex = 0;
            windowHandleLabel.Text = "Window handle:";
            // 
            // clickOptionsGroupBox
            // 
            clickOptionsGroupBox.Controls.Add(intervalTextBox);
            clickOptionsGroupBox.Controls.Add(intervalLabel);
            clickOptionsGroupBox.Controls.Add(buttonComboBox);
            clickOptionsGroupBox.Controls.Add(buttonLabel);
            clickOptionsGroupBox.Location = new Point(12, 138);
            clickOptionsGroupBox.Name = "clickOptionsGroupBox";
            clickOptionsGroupBox.Size = new Size(169, 80);
            clickOptionsGroupBox.TabIndex = 1;
            clickOptionsGroupBox.TabStop = false;
            clickOptionsGroupBox.Text = "Click options";
            // 
            // intervalTextBox
            // 
            intervalTextBox.Location = new Point(88, 51);
            intervalTextBox.MaxValue = 86400000;
            intervalTextBox.MinValue = 1;
            intervalTextBox.Name = "intervalTextBox";
            intervalTextBox.Size = new Size(75, 23);
            intervalTextBox.TabIndex = 3;
            intervalTextBox.Text = "1000";
            intervalTextBox.Value = 1000;
            intervalTextBox.TextChanged += intervalTextBox_TextChanged;
            // 
            // intervalLabel
            // 
            intervalLabel.AutoSize = true;
            intervalLabel.Location = new Point(6, 54);
            intervalLabel.Name = "intervalLabel";
            intervalLabel.Size = new Size(76, 15);
            intervalLabel.TabIndex = 2;
            intervalLabel.Text = "Interval (ms):";
            // 
            // buttonComboBox
            // 
            buttonComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            buttonComboBox.FormattingEnabled = true;
            buttonComboBox.Items.AddRange(new object[] { "Left", "Middle", "Right" });
            buttonComboBox.Location = new Point(88, 22);
            buttonComboBox.Name = "buttonComboBox";
            buttonComboBox.Size = new Size(75, 23);
            buttonComboBox.TabIndex = 1;
            // 
            // buttonLabel
            // 
            buttonLabel.AutoSize = true;
            buttonLabel.Location = new Point(6, 25);
            buttonLabel.Name = "buttonLabel";
            buttonLabel.Size = new Size(46, 15);
            buttonLabel.TabIndex = 0;
            buttonLabel.Text = "Button:";
            // 
            // clickPositionGroupBox
            // 
            clickPositionGroupBox.Controls.Add(yPosTextBox);
            clickPositionGroupBox.Controls.Add(xPosTextBox);
            clickPositionGroupBox.Controls.Add(yPosLabel);
            clickPositionGroupBox.Controls.Add(xPosLabel);
            clickPositionGroupBox.Location = new Point(187, 138);
            clickPositionGroupBox.Name = "clickPositionGroupBox";
            clickPositionGroupBox.Size = new Size(105, 80);
            clickPositionGroupBox.TabIndex = 2;
            clickPositionGroupBox.TabStop = false;
            clickPositionGroupBox.Text = "Click position";
            // 
            // yPosTextBox
            // 
            yPosTextBox.Location = new Point(29, 51);
            yPosTextBox.MaxValue = 32767;
            yPosTextBox.MinValue = -32768;
            yPosTextBox.Name = "yPosTextBox";
            yPosTextBox.Size = new Size(70, 23);
            yPosTextBox.TabIndex = 3;
            yPosTextBox.Text = "0";
            yPosTextBox.Value = 0;
            yPosTextBox.TextChanged += yPosTextBox_TextChanged;
            // 
            // xPosTextBox
            // 
            xPosTextBox.Location = new Point(29, 22);
            xPosTextBox.MaxValue = 32767;
            xPosTextBox.MinValue = -32768;
            xPosTextBox.Name = "xPosTextBox";
            xPosTextBox.Size = new Size(70, 23);
            xPosTextBox.TabIndex = 2;
            xPosTextBox.Text = "0";
            xPosTextBox.Value = 0;
            xPosTextBox.TextChanged += xPosTextBox_TextChanged;
            // 
            // yPosLabel
            // 
            yPosLabel.AutoSize = true;
            yPosLabel.Location = new Point(6, 54);
            yPosLabel.Name = "yPosLabel";
            yPosLabel.Size = new Size(17, 15);
            yPosLabel.TabIndex = 1;
            yPosLabel.Text = "Y:";
            // 
            // xPosLabel
            // 
            xPosLabel.AutoSize = true;
            xPosLabel.Location = new Point(6, 25);
            xPosLabel.Name = "xPosLabel";
            xPosLabel.Size = new Size(17, 15);
            xPosLabel.TabIndex = 0;
            xPosLabel.Text = "X:";
            // 
            // startButton
            // 
            startButton.Enabled = false;
            startButton.Location = new Point(12, 224);
            startButton.Name = "startButton";
            startButton.Size = new Size(137, 45);
            startButton.TabIndex = 3;
            startButton.Text = "Start (F6)";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // stopButton
            // 
            stopButton.Enabled = false;
            stopButton.Location = new Point(155, 224);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(137, 45);
            stopButton.TabIndex = 4;
            stopButton.Text = "Stop (F6)";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 281);
            Controls.Add(stopButton);
            Controls.Add(startButton);
            Controls.Add(clickPositionGroupBox);
            Controls.Add(clickOptionsGroupBox);
            Controls.Add(windowSelectToolGroupBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainWindow";
            Text = "auto-clicker";
            TopMost = true;
            windowSelectToolGroupBox.ResumeLayout(false);
            windowSelectToolGroupBox.PerformLayout();
            clickOptionsGroupBox.ResumeLayout(false);
            clickOptionsGroupBox.PerformLayout();
            clickPositionGroupBox.ResumeLayout(false);
            clickPositionGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox windowSelectToolGroupBox;
        private Button selectWindowButton;
        private TextBox windowTitleTextBox;
        private TextBox windowHandleTextBox;
        private Label windowTitleLabel;
        private Label windowHandleLabel;
        private GroupBox clickOptionsGroupBox;
        private NumericTextBox intervalTextBox;
        private Label intervalLabel;
        private ComboBox buttonComboBox;
        private Label buttonLabel;
        private GroupBox clickPositionGroupBox;
        private NumericTextBox xPosTextBox;
        private Label yPosLabel;
        private Label xPosLabel;
        private NumericTextBox yPosTextBox;
        private Button startButton;
        private Button stopButton;
    }
}