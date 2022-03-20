using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeldaniLibrary
{
    public class MoverClass
    {
        List<string> roomList = OptionsMenuClass.ListOption("rooms");

        #region brokenUpIntoMethods
        public static int[] CharMoveNorth(ref int roomLength, int locus, int numBumps)
        {
            locus += 1;
            string mover;

            if (locus > roomLength - 1)
            {
                locus = roomLength - 1;
                numBumps += 1;
                if (numBumps == 1)
                {
                    Console.WriteLine("Please stop banging your head on the dungeon wall. You must turn around and go back because this is the end.");
                }
                else if (numBumps == 2)
                {
                    Console.WriteLine("Seriously. Stop. You will DIE!");
                }
            }
            return new int[] { locus, numBumps }; 
        }
        public static int CharMoveSouth(ref int roomLength, int locus)
        {
            locus -= 1;
            if (locus < 0)
            {
                locus = 0;
                Console.WriteLine("You'll stay here until you move in another direction.");
            }
            return locus;
        }
        public static void MoveThroughRooms(List<string> roomList)
        {
            //string charName = Player.PlayerInfo();
            string[] roomArray = roomList.ToArray();
            int locus = 0;
            string mover;
            int numBumps = 0;
            int roomLength = roomArray.Length;
            Console.WriteLine("You are at the Entrance of the abandoned castle.");
            do
            {
                var currentRoom = roomArray[0];
                Console.WriteLine("Would you like to go North (n) or South (s) or Exit?");
                mover = Console.ReadLine();
                if (mover == "n")
                {
                    int[] moverReturn = CharMoveNorth(ref roomLength, locus, numBumps);
                    locus = moverReturn[0];
                    numBumps = moverReturn[1];
                    if (numBumps == 3)
                    {
                        Console.WriteLine("You dead, Mr. Adventure Guy. Back to the beginning.");
                        Console.ReadLine();
                        OptionsMenuClass.Exit();
                    }
                    // MOVED THIS UP BEFORE TWO NESTED IFS
                    currentRoom = roomArray[locus];
                    Console.WriteLine($"You are in the {currentRoom}.");
                }
                else if (mover == "s")
                {
                    // loop through, take user input (n or s), and move through rooms up and down the array
                    locus = CharMoveSouth(ref roomLength, locus);
                    currentRoom = roomArray[locus];
                    Console.WriteLine($"You are in the {currentRoom}.");
                }
                else if (mover == "Exit")
                {
                    Console.Clear();
                    OptionsMenuClass.MainMenu();
                }
                else
                {
                    Console.WriteLine("Invalid entry. Please enter (n) or (s) or Exit");
                }
            }
            while (locus < 5);
        } 
        #endregion

        #region allInOneMethod
        /*
        public static void MoveThroughRooms(List<string> roomList)
        {
            int locus = 0;
            string mover;
            int numBumps = 0;
            Console.WriteLine("You are at the Entrance of the abandoned castle.");
            string[] roomArray = roomList.ToArray();
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
                            OptionsMenuClass.Exit();
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
                    OptionsMenuClass.MainMenu();
                }
                else
                {
                    Console.WriteLine("Invalid entry. Please enter (n) or (s) or Exit");
                }
            }
            while (locus < 5);
        }
        */
        #endregion
    }

}
