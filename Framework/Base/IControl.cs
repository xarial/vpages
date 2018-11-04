/*********************************************************************
vPages
Copyright(C) 2018 www.xarial.net
Product URL: https://www.xarial.net/products/developers/vpages
License: https://github.com/xarial/vpages/blob/master/LICENSE
*********************************************************************/

namespace Xarial.VPages.Framework.Base
{
    public delegate void ControlObjectValueChangedDelegate(IControl sender, object newValue);

    public interface IControl
    {
        event ControlObjectValueChangedDelegate ValueChanged;

        int Id { get; }

        object Tag { get; }

        object GetValue();
        void SetValue(object value);
    }
}
