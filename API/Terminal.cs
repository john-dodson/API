using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
    public class Terminal
    {
        private ItemCatalog _catalog;
        private Hashtable _scanned;

        public Terminal(ItemCatalog catalog)
        {
            _scanned = new Hashtable();
            _catalog = catalog;
        }

        public void Scan(string name)
        {
            if (_scanned.ContainsKey(name))
            {
                var item = _scanned[name] as Product;
                item.count++;
                _scanned[name] = item;
            }
            else
            {
                _scanned[name] = _catalog.Get(name);
            }

        }

        public double CalculateTotal()
        {
            double total = 0;
            if (_scanned.Values.Count > 0)
            {
                foreach (Product prod in _scanned.Values)
                {
                    int quant = prod.count;
                    int dQuant = prod.GetDiscountQuantity();
                    if (quant > dQuant)
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
