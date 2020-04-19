using System;
using System.Collections.Generic;
using Npgsql;
namespace PetShop.DAO
{
    public class CommonDAO
    {
        public static void ExecuteNonQuery(string sql)
        {
            using NpgsqlConnection connection = CreateNewConnection();
            connection.Open();

            using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }
        public static NpgsqlConnection CreateNewConnection()
        {
            string accessConnection = "Host=localhost;Username=nataliafilipek;Password=postgres;Database=petshop";
            NpgsqlConnection connection = new NpgsqlConnection(accessConnection);
            return connection;

        }
        public List<string> GetHeadersTables(string _tableName)
        {
            string sql = $"SELECT * FROM \"{_tableName}\" WHERE false";

            using NpgsqlConnection connection = CreateNewConnection();
            connection.Open();

            using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            using NpgsqlDataReader reader = command.ExecuteReader();
            int fieldCount = reader.FieldCount;

            List<string> row = new List<string>();
            for (int i = 0; i < fieldCount; i++)
            {
                row.Add(reader.GetName(i));
            }

            return row;
        }
    }
}
