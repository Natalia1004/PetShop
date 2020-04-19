using System;
namespace PetShop.Model
{
    public class Product
    {
       
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        
       
        public Product(int productID, string name, int quantity, int price)
        {
            ProductID = productID;
            ProductName = name;
            Quantity = quantity;
            Price = price;
            
        }
    }
}
