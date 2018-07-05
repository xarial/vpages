using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xarial.VPages.Core.Constructors
{
    public interface IControlConstructor<out TControl, TGroup, TPage> : IPageElementConstructor<TControl, TGroup, TPage>
        where TControl : IControl
        where TPage : IPage
        where TGroup : IGroup
    {
        //TControl Create(TPage page, AttributeSet atts);
        //TControl Create(TGroup group, AttributeSet atts);
    }
}
