using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wilson_Dannie_Final_Project
{
    class Player : Character
    {
        private string _name;
        private int _bonHP, _bonDam, _bonEvd;

        public Player()
        {
            _name = NAME;
            _bonHP = BONHP;
            _bonDam = BONDAM;
            _bonEvd = BONEVD;
        }

        public string NAME
        {
            get { return _name; }
            set { _name = value; }
        }

        public int BONHP
        {
            get { return _bonHP; }
            set { _bonHP = value; }
        }

        public int BONDAM
        {
            get { return _bonDam; }
            set { _bonDam = value; }
        }

        public int BONEVD
        {
            get { return _bonEvd; }
            set { _bonEvd = value; }
        }
    }
}
