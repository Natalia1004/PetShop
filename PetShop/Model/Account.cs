using System;

namespace PetShop.Model
{
    public class Account
    {
        public int AccountID { get; set; }
        public int CustomerID{ get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public Account(int accountID, int customerID, string login, string password, string email)
        {
            AccountID = accountID;
            CustomerID = customerID;
            Login = login;
            Password = password;
            Email = email;
        }
    }

}
