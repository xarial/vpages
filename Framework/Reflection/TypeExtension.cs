/*********************************************************************
vPages
Copyright(C) 2018 www.xarial.net
Product URL: https://www.xarial.net/products/developers/vpages
License: https://github.com/xarial/vpages/blob/master/LICENSE
*********************************************************************/

using System.Linq;

namespace System
{
    public static class TypeExtension
    {
        public static bool TryGetAttribute<TAtt>(this Type type, out TAtt att)
            where TAtt : Attribute
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var custAtts = type.GetCustomAttributes(typeof(TAtt), true);

            if (custAtts != null && custAtts.Any())
            {
                att = custAtts.First() as TAtt;
                return true;
            }
            else
            {
                att = null;
                return false;
            }
        }
    }
}
