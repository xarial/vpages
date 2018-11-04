/*********************************************************************
vPages
Copyright(C) 2018 www.xarial.net
Product URL: https://www.xarial.net/products/developers/vpages
License: https://github.com/xarial/vpages/blob/master/LICENSE
*********************************************************************/

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
