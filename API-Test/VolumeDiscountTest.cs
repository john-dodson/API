using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using API;

namespace APITest
{
    [TestFixture]
    public class VolumeDiscountTest
    {
        /*
         * Test class constructor
         */
        [Test]
        public void ConstructorTest()
        {
            var volume = new VolumeDiscount(7.00, 4);
            Assert.AreEqual(volume.discountPrice, 7.00);
            Assert.AreEqual(volume.discountQuantity, 4);
            Assert.AreEqual(volume.discountType, DiscountType.Volume);
        }
    }
}
