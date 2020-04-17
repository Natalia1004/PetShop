using System;
using PetShop.Model;
using PetShop.DAO;
using PetShop.Controller;
using System.Collections.Generic;

namespace PetShop.Controller
{
    public class ShopBasketController
    {
        
        List<ShoppingBasket> basket = new List<ShoppingBasket>();
        DAOProduct productFromDB = new DAOProduct();

        public List<ShoppingBasket> addProductToBasket(int Id)
        {
            ShoppingBasket Basket = new ShoppingBasket();
            List<string> purchaseProdcut = productFromDB.GetProductByID(Id);
            Product product = new Product(Convert.ToInt32(purchaseProdcut[0]), purchaseProdcut[1], Convert.ToInt32(purchaseProdcut[2]), Convert.ToInt32(purchaseProdcut[3]));
            Basket.ProductName = product.ProductName;
            Basket.PriceProduct = product.Price;
            Basket.Quantity = 1;
            basket.Add(Basket);

            return basket;
            
        }

        public void printBasket()
        {
            foreach(ShoppingBasket row in basket)
            {
                Console.WriteLine(row);
            }
        }


        public ShoppingBasket removeProductToBasket(int Id)
        {
            ShoppingBasket Basket = new ShoppingBasket();
            Product product = new Product(1, "Proszek", 23, 2);
            Basket.ProductName = product.ProductName;
            Basket.PriceProduct = product.Price;
            Basket.Quantity = Basket.Quantity - product.Quantity;
            
            return Basket;

        }
        
    }
}
