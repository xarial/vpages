using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Core.Base;

namespace Xarial.VPages.Core
{
    //public delegate IControl BindToControlDelegate(
    //    IBinding binding, IBinding parentBinding, AttributeSet attributes);

    public delegate IControl BindToControlDelegate(DataModelInfo info, IGroup parent);
    public delegate IPage CreatePageDelegate(DataModelInfo info);

    public interface IDataModelBinder
    {
        //event BindDelegate Bind;
        //event BindToPage<TDataModel> BindToPage;
        //event BindToControlDelegate<TDataModel> BindToControl;

        BindingGroup Bind(object model, CreatePageDelegate pageCreator, BindToControlDelegate ctrlCreator);
        //void Bind(TDataModel model);
    }
}
