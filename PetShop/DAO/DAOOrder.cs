using System;
using System.Collections.Generic;
using System.Configuration;
using Npgsql;
using PetShop.Model;


namespace PetShop.DAO
{
    public class DAOOrder : IOrderDAO
    {
        Order order;
        List<Order> OrdersList;

        public void CreateNewRow(Order order)
        {
            string sql = $"INSERT INTO \"Order\" (\"CustomerID\", \"LoginName\", \"ProductID\", \"TotalSum\") VALUES ({order.CustomerID},{order.ProductID}, {order.TotalSum})";
            CommonDAO.ExecuteNonQuery(sql);
        }

        public void DeleteRow(int id)
        {
            string sql = $"DELETE FROM \"Order\" WHERE \"OrderID\" = {id}";
            CommonDAO.ExecuteNonQuery(sql);
        }


        public void UpdateRow(int id, string column, string value)
        {
            string sql = $"UPDATE \"Order\" SET \"{column}\" = \'{value}\' WHERE \"OrderID\" = {id}";
            CommonDAO.ExecuteNonQuery(sql);
        }

        public List<Order> GetAllRows()
        {
            List<Order> dataAccount = new List<Order>();

            using NpgsqlConnection connection = CommonDAO.CreateNewConnection();
            connection.Open();

            string sql = $"SELECT * FROM \"Order\"";
            using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            using NpgsqlDataReader reader = command.ExecuteReader();

            int countOfData = reader.FieldCount;

            while (reader.Read())
            {
                Order order = new Order(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), Convert.ToString(reader[2]), Convert.ToInt32(reader[3]));
                dataAccount.Add(order);
            }

            return dataAccount;

        }


        public void printAllRows()
        {
            using NpgsqlConnection connection = CommonDAO.CreateNewConnection();
            connection.Open();
            string sql = $"SELECT * FROM \"Order\"";

            using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            using NpgsqlDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine("{0} {1} {2} {3} ", rdr.GetInt32(0), rdr.GetInt32(1),
                        rdr.GetString(2), rdr.GetInt32(3));
            }
        }
    }
}