using System;
using System.Collections.Generic;
using System.Configuration;
using Npgsql;


namespace PetShop.DAO
{
    public class DAOCustomer : IDaoPetshop
    {
        
        private readonly string _tableName = "Customer";

       
        public  void CreateNewRow(string _tableName, string[] values)
        {
            string sql = $"INSERT INTO \"{_tableName}\" VALUES ({string.Join(',', values)})";
            ExecuteNonQuery(sql);
        }

        public void GetAllRows(string _tableName)
        {
            using NpgsqlConnection connection = CreateNewConnection();
            connection.Open();
            string sql = $"SELECT * FROM \"{_tableName}\"";
           
            using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            using NpgsqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", rdr.GetInt32(0), rdr.GetString(1),
                        rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6));
            }
            

        }
        public void UpdateRow(string _tableName, int id, string column, string value)
        {
            string sql = $"UPDATE \"{_tableName}\" SET \"{column}\" = \'{value}\' WHERE \"CustomerID\" = {id}";
            ExecuteNonQuery(sql);
        }

        public void DeleteRow(string _tableName, int id)
        {
            string sql = $"DELETE FROM \"{_tableName}\" WHERE \"CustomerID\" = {id}";
            ExecuteNonQuery(sql);
        }

        private static void ExecuteNonQuery(string sql)
        {
            using NpgsqlConnection connection = CreateNewConnection();
            connection.Open();

            using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }
        private static NpgsqlConnection CreateNewConnection()
        {
            string accessConnection = "Host=localhost;Username=nataliafilipek;Password=postgres;Database=petshop";
            NpgsqlConnection connection = new NpgsqlConnection(accessConnection);
            return connection;

        }


    }


       
 

}
