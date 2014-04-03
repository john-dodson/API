using System;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data;

namespace API
{
    class ItemCatalog
    {
        private Hashtable _products;
        public ItemCatalog(DataTable prods)
        {
            foreach (DataRow row in prods.Rows)
            {
                _products[row["Name"]] = new Product(row["Name"] as string, (double)row["Price"], (double)row["DiscountPrice"], (int)row["DiscountQuantity"]);
            }
        }

        public Product Get(string name)
        {
            try
            {
                return _products[name] as Product;
            }
            catch (System.IndexOutOfRangeException ex)
            {
                throw new System.ArgumentException("Invalid product name", "index", ex);
            }
        }


    }
}
