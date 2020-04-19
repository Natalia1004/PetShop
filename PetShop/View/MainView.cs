using System;
using ConsoleTables;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.View

{
    public class MainView
    {

        public static void printWelcome()
        {
            Console.WriteLine("Hello in our shop. If you want to do some shopping you have to:");
            Console.WriteLine("1) Log in");
            Console.WriteLine("2) Create new account");
            Console.WriteLine("0) Leave the shop");
            Console.WriteLine("Your choice is:");

        }

        public static void printGoodbay()
        {
            Console.WriteLine("Thank you so much for your visting.");
            Console.WriteLine("Hope so next will be very soon!");
            Console.WriteLine("Goodbay");

        }

        public static void printMainPage()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string textShop = "Select one of the following!";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textShop.Length / 2)) + "}", textShop));
            Console.ForegroundColor = ConsoleColor.DarkGray;
            var printTable = new ConsoleTable("(1)Story shop", "(2)List of Products", "(3) Basket", "(4)Quit");
            printTable.Write();
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
