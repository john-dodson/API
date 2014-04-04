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
    }
}
