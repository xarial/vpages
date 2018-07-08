using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace Xarial.VPages.Framework.Base
{
    public interface IPageConstructor<TPage>
        where TPage : IPage
    {
        TPage Create(IAttributeSet atts);
    }
}
