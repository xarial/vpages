using System;
using System.Collections.Generic;
using System.Reflection;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Core;

namespace Xarial.VPages.Framework.Binders
{
    public class TypeDataBinder : IDataModelBinder
    {
        private void TraverseType<TDataModel>(Type type, TDataModel model, List<PropertyInfo> parents,
            CreateBindingControlDelegate ctrlCreator,
            IGroup parentCtrl, List<IBinding> bindings)
        {
            foreach (var prp in type.GetProperties())
            {
                var prpType = prp.PropertyType;

                var ctrl = ctrlCreator.Invoke(prpType, GetAttributeSet(prp), parentCtrl);

                var isGroup = ctrl is IGroup;

                if (isGroup)
                {
                    var grpParents = new List<PropertyInfo>(parents);
                    grpParents.Add(prp);
                    TraverseType(prpType, model, grpParents, ctrlCreator, ctrl as IGroup, bindings);
                }

                var binding = new PropertyInfoBinding<TDataModel>(model, ctrl, prp, parents);
                bindings.Add(binding);
            }
        }

        private IAttributeSet GetAttributeSet(PropertyInfo prp)
        {
            return new AttributeSet();
        }

        private IAttributeSet GetAttributeSet(Type type)
        {
            return new AttributeSet();
        }

        public void Bind<TDataModel>(TDataModel model, CreateBindingPageDelegate pageCreator,
            CreateBindingControlDelegate ctrlCreator,
            out IEnumerable<IBinding> bindings)
        {
            var type = model.GetType();

            var bindingsList = new List<IBinding>();
            bindings = bindingsList;

            var page = pageCreator.Invoke(GetAttributeSet(type));

            TraverseType(model.GetType(), model, new List<PropertyInfo>(), 
                ctrlCreator, page, bindingsList);
        }
    }
}
