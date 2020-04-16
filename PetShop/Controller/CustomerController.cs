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



        private string[] CreateRowCustomer()
        {
            string[] detailsOfCustomer = new string[6];
            detailsOfCustomer[0] = saveDataCustomer("First Name");
            detailsOfCustomer[1] = saveDataCustomer("Last Name");
            detailsOfCustomer[2] = saveDataCustomer("AddressStreet");
            detailsOfCustomer[3] = saveDataCustomer("City");
            detailsOfCustomer[4] = saveDataCustomer("Country");
            detailsOfCustomer[5] = saveDataCustomer("ZipCode");
            return detailsOfCustomer;
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
            Customer.CreateNewRow("Customer", CreateRowCustomer());
        }

    }
}
