using System;
using System.Collections.Generic;
using PetShop.Model;
using PetShop.View;
using PetShop.DAO;
using System.Security;
using System.Text;

namespace PetShop.Controller

{
    public class AccountController
    {
        DAOCAccount Account = new DAOCAccount();

            private string[] saveDataAccount()
            {
                string[] detailsOfAccount = new string[4];

                detailsOfAccount[0] = DAOCAccount.GetLastID("Customer").ToString();

                AccountView.printUserLogin();
                string UserName = Console.ReadLine();
                detailsOfAccount[1] = "'" + UserName + "'";

                AccountView.printPassword();
                String stringPassword = new System.Net.NetworkCredential(string.Empty, GetPassword()).Password;
                detailsOfAccount[2] = "'" + stringPassword + "'";
                Console.WriteLine("");

                AccountView.printEmail();
                string Email = Console.ReadLine();
                detailsOfAccount[3] = "'" + Email + "'";

                return detailsOfAccount;
            }

            public void insertDataToAccountTable()
            {
                Account.CreateNewRow("Account", saveDataAccount());
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

    }
}
 