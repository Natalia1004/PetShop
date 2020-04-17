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

        public void insertDataToAccountTable()
        {

            try
            {
                Account.CreateNewRow("Account", CreateRowAccount(CreateNewAccount()));
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine("Something wrong maybe Login or Email exist. Try again!");
                insertDataToAccountTable();
            }
        }

        private Account CreateNewAccount()
        {
            Account account = new Account();
            
            account.CustomerID = DAOAccount.GetLastID("Customer");
            account.Login = saveDataAccountLogin("Login");
            account.Password = saveDataAccountPassword("Password");
            account.Email = saveDataAccountEmail("Email");

            return account;
        }

        private string [] CreateRowAccount(Account account)
        {
            string[] detailsOfAccount = new string[4] {Convert.ToString(account.CustomerID), account.Login,
                                                        account.Password, account.Email};
            return detailsOfAccount;
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
                string CustomerName = returnCustomerName(CustomerID);
                Console.Write("\n");
                Console.WriteLine($"\nHello {CustomerName} in our shop. Now You may buy want You need :)\n");
            }

        }
        private static string returnCustomerName(int CustomerID)
        {
            using NpgsqlConnection connection = DAOAccount.CreateNewConnection();
            connection.Open();
            string sql = $"SELECT \"FirstName\" FROM \"Customer\" WHERE \"CustomerID\" = {CustomerID}";
            using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            using NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();

            return reader.GetString(0);
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
 