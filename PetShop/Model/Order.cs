using System;
namespace PetShop.Model
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public DateTime ShipDate { get; set; }
        public int TotalSumOrder { get; set; }
        public int Quantity { get; set; }

        public Order(int orderID, int customerID, int productID, DateTime shipDate, int totalPrice, int quantity)
        {
            OrderID = orderID;
            CustomerID = customerID;
            ProductID = productID;
            ShipDate = shipDate;
            TotalSumOrder = totalPrice;
            Quantity = quantity;

        }
        
    }
}
