using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* list ex. List<int> firstList = new List <int>();
  
            Console.WriteLine(firstlist.Count);


            firstlist.Add(1);
            firstlist.Add(2);
            firstlist.Add(3);
            firstlist.Add(4);

            //Checking whether 4 is present
            //in List or not
            Console.Write(firstlist.Contains(4));

*/
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Menu: ");

            Console.WriteLine("1. Display Rooms\n" +
                "2. Display Weapons\n" +
                "3. Display Potions\n" +
                "4. Display Treasure\n" +
                "5. Display Items\n" +
                "6. Display Mobs\n" +
                "7. Exit Adventure");

            string UserChoice = Console.ReadLine();
        }
    }
}
