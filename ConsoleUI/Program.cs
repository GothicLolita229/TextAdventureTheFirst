using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

/**
* 2/26/2022
* CSC 153
* Lourdes Linares
* Text Adventure Version 2
*/

/*
 * In this iteration of the Text Adventure, you will use what you learned about
 * reading and writing files.
 * After this project, there should no longer be any information hardcoded into your 
 * program. You will need to create a text file that holds all the information. 
 * You may do this in a CSV file or any format you wish. 
 * When the Game starts it should load all the information. Then allow the user 
 * to create a player that will then be written to a file with the player’s name.
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

            List<string> menuList = new List<string>();

            StreamReader inputfile;

            try
            {
                inputfile = File.OpenText("optionsMenu.txt");

                while (inputfile.EndOfStream == false)
                {
                    menuList.Add(inputfile.ReadLine());
                }

                inputfile.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

            string[] menuArray = menuList.ToArray();

            foreach (var menuItem in menuArray)
            {
                Console.WriteLine(menuItem);
            }

            Console.WriteLine("\n");

            // Ask "Would you like to expand a category to see what's inside? Enter category name from menu: "
            // If user selects Rooms, display all rooms

            do
            {

                Console.Write($"{charName}, would you like to expand a category to see what's inside? Enter category name from menu: ");

                userChoice = Console.ReadLine();
                Console.WriteLine("\n");
                Console.WriteLine($"Here are all the {userChoice} options: ");

                if (userChoice == "Rooms")
                {

                    RoomOption();
                }
                else if (userChoice == "Weapons")
                {
                    WeaponsOption();
                }
                else if (userChoice == "Potions")
                {
                    PotionsOption();
                }
                else if (userChoice == "Treasure")
                {
                    TreasureOption();
                }
                else if (userChoice == "Items")
                {
                    ItemsListOption();
                }
                else if (userChoice == "Mobs")
                {
                    MobsListOption();
                }
                else if (userChoice == "Exit")
                {
                    Exit();
                }
                else
                {
                    Console.WriteLine("Not a valid option. Maybe check your case and spelling?");
                }
            }
            while (userChoice != "Exit");

            Console.Write("Press enter to exit...");
            // Program ends
            Console.ReadLine();

            # region CommentsofThingsMightAdd

            #endregion

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

        
        static void RoomOption() 
        {


            List<string> roomList = new List<string>();

            StreamReader inputfile;

            //TODO: Tried to call it only to get the charName but it runs the entire method so figure this out 
            //string charName = PlayerInfo();

            try
            {
                inputfile = File.OpenText("rooms.txt");

                while (inputfile.EndOfStream == false)
                {
                    roomList.Add(inputfile.ReadLine());
                }

                inputfile.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

            string[] roomArray = roomList.ToArray();
            string[] sortedRoomArray = roomList.ToArray();

            int locus = 0;
            string mover;
            int numBumps = 0;
            

            #region displayRoomMenuAlpha
            //puts room options in alphabetical order
            Array.Sort(sortedRoomArray);
            foreach (var sortedRoom in sortedRoomArray)
            {
                Console.WriteLine(sortedRoom);
            }
            #endregion


            Console.WriteLine("You are at the Entrance of the abandoned castle.");
            #region moveThroughRooms
            do
            {
                var currentRoom = roomArray[0];
                Console.WriteLine("Would you like to go North (n) or South (s) or Exit?");
                
                mover = Console.ReadLine();


                if (mover == "n")
                {
                    locus += 1;
                    // loop through, take user input (n or s), and move through rooms up and down the array

                    //TRY PUTTING THIS HERE SO IT EXITS PROGRAM AFTER USER DIES
                    //currentRoom = roomArray[locus];
                    //Console.WriteLine($"You are in the {currentRoom}.");

                    if (locus > roomArray.Length - 1)
                    {
                        // if user selects this option 5 times, Tell them they are kaput and exit the program
                        //wrap around
                        locus = roomArray.Length - 1;

                        numBumps += 1;
                        if (numBumps == 1)
                        {
                            Console.WriteLine("Please stop banging your head on the dungeon wall. You must turn around and go back because this is the end.");
                        }
                        else if (numBumps == 2)
                        {
                            Console.WriteLine("Seriously. Stop. You will DIE!");
                        }
                        else
                        {
                            Console.WriteLine("You dead, Mr. Adventure Guy. Back to the beginning.");
                            Console.ReadLine();
                            Exit();
                            // write and call an exitMethod(); maybe or just figure out some way to have the character respawn back to the main menu
                        }


                    }
                    // MOVED THIS UP BEFORE TWO NESTED IFS
                    currentRoom = roomArray[locus];
                    Console.WriteLine($"You are in the {currentRoom}.");

                }
                else if (mover == "s")
                {
                    locus -= 1;
                    if (locus < 0)
                    {
                        //wrap around
                        locus = 0;
                        Console.WriteLine("You'll stay here until you move in another direction.");
                    }
                    // loop through, take user input (n or s), and move through rooms up and down the array
                    currentRoom = roomArray[locus];
                    Console.WriteLine($"You are in the {currentRoom}.");
                }
                else if (mover == "Exit")
                {
                    Console.Clear();
                    MainMenu();
                }
                else
                {
                    Console.WriteLine("Invalid entry. Please enter (n) or (s) or Exit");
                }
            }
            while (locus < 5);
            #endregion
        }

        #region stuffThatsNotRooms
        static void WeaponsOption() 
        {
            // Battle Axe has slash damage of 1d20
            // Crossbow, piercing, 1d10 damage
            // Stiletto, piercing, 1d10 damage
            // Long Spear, impaling, 1d20 damage


            List<string> weaponList = new List<string>();

            StreamReader inputfile;

            try
            {
                inputfile = File.OpenText("weapons.txt");

                while (inputfile.EndOfStream == false)
                {
                    weaponList.Add(inputfile.ReadLine());
                }

                inputfile.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

            string[] weaponArray = weaponList.ToArray();

            Array.Sort(weaponArray);

            foreach (var weapon in weaponArray)
            {
                Console.WriteLine(weapon);
            }
        }

        static void PotionsOption() 
        {

            List<string> potionList = new List<string>();

            StreamReader inputfile;

            try
            {
                inputfile = File.OpenText("potions.txt");

                while (inputfile.EndOfStream == false)
                {
                    potionList.Add(inputfile.ReadLine());
                }

                inputfile.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

            string[] potionArray = potionList.ToArray();

            Array.Sort(potionArray);

            foreach (var potion in potionArray)
            {
                Console.WriteLine(potion);
            }
        }

        static void TreasureOption() 
        {

            List<string> treasureList = new List<string>();

            StreamReader inputfile;

            try
            {
                inputfile = File.OpenText("treasure.txt");

                while (inputfile.EndOfStream == false)
                {

                    treasureList.Add(inputfile.ReadLine());

                }
                inputfile.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

            string[] treasureArray = treasureList.ToArray();

            Array.Sort(treasureArray);

            foreach (var treasure in treasureArray)
            {
                Console.WriteLine(treasure);
            }
        }

        
        #region LISTS
        // LISTS
        static void ItemsListOption() 
        {

            List<string> itemList = new List<string>();

            StreamReader inputfile;

            try
            {
                inputfile = File.OpenText("items.txt");

                while (inputfile.EndOfStream == false)
                {

                    itemList.Add(inputfile.ReadLine());
                }
                inputfile.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            
            itemList.Sort();

            foreach (var item in itemList)
            {
                Console.WriteLine(item);
            }
        }

        static void MobsListOption() 
        {

            List<string> mobsList = new List<string>();

            StreamReader inputfile;

            try
            {
                inputfile = File.OpenText("mobs.txt");

                while (inputfile.EndOfStream == false)
                {

                    mobsList.Add(inputfile.ReadLine());
                }
                inputfile.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

            mobsList.Sort();

            foreach (var mob in mobsList)
            {
                Console.WriteLine(mob);
            }
        }

        #endregion

        static void Exit()
        {
            Environment.Exit(0);
        }

        // Maybe write an exit method? and ask "Are you sure?" once, then ask "Are you absolutely sure?" and if the answer to both is yes, the program quits
        #endregion

        

    }
}
