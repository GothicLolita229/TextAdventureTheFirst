using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeldaniLibrary
{
    abstract public class LivingCreatures
    {
        private string _name;
        private string _race;
        private string _lcclass;
        private int _hp;
        private int _ac;

        public LivingCreatures(string name, string race, string lcclass, int hp, int ac)
        {
            _name = name;
            _race = race;
            _lcclass = lcclass;
            _hp = hp;
            _ac = ac;
        }

        public string Name { get; set; }

        public string Race { get; set; }
        public string lcClass { get; set; }
        public int HP { get; set; }
        public int AC { get; set; }

    }
}
