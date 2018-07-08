using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Core;

namespace Xarial.VPages.Framework.PageElements
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
