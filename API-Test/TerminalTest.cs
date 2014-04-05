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
        private VolumeDiscount disA;
        private VolumeDiscount disC;
        private IEnumerable<Discount> packA;
        private IEnumerable<Discount> packC;

        /*
         * Setup unit tests
         */
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

        /*
         * Test retrieval of ItemCatalog
         */
        [Test]
        public void GetItemCatalogTest()
        {
            Terminal t = new Terminal(products);
            t.SetPrices();
            var catalog = t.GetItemCatalog();
            Assert.AreEqual(catalog.GetType(), typeof(ItemCatalog));
            Assert.AreEqual(catalog.GetCount(), 4);
        }

        /*
         * Test retrieval of product DataTable
         */
        [Test]
        public void GetDataTest()
        {
            Terminal t = new Terminal(products);
            Assert.AreEqual(t.GetData(), products);
        }

        /*
         * Test scanning an item
         */
        [Test]
        public void ScanTest()
        {
            Terminal t = new Terminal(products);
            t.SetPrices();
            t.Scan("A");
            var cart = t.GetCart();
            Assert.AreEqual(cart.GetContents().Count, 1);
            Assert.AreEqual(cart.GetItem("A").quantity, 1);
            Assert.AreEqual(cart.GetItem("A").GetName(), "A");
            Assert.AreEqual(cart.GetItem("A").GetProduct().GetName(), "A");
            Assert.AreEqual(cart.GetItem("A").GetProduct().GetPrice(), 2.00);
        }

        /*
         * Test scanning several different items
         */
        [Test]
        public void ScanTest2()
        {
            Terminal t = new Terminal(products);
            t.SetPrices();
            t.Scan("A");
            t.Scan("C");
            var cart = t.GetCart();
            Assert.AreEqual(cart.GetContents().Count, 2);
            Assert.AreEqual(cart.GetItem("A").quantity, 1);
            Assert.AreEqual(cart.GetItem("A").GetName(), "A");
            Assert.AreEqual(cart.GetItem("A").GetProduct().GetName(), "A");
            Assert.AreEqual(cart.GetItem("A").GetProduct().GetPrice(), 2.00);
            Assert.AreEqual(cart.GetItem("C").quantity, 1);
            Assert.AreEqual(cart.GetItem("C").GetName(), "C");
            Assert.AreEqual(cart.GetItem("C").GetProduct().GetName(), "C");
            Assert.AreEqual(cart.GetItem("C").GetProduct().GetPrice(), 1.25);
        }

        /*
         * Test scanning items in bulk
         */
        [Test]
        public void ScanMultipleTest()
        {
            Terminal t = new Terminal(products);
            t.SetPrices();
            t.ScanMultiple("A", 2);
            t.ScanMultiple("C", 2);
            var cart = t.GetCart();
            Assert.AreEqual(cart.GetContents().Count, 2);
            Assert.AreEqual(cart.GetItem("A").quantity, 2);
            Assert.AreEqual(cart.GetItem("A").GetName(), "A");
            Assert.AreEqual(cart.GetItem("A").GetProduct().GetName(), "A");
            Assert.AreEqual(cart.GetItem("A").GetProduct().GetPrice(), 2.00);
            Assert.AreEqual(cart.GetItem("C").quantity, 2);
            Assert.AreEqual(cart.GetItem("C").GetName(), "C");
            Assert.AreEqual(cart.GetItem("C").GetProduct().GetName(), "C");
            Assert.AreEqual(cart.GetItem("C").GetProduct().GetPrice(), 1.25);
        }

        /*
         * Satisfy first required Test case
         */
        [Test]
        public void CalculateTotalTest1()
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

        /*
         * Satisfy second required Test case
         */
        [Test]
        public void CalculateTotalTest2()
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

        /*
         * Satisfy third required Test case
         */
        [Test]
        public void CalculateTotalTest3()
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
