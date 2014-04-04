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
                if (row["Discounts"].GetType() != typeof(System.DBNull))
                {
                    _products[(row["Name"]).ToString()] = new Product(row["Name"] as string, Convert.ToDouble(row["Price"]), (Discount[])row["Discounts"]);
                }
                else
                {
                    _products[(row["Name"]).ToString()] = new Product(row["Name"] as string, Convert.ToDouble(row["Price"]));
                }
            }
        }

        public int GetCount()
        {
            return _products.Count();
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
