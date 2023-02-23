namespace auto_clicker
{
    internal class NumericTextBox : TextBox
    {
        public int Value
        {
            get => value;
            set
            {
                this.value = value;
                Text = value.ToString();
            }
        }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        private static readonly int DEFAULT_MIN_VALUE = 0;
        private static readonly int DEFAULT_MAX_VALUE = 100;

        private int value;

        public NumericTextBox() : this(DEFAULT_MIN_VALUE, DEFAULT_MAX_VALUE) { }

        public NumericTextBox(int minValue, int maxValue)
        {
            Value = minValue;
            MinValue = minValue;
            MaxValue = maxValue;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (string.IsNullOrEmpty(Text))
            {
                return;
            }

            if (TryParseText(out int result))
            {
                value = result;
            }
            else
            {
                SetTextToValue();
            }

            base.OnTextChanged(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            SetTextToValue();

            base.OnLeave(e);
        }

        private bool TryParseText(out int result)
        {
            if (MinValue < 0 && Text == "-")
            {
                result = 0;
            }
            else if (!int.TryParse(Text, out result))
            {
                return false;
            }

            return MinValue <= result && result <= MaxValue;
        }

        private void SetTextToValue()
        {
            Text = Value.ToString();
            Select(Text.Length, 0);
        }
    }
}
