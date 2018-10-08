using Xarial.VPages.Framework.Attributes;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Constructors;
using Xarial.VPages.WinForms.Constructors;

namespace Xarial.VPages.WinForms
{
    [DefaultType(typeof(string))]
    public class TextBoxConstructor : ControlConstructor<TextBoxControl, FormGroup, FormPage>
    {
        protected override TextBoxControl Create(FormPage page, IAttributeSet atts)
        {
            return CreateControl(page.Layout, atts);
        }

        protected override TextBoxControl Create(FormGroup group, IAttributeSet atts)
        {
            return CreateControl(group.Layout, atts);
        }

        private TextBoxControl CreateControl(LayoutControl layout, IAttributeSet atts)
        {
            var ctrl = new TextBoxControl(atts.Id, atts.Tag);
            layout.AddControl(ctrl.Control);
            return ctrl;
        }
    }
}
