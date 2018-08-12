using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Core;
using System.Diagnostics;
using Xarial.VPages.Framework.Base;

namespace Xarial.VPages.Framework.PageElements
{
    public delegate void ControlValueChangedDelegate<TVal>(Control<TVal> sender, TVal newValue);

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
            var destVal = value.Cast<TVal>();

            SetSpecificValue(destVal);
        }

        public int Id { get; private set; }

        protected Control(int id)
        {
            Id = id;
        }

        protected abstract TVal GetSpecificValue();
        protected abstract void SetSpecificValue(TVal value);

        object IControl.GetValue()
        {
            return GetSpecificValue();
        }
    }
}
