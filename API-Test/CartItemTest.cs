using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using API;

namespace APITest
{
    [TestFixture]
    public class CartItemTest
    {
        private VolumeDiscount discount;
        private IEnumerable<Discount> discounts;

        [SetUp]
        public void Init()
        {
            discount = new VolumeDiscount(7.00, 4);
            discounts = new Discount[] { discount };
        }

        [Test]
        public void ConstructorTest()
        {
            var product = new Product("A", 2.00, discounts);
            var item = new CartItem(product.GetName(), product, 1);
            Assert.AreEqual(product.GetName(), item.GetName());
            Assert.AreEqual(product, item.GetProduct());
        }

        [Test]
        public void CalculatePriceTest1()
        {
            var product = new Product("A", 2.00);
            var item = new CartItem(product.GetName(), product, 1);
            Assert.AreEqual(2.00, item.CalculatePrice());
        }

        [Test]
        public void CalculatePriceTest2()
        {
            var product = new Product("A", 2.00, discounts);
            var item = new CartItem(product.GetName(), product, 3);
            Assert.AreEqual(6.00, item.CalculatePrice());
        }

        [Test]
        public void CalculatePriceTest3()
        {
            var product = new Product("A", 2.00, discounts);
            var item = new CartItem(product.GetName(), product, 4);
            Assert.AreEqual(7.00, item.CalculatePrice());
        }

        [Test]
        public void CalculatePriceTest4()
        {
            var product = new Product("A", 2.00, discounts);
            var item = new CartItem(product.GetName(), product, 5);
            Assert.AreEqual(9.00, item.CalculatePrice());
        }
    }
}
