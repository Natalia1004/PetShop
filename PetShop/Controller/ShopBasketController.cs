using System;
using PetShop.Model;
using PetShop.DAO;
using PetShop.Controller;
using System.Collections.Generic;
using ConsoleTables;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Controller
{
    public class ShopBasketController
    {
        
        List<ShoppingBasket> basket = new List<ShoppingBasket>();
        DAOProduct productFromDB = new DAOProduct();

        public List<ShoppingBasket> AddProductToBasket(int Id)
        {
            ShoppingBasket Basket = new ShoppingBasket();
            List<string> purchaseProdcut = productFromDB.GetProductByID(Id);
            Product product = new Product(Convert.ToInt32(purchaseProdcut[0]), purchaseProdcut[1], Convert.ToInt32(purchaseProdcut[2]), Convert.ToInt32(purchaseProdcut[3]));
            Basket.ProductName = product.ProductName;
            Basket.PriceProduct = product.Price;
            Basket.Quantity = 1;

            if (checkEmptyBasket(basket) == true || checkExistProductInBasket(basket, Basket) == false)
            {
                basket.Add(Basket);
                return basket;
            }
            else
            {
                foreach(ShoppingBasket row in basket)
                {
                    if (Basket.ProductName == row.ProductName)
                    {
                        row.Quantity = row.Quantity + 1;
                        return basket;
                    }
                }
            }
            return basket;

        }

        private bool checkEmptyBasket(List<ShoppingBasket> basket)
        {
            if (basket.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool checkExistProductInBasket(List<ShoppingBasket> basket, ShoppingBasket Basket)
        {
            bool exist = false;
            foreach(ShoppingBasket item in basket)
            {
                if(item.ProductName == Basket.ProductName)
                {
                    exist = true;
                }
            }
            return exist;
        }


        public void printBasket()
        {

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string textShop = "Your basket!";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textShop.Length / 2)) + "}", textShop));
            Console.ForegroundColor = ConsoleColor.DarkGray;
            var printTable = new ConsoleTable("ProductName", "PriceProduct", "Quantity");
            foreach(ShoppingBasket row in basket)
            {
                printTable.AddRow(row.ProductName, row.PriceProduct, row.Quantity);
            }
            printTable.Write();
            Console.ForegroundColor = ConsoleColor.White;
        }


        private List<ShoppingBasket> removeProductToBasket(string nameProductToRemove, List<ShoppingBasket> basket)
        {

            foreach (ShoppingBasket row in basket)
            {

                if (row.ProductName == nameProductToRemove && row.Quantity == 1)
                {
                    basket.Remove(row);
                }
                else if (row.ProductName == nameProductToRemove && row.Quantity > 1)
                {
                    row.Quantity = row.Quantity - 1;
                }
                
            }
            
            return basket;

        }
        public void startRemoveProduct(string nameProductToRemove)
        {
            removeProductToBasket(nameProductToRemove, basket);
        }
        
        
    }
}
