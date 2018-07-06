using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace Xarial.VPages.Framework.Core
{
    public class BindingGroup : ReadOnlyCollection<IBinding>
    {
        internal BindingGroup(IList<IBinding> bindings) : base(bindings)
        {
        }

        public BindingGroup() : base(new List<IBinding>())
        {
        }

        internal void Load(BindingGroup grp)
        {
            this.Items.Clear();

            foreach (var bind in grp)
            {
                this.Items.Add(bind);
            }
        }
    }
}
