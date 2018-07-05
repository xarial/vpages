using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xarial.VPages.Core.Constructors
{
    public interface IConstructor
    {
    }

    public interface IPageElementConstructor<out TElem, TGroup, TPage> : IConstructor
        where TGroup : IGroup
        where TPage : IPage
        where TElem : IPageElement
    {
        TElem Create(TPage page, AttributeSet atts);
        TElem Create(TGroup group, AttributeSet atts);
    }
}
