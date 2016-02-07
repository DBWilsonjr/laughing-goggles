using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wilson_Dannie_Final_Project
{
    class Character
    {
        private int _health, _force, _evade, _color;
        private int[] _buffBit = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[] _buffVal = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[] _buffTime = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[] _debuffBit = { 0, 0, 0, 0, 0, 0, 0 };
        private int[] _debuffVal = { 0, 0, 0, 0, 0, 0, 0 };
        private int[] _debuffTime = { 0, 0, 0, 0, 0, 0, 0 };
        private int _ability1, _ability2, _ab2Val, _ability3, _ab3Cool, _ability4;

        public Character()
        {
            _health = HEALTH;
            _force = FORCE;
            _evade = EVADE;
            _color = COLOR;
            _buffBit = BUFFBIT;
            _buffVal = BUFFVAL;
            _buffTime = BUFFTIME;
            _debuffBit = DEBUFFBIT;
            _debuffVal = DEBUFFVAL;
            _debuffTime = DEBUFFTIME;
            _ability1 = ABILITY1;
            _ability2 = ABILITY2;
            _ab2Val = AB2VAL;
            _ability3 = ABILITY3;
            _ab3Cool = AB3COOL;
            _ability4 = ABILITY4;
        }

        public int HEALTH
        {
            get { return _health; }
            set { _health = value; }
        }

        public int FORCE
        {
            get { return _force; }
            set { _force = value; }
        }

        public int EVADE
        {
            get { return _evade; }
            set { _evade = value; }
        }

        public int COLOR
        {
            get { return _color; }
            set { _color = value; }
        }

        public int[] BUFFBIT
        {
            get { return _buffBit; }
            set { _buffBit = value; }
        }

        public int[] BUFFVAL
        {
            get { return _buffVal; }
            set { _buffVal = value; }
        }

        public int[] BUFFTIME
        {
            get { return _buffTime; }
            set { _buffTime = value; }
        }

        public int[] DEBUFFBIT
        {
            get { return _debuffBit; }
            set { _debuffBit = value; }
        }

        public int[] DEBUFFVAL
        {
            get { return _debuffVal; }
            set { _debuffVal = value; }
        }

        public int[] DEBUFFTIME
        {
            get { return _debuffTime; }
            set { _debuffTime = value; }
        }

        public int ABILITY1
        {
            get { return _ability1; }
            set { _ability1 = value; }
        }

        public int ABILITY2
        {
            get { return _ability2; }
            set { _ability2 = value; }
        }

        public int AB2VAL
        {
            get { return _ab2Val; }
            set { _ab2Val = value; }
        }

        public int ABILITY3
        {
            get { return _ability3; }
            set { _ability3 = value; }
        }

        public int AB3COOL
        {
            get { return _ab3Cool; }
            set { _ab3Cool = value; }
        }

        public int ABILITY4
        {
            get { return _ability4; }
            set { _ability4 = value; }
        }
    }
}
