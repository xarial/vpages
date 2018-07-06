using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace Xarial.VPages.Framework.Constructors
{
    public interface IGroupConstructor<TGroup, TPage> : IPageElementConstructor<TGroup, TGroup, TPage>
        where TGroup : IGroup
        where TPage : IPage
    {
    }
}
