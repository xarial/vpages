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
        public BindingGroup() : base(new List<IBinding>())
        {
        }

        internal void Load(IEnumerable<IBinding> bindings)
        {
            this.Items.Clear();

            foreach (var bind in bindings)
            {
                this.Items.Add(bind);
            }
        }
    }
}
