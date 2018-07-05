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
    public class PageBuilder<TPage, TGroup>
        where TPage : IPage
        where TGroup : IGroup
    {
        private class ConstructorsIndex<TPageElem> : Dictionary<Type, IPageElementConstructor<TPageElem, TGroup, TPage>>
            where TPageElem : IPageElement
        {
            internal ConstructorsIndex(IEnumerable<IPageElementConstructor<TPageElem, TGroup, TPage>> constructors)
            {
                IndexConstructors(constructors);
            }

            internal IPageElementConstructor<TPageElem, TGroup, TPage> FindConstructor(Type type)
            {
                IPageElementConstructor<TPageElem, TGroup, TPage> constr;

                if (!TryGetValue(type, out constr))
                {
                    constr = this.FirstOrDefault(t => type.IsAssignableFrom(type)).Value;
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

            private void IndexConstructors(IEnumerable<IPageElementConstructor<TPageElem, TGroup, TPage>> constructors)
            {
                foreach (var constr in constructors)
                {
                    DataTypeAttribute dataTypeAtt;
                    if (constr.GetType().TryGetAttribute(out dataTypeAtt))
                    {
                        if (!ContainsKey(dataTypeAtt.Type))
                        {
                            Add(dataTypeAtt.Type, constr);
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
            }
        }

        private readonly IDataModelBinder m_DataBinder;
        private readonly IPageConstructor<TPage> m_PageConstructor;

        //
        //private readonly IDictionary<Type, IGroupConstructor<TGroup, TPage>> m_GroupConstructors1;
        //private readonly IDictionary<Type, IControlConstructor<TControl, TGroup, TPage>> m_ControlConstructors1;
        //

        private readonly ConstructorsIndex<TGroup> m_GroupConstructors;
        private readonly ConstructorsIndex<IControl> m_ControlConstructors;

        //private Dictionary<IControl, IBinding<TDataModel>> m_Bindings;

        //private TPage m_Page;

        //private bool m_IsLoaded;

        //private TDataModel m_CurrentDataModel;

        public PageBuilder(IDataModelBinder dataBinder,
            IPageConstructor<TPage> pageConstr,
            IGroupConstructor<TGroup, TPage>[] groupConstrs,
            IControlConstructor<IControl, TGroup, TPage>[] ctrlsContstrs)
        {
            m_DataBinder = dataBinder;
            m_PageConstructor = pageConstr;
            //m_GroupConstructors = IndexConstructors(groupConstrs);
            //m_ControlConstructors = IndexConstructors(ctrlsContstrs);

            m_GroupConstructors = new ConstructorsIndex<TGroup>(groupConstrs);
            m_ControlConstructors = new ConstructorsIndex<IControl>(ctrlsContstrs);
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
        

        public TPage CreatePage<TModel>(TModel model)
        {
            TPage page = default(TPage);
            
            var bindingGrp = m_DataBinder.Bind(model,
                (DataModelInfo info) => 
                {
                    page = m_PageConstructor.Create(info.Attributes);
                    return page;
                },
                (DataModelInfo info, IGroup parent) =>
                {
                    IControl ctrl = null;

                    //TGroup parentGrp = default(TGroup);
                    //IPageElementConstructor<IPageElement, IGroup, TPage> constr = null;
                    //IConstructor constr = null;

                    if (info.IsGroup)
                    {
                        var constr = m_GroupConstructors.FindConstructor(info.Type);
                        //.Create(page, parentGrp, info.Attributes);
                        if (parent is TGroup)
                        {
                            ctrl = constr.Create((TGroup)parent, info.Attributes);
                        }
                        else if (parent is TPage)
                        {
                            ctrl = constr.Create((TPage)parent, info.Attributes);
                        }
                    }
                    else
                    {
                        var constr = m_ControlConstructors.FindConstructor(info.Type);
                        if (parent is TGroup)
                        {
                            ctrl = constr.Create((TGroup)parent, info.Attributes);
                        }
                        else if (parent is TPage)
                        {
                            ctrl = constr.Create((TPage)parent, info.Attributes);
                        }
                        //.Create(page, parentGrp, info.Attributes);
                    }

                    return ctrl;
                });

            page.Binding.Load(bindingGrp);

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

        //private IDictionary<Type, TConstructor> IndexConstructors<TConstructor>(IEnumerable<TConstructor> constructors)
        //    where TConstructor : IConstructor
        //{
        //    var index = new Dictionary<Type, TConstructor>();

        //    foreach (var constr in constructors)
        //    {
        //        DataTypeAttribute dataTypeAtt;
        //        if (constr.GetType().TryGetAttribute(out dataTypeAtt))
        //        {
        //            if (!index.ContainsKey(dataTypeAtt.Type))
        //            {
        //                index.Add(dataTypeAtt.Type, constr);
        //            }
        //            else
        //            {
        //                //TODO: throw exception
        //            }
        //        }
        //        else
        //        {
        //            //TODO: throw exception
        //        }
        //    }

        //    return index;
        //}

        //private IPageElementConstructor<TPageElem, TGroup, TPage> FindConstructor<TPageElem>(
        //    IDictionary<Type, IPageElementConstructor<TPageElem, TGroup, TPage>> index, Type type)
        //    where TPageElem : IPageElement
        //{
        //    IPageElementConstructor<TPageElem, TGroup, TPage> constr;
            
        //    if (!index.TryGetValue(type, out constr))
        //    {
        //        constr = index.FirstOrDefault(t => type.IsAssignableFrom(type)).Value;
        //    }

        //    if (constr != null)
        //    {
        //        return constr;
        //    }
        //    else
        //    {
        //        //TODO: throw exception
        //        throw new Exception();
        //    }
        //}

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
