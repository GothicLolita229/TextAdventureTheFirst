using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using VeldaniLibrary;

/**
* 2/26/2022
* CSC 153
* Lourdes Linares
* Text Adventure Version 3
*/

/*
 * In this iteration of the Text Adventure, you will be practicing and setting up for movement and combat in a larger game.
 * First, you will need to change the main menu to display the following:
 * 1.Move North
 * 2.Move South
 * 3.Attack
 * 4.Exit
 * Allow the user to make a choice. If they choose to move north the console will display the new room to the user in a 
 * numeric value starting at 1. If they choose south, then it will do the same thing however in reverse. Do not allow the 
 * location to drop below zero.
 * If they choose combat, then a random number from 1 to 20 should be taken away from a simulated Hit point count and then 
 * returned to display to the user.
 * To complete this part of the project you will need to use two “Void” methods and a “Value-Return” method. 
 * You will also need to use a few variables. Your methods will need to have parameters to accept arguments 
 * and they must be passed by reference.
 */

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
            #region MainMenuArray

            string charName = Player.PlayerInfo();
            char userChoice;
            //List<string> roomList = OptionsMenuClass.ListOption("rooms");
            Console.WriteLine("\n");
            Console.WriteLine("MAIN MENU: ");
            // TODO Display MainMenu();
            OptionsMenuClass.MainMenu();

            Console.WriteLine("\n");
            // Ask "Would you like to expand a category to see what's inside? Enter category name from menu: "
            // If user selects Rooms, display all rooms
            do
            {
                //Console.Write($"{charName}, would you like to expand a category to see what's inside? Enter numeric value from menu: ");
                Console.Write($"{charName}, enter numeric value from menu to select an option: ");
                userChoice = Console.ReadLine()[0];
                Console.WriteLine("\n");
                //Console.WriteLine($"Here are all the {userChoice} options: ");
                switch (userChoice)
                {
                    case '1':
                        /*MoverClass.CharMoveNorth(ref int roomLength, int locus, int numBumps);*/
                        MoverClass.MoveThroughRooms(OptionsMenuClass.ListOption("rooms"));
                        break;
                    case '2':
                        /*MoverClass.CharMoveSouth(ref int roomLength, int locus);*/
                        MoverClass.MoveThroughRooms(OptionsMenuClass.ListOption("rooms"));
                        //OptionsMenuClass.WeaponsOption(); // TEST; change to above ref afterwards
                        break;
                    case '3':
                        CombatClass.AttackPoints();
                        break;
                    case '4':
                        OptionsMenuClass.Exit();
                        break;
                    case '5':
                        OptionsMenuClass.ExploreMenu(userChoice);
                        break;
                    default:
                        Console.WriteLine("Not a valid option. Maybe check your case and spelling?");
                        break;
                }
            }
            while (userChoice != '4');

            Console.Write("Press enter to exit...");
            // Program ends
            Console.ReadLine();
            #endregion
        }
        // Maybe write an exit method? and ask "Are you sure?" once, then ask "Are you absolutely sure?" and if the answer to both is yes, the program quits
    }
}
