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
    public class NumberBoxConstructor : IControlConstructor<NumberBoxControl, FormGroup, FormPage>
    {
        public NumberBoxControl Create(FormPage page, IAttributeSet atts)
        {
            return CreateControl(page.Layout, atts);
        }
        
        public NumberBoxControl Create(FormGroup group, IAttributeSet atts)
        {
            return CreateControl(group.Layout, atts);
        }

        private NumberBoxControl CreateControl(LayoutControl layout, IAttributeSet atts)
        {
            var ctrl = new NumberBoxControl();
            layout.AddControl(ctrl.Control);
            return ctrl;
        }
    }
}
