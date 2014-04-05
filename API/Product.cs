using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
    public class Product
    {
        private string _name;
        private double _price;
        private IEnumerable<Discount> _discounts;

        /*
         * Creates a Product with a name, a price, and an empty Array of Discounts
         */
        public Product(string name, double price)
        {
            _name = name;
            _price = price;
            _discounts = new Discount[] { };
        }

        /*
         * Creates a Product with a name, price, and a collection of Discounts
         */
        public Product(string name, double price, IEnumerable<Discount> discounts)
        {
            _name = name;
            _price = price;
            _discounts = discounts;
        }

        /*
         * Returns the Product name
         */
        public string GetName()
        {
            return _name;
        }

        /*
         * Returns the Product price
         */
        public double GetPrice()
        {
            return _price;
        }

        /*
         * Returns an enumerable collection of the Product's Discounts
         */
        public IEnumerable<Discount> GetDiscounts()
        {
            return _discounts;
        }
    }
}
