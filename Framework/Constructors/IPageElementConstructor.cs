using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Core;

namespace Xarial.VPages.Framework.Constructors
{
    public interface IPageElementConstructor<out TElem, TGroup, TPage>
        where TGroup : IGroup
        where TPage : IPage
        where TElem : IControl
    {
        TElem Create(TPage page, AttributeSet atts);
        TElem Create(TGroup group, AttributeSet atts);
    }
}
