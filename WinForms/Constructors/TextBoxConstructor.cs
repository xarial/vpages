using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Core;
using Xarial.VPages.Core.Attributes;
using Xarial.VPages.Core.Constructors;

namespace Xarial.VPages.WinForms
{
    [DataType(typeof(string))]
    public class TextBoxConstructor : IControlConstructor<TextBoxControl, FormGroup, FormPage>
    {
        public TextBoxControl Create(FormPage page, AttributeSet atts)
        {
            return CreateControl(page.Panel.Controls);
        }

        public TextBoxControl Create(FormGroup group, AttributeSet atts)
        {
            throw new NotImplementedException();
        }

        private TextBoxControl CreateControl(System.Windows.Forms.Control.ControlCollection ctrls)
        {
            var ctrl = new TextBoxControl();
            ctrls.Add(ctrl.TextBox);
            return ctrl;
        }
    }
}
