using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Xarial.VPages.Core
{
    public delegate void ControlObjectValueChangedDelegate(IControl sender, object newValue);
    public delegate void ControlValueChangedDelegate<TVal>(Control<TVal> sender, TVal newValue);

    public interface IControl : IPageElement
    {
        event ControlObjectValueChangedDelegate ValueChanged;

        object GetValue();
        void SetValue(object value);
    }

    public abstract class Control<TVal> : IControl
    {
        protected abstract event ControlValueChangedDelegate<TVal> ValueChanged;

        private ControlObjectValueChangedDelegate m_ValueChangedHandler;

        event ControlObjectValueChangedDelegate IControl.ValueChanged
        {
            add
            {
                this.ValueChanged += OnValueChanged;
                m_ValueChangedHandler += value;
            }
            remove
            {
                this.ValueChanged -= OnValueChanged;
                m_ValueChangedHandler -= value;
            }
        }

        private void OnValueChanged(Control<TVal> sender, TVal newValue)
        {
            if (m_ValueChangedHandler != null)
            {
                m_ValueChangedHandler.Invoke(sender, newValue);
            }
            else
            {
                Debug.Assert(false, "Generic event handler and specific event handler should be synchronised");
            }
        }

        public void SetValue(object value)
        {
            SetValue((TVal)value);
        }

        protected abstract TVal GetValue();
        protected abstract void SetValue(TVal value);

        object IControl.GetValue()
        {
            return GetValue();
        }
    }
}
