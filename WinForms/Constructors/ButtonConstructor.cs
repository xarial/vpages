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
using Xarial.VPages.WinForms.Controls;

namespace Xarial.VPages.WinForms
{
    [DefaultType(typeof(Action))]
    public class ButtonConstructor : ControlConstructor<ButtonControl, FormGroup, FormPage>
    {
        protected override ButtonControl Create(FormPage page, IAttributeSet atts)
        {
            return CreateControl(page.Layout, atts);
        }

        protected override ButtonControl Create(FormGroup group, IAttributeSet atts)
        {
            return CreateControl(group.Layout, atts);
        }

        private ButtonControl CreateControl(LayoutControl layout, IAttributeSet atts)
        {
            var ctrl = new ButtonControl(atts.Id, atts.Tag, atts.Name);
            layout.AddControl(ctrl.Control);
            return ctrl;
        }
    }
}
