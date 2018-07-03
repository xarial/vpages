using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Xarial.VPages.Core.Base
{
    public class BindingGroup : ReadOnlyCollection<IBinding>
    {
        public BindingGroup(IList<IBinding> bindings) : base(bindings)
        {
        }

        public BindingGroup() : base(new List<IBinding>())
        {
        }

        internal void CopyFrom(BindingGroup grp)
        {
            this.Items.Clear();

            foreach (var bind in grp)
            {
                this.Items.Add(bind);
            }
        }
    }
}
