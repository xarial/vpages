using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xarial.VPages.Framework.Core
{
    public class DataModelInfo
    {
        public bool IsGroup { get; private set; }
        public string Name { get; private set; }
        public Type Type { get; private set; }
        public AttributeSet Attributes { get; private set; }

        public DataModelInfo(string name, Type type, bool isGroup, AttributeSet atts)
        {
            Name = name;
            IsGroup = isGroup;
            Type = type;
            Attributes = atts;
        }
    }
}
