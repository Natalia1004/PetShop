using System;
using System.Collections.Generic;
using System.Configuration;
using Npgsql;
using PetShop.Model;


namespace PetShop.DAO
{
    public class DAOProduct : IProductDAO
    {
        Product product;
        List<Product> productsList;

        public void CreateNewRow(Product product)
        {
            string sql = $"INSERT INTO \"Product\"(\"ProductName\", \"Quantity\", \"Price\") VALUES ({product.ProductName}, {product.Quantity}, {product.Price})";
            CommonDAO.ExecuteNonQuery(sql);
        }

        public void DeleteRow(int id)
        {
            string sql = $"DELETE FROM \"Product\" WHERE \"ProductID\" = {id}";
            CommonDAO.ExecuteNonQuery(sql);
        }


        public void UpdateRow(int id, string column, string value)
        {
            string sql = $"UPDATE \"Product\" SET \"{column}\" = \'{value}\' WHERE \"ProductID\" = {id}";
            CommonDAO.ExecuteNonQuery(sql);
        }

        public List<Product> GetAllRows()
        {
            List<Product> productList = new List<Product>();

            using NpgsqlConnection connection = CommonDAO.CreateNewConnection();
            connection.Open();
            
            string sql = $"SELECT * FROM \"Product\"";
            using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            using NpgsqlDataReader reader = command.ExecuteReader();

            int countOfData = reader.FieldCount;

            while (reader.Read())
            {
                Product product = new Product(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToInt32(reader[2]), Convert.ToInt32(reader[3]));
                productList.Add(product);
            }

            return productList;

        }


        public void printAllRows()
        {
            using NpgsqlConnection connection = CommonDAO.CreateNewConnection();
            connection.Open();
            string sql = $"SELECT * FROM \"Product\"";

            using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            using NpgsqlDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", rdr.GetInt32(0), rdr.GetString(1),
                        rdr.GetInt32(2), rdr.GetInt32(3));
            }
        }
    }


}
