using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeldaniLibrary
{
    abstract public class Things
    {
        private string _idNumber;
        private string _name;
        private string _description;
        private string _price;

        public Things(string idNumber, string name, string description, string price)
        {
            _idNumber = idNumber;
            _name = name;
            _description = description;
            _price = price;
            
        }

        public string IDNumber { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string Price { get; set; }
        
    }
}
