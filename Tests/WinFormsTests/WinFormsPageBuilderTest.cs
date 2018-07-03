using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xarial.VPages.WinForms;

namespace WinFormsTests
{
    [TestClass]
    public class WinFormsPageBuilderTest
    {
        public class DataModelMock1
        {
            public string TextField { get; set; }

            public int NumberField { get; set; }
        }

        [TestMethod]
        public void TestMethod1()
        {
            var bld = new WinFormsPageBuilder();
            var dm = new DataModelMock1();
            var p = bld.CreatePage(dm);
            p.Form.ShowDialog();
        }
    }
}
