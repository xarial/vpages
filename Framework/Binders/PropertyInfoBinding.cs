using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Xarial.VPages.Core.Binders
{
    public class PropertyInfoBinding : Binding
    {
        private IList<PropertyInfo> m_Parents;

        private PropertyInfo m_PrpInfo;

        internal PropertyInfoBinding(object dataModel, IControl control,
            PropertyInfo prpInfo, IList<PropertyInfo> parents)
            : base(control, dataModel)
        {
            m_PrpInfo = prpInfo;
            m_Parents = parents;

            //Type = prpInfo.PropertyType;
            //Name = prpInfo.Name;
            //IsGroup = isGroup;
        }

        //public object GetValueFromControl()
        //{
        //    return Control.GetValue();
        //}

        //public object GetValueFromData(TDataModel model)
        //{
        //    var curModel = GetCurrentModel(model);
        //    return m_PrpInfo.GetValue(curModel, null);
        //}

        //public void SetValueToControl(object value)
        //{
        //    Control.SetValue(value);
        //}
        
        public override void UpdateDataModel()
        {
            var value = Control.GetValue();
            var curModel = GetCurrentModel();
            m_PrpInfo.SetValue(curModel, value, null);
        }

        public override void UpdateUserControl()
        {
            var curModel = GetCurrentModel();
            var val = m_PrpInfo.GetValue(curModel, null);
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
