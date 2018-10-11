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
    public class CheckBoxControl : FormControl<bool>
    {
        protected override event ControlValueChangedDelegate<bool> ValueChanged;

        private CheckBox m_CheckBox;

        public override Control Control => m_CheckBox;

        internal CheckBoxControl(int id, object tag) : base(id, tag)
        {
            m_CheckBox = new CheckBox();
            m_CheckBox.CheckedChanged += OnCheckedChanged;
        }

        private void OnCheckedChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(this, GetSpecificValue());
        }
        
        protected override bool GetSpecificValue()
        {
            return m_CheckBox.Checked;
        }

        protected override void SetSpecificValue(bool value)
        {
            m_CheckBox.Checked = value;
        }
    }
}
