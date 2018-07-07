using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Attributes;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Constructors;

namespace Xarial.VPages.Framework.Internal
{
    internal class ConstructorsContainer<TOutPageElem, TPage, TGroup> 
        : Dictionary<Type, IPageElementConstructor<TOutPageElem, TGroup, TPage>>
        where TOutPageElem : IControl
        where TPage : IPage
        where TGroup : IGroup
    {
        internal ConstructorsContainer(IEnumerable<IPageElementConstructor<TOutPageElem, TGroup, TPage>> constructors)
        {
            IndexConstructors(constructors);
        }

        private IPageElementConstructor<TOutPageElem, TGroup, TPage> FindConstructor(Type type)
        {
            IPageElementConstructor<TOutPageElem, TGroup, TPage> constr;

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

        internal TOutPageElem CreateElement(Type type, IGroup parent, IAttributeSet atts)
        {
            var constr = FindConstructor(type);

            if (parent is TPage)
            {
                return constr.Create((TPage)parent, atts);
            }
            else if (parent is TGroup)
            {
                return constr.Create((TGroup)parent, atts);
            }
            else
            {
                //TODO: throw
                throw new Exception();
            }
        }

        private void IndexConstructors(IEnumerable<IPageElementConstructor<TOutPageElem, TGroup, TPage>> constructors)
        {
            foreach (var constr in constructors)
            {
                DefaultTypeAttribute dataTypeAtt;
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
}
