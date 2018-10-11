using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Core;

namespace Xarial.VPages.Framework.PageElements
{
    public abstract class Page : Group, IPage
    {
        private IBindingManager m_Binding;

        public Page() : base(-1, null)
        {
        }

        public IBindingManager Binding
        {
            get
            {
                return m_Binding ?? (m_Binding = new BindingManager());
            }
        }
    }
}
