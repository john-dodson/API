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
    public class CartTest
    {
        private Product product;
        private Product product2;
        private Product product3;
        private Product product4;
        private VolumeDiscount discount;
        private VolumeDiscount discount2;
        private IEnumerable<Discount> discounts;
        private IEnumerable<Discount> discounts2;
        private Cart cart;


        /*
         * Setup tests
         */
        [SetUp]
        public void Init()
        {
            discount = new VolumeDiscount(7.00, 4);
            discount2 = new VolumeDiscount(6.00, 6);
            discounts = new Discount[] { discount };
            discounts2 = new Discount[] { discount2 };
            product = new Product("A", 2.00, discounts);
            product2 = new Product("B", 12.00);
            product3 = new Product("C", 1.25, discounts2);
            product4 = new Product("D", 0.15);
            
        }
        /*
         * Test AddItem method
         */
        [Test]
        public void AddItemTest()
        {
            cart = new Cart();
            cart.AddItem(product, 1);
            Assert.AreEqual(cart.GetItem(product.GetName()).quantity, 1);
            Assert.AreEqual(cart.GetItem(product.GetName()).GetProduct(), product);
            Assert.AreEqual(cart.GetItem(product.GetName()).GetName(), product.GetName());
        }
        /*
         * Test adding another of same item
         */
        [Test]
        public void AddExistingItemTest()
        {
            cart = new Cart();
            cart.AddItem(product, 1);
            cart.AddItem(product, 1);
            Assert.AreEqual(cart.GetItem(product.GetName()).quantity, 2);
            Assert.AreEqual(cart.GetItem(product.GetName()).GetProduct(), product);
            Assert.AreEqual(cart.GetItem(product.GetName()).GetName(), product.GetName());
        }
        /*
         * Add two different items
         */
        [Test]
        public void AddMultipleItemsTest()
        {
            cart = new Cart();
            cart.AddItem(product, 1);
            cart.AddItem(product2, 1);
            Assert.AreEqual(cart.GetItem(product.GetName()).quantity, 1);
            Assert.AreEqual(cart.GetItem(product2.GetName()).quantity, 1);
            Assert.AreEqual(cart.GetItem(product.GetName()).GetProduct(), product);
            Assert.AreEqual(cart.GetItem(product2.GetName()).GetProduct(), product2);
            Assert.AreEqual(cart.GetItem(product.GetName()).GetName(), product.GetName());
            Assert.AreEqual(cart.GetItem(product2.GetName()).GetName(), product2.GetName());
        }
        /*
         * calculate price and discount for first required test case
         */
        [Test]
        public void CalculatePriceDiscountTest1()
        {
            cart = new Cart();
            cart.AddItem(product, 4);
            cart.AddItem(product2, 2);
            cart.AddItem(product3, 1);
            cart.AddItem(product4, 1);
            Assert.AreEqual(cart.CalculatePrice(), 33.40);
            Assert.AreEqual(cart.CalculateDiscount(), 1.00);
        }
        /*
         * calculate price and discount for second required test case
         */
        [Test]
        public void CalculatePriceDiscountTest2()
        {
            cart = new Cart();
            cart.AddItem(product3, 7);
            Assert.AreEqual(cart.CalculatePrice(), 8.75);
            Assert.AreEqual(cart.CalculateDiscount(), 1.50);
        }
        /*
         * calculate price and discount for third required test case
         */
        [Test]
        public void CalculatePriceDiscountTest3()
        {
            cart = new Cart();
            cart.AddItem(product, 1);
            cart.AddItem(product2, 1);
            cart.AddItem(product3, 1);
            cart.AddItem(product4, 1);
            Assert.AreEqual(cart.CalculatePrice(), 15.40);
            Assert.AreEqual(cart.CalculateDiscount(), 0.00);
        }
    }
}
