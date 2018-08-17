using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Core;

namespace Xarial.VPages.Framework.Base
{
    public interface IPageElementConstructor<TGroup, TPage>
        where TGroup : IGroup
        where TPage : IPage
    {
        IControl Create(TPage page, IAttributeSet atts);
        IControl Create(TGroup group, IAttributeSet atts);
    }
}
