using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using API;
using NUnit.Framework;
using System.Diagnostics;

namespace APITest
{
    [TestFixture]
    public class TerminalTest
    {
        DataTable products;
        ItemCatalog catalog;
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

            catalog = new ItemCatalog(products);
        }

        [Test]
        public void ScanTest()
        {
            Terminal t = new Terminal(products);
            t.SetPrices();
            t.Scan("A");
            Product scanned = t.scanned["A"] as Product;
            Assert.AreEqual(scanned.GetName(), "A");
            Assert.AreEqual(scanned.count, 1);
        }

        [Test]
        public void TotalTest1()
        {
            Terminal t = new Terminal(products);
            t.SetPrices();
            t.Scan("A");
            t.Scan("B");
            t.Scan("C");
            t.Scan("D");
            t.Scan("A");
            t.Scan("B");
            t.Scan("A");
            t.Scan("A");
            Assert.AreEqual(t.CalculateTotal(), 32.40);
        }

        [Test]
        public void TotalTest2()
        {
            Terminal t = new Terminal(products);
            t.SetPrices();
            t.Scan("C");
            t.Scan("C");
            t.Scan("C");
            t.Scan("C");
            t.Scan("C");
            t.Scan("C");
            t.Scan("C");
            Assert.AreEqual(t.CalculateTotal(), 7.25);
        }

        [Test]
        public void TotalTest3()
        {
            Terminal t = new Terminal(products);
            t.SetPrices();
            t.Scan("A");
            t.Scan("B");
            t.Scan("C");
            t.Scan("D");
            Assert.AreEqual(t.CalculateTotal(), 15.40);
        }

    }
}
