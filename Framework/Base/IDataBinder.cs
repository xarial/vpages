using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Core;

namespace Xarial.VPages.Framework.Base
{
    public delegate IControl CreateBindingControlDelegate(Type dataType, IAttributeSet atts, IGroup parent);
    public delegate IPage CreateBindingPageDelegate(IAttributeSet atts);

    public interface IDataModelBinder
    {
        void Bind<TDataModel>(TDataModel model, CreateBindingPageDelegate pageCreator,
            CreateBindingControlDelegate ctrlCreator,
            out IEnumerable<IBinding> bindings, out IDependencyManager dependencies);
    }
}
