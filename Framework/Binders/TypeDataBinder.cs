using System;
using System.Collections.Generic;
using System.Reflection;
using Xarial.VPages.Framework.Base;

namespace Xarial.VPages.Framework.Binders
{
    public class TypeDataBinder : IDataModelBinder
    {
        private void TraverseType<TDataModel>(Type type, TDataModel model, List<PropertyInfo> parents,
            CreateBindingControlDelegate ctrlCreator, CreateBindingGroupDelegate grpCreator,
            IGroup parentCtrl, List<IBinding> bindings)
        {
            foreach (var prp in type.GetProperties())
            {
                var prpType = prp.PropertyType;

                var isGroup = !(prpType.IsPrimitive || prpType.IsEnum || prpType == typeof(string) || prpType == typeof(decimal));

                IControl ctrl;

                if (isGroup)
                {
                    var grp = grpCreator.Invoke(prpType, GetAttributeSet(prp), parentCtrl);
                    ctrl = grp;

                    var grpParents = new List<PropertyInfo>(parents);
                    grpParents.Add(prp);
                    TraverseType(prpType, model, grpParents, ctrlCreator, grpCreator, grp, bindings);
                }
                else
                {
                    ctrl = ctrlCreator.Invoke(prpType, GetAttributeSet(prp), parentCtrl);
                }

                var binding = new PropertyInfoBinding<TDataModel>(model, ctrl, prp, parents);
                bindings.Add(binding);
            }
        }

        private IAttributeSet GetAttributeSet(PropertyInfo prp)
        {
            return null;
        }

        private IAttributeSet GetAttributeSet(Type type)
        {
            return null;
        }

        public void Bind<TDataModel>(TDataModel model, CreateBindingPageDelegate pageCreator,
            CreateBindingControlDelegate ctrlCreator, CreateBindingGroupDelegate grpCreator,
            out IEnumerable<IBinding> bindings)
        {
            var type = model.GetType();

            var bindingsList = new List<IBinding>();
            bindings = bindingsList;

            var page = pageCreator.Invoke(GetAttributeSet(type));

            TraverseType(model.GetType(), model, new List<PropertyInfo>(), 
                ctrlCreator, grpCreator, page, bindingsList);
        }
    }
}
