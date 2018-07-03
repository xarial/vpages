using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xarial.VPages.Core.Constructors
{
    public interface IControlConstructor<TControl, TPage, TGroup> : IConstructor
        where TControl : IControl
        where TPage : IPage
        where TGroup : IGroup
    {
        TControl Create(TPage page, TGroup parent, AttributeSet atts);
    }
}
