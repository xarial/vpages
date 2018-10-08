using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base.Attributes;

namespace Xarial.VPages.Framework.Attributes
{
    public class DependentOnAttribute : IDependentOnAttribute
    {
        public string[] Dependencies { get; private set; }

        public DependentOnAttribute(params string[] dependencies)
        {
            Dependencies = dependencies;
        }
    }
}
