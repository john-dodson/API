using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Data;
using API;

namespace APITest
{
    [TestFixture]
    public class ItemCatalogTest
    {
        DataTable products;
        private VolumeDiscount disA;
        private VolumeDiscount disC;
        private IEnumerable<Discount> packA;
        private IEnumerable<Discount> packC;

        [SetUp]
        public void Init()
        {
            products = new DataTable();
            products.Columns.Add("Name");
            products.Columns.Add("Price");
            products.Columns.Add("Discounts", typeof(IEnumerable<Discount>));

            disA = new VolumeDiscount(7.00, 4);
            disC = new VolumeDiscount(6.00, 6);
            packA = new Discount[] { disA };
            packC = new Discount[] { disC };

            DataRow a = products.NewRow();
            a["Name"] = "A";
            a["Price"] = 2.00;
            a["Discounts"] = packA;

            DataRow b = products.NewRow();
            b["Name"] = "B";
            b["Price"] = 12.00;

            DataRow c = products.NewRow();
            c["Name"] = "C";
            c["Price"] = 1.25;
            c["Discounts"] = packC;

            DataRow d = products.NewRow();
            d["Name"] = "D";
            d["Price"] = 0.15;

            products.Rows.Add(a);
            products.Rows.Add(b);
            products.Rows.Add(c);
            products.Rows.Add(d);
        }

        [Test]
        public void GetTest()
        {
            ItemCatalog catalog = new ItemCatalog(products);
            var a = catalog.Get("A");
            Assert.AreEqual(a.GetName(), "A");
            Assert.AreEqual(a.GetPrice(), 2.00);
            Assert.AreEqual(a.GetDiscounts(), packA);
            var b = catalog.Get("B");
            Assert.AreEqual(b.GetName(), "B");
            Assert.AreEqual(b.GetPrice(), 12.00);
            Assert.AreEqual(b.GetDiscounts(), null);
            var c = catalog.Get("C");
            Assert.AreEqual(c.GetName(), "C");
            Assert.AreEqual(c.GetPrice(), 1.25);
            Assert.AreEqual(c.GetDiscounts(), packC);
            var d = catalog.Get("D");
            Assert.AreEqual(d.GetName(), "D");
            Assert.AreEqual(d.GetPrice(), 0.15);
            Assert.AreEqual(d.GetDiscounts(), null);
        }

        [Test, ExpectedException(typeof(System.Collections.Generic.KeyNotFoundException))]
        public void InvalidProductTest()
        {
            var catalog = new ItemCatalog(products);
            Product a = catalog.Get("E");
        }

        [Test]
        public void GetCountTest()
        {
            var catalog = new ItemCatalog(products);
            Assert.AreEqual(catalog.GetCount(), 4);
        }

    }
}
