using System;
using System.Collections.Generic;
using Npgsql;



namespace PetShop.DAO
{
    public class DAOCAccount : IDaoPetshop
    {

        private readonly string _tableName = "Customer";


        public void CreateNewRow(string _tableName, string[] values)
        {
            string sql = $"INSERT INTO \"{_tableName}\" (\"CustomerID\", \"LoginName\", \"Password\", \"Email\") VALUES ({string.Join(',', values)})";
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
                Console.WriteLine("{0} {1} {2} {3} {4}", rdr.GetInt32(0), rdr.GetInt32(1),
                        rdr.GetString(2), rdr.GetString(3), rdr.GetString(4));
            }
        }

        public List<List<string>> AllCustomers(string sql, bool ifHeaders)
        {
            List<List<string>> data = new List<List<string>>();

            using NpgsqlConnection connection = CreateNewConnection();
            connection.Open();

            using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            using NpgsqlDataReader reader = command.ExecuteReader();

            int countOfData = reader.FieldCount;
            if (ifHeaders)
            {
                List<string> row = new List<string>();
                for (int i = 0; i < countOfData; i++)
                {
                    row.Add(reader.GetName(i));
                }
                data.Add(row);
            }

            while (reader.Read())
            {
                List<string> row = new List<string>();
                for (int i = 0; i < countOfData; i++)
                {
                    if (reader.GetPostgresType(i).Name == "integer")
                        row.Add($"{reader.GetInt32(i)}");
                    else if (reader.GetPostgresType(i).Name == "Date") row.Add($"{reader.GetDate(i)}");
                    else row.Add(reader.GetString(i));
                }
                data.Add(row);
            }
            return data;

        }

        public static int GetLastID(string tableName)
        {
            List<string> data = new List<string>();
            using NpgsqlConnection connection = CreateNewConnection();
            connection.Open();
            string sql = $"SELECT \"CustomerID\" FROM \"{tableName}\" ORDER BY \"CustomerID\" DESC";
            using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            using NpgsqlDataReader reader = command.ExecuteReader();
            
            reader.Read();
            return reader.GetInt32(0);
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




        public void UpdateRow(string _tableName, int id, string column, string value)
        {
            string sql = $"UPDATE \"{_tableName}\" SET \"{column}\" = \'{value}\' WHERE \"AccountID\" = {id}";
            ExecuteNonQuery(sql);
        }

        public void DeleteRow(string _tableName, int id)
        {
            string sql = $"DELETE FROM \"{_tableName}\" WHERE \"AccountID\" = {id}";
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
