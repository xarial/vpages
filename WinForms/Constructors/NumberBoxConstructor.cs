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
    [DefaultType(typeof(decimal))]
    public class NumberBoxConstructor : IControlConstructor<NumberBoxControl, FormGroup, FormPage>
    {
        public NumberBoxControl Create(FormPage page, IAttributeSet atts)
        {
            return CreateControl(page.Panel.Controls);
        }

        public NumberBoxControl Create(FormGroup group, IAttributeSet atts)
        {
            return null;
        }

        private NumberBoxControl CreateControl(System.Windows.Forms.Control.ControlCollection ctrls)
        {
            var ctrl = new NumberBoxControl();
            ctrls.Add(ctrl.NumberBox);
            return ctrl;
        }
    }
}
