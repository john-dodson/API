using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
    public class Terminal
    {
        public ItemCatalog catalog;
        public Dictionary<string, Product> scanned;

        public Terminal(ItemCatalog cat)
        {
            scanned = new Dictionary<string, Product>();
            catalog = cat;
        }

        public void Scan(string name)
        {
            if (scanned.ContainsKey(name))
            {
                var item = scanned[name] as Product;
                item.count++;
                scanned[name] = item;
            }
            else
            {
                var prod = catalog.Get(name);
                prod.count++;
                scanned[name] = prod;
            }

        }

        public double CalculateTotal()
        {
            double total = 0;
            if (scanned.Values.Count > 0)
            {
                foreach (Product prod in scanned.Values)
                {
                    int quant = prod.count;
                    int dQuant = prod.GetDiscountQuantity();
                    if ((quant >= dQuant) && dQuant != 0)
                    {
                        double extra = (quant % dQuant) * prod.GetPrice();
                        double discount = (quant / dQuant) * prod.GetDiscountPrice();
                        total += extra;
                        total += discount;
                    }
                    else
                    {
                        total += (prod.count * prod.GetPrice());
                    }
                }
            }
            return total;
        }


    }
}
