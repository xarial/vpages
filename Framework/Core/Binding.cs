﻿/*********************************************************************
vPages
Copyright(C) 2018 www.xarial.net
Product URL: https://www.xarial.net/products/developers/vpages
License: https://github.com/xarial/vpages/blob/master/LICENSE
*********************************************************************/

using System;
using Xarial.VPages.Framework.Base;

namespace Xarial.VPages.Framework.Core
{
    public abstract class Binding<TDataModel> : IBinding
    {
        public event Action<IBinding> ModelUpdated;
        public event Action<IBinding> ControlUpdated;

        public IControl Control { get; private set; }

        protected TDataModel DataModel { get; private set; }

        object IBinding.Model
        {
            get
            {
                return DataModel;
            }
        }

        public Binding(IControl control, TDataModel dataModel)
        {
            DataModel = dataModel;
            Control = control;
            Control.ValueChanged += OnControlValueChanged;
        }
        
        private void OnControlValueChanged(IControl sender, object newValue)
        {
            UpdateDataModel();
        }

        protected abstract void SetUserControlValue();

        protected abstract void SetDataModelValue();

        public void UpdateControl()
        {
            SetUserControlValue();
            ControlUpdated?.Invoke(this);
        }

        public void UpdateDataModel()
        {
            SetDataModelValue();
            ModelUpdated?.Invoke(this);
        }
    }
}
