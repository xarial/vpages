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
    public class TextBoxControl : FormControl<string>
    {
        protected override event ControlValueChangedDelegate<string> ValueChanged;

        private TextBox m_TextBox;

        internal override Control Control => m_TextBox;

        internal TextBoxControl()
        {
            m_TextBox = new TextBox();
            m_TextBox.TextChanged += OnTextChanged;
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            ValueChanged.Invoke(this, m_TextBox.Text);
        }

        protected override string GetValue()
        {
            return m_TextBox.Text;
        }

        protected override void SetValue(string value)
        {
            m_TextBox.Text = value as string;
        }
    }
}
