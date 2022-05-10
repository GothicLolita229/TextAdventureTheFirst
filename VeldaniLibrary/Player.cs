using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace VeldaniLibrary
{
    public class Player
    {
        
        private string _name;
        private string _password; //The first time the player is created
                                  //the password must meet a format
                                  //1 Capital Letter, 1 lowercase letter,
                                  //1 Special Character.
        private string _race; //Elf, Human, Dwarf……etc
        private string _playerClass; //Warrior, Mage, Thief, Cleric……etc
        private int _hp;
        private int _ac;
        private int _location;
        //private string _inventory;
        //private string _quests;

        public Player(int idNumber, string name, string password, string race, string playerClass, int hp, int ac, int location, string inventory, string quests )
        {
            IdNumber = idNumber;
            Name = name;
            _password = password;
            _race = race;
            _playerClass = playerClass;
            _hp = hp;
            _ac = ac;
            _location = location;
            //_inventory = inventory;
            //_quests = quests;
        }

        public int IdNumber { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Race { get; set; }
        public string PlayerClass { get; set; } //Could use either a set value or
                                           //random dice roll. Leaning towards random
        public int HP { get; set; }
        public int AC { get; set; }

        
        
        
    }
}
