using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace Xarial.VPages.Framework.Core
{
    public class AttributeSet : IAttributeSet
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public bool Has<TAtt>()
            where TAtt : IAttribute
        {
            return false;
        }

        public TAtt Get<TAtt>()
            where TAtt : IAttribute
        {
            return default(TAtt);
        }

        public void Add<TAtt>(TAtt att) where TAtt : IAttribute
        {
            throw new NotImplementedException();
        }
    }
}
