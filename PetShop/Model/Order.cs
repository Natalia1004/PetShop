using System;
namespace PetShop.Model
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string ProductID { get; set; }
        public int TotalSum { get; set; }
        
        public Order(int orderID, int customerID, string productID, int totalSumOrder)
        {
            OrderID = orderID;
            CustomerID = customerID;
            ProductID = productID;
            TotalSum = totalSumOrder;
        }
    }
}
