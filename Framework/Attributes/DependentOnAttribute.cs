using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
