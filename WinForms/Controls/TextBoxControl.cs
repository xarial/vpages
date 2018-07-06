using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xarial.VPages.Core;
using Xarial.VPages.Framework.Core;

namespace Xarial.VPages.WinForms
{
    public class TextBoxControl : FormControl<string>
    {
        protected override event ControlValueChangedDelegate<string> ValueChanged;

        internal TextBox TextBox { get; private set; }

        internal TextBoxControl()
        {
            TextBox = new TextBox();
            TextBox.TextChanged += OnTextChanged;
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            ValueChanged.Invoke(this, TextBox.Text);
        }

        protected override string GetValue()
        {
            return TextBox.Text;
        }

        protected override void SetValue(string value)
        {
            TextBox.Text = value as string;
        }
    }
}
