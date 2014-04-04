using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
    public class Cart
    {
        private Dictionary<string, CartItem> _contents;

        public Cart()
        {
            _contents = new Dictionary<string, CartItem>();
        }

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

        public Dictionary<string, CartItem> GetContents()
        {
            return _contents;
        }

        public CartItem GetItem(string name)
        {
            return _contents[name];
        }

        public double CalculateTotal()
        {
            double total = 0;
            foreach (CartItem item in _contents.Values)
            {
                total += item.GetProduct().GetPrice() * item.quantity;
            }
            return total;
        }

        public double CalculateDiscount()
        {
            double discount = 0;
            foreach (CartItem item in _contents.Values)
            {
                var product = item.GetProduct();
                var quantity = item.quantity;
                if (product.GetDiscounts() != null)
                {
                    foreach (Discount d in product.GetDiscounts())
                    {
                        double dprice = 0;
                        if (d.discountType == DiscountType.Volume)
                        {
                            var volume = d as VolumeDiscount;
                            int dQuant = volume.discountQuantity;
                            if ((quantity >= dQuant))
                            {
                                double extra = (quantity % dQuant) * product.GetPrice();
                                double dis = (quantity / dQuant) * volume.discountPrice;
                                dprice += extra;
                                dprice += discount;
                                discount += (product.GetPrice() * quantity) - dprice;
                            }
                        }
                    }
                }
            }
            return discount;
        }
    }
}
