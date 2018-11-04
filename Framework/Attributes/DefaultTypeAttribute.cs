/*********************************************************************
vPages
Copyright(C) 2018 www.xarial.net
Product URL: https://www.xarial.net/products/developers/vpages
License: https://github.com/xarial/vpages/blob/master/LICENSE
*********************************************************************/

using System;
using Xarial.VPages.Framework.Base.Attributes;

namespace Xarial.VPages.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DefaultTypeAttribute : Attribute, IDefaultTypeAttribute
    {
        public Type Type { get; private set; }
        
        public DefaultTypeAttribute(Type type)
        {
            Type = type;
        }
    }
}
