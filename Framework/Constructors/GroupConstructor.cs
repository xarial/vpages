/*********************************************************************
vPages
Copyright(C) 2018 www.xarial.net
Product URL: https://www.xarial.net/products/developers/vpages
License: https://github.com/xarial/vpages/blob/master/LICENSE
*********************************************************************/

using Xarial.VPages.Framework.Base;

namespace Xarial.VPages.Framework.Constructors
{
    public abstract class GroupConstructor<TGroup, TPage> : PageElementConstructor<TGroup, TGroup, TPage>
        where TGroup : IGroup
        where TPage : IPage
    {
    }
}
