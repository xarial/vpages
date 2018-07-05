using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Core;
using Xarial.VPages.Core.Attributes;
using Xarial.VPages.Core.Constructors;

namespace Xarial.VPages.WinForms
{
    [DataType(typeof(decimal))]
    public class NumberBoxConstructor : IControlConstructor<NumberBoxControl, FormGroup, FormPage>
    {
        //public NumberBoxControl Create(Page page, FormGroup parent, AttributeSet atts)
        //{
        //    var ctrl = new NumberBoxControl();
        //    page.Panel.Controls.Add(ctrl.NumberBox);
        //    return ctrl;
        //}
        public NumberBoxControl Create(FormPage page, AttributeSet atts)
        {
            return CreateControl(page.Panel.Controls);
        }

        public NumberBoxControl Create(FormGroup group, AttributeSet atts)
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
