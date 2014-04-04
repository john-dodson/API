using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
    public enum DiscountType
    {
        Volume
    }

    public class Discount
    {
        public DiscountType discountType { get; set; }
        public Discount(DiscountType discount)
        {
            discountType = discount;
        }
    }
}
