using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Core;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Binders;
using Xarial.VPages.Framework.Constructors;

namespace Xarial.VPages.WinForms
{
    public class WinFormsPageBuilder : PageBuilder<FormPage, FormGroup, IFormControl>
    {
        public WinFormsPageBuilder(IDataModelBinder dataBinder)
            : base(dataBinder, new FormPageConstructor(),
                  new FormGroupConstructor(),
                  new TextBoxConstructor(),
                  new NumberBoxConstructor(),
                  new CheckBoxConstructor())
        {
        }

        public WinFormsPageBuilder()
            : this(new TypeDataBinder())
        {
        }
    }
}
