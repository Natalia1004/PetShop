using System;
using PetShop.Model;
using System.Collections.Generic;
using PetShop.DAO;
namespace PetShop.Controller
{
    public class OrderController
    {
        private Order NewOrder = new Order();
        public Customer customer = new Customer();
        
        public ShoppingBasket basket = new ShoppingBasket();
        public ShopBasketController basketCon = new ShopBasketController();
        public List<ShoppingBasket> shoppingBasket = new List<ShoppingBasket>();
        DAOOrder Orders = new DAOOrder();

        public Order CreateNewOrder()
        {
            NewOrder.CustomerID = customer.CustomerID;
            NewOrder.ProductID = basket.ProductID;
            NewOrder.TotalSumOrder = basketCon.TotalPrice(shoppingBasket);

            return NewOrder;
        }

        public string[] convertOrderOnArray(Order order)
        {
            string[] orderDetails = new string[3] { Convert.ToString(order.CustomerID), Convert.ToString(order.ProductID), Convert.ToString(order.TotalSumOrder)};

            return orderDetails;
        }
        public void AddOrderToDatabase()
        {
            Orders.CreateNewRow("Order", convertOrderOnArray(CreateNewOrder()));
        }
    }
}
