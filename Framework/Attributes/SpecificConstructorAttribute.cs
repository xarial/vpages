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
    [AttributeUsage(AttributeTargets.Property)]
    public class SpecificConstructorAttribute : Attribute, ISpecificConstructorAttribute
    {
        public Type ConstructorType { get; private set; }

        public SpecificConstructorAttribute(Type constrType)
        {
            ConstructorType = constrType;
        }
    }
}
