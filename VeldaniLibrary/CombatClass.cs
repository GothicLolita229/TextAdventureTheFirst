using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeldaniLibrary
{
    public class CombatClass
    {
        public static void AttackPoints()
        {
            var rand = new Random();

            Console.WriteLine("You are in a fight!");
            Console.Write("You've taken ", rand.Next(1, 20), "points of damage");
            Console.WriteLine();
        }
    }
}
