using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xarial.VPages.Framework.Exceptions
{
    public class ConstructorNotFoundException : Exception
    {
        internal ConstructorNotFoundException(Type type, string message = "") 
            : base($"Constructor for type {type.FullName} is not found. {message}")
        {
        }
    }
}
