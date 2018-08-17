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
    public class FormPage : Page
    {
        internal Form Form { get; private set; }
        internal LayoutControl Layout { get; private set; }

        internal FormPage()
        {
            Form = new Form();
            Layout = new LayoutControl(Form);
        }
    }
}
