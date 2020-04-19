using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Model
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressStreet { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public Customer(int customerID, string firstName, string lastName, string addressStreet, string city, string country, string zipCode)
        {
            CustomerID = customerID;
            FirstName = firstName;
            LastName = lastName;
            AddressStreet = addressStreet;
            City = city;
            Country = country;
            ZipCode = zipCode;
        }
    }
}
