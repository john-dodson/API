using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
    public class Cart
    {
        private Dictionary<string, CartItem> _contents;

        /*
         * Creates a cart with an empty Dictioary of CartItems
         */
        public Cart()
        {
            _contents = new Dictionary<string, CartItem>();
        }

        /*
         * Adds a CartItem to the cart and sets the quanity of that CartItem
         */
        public void AddItem(Product product, int quantity)
        {
            if (_contents.ContainsKey(product.GetName()))
            {
                _contents[product.GetName()].quantity += quantity;
            }
            else
            {
                var item = new CartItem(product.GetName(), product, quantity);
                _contents[product.GetName()] = item;
            }
        }

        /*
         * Returns Dictionary of CartItems as the Cart contents
         */
        public Dictionary<string, CartItem> GetContents()
        {
            return _contents;
        }

        /*
         * Returns a CartItem by name
         */
        public CartItem GetItem(string name)
        {
            return _contents[name];
        }

        /*
         * Calculates the total price of the CartItems in the cart before any discounts are applied
         */
        public double CalculatePrice()
        {
            double price = 0;
            foreach (CartItem item in _contents.Values)
            {
                price += item.CalculatePrice();
            }
            return price;
        }

        /*
         * Calculates the total amount of discounts for the CartItems in the Cart. It's more efficient to calculate and apply discounts when 
         * calculating the price because you only need to iterate through the Cart once, but it is tightly coupled. I went with more of a Decorator
         * pattern because it is loosely coupled and most Carts display a total discount at the bottom.
         */
        public double CalculateDiscount()
        {
            double discount = 0;
            foreach (CartItem item in _contents.Values)
            {
                discount += item.CalculateDiscount();
            }
            return discount;
        }
    }
}
