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

    public abstract class BasePage : IPage
    {
        public virtual event ControlValueChangedDelegate ValueChanged;

        private BindingGroup m_Binding;

        public virtual object GetValue()
        {
            return null;
        }

        public virtual void SetValue(object value)
        {
        }

        public BindingGroup Binding
        {
            get
            {
                return m_Binding ?? (m_Binding = new BindingGroup());
            }
        }
    }
}
