using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xarial.VPages.Core;

namespace Xarial.VPages.WinForms
{
    public class NumberBoxControl : Control
    {
        public override event ControlValueChangedDelegate ValueChanged;

        internal NumericUpDown NumberBox { get; private set; }

        internal NumberBoxControl()
        {
            NumberBox = new NumericUpDown();
            NumberBox.ValueChanged += OnNumberBoxValueChanged;
        }

        private void OnNumberBoxValueChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(this, GetValue());
        }

        public override object GetValue()
        {
            return NumberBox.Value;
        }

        public override void SetValue(object value)
        {
            NumberBox.Value = (decimal)value;
        }
    }
}
