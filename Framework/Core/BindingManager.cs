using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace Xarial.VPages.Framework.Core
{
    public class BindingManager : IBindingManager
    {
        public IEnumerable<IBinding> Bindings { get; private set; }
        public IDependencyManager Dependency { get; private set; }

        public void Load(IEnumerable<IBinding> bindings, IRawDependencyGroup dependencies)
        {
            Bindings = bindings;
            Dependency = new DependencyManager();
            Dependency.Init(dependencies);
        }
    }
}
