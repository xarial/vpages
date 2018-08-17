using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xarial.VPages.WinForms;

namespace WinFormsTests
{
    [TestClass]
    public class WinFormsPageBuilderTest
    {
        public class DataModelMock1
        {
            public class GroupMock1
            {
                public string GroupTextField1 { get; set; }
                public string GroupTextField2 { get; set; }
                public decimal NumberField1 { get; set; }
                public decimal NumberField2 { get; set; }
                public decimal NumberField3 { get; set; }
                public string GroupTextField4 { get; set; }
                public string GroupTextField5 { get; set; }
            }

            public string TextField { get; set; }

            public decimal NumberField { get; set; }

            public GroupMock1 Group { get; set; }
        }

        //[TestMethod]
        public void TestMethod1()
        {
            var bld = new WinFormsPageBuilder();
            var dm = new DataModelMock1();
            var p = bld.CreatePage(dm);
            p.Form.ShowDialog();
            MessageBox.Show($"{dm.TextField} {dm.NumberField}");
        }
    }
}
