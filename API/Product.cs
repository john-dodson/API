using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
    class Product
    {
        private string _name;
        private double _price;
        private double _discountPrice;
        private int _discountQuantity;
        public int count { get; set; }

        public Product(string name, double price, double discountPrice, int discountQuantity)
        {
            _name = name;
            _price = price;
            _discountPrice = discountPrice;
            _discountQuantity = discountQuantity;
            count = 0;
        }

        public string GetName()
        {
            return _name;
        }

        public double GetPrice()
        {
            return _price;
        }

        public double GetDiscountPrice()
        {
            return _discountPrice;
        }

        public int GetDiscountQuantity()
        {
            return _discountQuantity;
        }
    }
}
