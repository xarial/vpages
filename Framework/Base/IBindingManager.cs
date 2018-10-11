using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Core;

namespace Xarial.VPages.Framework.Base
{
    public interface IBindingManager
    {
        IEnumerable<IBinding> Bindings { get; }
        IDependencyManager Dependency { get; }

        void Load(IEnumerable<IBinding> bindings, IRawDependencyGroup dependencies);
    }
}
