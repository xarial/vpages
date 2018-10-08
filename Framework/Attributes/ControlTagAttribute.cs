using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base.Attributes;

namespace Xarial.VPages.Framework.Attributes
{
    public class ControlTagAttribute : Attribute, IControlTagAttribute
    {
        public object Tag { get; private set; }

        public ControlTagAttribute(object tag)
        {
            Tag = tag;
        }
    }
}
