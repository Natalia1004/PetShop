using System;
using PetShop.Model;
using PetShop.DAO;
using System.Collections.Generic;

namespace PetShop.Controller
{
    public class ProductController
    {
        DAOProduct productFromDB = new DAOProduct();

        public bool UpadateQuntityProductDatabase(int productID)
        {
            List<string> purchaseProdcut = productFromDB.GetProductByID(productID);
            Product product = new Product(Convert.ToInt32(purchaseProdcut[0]), purchaseProdcut[1], Convert.ToInt32(purchaseProdcut[2]), Convert.ToInt32(purchaseProdcut[3]));

            if (product.Quantity > 0)
            { 
                string newQuantity = Convert.ToString(product.Quantity - 1);
                productFromDB.UpdateRow("Product", productID, "Quantity", newQuantity);
                return true;
            }
            else
            {
                Console.WriteLine("You can't buy this product because sold out");
                return false;
            }  
        }

        public static int GetIdPurchaseProduct()
        {
            int purchaseProduct = Convert.ToInt32(Console.ReadLine());
            return purchaseProduct;
        }
    }
}
