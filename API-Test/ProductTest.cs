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
            var a = new Product("A", 2.00, 7.00, 4);
            Assert.AreEqual(a.GetName(), "A");
            Assert.AreEqual(a.GetPrice(), 2.00);
            Assert.AreEqual(a.GetDiscountPrice(), 7.00);
            Assert.AreEqual(a.GetDiscountQuantity(), 4);
        }
    }
}
