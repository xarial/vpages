using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Attributes;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Base.Attributes;
using Xarial.VPages.Framework.Constructors;
using Xarial.VPages.Framework.Core;

namespace Xarial.VPages.Framework.Internal
{
    internal class ConstructorsContainer<TPage, TGroup> 
        where TPage : IPage
        where TGroup : IGroup
    {
        private readonly IPageElementConstructor<TGroup, TPage> m_GenericConstructor;
        private readonly IPageElementConstructor<TGroup, TPage> m_GenericComplexTypeConstructor;

        private readonly Dictionary<Type, IPageElementConstructor<TGroup, TPage>> m_DefaultConstructors;
        private readonly Dictionary<Type, IPageElementConstructor<TGroup, TPage>> m_SpecificConstructors;

        internal ConstructorsContainer(params IPageElementConstructor<TGroup, TPage>[] constructors)
        {
            m_DefaultConstructors = new Dictionary<Type, IPageElementConstructor<TGroup, TPage>>();
            m_SpecificConstructors = new Dictionary<Type, IPageElementConstructor<TGroup, TPage>>();

            foreach (var constr in constructors)
            {
                var dataTypeAtts = constr.GetType().GetCustomAttributes(
                    typeof(DefaultTypeAttribute), true).OfType<DefaultTypeAttribute>();

                var isDefaultConstr = dataTypeAtts.Any();

                if (isDefaultConstr)
                {
                    foreach (var dataTypeAtt in dataTypeAtts)
                    {
                        var type = dataTypeAtt.Type;

                        if (type == typeof(SpecialTypes.AnyType))
                        {
                            if (m_GenericConstructor != null)
                            {
                                //throw exception - duplicate generic constructor
                            }

                            m_GenericConstructor = constr;
                        }
                        if (type == typeof(SpecialTypes.ComplexType))
                        {
                            if (m_GenericComplexTypeConstructor != null)
                            {
                                //throw exception - duplicate generic group constructor
                            }

                            m_GenericComplexTypeConstructor = constr;
                        }
                        else
                        {
                            if (!m_DefaultConstructors.ContainsKey(dataTypeAtt.Type))
                            {
                                m_DefaultConstructors.Add(dataTypeAtt.Type, constr);
                            }
                            else
                            {
                                //TODO: throw exception
                            }
                        }
                    }
                }
                else
                {
                    if (!m_SpecificConstructors.ContainsKey(constr.GetType()))
                    {
                        m_SpecificConstructors.Add(constr.GetType(), constr);
                    }
                    else
                    {
                        //TODO: throw exception
                    }
                }
            }
        }

        private IPageElementConstructor<TGroup, TPage> FindConstructor(Type type, IAttributeSet atts)
        {
            if (atts == null)
            {
                throw new ArgumentNullException(nameof(atts));
            }

            IPageElementConstructor<TGroup, TPage> constr = null;

            if (atts.Has<ISpecificConstructorAttribute>())
            {
                var constrType = atts.Get<ISpecificConstructorAttribute>().ConstructorType;

                var constrs = m_SpecificConstructors.Where(c => constrType.IsAssignableFrom(c.Key));

                if (constrs.Count() == 1)
                {
                    constr = constrs.First().Value;
                }
                else if (!constrs.Any())
                {
                    throw new Exception("No constructors");
                }
                else
                {
                    throw new Exception("Too many constructors");
                }
                
            }
            else
            {
                if (!m_DefaultConstructors.TryGetValue(type, out constr))
                {
                    constr = m_DefaultConstructors.FirstOrDefault(
                        t => t.Key.IsAssignableFrom(type)).Value;

                    if (constr == null)
                    {
                        if (IsComplexType(type))
                        {
                            constr = m_GenericComplexTypeConstructor;
                        }
                        else
                        {
                            constr = m_GenericConstructor;
                        }
                    }
                }
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

        private bool IsComplexType(Type type)
        {
            return !(type.IsPrimitive
                || type.IsEnum
                || type == typeof(string) 
                || type == typeof(decimal));
        }

        internal IControl CreateElement(Type type, IGroup parent, IAttributeSet atts)
        {
            if (atts == null)
            {
                throw new ArgumentNullException(nameof(atts));
            }

            var constr = FindConstructor(type, atts);

            //TODO: check if attributes set is compatible with the constructor

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
    }
}
