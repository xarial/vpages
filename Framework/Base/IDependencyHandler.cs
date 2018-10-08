using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xarial.VPages.Framework.Base
{
    public interface IDependencyHandler
    {
        void UpdateState(IBinding binding, IBinding[] dependencies);
    }
}
