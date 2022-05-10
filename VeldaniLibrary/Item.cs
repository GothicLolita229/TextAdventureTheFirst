using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeldaniLibrary
{
    public class Item
    {
        private int _idNumber;
        private string _name;
        private string _description;
        private string _questItem;
        private int _price;

        public Item(int idNumber, string name, string description, string questItem, int price)
        {
            _idNumber = idNumber;
            _name = name;
            _description = description;
            _questItem = questItem;
            _price = price;
        }

        public string IdNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string QuestItem { get; set; }
        public string Price { get; set; }
    }
}
