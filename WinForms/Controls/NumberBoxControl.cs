using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xarial.VPages.Core;

namespace Xarial.VPages.WinForms
{
    public class NumberBoxControl : FormControl<decimal>
    {
        protected override event ControlValueChangedDelegate<decimal> ValueChanged;

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

        protected override decimal GetValue()
        {
            return NumberBox.Value;
        }

        protected override void SetValue(decimal value)
        {
            NumberBox.Value = (decimal)value;
        }
    }
}
