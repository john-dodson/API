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

        /*
         * Create cart item with it's name, the product it refers to, and the quantity
         */
        public CartItem(string productName, Product prod, int quant)
        {
            _name = productName;
            quantity = quant;
            _product = prod;
        }

        /*
         * Return CartItem Name
         */
        public string GetName()
        {
            return _name;
        }

        /*
         * Return CartItem product
         */
        public Product GetProduct()
        {
            return _product;
        }

        /*
         * Calculate total price of CartItem before discounts are applied
         */
        public double CalculatePrice()
        {
            return quantity * _product.GetPrice();
        }

        /*
         * Calculate total discount for CartItem, only Volume discounts are implemented because all required test cases were volume discounts
         */
        public double CalculateDiscount()
        {
            double discount = 0;
            foreach (Discount d in _product.GetDiscounts())
            {
                if (d.discountType == DiscountType.Volume)
                {
                    var volD = d as VolumeDiscount;
                    if (quantity >= volD.discountQuantity)
                    {
                        double discountRate = ((volD.discountQuantity * _product.GetPrice()) - volD.discountPrice);
                        double discountsToApply = (quantity / volD.discountQuantity);
                        discount += (discountRate * discountsToApply);
                    }
                }
            }
            return discount;
        }

    
    }
}
