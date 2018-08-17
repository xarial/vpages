using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Base.Attributes;
using Xarial.VPages.Framework.Core;

namespace Xarial.VPages.Framework.Binders
{
    public class TypeDataBinder : IDataModelBinder
    {
        public void Bind<TDataModel>(TDataModel model, CreateBindingPageDelegate pageCreator,
            CreateBindingControlDelegate ctrlCreator,
            out IEnumerable<IBinding> bindings)
        {
            var type = model.GetType();

            var bindingsList = new List<IBinding>();
            bindings = bindingsList;

            var page = pageCreator.Invoke(GetAttributeSet(type, -1));

            var firstCtrlId = 0;

            TraverseType(model.GetType(), model, new List<PropertyInfo>(),
                ctrlCreator, page, bindingsList, ref firstCtrlId);
        }

        private void TraverseType<TDataModel>(Type type, TDataModel model, List<PropertyInfo> parents,
            CreateBindingControlDelegate ctrlCreator,
            IGroup parentCtrl, List<IBinding> bindings, ref int nextCtrlId)
        {
            foreach (var prp in type.GetProperties())
            {
                var prpType = prp.PropertyType;

                var atts = GetAttributeSet(prp, nextCtrlId);

                if (!atts.Has<IIgnoreBindingAttribute>())
                {
                    var ctrl = ctrlCreator.Invoke(prpType, atts, parentCtrl);
                    nextCtrlId++;

                    var binding = new PropertyInfoBinding<TDataModel>(model, ctrl, prp, parents);
                    bindings.Add(binding);

                    binding.UpdateUserControl();

                    var isGroup = ctrl is IGroup;

                    if (isGroup)
                    {
                        var grpParents = new List<PropertyInfo>(parents);
                        grpParents.Add(prp);
                        TraverseType(prpType, model, grpParents, ctrlCreator,
                            ctrl as IGroup, bindings, ref nextCtrlId);
                    }
                }
            }
        }

        private IAttributeSet GetAttributeSet(PropertyInfo prp, int ctrlId)
        {
            string name;
            string desc;

            var type = prp.PropertyType;

            var typeAtts = ParseAttributes(type.GetCustomAttributes(true), out name, out desc);

            var prpAtts = ParseAttributes(prp.GetCustomAttributes(true), out name, out desc);

            if (string.IsNullOrEmpty(name))
            {
                name = prp.Name;
            }

            return CreateAttributeSet(ctrlId, name, desc, type, prpAtts.Union(typeAtts).ToArray());
        }

        private IAttributeSet GetAttributeSet(Type type, int ctrlId)
        {
            string name;
            string desc;

            var typeAtts = ParseAttributes(type.GetCustomAttributes(true), out name, out desc);

            if (string.IsNullOrEmpty(name))
            {
                name = type.Name;
            }

            return CreateAttributeSet(ctrlId, name, desc, type, typeAtts.ToArray());
        }

        private IEnumerable<IAttribute> ParseAttributes(object[] customAtts, out string name, out string desc)
        {
            name = customAtts?.OfType<DisplayNameAttribute>()?.FirstOrDefault()?.DisplayName;
            desc = customAtts?.OfType<DescriptionAttribute>()?.FirstOrDefault()?.Description;

            if (customAtts == null)
            {
                return Enumerable.Empty<IAttribute>();
            }
            else
            {
                return customAtts.OfType<IAttribute>();
            }
        }

        private IAttributeSet CreateAttributeSet(int ctrlId, string ctrlName, 
            string desc, Type boundType, IAttribute[] atts)
        {
            var attsSet = new AttributeSet(ctrlId, ctrlName, desc, boundType);

            if (atts?.Any() == true)
            {
                foreach (var att in atts)
                {
                    attsSet.Add(att);
                }
            }

            return attsSet;
        }
    }
}
