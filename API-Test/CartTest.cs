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
        private Cart cart;

        [SetUp]
        public void Init()
        {
            product = new Product("A", 7.00);
            product2 = new Product("B", 6.00);
            
        }

        [Test]
        public void AddItemTest()
        {
            cart = new Cart();
            cart.AddItem(product, 1);
            Assert.AreEqual(cart.GetItem(product.GetName()).quantity, 1);
            Assert.AreEqual(cart.GetItem(product.GetName()).GetProduct(), product);
            Assert.AreEqual(cart.GetItem(product.GetName()).GetName(), product.GetName());
        }

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
    }
}
