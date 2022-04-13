using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeldaniLibrary
{
    public class OptionsMenuClass
    {

        public List<string> roomList = new List<string>(ListOption("rooms"));
        public static List<string> ListOption(string input)
        {
            List<string> optionList = LoopClass.ListFileReader($"{input}.txt");
            //optionList.Sort();
            foreach (var option in optionList)
            {
                Console.WriteLine(option);
            }
            return optionList;
        }

        public static void ExploreMenu(char userChoice)
        {
            switch (userChoice)
            {
                case '1':
                    RoomOption();
                    break;
                case '2':
                    WeaponsOption();
                    break;
                case '3':
                    PotionsOption();
                    break;
                case '4':
                    TreasureOption();
                    break;
                case '5':
                    ItemsOption();
                    break;
                case '6':
                    MobsOption();
                    break;
                default:
                    Exit();
                    break;
            }
        }
        public static void MainMenu()
        {
            ListOption("mainMenu");
        }
        public static List<Room> RoomOption()
        {
            List<string> roomStrList = ListOption("rooms");
            List<Room> roomList = new List<Room>();
            foreach (var roomName in roomStrList)
            {
                Room myRoom = new Room();
                myRoom.Name = roomName;
                roomList.Add(myRoom);
            }
            return roomList;
            //MoverClass.MoveThroughRooms(roomList);
        }
        public static void WeaponsOption()
        {
            // Battle Axe has slash damage of 1d20
            // Crossbow, piercing, 1d10 damage
            // Stiletto, piercing, 1d10 damage
            // Long Spear, impaling, 1d20 damage
            ListOption("weapons");
        }
        // TODO PROFESSOR make new method and pass the name of option as argument.
        // Then make another class and within use
        public static void PotionsOption()
        {
            ListOption("potions");
        }
        public static void TreasureOption()
        {
            ListOption("treasure");
        }
        public static void ItemsOption()
        {
            ListOption("items");
        }
        public static void MobsOption()
        {
            ListOption("mobs");
        }
        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}
