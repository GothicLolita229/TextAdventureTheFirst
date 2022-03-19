using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeldaniLibrary
{
    public class MoverClass
    {
        public static int[] CharMoveNorth(ref int roomLength, int locus, int numBumps)
        {
            locus+=1;
            string mover;

            if (locus > roomLength - 1)
            {
                // if user selects this option 5 times, Tell them they are kaput and exit the program
                //wrap around
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
                //wrap around
                locus = 0;
                Console.WriteLine("You'll stay here until you move in another direction.");
            }
            return locus;
        }

        public static void MoveThroughRooms(string[] roomArray)
        {
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
                    int[] moverReturn = MoverClass.CharMoveNorth(ref roomLength, locus, numBumps);
                    locus = moverReturn[0];
                    numBumps = moverReturn[1];
                    if (numBumps == 3)
                    {
                        Console.WriteLine("You dead, Mr. Adventure Guy. Back to the beginning.");
                        Console.ReadLine();
                        OptionMethods.Exit();
                    }
                    // MOVED THIS UP BEFORE TWO NESTED IFS
                    currentRoom = roomArray[locus];
                    Console.WriteLine($"You are in the {currentRoom}.");
                }
                else if (mover == "s")
                {
                    // loop through, take user input (n or s), and move through rooms up and down the array
                    locus = MoverClass.CharMoveSouth(ref roomLength, locus);
                    currentRoom = roomArray[locus];
                    Console.WriteLine($"You are in the {currentRoom}.");
                }
                else if (mover == "Exit")
                {
                    Console.Clear();
                    OptionMethods.MainMenu();
                }
                else
                {
                    Console.WriteLine("Invalid entry. Please enter (n) or (s) or Exit");
                }
            }
            while (locus < 5);
        }
    }
    
}
