using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Core;

namespace Xarial.VPages.Framework.Constructors
{
    public interface IPageConstructor<TPage>
        where TPage : IPage
    {
        TPage Create(AttributeSet atts);
    }
}
