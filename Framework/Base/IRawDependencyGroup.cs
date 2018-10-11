using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xarial.VPages.Framework.Base
{
    public interface IRawDependencyGroup
    {
        Dictionary<object, IBinding> TaggedBindings { get; }
        Dictionary<IBinding, Tuple<object[], Type>> DependenciesTags { get; }

        void RegisterBindingTag(IBinding binding, object tag);
        void RegisterDependency(IBinding binding, object[] dependentOnTags, Type dependencyHandlerType);
    }
}
