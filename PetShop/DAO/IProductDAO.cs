using System;
using System.Collections.Generic;
using PetShop.Model;

namespace PetShop.DAO
{
    public interface IProductDAO
    {
        void CreateNewRow(Product product);
        List<Product> GetAllRows();
        void UpdateRow(int id, string column, string value);
        void DeleteRow(int id);
       
    }
}
