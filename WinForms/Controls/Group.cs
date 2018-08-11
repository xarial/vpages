using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xarial.VPages.Core;
using Xarial.VPages.Framework.Core;
using Xarial.VPages.Framework.PageElements;
using Xarial.VPages.WinForms.Constructors;

namespace Xarial.VPages.WinForms
{
    public class FormGroup : Group
    {
        internal LayoutControl Layout { get; private set; }

        internal GroupBox Group { get; private set; }

        internal FormGroup(int id) : base(id)
        {
            Group = new GroupBox()
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            
            Layout = new LayoutControl(Group);
        }
    }
}
