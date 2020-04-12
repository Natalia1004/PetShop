using System;
using ConsoleTables;
using System.Linq;
using PetShop.DAO;
using System.Collections.Generic;

namespace PetShop.View
{
    public class ShopCartView
    {
        public static void printInventory()
        {
            string sql = $"SELECT * FROM \"Product\"";
            var table = DAOProduct.AllProducts(sql, false);
            var printTable = new ConsoleTable("ProductID", "ProductName", "Quantity", "Price");

            foreach (List<string> list in table)
            {
                printTable.AddRow(list[0], list[1], list[2], list[3]);
            }
            printTable.Write();
        }

    }
}
