using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Core;
using Xarial.VPages.Framework.Base;

namespace Xarial.VPages.Framework.PageElements
{
    public abstract class Group<TVal> : Control<TVal>, IGroup
    {
#pragma warning disable CS0067
        protected override event ControlValueChangedDelegate<TVal> ValueChanged;
#pragma warning restore CS0067

        protected override TVal GetValue()
        {
            return default(TVal);
        }

        protected override void SetValue(TVal value)
        {
        }
    }

    public abstract class Group : Group<object>
    {
    }
}
