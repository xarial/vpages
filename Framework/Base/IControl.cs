using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xarial.VPages.Core
{
    public delegate void ControlValueChangedDelegate(IControl sender, object newValue);

    public interface IControl
    {
        event ControlValueChangedDelegate ValueChanged;
        object GetValue();
        void SetValue(object value);
    }
}
