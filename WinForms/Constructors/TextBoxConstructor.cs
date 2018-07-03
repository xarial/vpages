using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Core;
using Xarial.VPages.Core.Attributes;
using Xarial.VPages.Core.Constructors;

namespace Xarial.VPages.WinForms
{
    [DataType(typeof(string))]
    public class TextBoxConstructor : IControlConstructor<Control, Page, Group>
    {
        public Control Create(Page page, Group parent, AttributeSet atts)
        {
            var ctrl = new TextBoxControl();
            page.Panel.Controls.Add(ctrl.TextBox);
            return ctrl;
        }
    }
}
