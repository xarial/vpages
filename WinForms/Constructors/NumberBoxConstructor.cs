using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Core;
using Xarial.VPages.Framework.Attributes;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Constructors;
using Xarial.VPages.Framework.Core;
using Xarial.VPages.WinForms.Constructors;

namespace Xarial.VPages.WinForms
{
    [DefaultType(typeof(decimal))]
    public class NumberBoxConstructor : ControlConstructor<NumberBoxControl, FormGroup, FormPage>
    {
        protected override NumberBoxControl Create(FormPage page, IAttributeSet atts)
        {
            return CreateControl(page.Layout, atts);
        }

        protected override NumberBoxControl Create(FormGroup group, IAttributeSet atts)
        {
            return CreateControl(group.Layout, atts);
        }

        private NumberBoxControl CreateControl(LayoutControl layout, IAttributeSet atts)
        {
            var ctrl = new NumberBoxControl(atts.Id, atts.Tag);
            layout.AddControl(ctrl.Control);
            return ctrl;
        }
    }
}
