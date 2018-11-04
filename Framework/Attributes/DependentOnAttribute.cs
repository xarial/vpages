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
    public class DependentOnAttribute : Attribute, IDependentOnAttribute
    {
        public object[] Dependencies { get; private set; }

        public Type DependencyHandler { get; private set; }

        public DependentOnAttribute(Type dependencyHandler, params object[] dependencies)
        {
            DependencyHandler = dependencyHandler;
            Dependencies = dependencies;
        }
    }
}
