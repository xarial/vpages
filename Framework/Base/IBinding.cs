using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Xarial.VPages.Core
{
    public interface IBinding
    {
        //IControl Control { get; }
        //object Data { get; }

        //void SetDataValue(object value);
        //void UpdateControlValue

        //void SetValueToControl(object value);
        //void SetValueToData(object value, object model);
        //object GetValueFromControl();
        //object GetValueFromData(object model);

        void UpdateUserControl();
        void UpdateDataModel();
    }

    //public interface IBinding<TVal> : IBinding
    //{
        //IControl Control { get; }
        //object Data { get; }

        //void SetDataValue(object value);
        //void UpdateControlValue

        //void SetValueToControl(object value);
        //void SetValueToData(object value, object model);
        //object GetValueFromControl();
        //object GetValueFromData(object model);

        //void UpdateUserControl();
        //void UpdateDataModel();
    //}
    
    public abstract class Binding : IBinding
    {
        protected IControl Control { get; private set; }

        protected object DataModel { get; private set; }
        //public object Data { get; private set; }

        public Binding(IControl control, object dataModel)
        {
            DataModel = dataModel;
            Control = control;
            Control.ValueChanged += OnControlValueChanged;
            //Data = data;
        }

        private void OnControlValueChanged(IControl sender, object newValue)
        {
            UpdateDataModel();
            //SetDataValue(newValue);
        }

        //public abstract void SetDataValue(object value);

        public abstract void UpdateUserControl();

        public abstract void UpdateDataModel();

        //public void SetValueToControl(object value)
        //{
        //    throw new NotImplementedException();
        //}

        //public void SetValueToData(object value, object model)
        //{
        //    throw new NotImplementedException();
        //}

        //public object GetValueFromControl()
        //{
        //    throw new NotImplementedException();
        //}

        //public object GetValueFromData(object model)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
