using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Base.Attributes;

namespace Xarial.VPages.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DefaultTypeAttribute : Attribute, IDefaultTypeAttribute
    {
        public Type Type { get; private set; }
        
        public DefaultTypeAttribute(Type type)
        {
            Type = type;
        }
    }
}
