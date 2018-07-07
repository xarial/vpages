using System;
using Xarial.VPages.Framework.Constructors;
using Xarial.VPages.Framework.Base;

namespace Xarial.VPages.WinForms
{
    public class FormPageConstructor : IPageConstructor<FormPage>
    {
        public FormPage Create(IAttributeSet atts)
        {
            return new FormPage();
        }
    }
}
