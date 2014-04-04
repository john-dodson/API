using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
    public class CartItem
    {
        private string _name { get; set; }
        public int quantity { get; set; }
        private Product _product { get; set; }

        public CartItem(string productName, Product prod, int quant)
        {
            _name = productName;
            quantity = quant;
            _product = prod;
        }

        public string GetName()
        {
            return _name;
        }

        public Product GetProduct()
        {
            return _product;
        }

    
    }
}
