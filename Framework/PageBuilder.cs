/*********************************************************************
vPages
Copyright(C) 2018 www.xarial.net
Product URL: https://www.xarial.net/products/developers/vpages
License: https://github.com/xarial/vpages/blob/master/LICENSE
*********************************************************************/

using System.Collections.Generic;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Internal;

namespace Xarial.VPages.Core
{
    public class PageBuilder<TPage, TGroup, TControl>
        where TPage : IPage
        where TGroup : IGroup
        where TControl : IControl
    {
        private readonly IDataModelBinder m_DataBinder;
        private readonly IPageConstructor<TPage> m_PageConstructor;

        private readonly ConstructorsContainer<TPage, TGroup> m_ControlConstructors;

        public PageBuilder(IDataModelBinder dataBinder,
            IPageConstructor<TPage> pageConstr,
            params IPageElementConstructor<TGroup, TPage>[]
            ctrlsContstrs)
        {
            m_DataBinder = dataBinder;
            m_PageConstructor = pageConstr;

            m_ControlConstructors = new ConstructorsContainer<TPage, TGroup>(ctrlsContstrs);
        }
        
        public TPage CreatePage<TModel>(TModel model)
        {
            var page = default(TPage);

            IEnumerable<IBinding> bindings;

            IRawDependencyGroup dependencies;

            m_DataBinder.Bind(model,
                atts => 
                {
                    page = m_PageConstructor.Create(atts);
                    return page;
                },
                (type, atts, parent) => m_ControlConstructors.CreateElement(type, parent, atts),
                out bindings, out dependencies);

            page.Binding.Load(bindings, dependencies);

            return page;
        }
    }
}
