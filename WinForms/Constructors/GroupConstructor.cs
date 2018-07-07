using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Core;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Constructors;
using Xarial.VPages.Framework.Core;

namespace Xarial.VPages.WinForms
{
    public class FormGroupConstructor : IGroupConstructor<FormGroup, FormPage>
    {
        public FormGroup Create(FormPage page, IAttributeSet atts)
        {
            throw new NotImplementedException();
        }

        public FormGroup Create(FormGroup group, IAttributeSet atts)
        {
            throw new NotImplementedException();
        }
    }
}
