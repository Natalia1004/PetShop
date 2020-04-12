using System;
using PetShop.View;
using System.Collections.Generic;
using PetShop.DAO;

namespace PetShop.Controller
{
    public class RootController
    {
        public static void Run()
        {
            CustomerController CustomerCon = new CustomerController();
            AccountController AccountCon = new AccountController();

            ViewMain.printWelcome();

            while (ChoiceUser() != "0")
            {

                if (ChoiceUser() == "1")
                {

                    Console.WriteLine("nothing");
                }
                else
                {
                    CustomerCon.insertDataToCustomerTable();
                    AccountCon.insertDataToAccountTable();
                    break;
                }
            }
            ViewMain.printGoodbay();


        }

        private static string ChoiceUser()
        {
            string answer = Console.ReadLine();
            return answer;
        }
    }
}
