using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace Xarial.VPages.Framework.Constructors
{
    public abstract class PageConstructor<TPage> : IPageConstructor<TPage>
        where TPage : IPage
    {
        TPage IPageConstructor<TPage>.Create(IAttributeSet atts)
        {
            return Create(atts);
        }

        protected abstract TPage Create(IAttributeSet atts);
    }
}
