using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Binders;
using Xarial.VPages.Framework.Core;

namespace FrameworkTests
{
    [TestClass]
    public class TypeDataBinderTests
    {
        #region Mocks

        public class DataModelMock1
        {
            public string Field1 { get; set; }
            public int Field2 { get; set; }
            public double Field3 { get; set; }
        }

        public class DataModelMock2
        {
            public string Field1 { get; set; }
            public int Field2 { get; set; }
            public double Field3 { get; set; }

            public DataModelMock1 Group1 { get; set; }
        }

        public class DataModelMock3
        {
            public string Field1 { get; set; }

            public DataModelMock2 Group2 { get; set; }
        }

        #endregion

        [TestMethod]
        public void TestBindSimple()
        {
            var binder = new TypeDataBinder();
            IEnumerable<IBinding> bindings;

            IDependencyManager dependencies;

            binder.Bind(new DataModelMock1(),
                a =>
                {
                    return new Moq.Mock<IPage>().Object;
                },
                (t, a, p) =>
                {
                    return new Moq.Mock<IControl>().Object;
                }, out bindings, out dependencies);

            Assert.AreEqual(3, bindings.Count());
            Assert.AreEqual(typeof(DataModelMock1).GetProperty("Field1"),
                (bindings.ElementAt(0) as PropertyInfoBinding<DataModelMock1>).Property);
            Assert.AreEqual(typeof(DataModelMock1).GetProperty("Field2"),
                (bindings.ElementAt(1) as PropertyInfoBinding<DataModelMock1>).Property);
            Assert.AreEqual(typeof(DataModelMock1).GetProperty("Field3"),
                (bindings.ElementAt(2) as PropertyInfoBinding<DataModelMock1>).Property);
        }

        [TestMethod]
        public void TestBindGroup()
        {
            var binder = new TypeDataBinder();
            IEnumerable<IBinding> bindings;

            IDependencyManager dependencies;

            binder.Bind(new DataModelMock2(),
                a =>
                {
                    return new Moq.Mock<IPage>().Object;
                },
                (t, a, p) =>
                {
                    if (t == typeof(DataModelMock1))
                    {
                        return new Moq.Mock<IGroup>().Object;
                    }
                    else
                    {
                        return new Moq.Mock<IControl>().Object;
                    }
                }, out bindings, out dependencies);

            Assert.AreEqual(7, bindings.Count());
            Assert.AreEqual(typeof(DataModelMock2).GetProperty("Field1"),
                (bindings.ElementAt(0) as PropertyInfoBinding<DataModelMock2>).Property);
            Assert.AreEqual(typeof(DataModelMock2).GetProperty("Field2"),
                (bindings.ElementAt(1) as PropertyInfoBinding<DataModelMock2>).Property);
            Assert.AreEqual(typeof(DataModelMock2).GetProperty("Field3"),
                (bindings.ElementAt(2) as PropertyInfoBinding<DataModelMock2>).Property);
            Assert.AreEqual(typeof(DataModelMock2).GetProperty("Group1"),
                (bindings.ElementAt(3) as PropertyInfoBinding<DataModelMock2>).Property);
            Assert.AreEqual(typeof(DataModelMock1).GetProperty("Field1"),
                (bindings.ElementAt(4) as PropertyInfoBinding<DataModelMock2>).Property);
            Assert.AreEqual(typeof(DataModelMock1).GetProperty("Field2"),
                (bindings.ElementAt(5) as PropertyInfoBinding<DataModelMock2>).Property);
            Assert.AreEqual(typeof(DataModelMock1).GetProperty("Field3"),
                (bindings.ElementAt(6) as PropertyInfoBinding<DataModelMock2>).Property);
        }

        [TestMethod]
        public void TestBindParent()
        {
            var binder = new TypeDataBinder();
            IEnumerable<IBinding> bindings;

            IPage page = null;
            IGroup grp1 = null;
            IGroup grp2 = null;

            var parents = new Dictionary<IControl, IGroup>();

            IDependencyManager dependencies;

            binder.Bind(new DataModelMock3(),
                a =>
                {
                    page = new Moq.Mock<IPage>().Object;
                    return page;
                },
                (t, a, p) =>
                {
                    if (t == typeof(DataModelMock1))
                    {
                        grp1 = new Moq.Mock<IGroup>().Object;
                        parents.Add(grp1, p);
                        return grp1;
                    }
                    if (t == typeof(DataModelMock2))
                    {
                        grp2 = new Moq.Mock<IGroup>().Object;
                        parents.Add(grp2, p);
                        return grp2;
                    }
                    else
                    {
                        var ctrl = new Moq.Mock<IControl>().Object;
                        parents.Add(ctrl, p);
                        return ctrl;
                    }
                }, out bindings, out dependencies);

            Assert.AreEqual(page,
                parents[(bindings.ElementAt(0) as PropertyInfoBinding<DataModelMock3>).Control]);
            Assert.AreEqual(page,
                parents[(bindings.ElementAt(1) as PropertyInfoBinding<DataModelMock3>).Control]);

            Assert.AreEqual(grp2,
                parents[(bindings.ElementAt(2) as PropertyInfoBinding<DataModelMock3>).Control]);
            Assert.AreEqual(grp2,
                parents[(bindings.ElementAt(3) as PropertyInfoBinding<DataModelMock3>).Control]);
            Assert.AreEqual(grp2,
                parents[(bindings.ElementAt(4) as PropertyInfoBinding<DataModelMock3>).Control]);
            Assert.AreEqual(grp2,
                parents[(bindings.ElementAt(5) as PropertyInfoBinding<DataModelMock3>).Control]);

            Assert.AreEqual(grp1,
                parents[(bindings.ElementAt(6) as PropertyInfoBinding<DataModelMock3>).Control]);
            Assert.AreEqual(grp1,
                parents[(bindings.ElementAt(7) as PropertyInfoBinding<DataModelMock3>).Control]);
            Assert.AreEqual(grp1,
                parents[(bindings.ElementAt(8) as PropertyInfoBinding<DataModelMock3>).Control]);
        }

        [TestMethod]
        public void TestBindAttributes()
        {
        }

        [TestMethod]
        public void TestDependencies()
        {
        }
    }
}
