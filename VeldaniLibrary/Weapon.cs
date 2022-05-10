using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeldaniLibrary
{
    public class Weapon
    {
        private int _idNumber;
        private string _name;
        private string _description;
        private string _damageType;
        private int _damage;
        private int _price;

        public Weapon(int idNumber, string name, string description, string damageType, int damage, int price)
        {
            _idNumber = idNumber;
            _name = name;
            _description = description;
            _damageType = damageType;
            _damage = damage;
            _price = price;
        }

        public string IdNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DamageType { get; set; }
        public string Damage { get; set; } //Could use either a set value or
                                           //random dice roll. Leaning towards random
        public string Price { get; set; }
    }
}
