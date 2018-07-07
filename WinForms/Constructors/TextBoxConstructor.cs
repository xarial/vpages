using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Core;
using Xarial.VPages.Framework.Attributes;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Constructors;
using Xarial.VPages.Framework.Core;

namespace Xarial.VPages.WinForms
{
    [DefaultType(typeof(string))]
    public class TextBoxConstructor : IControlConstructor<TextBoxControl, FormGroup, FormPage>
    {
        public TextBoxControl Create(FormPage page, IAttributeSet atts)
        {
            return CreateControl(page.Panel.Controls);
        }

        public TextBoxControl Create(FormGroup group, IAttributeSet atts)
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
