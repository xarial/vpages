using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Core;
using Xarial.VPages.Core.Constructors;
using Xarial.VPages.Core.Parsers;

namespace Xarial.VPages.WinForms
{
    public class WinFormsPageBuilder : PageBuilder<FormPage, FormGroup>
    {
        public WinFormsPageBuilder(IDataModelBinder dataBinder)
            : base(dataBinder, new FormPageConstructor(), 
                  new IGroupConstructor<FormGroup, FormPage>[] { new FormGroupConstructor() },
                  new IControlConstructor<IControl, FormGroup, FormPage>[] 
                  {
                      new TextBoxConstructor(),
                      new NumberBoxConstructor()
                  })
        {
        }

        public WinFormsPageBuilder()
            : this(new TypeDataBinder())
        {
        }
    }
}
