using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace Xarial.VPages.Framework.Constructors
{
    public abstract class PageElementConstructor<TElem, TGroup, TPage> : IPageElementConstructor<TGroup, TPage>
            where TGroup : IGroup
            where TPage : IPage
            where TElem : IControl
    {
        protected abstract TElem Create(TPage page, IAttributeSet atts);
        protected abstract TElem Create(TGroup group, IAttributeSet atts);

        IControl IPageElementConstructor<TGroup, TPage>.Create(TPage page, IAttributeSet atts)
        {
            return Create(page, atts);
        }

        IControl IPageElementConstructor<TGroup, TPage>.Create(TGroup group, IAttributeSet atts)
        {
            return Create(group, atts);
        }
    }
}
