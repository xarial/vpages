using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xarial.VPages.Framework.Base.Attributes
{
    ///<summary>
    ///This attribute indicates that the constructor must be used as a default control constructor for the nominated type
    ///</summary>
    /// <remarks>
    /// Must be applied to <see cref="Constructors.IPageElementConstructor{TElem, TGroup, TPage}"/>
    /// or <see cref="Constructors.IPageConstructor{TPage}"/> only
    /// </summary>
    public interface IDefaultTypeAttribute : IAttribute
    {
        /// <summary>
        /// Specifies the type of the data which this constructor creates control for
        /// </summary>
        Type Type { get; }
    }
}
