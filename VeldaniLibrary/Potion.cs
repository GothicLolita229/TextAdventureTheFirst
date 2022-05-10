using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeldaniLibrary
{
    public class Potion : Things
    {
        private string _idNumber;
        private string _name;
        private string _description;
        private string _price;
        private int _valueChange;
        private int _healthPotion = 20;

        public Potion(string idNumber, string name, string description, string price, int valueChange, int healthPotion)
            :base(idNumber, name, description, price)
        {
            _idNumber = idNumber;
            //IdNumber = idNumber;
            //Name = name;
            //Description = description;
            //ValueChange = valueChange;
            _name = name;
            _description = description;
            _valueChange = valueChange;
            _healthPotion = healthPotion;
        }

        
        public int ValueChange { get; set; } //This could be anything depending on the potion.
                                            //Health Potion: 20. Since this will not be used yet we
                                            //will just have it ready.These may change when we move forward.
        public int HealthPotion { get; set; }
    }
}
