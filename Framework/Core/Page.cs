using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Core;
using Xarial.VPages.Framework.Base;

namespace Xarial.VPages.Framework.Core
{
    public abstract class Page : Group, IPage
    {
        private BindingGroup m_Binding;

        public BindingGroup Binding
        {
            get
            {
                return m_Binding ?? (m_Binding = new BindingGroup());
            }
        }
    }
}
