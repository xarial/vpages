using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xarial.VPages.Framework.Base.Attributes
{
    public interface IDependentOnAttribute : IAttribute
    {
        string[] Dependencies { get; }
    }
}
