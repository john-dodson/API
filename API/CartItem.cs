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

        public double CalculatePrice()
        {
            double price = 0;
            if (_product.GetDiscounts() != null)
            {
                foreach (Discount d in _product.GetDiscounts())
                {
                    if (d.discountType == DiscountType.Volume)
                    {
                        var volume = d as VolumeDiscount;
                        int dQuant = volume.discountQuantity;
                        if ((quantity >= dQuant))
                        {
                            double extra = (quantity % dQuant) * _product.GetPrice();
                            double discount = (quantity / dQuant) * volume.discountPrice;
                            price += extra;
                            price += discount;
                        }
                        else
                        {
                            price += (quantity * _product.GetPrice());
                        }
                    }
                }
            }
            else
            {
                price += (quantity * _product.GetPrice());
            }
            return price;
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
