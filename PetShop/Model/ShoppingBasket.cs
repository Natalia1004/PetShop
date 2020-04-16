using System;
using System.Collections.Generic;
using PetShop.Controller;


namespace PetShop.Model
{
    public class ShoppingBasket
    {
        public string ProductName { get; set; }
        public int PriceProduct { get; set; }
        public int Quantity { get; set; }
        public ShoppingBasket()
        {
            ProductName = this.ProductName;
            PriceProduct = this.PriceProduct;
            Quantity = this.Quantity;
        }

    }
}
