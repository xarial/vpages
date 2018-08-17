using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Xarial.VPages.WinForms.Constructors
{
    internal class LayoutControl
    {
        private TableLayoutPanel m_Panel;
        
        internal LayoutControl(Control parent)
        {
            m_Panel = new TableLayoutPanel();
            m_Panel.ColumnCount = 1;
            m_Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            m_Panel.Dock = DockStyle.Top;
            parent.Controls.Add(m_Panel);
        }

        internal void AddControl(Control ctrl)
        {
            m_Panel.RowCount = m_Panel.RowCount + 1;
            m_Panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            var lastRowIndex = m_Panel.RowCount - 1;

            ctrl.Dock = DockStyle.Fill;

            m_Panel.Controls.Add(ctrl, 0, lastRowIndex);

            UpdateHeight();
        }

        private void UpdateHeight()
        {
            int height = 0;

            foreach (Control ctrl in m_Panel.Controls)
            {
                height += ctrl.Height + ctrl.Margin.Top + ctrl.Margin.Bottom;
            }
            
            m_Panel.Height = height;
        }
    }
}
