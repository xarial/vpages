using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xarial.VPages.Framework.Exceptions
{
    public class InvalidParentControlException : Exception
    {
        internal InvalidParentControlException(Type parentType, params Type[] supportedParents)
            : base($"{parentType.FullName} is not supported as a parent control. Only {string.Join(", ", supportedParents.Select(t => t.FullName).ToArray())} are supported")
        {
        }
    }
}
