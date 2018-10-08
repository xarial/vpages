using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Xarial.VPages.Framework.Base
{
    public delegate void ControlObjectValueChangedDelegate(IControl sender, object newValue);

    public interface IControl
    {
        event ControlObjectValueChangedDelegate ValueChanged;

        int Id { get; }

        object Tag { get; }

        object GetValue();
        void SetValue(object value);
    }
}
