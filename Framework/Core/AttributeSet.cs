using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace Xarial.VPages.Framework.Core
{
    public class AttributeSet
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public bool Has<TAtt>()
            where TAtt : IAttribute
        {
            throw new NotImplementedException();
        }

        public TAtt Get<TAtt>()
            where TAtt : IAttribute
        {
            throw new NotImplementedException();
        }

        public void Set<TAtt>()
            where TAtt : IAttribute
        {
            throw new NotImplementedException();
        }
    }
}
