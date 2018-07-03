using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xarial.VPages.Core;

namespace Xarial.VPages.WinForms
{
    public class TextBoxControl : Control
    {
        public override event ControlValueChangedDelegate ValueChanged;

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

        public override object GetValue()
        {
            return TextBox.Text;
        }

        public override void SetValue(object value)
        {
            TextBox.Text = value as string;
        }
    }
}
