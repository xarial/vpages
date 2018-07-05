using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xarial.VPages.Core;
using Xarial.VPages.Core.Base;

namespace Xarial.VPages.WinForms
{
    public class FormPage : Page
    {
        internal Form Form { get; private set; }
        internal FlowLayoutPanel Panel { get; private set; }

        internal FormPage()
        {
            Form = new Form();
            Panel = new FlowLayoutPanel();
            Panel.FlowDirection = FlowDirection.TopDown;
            Panel.Dock = DockStyle.Fill;
            Form.Controls.Add(Panel);
        }

        //private BindingGroup m_Binding;

        //public BindingGroup Binding
        //{
        //    get
        //    {
        //        return m_Binding ?? (m_Binding = new BindingGroup());
        //    }
        //}
    }
}
