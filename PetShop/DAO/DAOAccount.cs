using System;
using System.Collections.Generic;
using Npgsql;
using PetShop.Model;



namespace PetShop.DAO
{
    public class DAOAccount : IAccountDAO
    {
        Account account;
        List<Account> accountList;

        public void CreateNewRow(Account account)
        {
            string sql = $"INSERT INTO \"Account\" (\"CustomerID\", \"LoginName\", \"Password\", \"Email\") VALUES ({account.CustomerID},{account.Login}, {account.Password}, {account.Email})";
            CommonDAO.ExecuteNonQuery(sql);
        }

        public void DeleteRow(int id)
        {
            string sql = $"DELETE FROM \"Account\" WHERE \"AccountID\" = {id}";
            CommonDAO.ExecuteNonQuery(sql);
        }
        

        public void UpdateRow( int id, string column, string value)
        {
            string sql = $"UPDATE \"Account\" SET \"{column}\" = \'{value}\' WHERE \"AccountID\" = {id}";
            CommonDAO.ExecuteNonQuery(sql);
        }

        public List<Account> GetAllRows()
        {
            List<Account> dataAccount = new List<Account>();

            using NpgsqlConnection connection = CommonDAO.CreateNewConnection();
            connection.Open();
            //prepared statement 
            string sql = $"SELECT * FROM \"Account\"";
            using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            using NpgsqlDataReader reader = command.ExecuteReader();

            int countOfData = reader.FieldCount;

            while (reader.Read())
            {
                Account account = new Account(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), Convert.ToString(reader[2]), Convert.ToString(reader[3]), Convert.ToString(reader[4]));
                dataAccount.Add(account);
            }
            
            return dataAccount;

        }


        public void printAllRows()
        {
            using NpgsqlConnection connection = CommonDAO.CreateNewConnection();
            connection.Open();
            string sql = $"SELECT * FROM \"Account\"";

            using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            using NpgsqlDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", rdr.GetInt32(0), rdr.GetInt32(1),
                        rdr.GetString(2), rdr.GetString(3), rdr.GetString(4));
            }
        }

        

        public int GetLastID()
        {
            
            using NpgsqlConnection connection = CommonDAO.CreateNewConnection();
            connection.Open();
            string sql = $"SELECT \"CustomerID\" FROM \"Customer\" ORDER BY \"CustomerID\" DESC";
            using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            using NpgsqlDataReader reader = command.ExecuteReader();
            
            reader.Read();
            return reader.GetInt32(0);
        }

        public static int GetCustomerID(string UserName, string password)
        {
            using NpgsqlConnection connection = CommonDAO.CreateNewConnection();
            connection.Open();
            string sql = $"SELECT \"CustomerID\" FROM \"Account\" WHERE \"LoginName\" LIKE \'{UserName}\' AND \"Password\" LIKE \'{password}\'";
            using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            Int32 reader = Convert.ToInt32(command.ExecuteScalar());

            return reader;
        }
        public string returnCustomerName(int CustomerID)
        {
            using NpgsqlConnection connection = CommonDAO.CreateNewConnection();
            connection.Open();
            string sql = $"SELECT \"FirstName\" FROM \"Customer\" WHERE \"CustomerID\" = {CustomerID}";
            using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            using NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();

            return reader.GetString(0);
        }


    }


}
