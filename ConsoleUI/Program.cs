using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using VeldaniLibrary;

/**
* 4/11/2022
* CSC 153
* Lourdes Linares
* Text Adventure Version 4
*/
/**
 * The Player should now be able to move North, East, South, or West in your game. 
 * They should be able to pick up and drop items in the room. 
 * There should be a combat system in place so that the player can fight Mobs.
 **/


namespace ConsoleUI
{
    class Program
    {
        // globally initialize roomArray
        static void Main(string[] args)
        {
            //string charName = PlayerInfo();
            MainMenu();
        }
        static void MainMenu()
        {
            int currentLocation = 0 ;
            int startHp = 100;
            int newHp = 0;
            int damage = 0;
            //List<string> roomList = LoopClass.ListFileReader("rooms.txt");
            List<string> roomStrList = LoopClass.ListFileReader("rooms.txt");
            List<Room> roomList = new List<Room>();
            int idNum = 0;
            foreach (var roomName in roomStrList)
            {
                Room myRoom = new Room();
                myRoom.Name = roomName;
                myRoom.IdNumber = idNum;
                myRoom.Description = "Description";
                idNum++;
                roomList.Add(myRoom);
            }

            #region MainMenuArray
            string charName = LoadPlayer.PlayerInfo();
            char userChoice;
           
            //List<string> roomList = OptionsMenuClass.ListOption("rooms");
            Console.WriteLine("\nMAIN MENU: \n");
            do
            {
                OptionsMenuClass.MainMenu();
                //Console.Write($"{charName}, would you like to expand a category to see what's inside? Enter numeric value from menu: ");
                Console.Write($"{charName}, enter numeric value from menu to select an option: ");
                userChoice = Console.ReadLine()[0];
                //menuOption = Console.ReadLine()[0];
                Console.WriteLine("\n");
                //Console.WriteLine($"Here are all the {userChoice} options: ");
                Room thisRoom = roomList[currentLocation];
                // Print out our current location
                Console.WriteLine($"You are in {thisRoom.Name} ( {thisRoom.IdNumber} )");
                Console.WriteLine(thisRoom.Description);
                // TODO Move entire switch statement to something like a command class
                switch (userChoice)
                {
                    case '1':
                        currentLocation = MoverClass.CharMoveNorth(ref currentLocation);
                        //Console.WriteLine($"You are in {thisRoom.Name} {thisRoom.IdNumber}");
                        if (currentLocation > roomList.Count - 1)
                        {
                            Console.WriteLine("Please stop banging your head on the dungeon wall. " +
                                "You must turn around and go back because this is the end.");
                        }
                        break;
                    case '2':
                        currentLocation = MoverClass.CharMoveSouth(ref currentLocation);
                        //Console.WriteLine($"You are in {thisRoom.Name} {thisRoom.IdNumber}");
                        if (currentLocation <= 0) 
                        {
                            Console.WriteLine("You'll stay here until you move in another direction.");
                        }
                        break;
                    case '3':
                        currentLocation = MoverClass.CharMoveEast(ref currentLocation);
                        //Console.WriteLine($"You are in {thisRoom.Name} {thisRoom.IdNumber}");
                        if (currentLocation <= 0)
                        {
                            Console.WriteLine("You'll stay here until you move in another direction.");
                        }
                        break;
                    case '4':
                        currentLocation = MoverClass.CharMoveWest(ref currentLocation);
                        //Console.WriteLine($"You are in {thisRoom.Name} {thisRoom.IdNumber}");
                        if (currentLocation <= 0)
                        {
                            Console.WriteLine("You'll stay here until you move in another direction.");
                        }
                        break;
                    case '5':
                        // TODO Move entire to combat Class method and then just call method here
                        if (startHp >= 1)
                        {
                            Console.WriteLine("You are in a fight!");
                            //Console.WriteLine("Enter action: (a) for attack or any other key to exit.");
                            damage = CombatClass.AttackPoints();
                            Console.WriteLine($"You've taken {damage} points of damage");
                            newHp = CombatClass.CalcHealth(ref startHp, damage);
                            Console.WriteLine($"Your hp is at {newHp}\n");
                        }
                        else 
                        {
                            Console.WriteLine("You are dead.");
                        }
                        break;
                    case '6':
                        OptionsMenuClass.Exit();
                        break;
                    case '7':
                        Console.WriteLine("Debug Menu");
                        char menuOption = Console.ReadLine()[0];
                        OptionsMenuClass.ExploreMenu(menuOption);
                        break;
                    default:
                        Console.WriteLine("Not a valid option. Maybe check your case and spelling?");
                        break;
                }
            }
            while (userChoice != '6');
            Console.Write("Press enter to exit...");
            // Program ends
            Console.ReadLine();
            #endregion
        }
        // Maybe write an exit method? and ask "Are you sure?" once, then ask "Are you absolutely sure?" and if the answer to both is yes, the program quits
    }
}
