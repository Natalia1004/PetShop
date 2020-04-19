using System;
using System.Collections.Generic;
using PetShop.Model;

namespace PetShop.DAO
{
    public interface IOrderDAO
    {
        void CreateNewRow(Order order);
        List<Order> GetAllRows();
        void UpdateRow(int id, string column, string value);
        void DeleteRow(int id);
       
    }
}
