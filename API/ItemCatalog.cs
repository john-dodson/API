using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data;

namespace API
{
    public class ItemCatalog
    {
        private Dictionary<string, Product> _products;
        public ItemCatalog(DataTable prods)
        {
            _products = new Dictionary<string, Product>();
            foreach (DataRow row in prods.Rows)
            {
                _products[(row["Name"]).ToString()] = new Product(row["Name"] as string, Convert.ToDouble(row["Price"]), Convert.ToDouble(row["DiscountPrice"]), Convert.ToInt32(row["DiscountQuantity"]));
            }
        }

        public Product Get(string name)
        {
            try
            {
                return _products[name] as Product;
            }
            catch (System.Collections.Generic.KeyNotFoundException ex)
            {
                throw new System.Collections.Generic.KeyNotFoundException("Invalid product name", ex);
            }
        }


    }
}
