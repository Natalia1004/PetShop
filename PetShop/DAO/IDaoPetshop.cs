using System;
using System.Collections.Generic;


namespace PetShop.DAO
{
    public interface IDaoPetshop
    {
        void CreateNewRow(string _tableName, string[] values);
        void GetAllRows(string _tableName);
        void UpdateRow(string _tableName, int id, string column, string value);
        void DeleteRow(string _tableName, int id);
       
    }
}
