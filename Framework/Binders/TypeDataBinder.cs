using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Xarial.VPages.Core.Base;
using Xarial.VPages.Core.Binders;

namespace Xarial.VPages.Core.Parsers
{
    public class TypeDataBinder : IDataModelBinder
    {
        //public event BindToPage<TDataModel> BindToPage;
        //public event BindToControlDelegate<TDataModel> BindToControl;
        
        //public void Init()
        //{
        //    var binding = new RootBinding<TDataModel>(typeof(TDataModel));
        //    binding.Control = BindToPage?.Invoke(binding, GetAttributeSet(typeof(TDataModel)));

        //    TraverseType(typeof(TDataModel), new List<PropertyInfo>(), null);
        //}

        private void TraverseType(Type type, object model, List<PropertyInfo> parents,
            BindToControlDelegate ctrlCreator, IGroup parentCtrl, List<IBinding> bindings)
        {
            foreach (var prp in type.GetProperties())
            {
                var prpType = prp.PropertyType;

                var isGroup = !(prpType.IsPrimitive || prpType.IsEnum || prpType == typeof(string) || prpType == typeof(decimal));

                var ctrl = ctrlCreator.Invoke(
                    new DataModelInfo(prp.Name, prpType, isGroup, GetAttributeSet(prp)), parentCtrl);

                var binding = new PropertyInfoBinding(model, ctrl, prp, parents);
                bindings.Add(binding);
                //binding.Control = BindToControl?.Invoke(binding, parentBinding, GetAttributeSet(prp));

                if (isGroup)
                {
                    if (!(ctrl is IGroup))
                    {
                        //throw
                    }

                    var grpParents = new List<PropertyInfo>(parents);
                    grpParents.Add(prp);
                    TraverseType(prpType, model, grpParents, ctrlCreator, ctrl as IGroup, bindings);
                }
            }
        }

        private AttributeSet GetAttributeSet(PropertyInfo prp)
        {
            return null;
        }

        private AttributeSet GetAttributeSet(Type type)
        {
            return null;
        }

        public BindingGroup Bind(object model, CreatePageDelegate pageCreator, BindToControlDelegate ctrlCreator)
        {
            var type = model.GetType();

            var bindings = new List<IBinding>();

            var page = pageCreator.Invoke(
                    new DataModelInfo(type.Name, type, true, GetAttributeSet(type)));

            if (!(page is IPage))
            {
                //throw
            }

            TraverseType(model.GetType(), model, new List<PropertyInfo>(), ctrlCreator, page as IGroup, bindings);

            return new BindingGroup(bindings);
        }
    }
}
