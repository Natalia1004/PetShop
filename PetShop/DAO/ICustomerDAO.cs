using System;
using System.Collections.Generic;
using PetShop.Model;

namespace PetShop.DAO
{
    public interface ICustomerDAO
    {
        void CreateNewRow(Customer customer);
        List<Customer> GetAllRows();
        void UpdateRow(int id, string column, string value);
        void DeleteRow(int id);
       
    }
}
