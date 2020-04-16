using System;
namespace PetShop.Model
{
    public class Product
    {
       
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
       

        public Product(int productID, string productName, int quantity, int price)
        {
            ProductID = productID;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }
    }
}
