using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
    /*
    * Enum of types of Discounts. Only Volume has been created because all test cases were Volume discounts
    */
    public enum DiscountType
    {
        Volume
    }

    public class Discount
    {
        /*
         * Creates a discount with a Type
         */
        public DiscountType discountType { get; set; }
        public Discount(DiscountType discount)
        {
            discountType = discount;
        }
    }
}
