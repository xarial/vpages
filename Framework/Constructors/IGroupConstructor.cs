using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xarial.VPages.Core.Constructors
{
    public interface IGroupConstructor<TGroup, TPage> : IConstructor
        where TGroup : IGroup
        where TPage : IPage
    {
        TGroup Create(TPage page, TGroup parent, AttributeSet atts);
    }
}
