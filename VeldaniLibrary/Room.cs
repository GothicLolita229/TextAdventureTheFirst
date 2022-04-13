using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeldaniLibrary
{
    public class Room
    {
        private string _name;
        private string _description;
        //private bool _exit;
        public Room()
﻿        {
          _name = "";
        }
        public string Name{ get; set; }
        public int IdNumber { get; set; }
        public string Description { get; set; }
        // TODO public string(?) Exit
    }
}
