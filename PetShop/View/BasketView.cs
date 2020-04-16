using System;
using ConsoleTables;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.View
{
    public class BasketView
    {
        public void printBasket()
        {
            
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string textShop = "Your basket!";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textShop.Length / 2)) + "}", textShop));
            Console.ForegroundColor = ConsoleColor.DarkGray;
            var printTable = new ConsoleTable("ProductName", "PriceProduct", "Quantity");
            
            printTable.Write();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
