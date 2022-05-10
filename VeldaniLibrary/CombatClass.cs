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
        // TODO Move to Console UI
        public static int Hp = 100;
        //public static int newHp = 0;
        public static int damage = 0;
        public static int AttackPoints()
        {
            Random rand = new Random();
            //char userAction;
            
            damage = rand.Next(1, 20);
            /*do
            {
                //userAction = Console.ReadLine()[0];
            }
            while (userAction != 'a');*/
            return damage;
        }
        public static int CalcHealth(ref int Hp, int damage)
        {
            Hp = Hp - damage;
            return Hp;
        }
    }
}
