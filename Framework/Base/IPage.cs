﻿/*********************************************************************
vPages
Copyright(C) 2018 www.xarial.net
Product URL: https://www.xarial.net/products/developers/vpages
License: https://github.com/xarial/vpages/blob/master/LICENSE
*********************************************************************/

namespace Xarial.VPages.Framework.Base
{
    public interface IPage : IGroup
    {
        IBindingManager Binding { get; }
    }
}
