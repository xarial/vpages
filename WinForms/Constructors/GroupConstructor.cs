using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Core;
using Xarial.VPages.Core.Constructors;

namespace Xarial.VPages.WinForms
{
    public class GroupConstructor : IGroupConstructor<Group, Page>
    {
        public Group Create(Page page, Group parent, AttributeSet atts)
        {
            return null;
        }
    }
}
