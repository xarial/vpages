using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xarial.VPages.Core;
using Xarial.VPages.Framework.Core;
using Xarial.VPages.Framework.PageElements;

namespace Xarial.VPages.WinForms
{
    public class NumberBoxControl : FormControl<decimal>
    {
        protected override event ControlValueChangedDelegate<decimal> ValueChanged;

        private NumericUpDown m_NumberBox;

        internal override Control Control => m_NumberBox;

        internal NumberBoxControl(int id) : base(id)
        {
            m_NumberBox = new NumericUpDown();
            m_NumberBox.ValueChanged += OnNumberBoxValueChanged;
        }

        private void OnNumberBoxValueChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(this, GetSpecificValue());
        }

        protected override decimal GetSpecificValue()
        {
            return m_NumberBox.Value;
        }

        protected override void SetSpecificValue(decimal value)
        {
            m_NumberBox.Value = value;
        }
    }
}
