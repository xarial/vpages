using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xarial.VPages.Core.Attributes;
using Xarial.VPages.Core.Base;
using Xarial.VPages.Core.Constructors;

namespace Xarial.VPages.Core
{
    public class PageBuilder<TPage, TGroup, TControl>
        where TPage : IPage
        where TGroup : IGroup
        where TControl : IControl
    {
        private readonly IDataModelBinder m_DataBinder;
        private readonly IPageConstructor<TPage> m_PageConstructor;
        private readonly IDictionary<Type, IGroupConstructor<TGroup, TPage>> m_GroupConstructors;
        private readonly IDictionary<Type, IControlConstructor<TControl, TPage, TGroup>> m_ControlConstructors;

        //private Dictionary<IControl, IBinding<TDataModel>> m_Bindings;

        //private TPage m_Page;

        //private bool m_IsLoaded;

        //private TDataModel m_CurrentDataModel;

        public PageBuilder(IDataModelBinder dataBinder,
            IPageConstructor<TPage> pageConstr,
            IGroupConstructor<TGroup, TPage>[] groupConstrs,
            IControlConstructor<TControl, TPage, TGroup>[] ctrlsContstrs)
        {
            m_DataBinder = dataBinder;
            m_PageConstructor = pageConstr;
            m_GroupConstructors = IndexConstructors(groupConstrs);
            m_ControlConstructors = IndexConstructors(ctrlsContstrs);

            //m_Bindings = new Dictionary<IControl, IBinding<TDataModel>>();

            //BuildPage();
        }

        //protected void BuildPage()
        //{
        //    m_DataBinder.BindToPage += OnBindToPage;
        //    m_DataBinder.BindToControl += OnBindToControl;
        //    m_DataBinder.Init();
        //}

        //private IPage OnBindToPage(IBinding<TDataModel> binding, AttributeSet attributes)
        //{
        //    m_Page = m_PageConstructor.Create(attributes);
        //    m_Bindings.Add(m_Page, binding);

        //    return m_Page;
        //}

        public TPage CreatePage(object model)
        {
            TPage page = default(TPage);

            var bindingGrp = m_DataBinder.Bind(model,
                (DataModelInfo info, IGroup parent) =>
                {
                    IControl ctrl = null;

                    if (parent == null)
                    {
                        page = m_PageConstructor.Create(info.Attributes);
                        ctrl = page;
                    }
                    else
                    {
                        TGroup parentGrp = default(TGroup);

                        if (parent is TGroup)
                        {
                            parentGrp = (TGroup)parent;
                        }
                        else
                        {
                            //throw
                        }

                        if (info.IsGroup)
                        {
                            ctrl = FindConstructor(m_GroupConstructors, info.Type)
                                .Create(page, parentGrp, info.Attributes);
                        }
                        else
                        {
                            ctrl = FindConstructor(m_ControlConstructors, info.Type)
                                .Create(page, parentGrp, info.Attributes);
                        }
                    }

                    return ctrl;
                });

            page.Binding.CopyFrom(bindingGrp);

            return page;
        }

        //private IControl OnBindToControl(IBinding<TDataModel> binding,
        //    IBinding<TDataModel> parentBinding, AttributeSet attributes)
        //{
        //    IControl ctrl = null;

        //    if (m_Page == null)
        //    {
        //        //TODO: throw exception
        //    }

        //    if (parentBinding == null)
        //    {
        //        //TODO: throw exception
        //    }

        //    if (parentBinding.Control is TGroup)
        //    {
        //        var parentGroup = (TGroup)parentBinding.Control;

        //        if (binding.IsGroup)
        //        {
        //            ctrl = FindConstructor(m_GroupConstructors, binding.Type)
        //                .Create(m_Page, parentGroup, attributes);
        //        }
        //        else
        //        {
        //            ctrl = FindConstructor(m_GroupConstructors, binding.Type)
        //                .Create(m_Page, parentGroup, attributes);
        //        }
        //    }
        //    else
        //    {
        //        //TODO: throw exception
        //        //throw new InvalidOperationException("Parent control must be a group");
        //    }

        //    ctrl.ValueChanged += OnControlValueChanged;
        //    m_Bindings.Add(ctrl, binding);

        //    return ctrl;
        //}

        //private void OnControlValueChanged(IControl sender, object newValue)
        //{
        //    m_Bindings[sender].SetValueToData(newValue, m_CurrentDataModel);
        //}

        private IDictionary<Type, TConstructor> IndexConstructors<TConstructor>(IEnumerable<TConstructor> constructors)
            where TConstructor : IConstructor
        {
            var index = new Dictionary<Type, TConstructor>();

            foreach (var constr in constructors)
            {
                DataTypeAttribute dataTypeAtt;
                if (constr.GetType().TryGetAttribute(out dataTypeAtt))
                {
                    if (!index.ContainsKey(dataTypeAtt.Type))
                    {
                        index.Add(dataTypeAtt.Type, constr);
                    }
                    else
                    {
                        //TODO: throw exception
                    }
                }
                else
                {
                    //TODO: throw exception
                }
            }

            return index;
        }

        private TConstructor FindConstructor<TConstructor>(IDictionary<Type, TConstructor> index, Type type)
            where TConstructor : IConstructor
        {
            TConstructor constr;

            if (!index.TryGetValue(type, out constr))
            {
                constr = index.FirstOrDefault(t => type.IsAssignableFrom(type)).Value;
            }

            if (constr != null)
            {
                return constr;
            }
            else
            {
                //TODO: throw exception
                throw new Exception();
            }
        }

        //public void LoadPage(TDataModel data)
        //{
        //    if (m_IsLoaded)
        //    {
        //        m_IsLoaded = true;
        //        m_CurrentDataModel = data;

        //        foreach (var binding in m_Bindings.Values)
        //        {
        //            var val = binding.GetValueFromData(data);
        //            binding.SetValueToControl(val);
        //        }
        //    }
        //    else
        //    {
        //        //TODO: throw exception
        //    }
        //}

        //public void UnloadPage()
        //{
        //    m_CurrentDataModel = default(TDataModel);
        //    m_IsLoaded = false;
        //}
    }
}
