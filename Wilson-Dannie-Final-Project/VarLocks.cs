using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wilson_Dannie_Final_Project
{

    class VarLocks
    {
        public static int[] unlocks;
        public static bool enSpec1 = false;
        public static bool enGreen = false;
        public static bool enOrange = false;
        public static bool enPurple = false;
        public static bool enHRBlue = false;
        public static bool enHRRed = false;

        public static int[] bestiary;
        public static bool besRed = false;
        public static bool besBlue = false;
        public static bool besYellow = false;
        public static bool besGreen = false;
        public static bool besOrange = false;
        public static bool besPurple = false;

        public static int RedCnt;
        public static int BluCnt;
        public static int YelCnt;
        public static int GreCnt;
        public static int OraCnt;
        public static int PurCnt;
    }

    class Globals
    {
        public static string pName, pClass, pColor, s1Name, s1Tip, s2Name, s2Tip, s3Name, s3Tip, s4Name, s4Tip, s4Color = "";
        public static int Difficulty;
        public static int placa, ab1, ab1Cool, ab2, ab2Val, ab3, ab3Cool, ab4, ab4Cool;
        public static int templeHP, templeProt, bonHP, bonDam, bonEvd;
    }
}
