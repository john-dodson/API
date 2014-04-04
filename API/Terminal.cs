using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace API
{
    public class Terminal
    {
        private ItemCatalog _catalog;
        private Cart _cart;
        private DataTable _dt;

        public Terminal(DataTable data)
        {
            _cart = new Cart();
            _dt = data;
        }

        public void SetPrices()
        {
            _catalog = new ItemCatalog(_dt);
        }

        public void Scan(string name)
        {
            _cart.AddItem(_catalog.Get(name), 1);
        }

        public void ScanMultiple(string name, int quantity)
        {
            _cart.AddItem(_catalog.Get(name), quantity);
        }

        public double CalculateTotal()
        {
            return _cart.CalculateTotal();
        }

        public Cart GetCart()
        {
            return _cart;
        }

        public ItemCatalog GetItemCatalog()
        {
            return _catalog;
        }

        public DataTable GetData()
        {
            return _dt;
        }


    }
}
