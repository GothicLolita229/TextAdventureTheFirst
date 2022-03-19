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
 * 
 */

namespace ConsoleUI
{
    class Program
    {
        //StreamWriter outputfile; -- not working as global object
        //StreamReader inputfile; -- not working as global object
        
        static void Main(string[] args)
        {
            //string charName = PlayerInfo();
            MainMenu();
        }
        static void MainMenu()
        {
            #region MainMenuArray

            string charName = PlayerInfo();
            string userChoice;
            Console.WriteLine("\n");
            Console.WriteLine("MAIN MENU: ");

            // TODO Display MainMenu();

            Console.WriteLine("\n");

            // Ask "Would you like to expand a category to see what's inside? Enter category name from menu: "
            // If user selects Rooms, display all rooms

            do
            {

                //Console.Write($"{charName}, would you like to expand a category to see what's inside? Enter numeric value from menu: ");
                Console.Write($"{charName}, enter numeric value from menu to select an option: ");
                userChoice = Console.ReadLine();
                Console.WriteLine("\n");
                //Console.WriteLine($"Here are all the {userChoice} options: ");

                switch (userChoice)
                {
                    case "1":
                        /*MoverClass.CharMoveNorth(ref int roomLength, int locus, int numBumps);*/
                        OptionMethods.RoomOption();
                        break;
                    case "2":
                        /*MoverClass.CharMoveSouth(ref int roomLength, int locus);*/
                        OptionMethods.WeaponsOption(); // TEST; change to abovde ref afterwards
                        break;
                    case "3":
                        CombatClass.AttackPoints();
                        break;
                    case "4":
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Not a valid option. Maybe check your case and spelling?");
                        break;
                }
                
            }
            while (userChoice != "4");

            Console.Write("Press enter to exit...");
            // Program ends
            Console.ReadLine();
            #endregion
        }
        #region player Information
        static string PlayerInfo() 
        {
            string username;
            Console.Write("Please enter your username: ");
            username = Console.ReadLine();
            
            // does file with username.txt exist?
            string charName = "";
            try
            {
                if (File.Exists(username + ".txt"))
                {
                    charName = ReturnPlayer(username);
                }
                else
                {
                    charName = NewPlayer(username);
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error checking file...");
            }
            return charName;
        }
        static string NewPlayer(string username) 
        {
            // make file with username as name
            StreamWriter outputfile; //-- declare as global object to use for other methods
            // variable called characters
            string charName;
            try
            {
                outputfile = File.CreateText(username + ".txt");
                Console.WriteLine($"Welcome, {username}!");
                Console.WriteLine("Let's create a character for you...");
                //for some reason have to close file and then open again to append text
                outputfile.Close();
                try
                {
                    outputfile = File.AppendText(username + ".txt");
                    // ask user what to name char
                    Console.WriteLine("What would you like to name your character?");
                    charName = Console.ReadLine();
                    outputfile.WriteLine(charName);
                    outputfile.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error making character...");
                throw;
            }
            //outputfile.Close();
            return charName;
        }
        static string ReturnPlayer(string username) 
        {
            // get input from file with playername.txt
            StreamReader inputfile; //declare as global object to use for other methods
            string charName;

            inputfile = File.OpenText(username + ".txt");
            charName = inputfile.ReadLine();
            Console.WriteLine($"Welcome back, {username}!");

            inputfile.Close();
            return charName;
        }
        #endregion
        
        
        
        static void Exit()
        {
            Environment.Exit(0);
        }
        // Maybe write an exit method? and ask "Are you sure?" once, then ask "Are you absolutely sure?" and if the answer to both is yes, the program quits
        

    }
}
