using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace Xarial.VPages.Framework.Constructors
{
    public interface IControlConstructor<out TControl, TGroup, TPage> : IPageElementConstructor<TControl, TGroup, TPage>
        where TControl : IControl
        where TPage : IPage
        where TGroup : IGroup
    {
    }
}
