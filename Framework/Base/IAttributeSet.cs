using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Xarial.VPages.Framework.Base
{
    public interface IAttributeSet
    {
        int Id { get; }
        object Tag { get; }
        string Name { get; }
        string Description { get; }
        Type BoundType { get; }

        bool Has<TAtt>() where TAtt : IAttribute;

        TAtt Get<TAtt>() where TAtt : IAttribute;

        IEnumerable<TAtt> GetAll<TAtt>() where TAtt : IAttribute;

        void Add<TAtt>(TAtt att) where TAtt : IAttribute;
    }
}
