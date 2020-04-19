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

        public DAOCustomer CustomerConn = new DAOCustomer();


        public Customer CreateCustomer()
        {
            string FirstName = saveDataCustomer("First Name");
            string LastName = saveDataCustomer("Last Name");
            string AddressStreet = saveDataCustomer("AddressStreet");
            string City = saveDataCustomer("City");
            string Country = saveDataCustomer("Country");
            string ZipCode = saveDataCustomer("ZipCode");
            Customer customer = new Customer(0, FirstName, LastName, AddressStreet, City, Country, ZipCode);

            return customer;
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
            { resultOfCorrectData = Regex.IsMatch(input, @"^[\p{L} ]+$"); }
            else if (data == "First Name" || data == "Last Name")
            { resultOfCorrectData = Regex.IsMatch(input, @"^[\p{L}]+$"); }
            else { resultOfCorrectData = Regex.IsMatch(input, @"^[0-9]+$"); };
            return resultOfCorrectData;
        }

        public void insertDataToCustomerTable()
        {

            CustomerConn.CreateNewRow(CreateCustomer());
        }

    }
}
