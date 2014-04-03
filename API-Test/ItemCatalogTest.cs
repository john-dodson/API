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
        [SetUp]
        public void Init()
        {
            products = new DataTable();
            products.Columns.Add("Name");
            products.Columns.Add("Price");
            products.Columns.Add("DiscountPrice");
            products.Columns.Add("DiscountQuantity");

            DataRow a = products.NewRow();
            a["Name"] = "A";
            a["Price"] = 2.00;
            a["DiscountPrice"] = 7.00;
            a["DiscountQuantity"] = 4;

            DataRow b = products.NewRow();
            b["Name"] = "B";
            b["Price"] = 12.00;
            b["DiscountPrice"] = 0.00;
            b["DiscountQuantity"] = 0;

            DataRow c = products.NewRow();
            c["Name"] = "C";
            c["Price"] = 1.25;
            c["DiscountPrice"] = 6.00;
            c["DiscountQuantity"] = 6;

            DataRow d = products.NewRow();
            d["Name"] = "D";
            d["Price"] = 0.15;
            d["DiscountPrice"] = 0.00;
            d["DiscountQuantity"] = 0;

            products.Rows.Add(a);
            products.Rows.Add(b);
            products.Rows.Add(c);
            products.Rows.Add(d);
        }

        [Test]
        public void CreateAndGetCatalog()
        {
            ItemCatalog catalog = new ItemCatalog(products);
            var a = catalog.Get("A");
            Assert.AreEqual(a.GetName(), "A");
            Assert.AreEqual(a.GetPrice(), 2.00);
            Assert.AreEqual(a.GetDiscountPrice(), 7.00);
            Assert.AreEqual(a.GetDiscountQuantity(), 4);
            var b = catalog.Get("B");
            Assert.AreEqual(b.GetName(), "B");
            Assert.AreEqual(b.GetPrice(), 12.00);
            Assert.AreEqual(b.GetDiscountPrice(), 0.00);
            Assert.AreEqual(b.GetDiscountQuantity(), 0);
            var c = catalog.Get("C");
            Assert.AreEqual(c.GetName(), "C");
            Assert.AreEqual(c.GetPrice(), 1.25);
            Assert.AreEqual(c.GetDiscountPrice(), 6.00);
            Assert.AreEqual(c.GetDiscountQuantity(), 6);
            var d = catalog.Get("D");
            Assert.AreEqual(d.GetName(), "D");
            Assert.AreEqual(d.GetPrice(), 0.15);
            Assert.AreEqual(d.GetDiscountPrice(), 0.00);
            Assert.AreEqual(d.GetDiscountQuantity(), 0);
        }

        [Test, ExpectedException(typeof(System.Collections.Generic.KeyNotFoundException))]
        public void InvalidProduct()
        {
            var catalog = new ItemCatalog(products);
            Product a = catalog.Get("E");
        }

    }
}
