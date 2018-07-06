using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Core;
using Xarial.VPages.Framework.Constructors;
using Xarial.VPages.Framework.Core;

namespace Xarial.VPages.WinForms
{
    public class FormPageConstructor : IPageConstructor<FormPage>
    {
        public FormPage Create(AttributeSet atts)
        {
            return new FormPage();
        }
    }
}
