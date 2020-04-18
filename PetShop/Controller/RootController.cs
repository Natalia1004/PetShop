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
            ShopController Shop = new ShopController(0);

            MainView.printWelcome();
            string choice = ChoiceUser();
            while (choice != "0")
            {

                if (choice == "1")
                {
                    AccountCon.LogIn();
                    
                    while (Shop.Choice != 3)
                    { 
                        MainView.printMainPage();
                        Shop.switchChoiceInShop();
                    }
                    break;
                    
                }
                else if (choice == "2")
                {
                    CustomerCon.insertDataToCustomerTable();
                    AccountCon.insertDataToAccountTable();
                    MainView.printWelcome();
                    choice = ChoiceUser();
                }
                
            }
            MainView.printGoodbay();


        }

        private static string ChoiceUser()
        {
            string answer = Console.ReadLine();

            List<string> ValidAnswers = new List<string>() { "1", "2", "0" };
            while (!ValidAnswers.Contains(answer))
                try
                {
                    answer = Console.ReadLine();
                    if (!ValidAnswers.Contains(answer)) throw new ArgumentException();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong input.Please enter a value '1', '2' or '0'.");

                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Please enter number from range 0-2");
                }
            return answer;
        }
    }
}
