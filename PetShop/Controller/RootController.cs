using System;
using PetShop.Model;
using PetShop.DAO;
using System.Collections.Generic;
using System.Text;
using PetShop.View;
using System.Enum;

namespace PetShop.Controller
    {
        public class RootController
        {
           
            public Customer customer;
            public static void Run()
            {
                CustomerController CustomerCon = new CustomerController();
                AccountController AccountCon = new AccountController();
                
                MainView.printWelcome();
               
                Priority priority = ChoiceUser();
                switch (priority)
                {
                case priority.LogIn:
                    {
                        Console.WriteLine("Hello");
                        break;
                    }
                case priority.CreateNewAccount:
                    {
                        CustomerCon.insertDataToCustomerTable();
                        AccountCon.insertDataToAccountTable();
                        MainView.printWelcome();
                        priority = ChoiceUser();
                        continue;
                    }
                case priority.Quit:
                    {
                        MainView.printGoodbay();
                        break;
                    }
                }
            }

            private static int ChoiceUser()
            {
                int answer = Convert.INT32(Console.ReadLine());

                List<int> ValidAnswers = new List<int>() { 0,1,2 };
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
            
            Enum priority
            {
                LogIn,
                CreateNewAccount,
                Quit
            };
        }
    }


