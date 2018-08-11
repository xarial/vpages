using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace Xarial.VPages.Framework.Core
{
    public class AttributeSet : IAttributeSet
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        private readonly Dictionary<Type, List<IAttribute>> m_Attributes;

        internal AttributeSet(int ctrlId, string ctrlName, string desc)
        {
            Id = ctrlId;
            Name = ctrlName;
            Description = desc;
            m_Attributes = new Dictionary<Type, List<IAttribute>>();
        }

        public bool Has<TAtt>()
            where TAtt : IAttribute
        {
            return m_Attributes.ContainsKey(typeof(TAtt));
        }

        public TAtt Get<TAtt>()
            where TAtt : IAttribute
        {
            return GetAll<TAtt>().First();
        }

        public void Add<TAtt>(TAtt att) where TAtt : IAttribute
        {
            if (att == null)
            {
                throw new ArgumentNullException(nameof(att));
            }

            List<IAttribute> atts;

            if (!m_Attributes.TryGetValue(att.GetType(), out atts))
            {
                atts = new List<IAttribute>();
                m_Attributes.Add(att.GetType(), atts);
            }

            atts.Add(att);
        }

        public IEnumerable<TAtt> GetAll<TAtt>() where TAtt : IAttribute
        {
            List<IAttribute> atts;
            if (m_Attributes.TryGetValue(typeof(TAtt), out atts))
            {
                return atts.Cast<TAtt>();
            }
            else
            {
                //throw exception
                throw new Exception();
            }
        }
    }
}
