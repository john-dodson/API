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

        /*
         * Creates a terminal with a new Cart and DataTable of product data
         */
        public Terminal(DataTable data)
        {
            _cart = new Cart();
            _dt = data;
        }

        /*
         * Turn product data into an ItemCatalog
         */
        public void SetPrices()
        {
            _catalog = new ItemCatalog(_dt);
        }

        /*
         * Scan an object
         */
        public void Scan(string name)
        {
            _cart.AddItem(_catalog.Get(name), 1);
        }

        /*
         * Scan an object in bulk
         */
        public void ScanMultiple(string name, int quantity)
        {
            _cart.AddItem(_catalog.Get(name), quantity);
        }

        /*
         * Calculate the total price of scanned items
         */
        public double CalculateTotal()
        {
            return _cart.CalculatePrice() - _cart.CalculateDiscount();
        }

        /*
         * Return the cart
         */
        public Cart GetCart()
        {
            return _cart;
        }

        /*
         * Return the ItemCatalog
         */
        public ItemCatalog GetItemCatalog()
        {
            return _catalog;
        }

        /*
         * Return the product DataTable
         */
        public DataTable GetData()
        {
            return _dt;
        }


    }
}
