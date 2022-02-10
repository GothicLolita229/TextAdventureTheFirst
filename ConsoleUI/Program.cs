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
        static void RoomOption() 
        {
            string[] roomArray = new string[] { "Entrance", "Foyer", "Great Hall", "Corridor", "Dungeon" };

            Array.Sort(roomArray);

            foreach (var room in roomArray)
            {
                Console.WriteLine(room);
            }
        }

        static void WeaponsOption() 
        {
            string[] weaponArray = new string[] { "Battle Axe", "Crossbow", "Stiletto", "Long Spear" };

            Array.Sort(weaponArray);

            foreach (var weapon in weaponArray)
            {
                Console.WriteLine(weapon);
            }
        }

        static void PotionsOption() 
        {
            string[] potionArray = new string[] { "Elixir of Health", "Oil of Sharpness" };

            Array.Sort(potionArray);

            foreach (var potion in potionArray)
            {
                Console.WriteLine(potion);
            }
        }

        static void TreasureOption() 
        {
            string[] treasureArray = new string[] { "Amulet of Proof against Detection and Location", "Gem of Brightness", "Orb of Dragonkind" };

            Array.Sort(treasureArray);

            foreach (var treasure in treasureArray)
            {
                Console.WriteLine(treasure);
            }
        }

        // lists
        static void ItemsListOption() 
        {
            List<string> itemList = new List<string> { "Abacus", "Bag of Holding", "Vial", "Tinderbox" };

            itemList.Sort();

            foreach (var item in itemList)
            {
                Console.WriteLine(item);
            }
        }

        static void MobsListOption() 
        {
            List<string> mobsList = new List<string> { "Humans", "Zombies", "Rats", "Goblins", "Five Points Gang" };

            mobsList.Sort();

            foreach (var mob in mobsList)
            {
                Console.WriteLine(mob);
            }
        }

        static void Main(string[] args)
        {
            #region MainMenuArray
            Console.WriteLine("Main Menu: ");

            // array
            string[] menuArray = new string[] { "Rooms", "Weapons", "Potions", "Treasure", "Items", "Mobs", "Exit"};
            
            foreach(var menuItem in menuArray)
            {
                Console.WriteLine(menuItem);
            }

            string UserChoice = Console.ReadLine();
            #endregion

        }
    }
}
