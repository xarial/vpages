﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Core;
using Xarial.VPages.Framework.Base;

namespace Xarial.VPages.Framework.Core
{
    public abstract class Binding<TDataModel> : IBinding
    {
        protected IControl Control { get; private set; }

        protected TDataModel DataModel { get; private set; }

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

        public abstract void UpdateUserControl();

        public abstract void UpdateDataModel();
    }
}
