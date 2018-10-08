using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace Xarial.VPages.Framework.Core
{
    public interface IDependencyManager
    {
        void RegisterBindingTag(IBinding binding, object tag);
        void RegisterDependency(IBinding binding, object[] dependentOnTags, Type dependencyHandlerType);
        void Init();
    }

    public class DependencyManager : IDependencyManager
    {
        private class UpdateStateData
        {
            private IBinding m_Source;
            private IBinding[] m_Dependencies;
            IDependencyHandler m_Handler;

            internal UpdateStateData(IBinding src, IBinding[] deps, IDependencyHandler handler)
            {
                m_Source = src;
                m_Dependencies = deps;
                m_Handler = handler;
            }

            internal void Update()
            {
                m_Handler.UpdateState(m_Source, m_Dependencies);
            }
        }

        private Dictionary<object, IBinding> m_TaggedBindings;
        private Dictionary<IBinding, Tuple<object[], Type>> m_DependenciesTags;

        private Dictionary<IBinding, List<UpdateStateData>> m_Dependencies;

        internal DependencyManager()
        {
            m_TaggedBindings = new Dictionary<object, IBinding>();
            m_DependenciesTags = new Dictionary<IBinding, Tuple<object[], Type>>();
        }

        public void Init()
        {
            m_Dependencies = new Dictionary<IBinding, List<UpdateStateData>>();

            var handlersCache = new Dictionary<Type, IDependencyHandler>();

            foreach (var data in m_DependenciesTags)
            {
                var srcBnd = data.Key;
                var dependOnTags = data.Value.Item1;
                var depHandlerType = data.Value.Item2;

                var dependOnBindings = new IBinding[dependOnTags.Length];

                for (int i = 0; i < dependOnTags.Length; i++)
                {
                    var dependOnTag = dependOnTags[i];

                    IBinding dependOnBinding;
                    if (!m_TaggedBindings.TryGetValue(dependOnTag, out dependOnBinding))
                    {
                        throw new Exception("Dependent on binding is not fond for tag");
                    }

                    dependOnBindings[i] = dependOnBinding;
                }

                IDependencyHandler handler;

                if (!handlersCache.TryGetValue(depHandlerType, out handler))
                {
                    handler = Activator.CreateInstance(depHandlerType) as IDependencyHandler;
                    handlersCache.Add(depHandlerType, handler);
                }

                foreach (var dependOnBinding in dependOnBindings)
                {
                    List<UpdateStateData> updates;
                    if (!m_Dependencies.TryGetValue(dependOnBinding, out updates))
                    {
                        //TODO: subscribe to update event

                        updates = new List<UpdateStateData>();
                        m_Dependencies.Add(dependOnBinding, updates);
                    }

                    updates.Add(new UpdateStateData(srcBnd, dependOnBindings, handler));
                }
            }
        }

        public void RegisterBindingTag(IBinding binding, object tag)
        {
            if (!m_TaggedBindings.ContainsKey(tag))
            {
                m_TaggedBindings.Add(tag, binding);
            }
            else
            {
                throw new Exception("Tag is not unique");
            }
        }

        public void RegisterDependency(IBinding binding, object[] dependentOnTags, Type dependencyHandlerType)
        {
            m_DependenciesTags.Add(binding, new Tuple<object[], Type>(dependentOnTags, dependencyHandlerType));
        }
    }
}
