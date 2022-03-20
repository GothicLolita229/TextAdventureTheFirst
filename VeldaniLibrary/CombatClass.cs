using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace VeldaniLibrary
{
    public class CombatClass
    {
        public static void AttackPoints()
        {
            var rand = new Random();
            Console.WriteLine("Enter action: (a) for attack or any other key to exit.");
            char userAction = Console.ReadLine()[0];
            do
            {
                Console.WriteLine("You are in a fight!");
                int hp = rand.Next(1, 20);
                Console.Write("You've taken " + hp + " points of damage");
                Console.WriteLine();
            }
            while (userAction != 'a');
        }
    }
}
