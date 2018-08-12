using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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
        
        public override void UpdateDataModel()
        {
            var value = Control.GetValue();
            var curModel = GetCurrentModel();

            var destVal = value.Cast(Property.PropertyType);

            Property.SetValue(curModel, destVal, null);
        }

        public override void UpdateUserControl()
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
