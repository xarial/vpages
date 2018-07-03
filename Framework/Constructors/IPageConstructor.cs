using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xarial.VPages.Core.Constructors
{
    public interface IPageConstructor<TPage> : IConstructor
        where TPage : IPage
    {
        TPage Create(AttributeSet atts);
    }
}
