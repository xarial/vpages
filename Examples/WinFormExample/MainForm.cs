using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xarial.VPages.WinForms;

namespace WinFormExample
{
    public partial class MainForm : Form
    {
        private DataModel m_Model;

        private WinFormsPageBuilder m_Builder;

        private FormPage m_ActivePage;

        public MainForm()
        {
            InitializeComponent();

            m_Model = new DataModel();
            m_Builder = new WinFormsPageBuilder();
        }

        private void OnOpen(object sender, EventArgs e)
        {
            m_ActivePage = m_Builder.CreatePage(m_Model);
            m_ActivePage.Show();
        }
    }
}
