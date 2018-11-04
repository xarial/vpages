﻿/*********************************************************************
vPages
Copyright(C) 2018 www.xarial.net
Product URL: https://www.xarial.net/products/developers/vpages
License: https://github.com/xarial/vpages/blob/master/LICENSE
*********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Core;

namespace Xarial.VPages.Framework.Binders
{
    public class PropertyInfoBinding<TDataModel> : Binding<TDataModel>
    {
        private IList<PropertyInfo> m_Parents;

        internal PropertyInfo Property { get; private set; }

        internal PropertyInfoBinding(TDataModel dataModel, IControl control,
            PropertyInfo prpInfo, IList<PropertyInfo> parents)
            : base(control, dataModel)
        {
            Property = prpInfo;
            m_Parents = parents;
        }
        
        protected override void SetDataModelValue()
        {
            var value = Control.GetValue();
            var curModel = GetCurrentModel();

            var destVal = value.Cast(Property.PropertyType);

            Property.SetValue(curModel, destVal, null);
        }

        protected override void SetUserControlValue()
        {
            var curModel = GetCurrentModel();
            var val = Property.GetValue(curModel, null);
            Control.SetValue(val);
        }

        private object GetCurrentModel(bool init = true)
        {
            object curModel = DataModel;

            if (m_Parents != null)
            {
                foreach (var parent in m_Parents)
                {
                    var nextModel = parent.GetValue(curModel, null);

                    if (nextModel == null)
                    {
                        if (init)
                        {
                            nextModel = Activator.CreateInstance(parent.PropertyType);
                            parent.SetValue(curModel, nextModel, null);
                        }
                        else
                        {
                            return null;
                        }
                    }

                    curModel = nextModel;
                }
            }

            return curModel;
        }
    }
}
