using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Core.Base;

namespace Xarial.VPages.Core
{
    public interface IPage : IGroup
    {
        BindingGroup Binding { get; }
    }

    public abstract class Page : Group, IPage
    {
        private BindingGroup m_Binding;

        public BindingGroup Binding
        {
            get
            {
                return m_Binding ?? (m_Binding = new BindingGroup());
            }
        }
    }
}
