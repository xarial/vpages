using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Base.Attributes;

namespace Xarial.VPages.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SpecificConstructorAttribute : Attribute, ISpecificConstructorAttribute
    {
        public Type ConstructorType { get; private set; }

        public SpecificConstructorAttribute(Type constrType)
        {
            ConstructorType = constrType;
        }
    }
}
