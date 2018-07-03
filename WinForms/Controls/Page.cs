using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xarial.VPages.Core;

namespace Xarial.VPages.WinForms
{
    public class Page : BasePage
    {
        internal Form Form { get; private set; }
        internal FlowLayoutPanel Panel { get; private set; }

        internal Page()
        {
            Form = new Form();
            Panel = new FlowLayoutPanel();
            Panel.FlowDirection = FlowDirection.TopDown;
            Panel.Dock = DockStyle.Fill;
            Form.Controls.Add(Panel);
        }
    }
}
