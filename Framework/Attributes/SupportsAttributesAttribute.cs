using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xarial.VPages.Core
{
    public class SupportsAttributesAttribute : Attribute
    {
        public Type[] Types { get; private set; }

        public SupportsAttributesAttribute(params Type[] types)
        {
            Types = types;
        }
    }
}
