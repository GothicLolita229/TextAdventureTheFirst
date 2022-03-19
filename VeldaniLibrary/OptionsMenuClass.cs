using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeldaniLibrary
{
    public class OptionsMenuClass
    {
        public static void ListOption(string input)
        {

            List<string> optionList = LoopClass.ListFileReader($"{input}.txt");

            optionList.Sort();

            foreach (var option in optionList)
            {
                Console.WriteLine(option);
            }
        }

        public static void ExploreMenu(char userChoice, string input)
        {
            switch (userChoice)
            {
                case '1':
                    OptionMethods.RoomOption();
                    break;
                case '2':
                    OptionMethods.WeaponsOption();
                    break;
                case '3':
                    OptionMethods.PotionsOption();
                    break;
                case '4':
                    OptionMethods.TreasureOption();
                    break;
                case '5':
                    OptionMethods.ItemsOption();
                    break;
                case '6':
                    OptionMethods.MobsOption();
                    break;
                default:
                    OptionMethods.Exit();
                    break;
            }
        }

    }
}
