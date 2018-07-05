using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xarial.VPages.Core.Constructors
{
    public interface IGroupConstructor<TGroup, TPage> : IPageElementConstructor<TGroup, TGroup, TPage>
        where TGroup : IGroup
        where TPage : IPage
    {
        //TGroup Create(TPage page, AttributeSet atts);
        //TGroup Create(TGroup group, AttributeSet atts);
    }
}
