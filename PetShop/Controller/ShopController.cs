using System;
using System.Collections.Generic;
using PetShop.View;

namespace PetShop.Controller
{
    public class ShopController
    {
        public int Choice { get; set; }
        ProductController productController = new ProductController();
        ShopBasketController basket = new ShopBasketController();
        
        public ShopController(int choice)
        {
            Choice = choice;
        }
        
        public void switchChoiceInShop()
        {
            int choiceUser = ChoiceMainSection();

            while (choiceUser != 0)
            {

                if (choiceUser == 1)
                {
                    StoryView.StoryShop();
                    if (backToMenu() == "q")
                    {
                        break;
                    }

                }
                else if (choiceUser == 2)
                {
                    ShopCartView.printInventory();
                    if (backToMenu() == "q")
                    {
                        choiceUser = 0;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("If you want buy some product enter correct ProductName to add items to your basket");
                        int IdProduct = ProductController.GetIdPurchaseProduct();
                        if (productController.UpadateQuntityProductDatabase(IdProduct) == false)
                        {
                            continue;
                        }
                        else
                        {
                            basket.addProductToBasket(IdProduct);
                            break;
                        }
                    }

                }
                else if(choiceUser ==3)
                {
                    basket.printBasket();
                }
                
                else if (choiceUser == 4)
                {
                    break;
                }

                continue;
            }
            
        }

        private int ChoiceMainSection()
        {

            Console.WriteLine("Your choice: ");
            Choice = 0;
            List<int> ValidAnswers = new List<int>() {1, 2, 3, 4};
            while (!ValidAnswers.Contains(Choice))
                try
                {
                    Choice = int.Parse(Console.ReadLine());
                    if (!ValidAnswers.Contains(Choice)) throw new ArgumentException();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong input.Please enter a value '1', '2', '3' or '4'.");

                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Please enter number from range 1-4");
                }
            return Choice;
        }
        private string backToMenu()
        {
            Console.Write("\nIf you want back to Main menu enter 'q'");
            string back = Console.ReadLine();
            return back;
        }

   
    }
}
