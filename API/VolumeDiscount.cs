using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
    public class VolumeDiscount : Discount
    {
        public int discountQuantity { get; set; }
        public double discountPrice { get; set; }

        /*
         * Creates a VolumeDiscount with a bulk price, minimum quantity to receive that bulk price, and a DiscountType of Volume, inherits Discount
         */
        public VolumeDiscount(double price, int quantity) : base(DiscountType.Volume)
        {
            discountPrice = price;
            discountQuantity = quantity;
        }
    }
}
