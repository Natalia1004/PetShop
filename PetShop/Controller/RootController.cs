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
            string choice = ChoiceUser();
            while (choice != "0")
            {

                if (choice == "1")
                {
                    ShopCartView.printInventory();
                    break;
                }
                else if (choice == "2")
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
