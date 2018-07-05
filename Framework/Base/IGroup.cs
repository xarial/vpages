using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xarial.VPages.Core
{
    //public interface IPageGroupElement : IPageElement
    //{
    //}

    public interface IPageElement
    {
    }

    public interface IGroup : IControl
    {
    }

    public abstract class Group<TVal> : Control<TVal>, IGroup
    {
        protected override event ControlValueChangedDelegate<TVal> ValueChanged;

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
