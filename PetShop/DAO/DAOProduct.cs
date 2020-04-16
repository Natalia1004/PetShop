using System;
using System.Collections.Generic;
using System.Configuration;
using Npgsql;


namespace PetShop.DAO
{
    public class DAOProduct : IDaoPetshop
    {

        private readonly string _tableName = "Product";


        public void CreateNewRow(string _tableName, string[] values)
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
                Console.WriteLine("{0} {1} {2} {3}", rdr.GetInt32(0), rdr.GetString(1),
                        rdr.GetInt32(2), rdr.GetInt32(3));
            }


        }

        public static List<List<string>> AllProducts(string sql, bool ifHeaders)
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
        public List<string> GetProductByID(int ID)
        {

            using NpgsqlConnection connection = CreateNewConnection();
            connection.Open();
            string sql = $"SELECT * FROM \"Product\" WHERE \"ProductID\" = {ID} ";
            using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            using NpgsqlDataReader reader = command.ExecuteReader();

            int fieldCount = reader.FieldCount;

            List<string> row = new List<string>();
            while (reader.Read())
            {
                for (int i = 0; i < fieldCount; i++)
                row.Add(reader[i].ToString());
            }
            return row;

        }



        public static List<string> GetHeadersTables(string _tableName)
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
            string sql = $"UPDATE \"{_tableName}\" SET \"{column}\" = \'{value}\' WHERE \"ProductID\" = {id}";
            ExecuteNonQuery(sql);
        }

        public void DeleteRow(string _tableName, int id)
        {
            string sql = $"DELETE FROM \"{_tableName}\" WHERE \"ProductID\" = {id}";
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
