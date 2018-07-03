using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Core;

namespace Xarial.VPages.WinForms
{
    public abstract class Control : IControl
    {
        public abstract event ControlValueChangedDelegate ValueChanged;

        public abstract object GetValue();

        public abstract void SetValue(object value);
    }
}
