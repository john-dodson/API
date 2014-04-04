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

        public VolumeDiscount(double price, int quantity) : base(DiscountType.Volume)
        {
            discountPrice = price;
            discountQuantity = quantity;
        }
    }
}
