using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeldaniLibrary
{
    public class Room
    {
        private string _idNumber;
        private string _name;
        private string _description;
        private string _exit;
        public List<Item> bag;

        public Room()
        {
        }

        //public List<Item> bag;
        //private List<Weapon> weapons;
        public Room(string idNumber, string name, string description, string exit)
﻿        {
            _idNumber = idNumber;
            _name = name;
            _description = description;
            _exit = exit;
            bag = new List<Item>();
        }
        public string Name{ get; set; }
        public string IdNumber { get; set; }
        public string Description { get; set; }
        // TODO public string(?) Exit
        public string Exit { get; set; }

        //TODO add items to room bag of holding

        public static void addItem(Item newItem, List<Item> playerBag)
        {
            playerBag.Add(newItem);
        }

        public static void addWeapon(Weapon newWeapon, List<Weapon> playerBag)
        {
            playerBag.Add(newWeapon);
        }
        


    }
}
