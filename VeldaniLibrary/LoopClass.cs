using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeldaniLibrary
{
    public class LoopClass
    {
        public static string[] ArrayFileReader(string fileName)
        {
            List<string> returnList = new List<string>();

            returnList = FileReader(fileName);

            string[] returnArray = returnList.ToArray();

            return returnArray;
        }
        public static List<string> ListFileReader(string fileName)
        {
            List<string> returnList = new List<string>();

            returnList = FileReader(fileName);

            return returnList;
        }
        private static List<string> FileReader(string fileName)
        {
            List<string> returnList = new List<string>();
            StreamReader inputfile;
            try
            {
                inputfile = File.OpenText(fileName);

                while (inputfile.EndOfStream == false)
                {
                    returnList.Add(inputfile.ReadLine());
                }
                inputfile.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            return returnList;
        }
    }
}
