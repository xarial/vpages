using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xarial.VPages.Framework.PageElements;

namespace Xarial.VPages.WinForms.Controls
{
    public class ButtonControl : FormControl<Action>
    {
        protected override event ControlValueChangedDelegate<Action> ValueChanged;

        private Button m_Button;
        private Action m_Handler;

        public override Control Control => m_Button;
        
        internal ButtonControl(int id, object tag, string name) : base(id, tag)
        {
            m_Button = new Button()
            {
                Text = name
            };

            m_Button.Click += OnButtonClick;
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            m_Handler?.Invoke();
        }

        protected override Action GetSpecificValue()
        {
            return m_Handler;
        }

        protected override void SetSpecificValue(Action value)
        {
            m_Handler = value;
        }
    }
}
