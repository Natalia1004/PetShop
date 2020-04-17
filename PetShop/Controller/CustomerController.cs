using System;
using PetShop.View;
using PetShop.DAO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using PetShop.Model;

namespace PetShop.Controller
{
    public class CustomerController
    {
        DAOCustomer Customer = new DAOCustomer();


        public Customer CreateCustomer()
        {
            Customer customer = new Customer();
            customer.FirstName = saveDataCustomer("First Name");
            customer.LastName = saveDataCustomer("Last Name");
            customer.AddressStreet = saveDataCustomer("AddressStreet");
            customer.City = saveDataCustomer("City");
            customer.Country = saveDataCustomer("Country");
            customer.ZipCode = saveDataCustomer("ZipCode");
            return customer;
        }

        private string[] CreateRowCustomer(Customer customer)
        {
            string[] customerDetails = new string[6] {customer.FirstName,customer.LastName,
                                                      customer.AddressStreet, customer.City,
                                                        customer.Country, customer.ZipCode};
            return customerDetails;
        }

        private string saveDataCustomer(string data)
        {
            CustomerView.printNameColumn(data);
            string dataOfCustomer = Console.ReadLine();
            if (checkCorrectInput(dataOfCustomer, data) == false)
            {
                Console.WriteLine("Wrong input. Try again!");
                saveDataCustomer(data);
            }
            string dataToTableCustomer = "'" + dataOfCustomer + "'";
            return dataToTableCustomer;
        }
        private bool checkCorrectInput(string input, string data)
        {
            bool resultOfCorrectData = false;
            if (data == "AddressStreet" || data == "Country" || data == "City")
            {resultOfCorrectData = Regex.IsMatch(input, @"^[\p{L} ]+$"); }
            else if (data == "First Name" || data == "Last Name")
            {resultOfCorrectData = Regex.IsMatch(input, @"^[\p{L}]+$"); }
            else {resultOfCorrectData = Regex.IsMatch(input, @"^[0-9]+$"); };
            return resultOfCorrectData;
        }

        public void insertDataToCustomerTable()
        {
          
            Customer.CreateNewRow("Customer", CreateRowCustomer(CreateCustomer()));
        }

    }
}
