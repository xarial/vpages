using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Core;

namespace Xarial.VPages.Framework.Base
{
    public delegate IControl BindToControlDelegate(DataModelInfo info, IGroup parent);
    public delegate IPage CreatePageDelegate(DataModelInfo info);

    public interface IDataModelBinder
    {
        BindingGroup Bind(object model, CreatePageDelegate pageCreator, BindToControlDelegate ctrlCreator);
    }
}
