using System;
using System.Collections.Generic;
using System.Configuration;
using Npgsql;
using System.Data;
using PetShop.Model;


namespace PetShop.DAO
{
    public class DAOCustomer : ICustomerDAO
    {

        Customer customer;
        List<Customer> CustomerList;

        public void CreateNewRow(Customer customer)
        {
            string sql = $"INSERT INTO \"Customer\" (\"FirstName\", \"LastName\", \"AddressStreet\", \"City\", \"Country\", \"ZipCode\") VALUES ({customer.FirstName},{customer.LastName}, {customer.AddressStreet}, {customer.City}, {customer.Country}, {customer.ZipCode})";
            CommonDAO.ExecuteNonQuery(sql);
        }

        public void DeleteRow(int id)
        {
            string sql = $"DELETE FROM \"Customer\" WHERE \"CustomerID\" = {id}";
            CommonDAO.ExecuteNonQuery(sql);
        }


        public void UpdateRow(int id, string column, string value)
        {
            string sql = $"UPDATE \"Customer\" SET \"{column}\" = \'{value}\' WHERE \"Customer\" = {id}";
            CommonDAO.ExecuteNonQuery(sql);
        }

        public List<Customer> GetAllRows()
        {
            List<Customer> dataCustomer = new List<Customer>();

            using NpgsqlConnection connection = CommonDAO.CreateNewConnection();
            connection.Open();
            
            string sql = $"SELECT * FROM \"Customer\"";
            using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            using NpgsqlDataReader reader = command.ExecuteReader();

            

            while (reader.Read())
            {
                Customer customer = new Customer(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToString(reader[3]), Convert.ToString(reader[4]), Convert.ToString(reader[5]), Convert.ToString(reader[6]));
                dataCustomer.Add(customer);
            }
             

            return dataCustomer;

        }


        public void printAllRows()
        {
            using NpgsqlConnection connection = CommonDAO.CreateNewConnection();
            connection.Open();
            string sql = $"SELECT * FROM \"Customer\"";

            using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            using NpgsqlDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", rdr.GetInt32(0), rdr.GetInt32(1),
                        rdr.GetString(2), rdr.GetString(3), rdr.GetString(4));
            }
        }



    }


}
