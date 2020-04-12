using System;
using PetShop.View;
using PetShop.DAO;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Controller
{
    public class CustomerController
    {
        DAOCustomer Customer = new DAOCustomer();

        private string[] saveDataCustomer()
        {
            string[] detailsOfCustomer = new string[6];

            CustomerView.printFirstName();
            string FirstName = Console.ReadLine();
            detailsOfCustomer[0] = "'" + FirstName + "'";

            CustomerView.printLastName();
            string LastName = Console.ReadLine();
            detailsOfCustomer[1] = "'" + LastName + "'";

            CustomerView.printAddressStreet();
            string AddressStreet = Console.ReadLine();
            detailsOfCustomer[2] = "'" + AddressStreet + "'";

            CustomerView.printCity();
            string City = Console.ReadLine();
            detailsOfCustomer[3] = "'" + City + "'";

            CustomerView.printCountry();
            string Country = Console.ReadLine();
            detailsOfCustomer[4] = "'" + Country + "'";

            CustomerView.printZipCode();
            string ZipCode = Console.ReadLine();
            detailsOfCustomer[5] = "'" + ZipCode + "'";

            return detailsOfCustomer;
        }

        public void insertDataToCustomerTable()
        {
            Customer.CreateNewRow("Customer", saveDataCustomer());
        }

    }
}
