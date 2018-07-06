using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xarial.VPages.Framework.Attributes
{
    public class DefaultTypeAttribute : Attribute
    {
        public Type Type { get; private set; }
        
        public DefaultTypeAttribute(Type type)
        {
            Type = type;
        }
    }
}
