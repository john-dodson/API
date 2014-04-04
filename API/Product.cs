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

        public Product(string name, double price)
        {
            _name = name;
            _price = price;
        }

        public Product(string name, double price, IEnumerable<Discount> discounts)
        {
            _name = name;
            _price = price;
            _discounts = discounts;
        }

        public string GetName()
        {
            return _name;
        }

        public double GetPrice()
        {
            return _price;
        }

        public IEnumerable<Discount> GetDiscounts()
        {
            return _discounts;
        }
    }
}
