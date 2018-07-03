using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Core;
using Xarial.VPages.Core.Constructors;
using Xarial.VPages.Core.Parsers;

namespace Xarial.VPages.WinForms
{
    public class WinFormsPageBuilder : PageBuilder<Page, Group, Control>
    {
        public WinFormsPageBuilder(IDataModelBinder dataBinder)
            : base(dataBinder, new PageConstructor(), 
                  new IGroupConstructor<Group, Page>[] { new GroupConstructor() },
                  new IControlConstructor<Control, Page, Group>[] 
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
