using System;
using PetShop.DAO;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DAOCustomer some = new DAOCustomer();
            string[] values = new string[]{"3","\'Kamila\'","\'Kowalska\'","\'Staopolska\'","\'Warszawa\'","\'Polska\'","\'23876\'"};
            some.UpdateRow("Customer", 2, "LastName", "Gola");
            some.GetAllRows("Customer");


        }
    }
}
