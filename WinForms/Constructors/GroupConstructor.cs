using Xarial.VPages.Framework.Attributes;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Constructors;
using Xarial.VPages.Framework.Core;
using Xarial.VPages.WinForms.Constructors;

namespace Xarial.VPages.WinForms
{
    [DefaultType(typeof(AnyType))]
    public class FormGroupConstructor : IGroupConstructor<FormGroup, FormPage>
    {
        public FormGroup Create(FormPage page, IAttributeSet atts)
        {
            return CreateGroup(page.Layout, atts);
        }

        public FormGroup Create(FormGroup group, IAttributeSet atts)
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
