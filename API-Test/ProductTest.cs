using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using API;

namespace APITest
{
    [TestFixture]
    public class ProductTest
    {
        [Test]
        public void ConstructorTest()
        {
            var discount = new VolumeDiscount(7.00, 4);
            var discounts = new Discount[] { discount };

            var a = new Product("A", 2.00, discounts);
            Assert.AreEqual(a.GetName(), "A");
            Assert.AreEqual(a.GetPrice(), 2.00);
            Assert.AreEqual(a.GetDiscounts(), discounts);
        }

        [Test]
        public void NoDiscountTest()
        {

            var a = new Product("A", 2.00);
            Assert.AreEqual(a.GetName(), "A");
            Assert.AreEqual(a.GetPrice(), 2.00);
            Assert.AreEqual(a.GetDiscounts(), null);
        }
    }
}
