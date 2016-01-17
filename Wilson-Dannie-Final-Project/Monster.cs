using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wilson_Dannie_Final_Project
{
    class Monster : Character
    {
        private int _templeDam;

        public Monster()
        {
            _templeDam = TEMPLEDAM;
        }

        public int TEMPLEDAM
        {
            get { return _templeDam; }
            set { _templeDam = value; }
        }

    }
}
