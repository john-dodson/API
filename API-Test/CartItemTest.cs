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

        /*
         * Setup tests
         */
        [SetUp]
        public void Init()
        {
            discount = new VolumeDiscount(7.00, 4);
            discounts = new Discount[] { discount };
        }

        /*
         * Test CartItemConstructor
         */
        [Test]
        public void ConstructorTest()
        {
            var product = new Product("A", 2.00, discounts);
            var item = new CartItem(product.GetName(), product, 1);
            Assert.AreEqual(product.GetName(), item.GetName());
            Assert.AreEqual(product, item.GetProduct());
        }

        /*
         * Test calculating item price for multiple quantities of items
         */
        [Test]
        public void CalculatePriceTest()
        {
            var product = new Product("A", 2.00, discounts);
            var item = new CartItem(product.GetName(), product, 1);
            var item2 = new CartItem(product.GetName(), product, 2);
            Assert.AreEqual(item.CalculatePrice(), 2.00);
            Assert.AreEqual(item2.CalculatePrice(), 4.00);
        }

        /*
         * Test calculating discounts for multiple quantities of items
         */
        [Test]
        public void CalculateDiscountTest()
        {
            var product = new Product("A", 2.00, discounts);
            var item = new CartItem(product.GetName(), product, 4);
            var item2 = new CartItem(product.GetName(), product, 5);
            var item3 = new CartItem(product.GetName(), product, 10);
            Assert.AreEqual(item.CalculateDiscount(), 1.00);
            Assert.AreEqual(item2.CalculateDiscount(), 1.00);
            Assert.AreEqual(item3.CalculateDiscount(), 2.00);
        }
    }
}
