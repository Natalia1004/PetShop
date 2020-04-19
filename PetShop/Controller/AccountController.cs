using System;
using System.Collections.Generic;
using PetShop.Model;
using PetShop.View;
using PetShop.DAO;
using System.Security;
using System.Text;
using Npgsql;
using System.Net.Mail;

namespace PetShop.Controller

{
    public class AccountController
    {
        DAOAccount Account = new DAOAccount();
        Customer customer;

        public void insertDataToAccountTable()
        {

            try
            {
                Account.CreateNewRow(CreateNewAccount());
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine("Something wrong maybe Login or Email exist. Try again!");
                insertDataToAccountTable();
            }
        }

        private Account CreateNewAccount()
        {
            int CustomerID = Account.GetLastID();
            string Login = saveDataAccountLogin("Login");
            string Password = saveDataAccountPassword("Password");
            string Email = saveDataAccountEmail("Email");
            Account account = new Account(0, CustomerID, Login, Password, Email);
            return account;
        }

        private string saveDataAccountLogin(string data)
        {
            AccountView.printAccountDetails(data);
            string dataAccount = Console.ReadLine();
            string dataToTableAccount = "'" + dataAccount + "'";
            return dataToTableAccount;
        }
        private string saveDataAccountPassword(string data)
        {
            AccountView.printAccountDetails(data);
            String stringPassword = new System.Net.NetworkCredential(string.Empty, GetPassword()).Password;
            Console.Write("\n");
            string dataToTableAccount = "'" + stringPassword + "'";
            return dataToTableAccount;
        }

        private string saveDataAccountEmail(string data)
        {
            AccountView.printAccountDetails(data);
            string dataAccount = Console.ReadLine();
            if (IsEmailValid(dataAccount) == false)
            {
                saveDataAccountEmail(data);
            }

            string dataToTableAccount = "'" + dataAccount + "'";
            return dataToTableAccount;
        }

        public void LogIn()
        {
            AccountView.printAccountDetails("Login: ");
            string UserName = Console.ReadLine();

            AccountView.printAccountDetails("Password: ");
            string password = new System.Net.NetworkCredential(string.Empty, GetPassword()).Password;

            int CustomerID = DAOAccount.GetCustomerID(UserName, password);

            if (CustomerID == 0)
            {
                Console.WriteLine("\nTry again because Login or Password is wrong!");
                Console.WriteLine("Create new acconunt if you don't have.");
                LogIn();
            }
            else
            {
                string CustomerName = customer.FirstName;
                Console.Write("\n");
                Console.WriteLine($"\nHello {CustomerName} in our shop. Now You may buy want You need :)\n");
            }

        }
        

        private SecureString GetPassword()
        {
            var pwd = new SecureString();
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd.RemoveAt(pwd.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (i.KeyChar != '\u0000')
                {
                    pwd.AppendChar(i.KeyChar);
                    Console.Write("*");
                }
            }
            return pwd;
        }
        private bool IsEmailValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }


    }
}
