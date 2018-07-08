using Xarial.VPages.Framework.Attributes;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Constructors;
using Xarial.VPages.Framework.Core;
using Xarial.VPages.WinForms.Constructors;

namespace Xarial.VPages.WinForms
{
    [DefaultType(typeof(SpecialTypes.ComplexType))]
    public class FormGroupConstructor : GroupConstructor<FormGroup, FormPage>
    {
        protected override FormGroup Create(FormPage page, IAttributeSet atts)
        {
            return CreateGroup(page.Layout, atts);
        }

        protected override FormGroup Create(FormGroup group, IAttributeSet atts)
        {
            return CreateGroup(group.Layout, atts);
        }

        private FormGroup CreateGroup(LayoutControl layout, IAttributeSet atts)
        {
            var grp = new FormGroup();
            layout.AddControl(grp.Group);
            return grp;
        }
    }
}
