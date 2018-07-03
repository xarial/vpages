using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xarial.VPages.Core.Attributes
{
    public class DataTypeAttribute : Attribute
    {
        public Type Type { get; private set; }
        
        public DataTypeAttribute(Type type)
        {
            Type = type;
        }
    }
}
