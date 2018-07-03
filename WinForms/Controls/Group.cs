using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Core;

namespace Xarial.VPages.WinForms
{
    public class Group : IGroup
    {
        public event ControlValueChangedDelegate ValueChanged;

        public object GetValue()
        {
            throw new NotImplementedException();
        }

        public void SetValue(object value)
        {
            throw new NotImplementedException();
        }
    }
}
