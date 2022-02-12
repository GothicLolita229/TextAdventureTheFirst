using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
* 2/11/2022
* CSC 153
* Lourdes Linares
* Text Adventure Version 1
*/



namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {

            #region MainMenuArray

            string userChoice;
            Console.WriteLine("\n");
            Console.WriteLine("MAIN MENU: ");

            // array
            string[] menuArray = new string[] { "Rooms", "Weapons", "Potions", "Treasure", "Items", "Mobs", "Exit" };

            foreach (var menuItem in menuArray)
            {
                Console.WriteLine(menuItem);
            }

            // Ask "Would you like to expand a category to see what's inside? Enter category name from menu: "
            // If user selects Rooms, display all rooms

            do
            {

                Console.Write("Would you like to expand a category to see what's inside? Enter category name from menu: ");

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

            // loop through menuArray to select one option that links to an individual array or list
            // Maybe use a for loop? or a do-while loop?
            /* Do While Loop
             * int count = 0;
             * do
             * {
             *      Console.WriteLine(count);
             *      count++;
             * }
             * while(count < 5);
             * 
             */
            #endregion

            #endregion

        }

        static void RoomOption() 
        {
            string[] roomArray = new string[] { "Entrance", "Foyer", "Great Hall", "Corridor", "Dungeon" };
            string[] sortedRoomArray = new string[] { "Entrance", "Foyer", "Great Hall", "Corridor", "Dungeon" };
            int locus = 0;
            string mover;
            int numBumps = 0;
            // TO DO: Create variable for to name the rooms for the if statement

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

        static void Exit()
        {
            Environment.Exit(0);
        }

        // Maybe write an exit method? and ask "Are you sure?" once, then ask "Are you absolutely sure?" and if the answer to both is yes, the program quits
        #endregion

        

    }
}
