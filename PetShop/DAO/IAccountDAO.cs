using System;
using System.Collections.Generic;
using PetShop.Model;

namespace PetShop.DAO
{
    public interface IAccountDAO
    {
        void CreateNewRow(Account account);
        List<Account> GetAllRows();
        void UpdateRow(int id, string column, string value);
        void DeleteRow(int id);
       
    }
}
