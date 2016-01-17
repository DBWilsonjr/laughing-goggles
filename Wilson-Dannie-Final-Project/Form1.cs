using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Wilson_Dannie_Final_Project
{
    public partial class Intro : Form
    {
        public Intro()
        {
            InitializeComponent();
            UnlockCheck();
            BestiaryCheck();
        }

        private void lblStart_Click(object sender, EventArgs e)
        {
            Creator CharForm = new Creator();
            CharForm.ShowDialog();
        }

        private void lblUnlock_Click(object sender, EventArgs e)
        {
            //This working right depends on the unlock file read in the intro
            Unlocks UnlockForm = new Unlocks();
            UnlockForm.ShowDialog();
        }

        private void lblEnemies_Click(object sender, EventArgs e)
        {
            //This working right depends on the bestiary file read in the intro
            Bestiary BestForm = new Bestiary();
            BestForm.ShowDialog();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Instruct instruForm = new Instruct();
            instruForm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void UnlockCheck()
        {
            int cntr = 0;
            string[] holder; holder = new string[6];
            VarLocks.unlocks = new int[6];

            StreamReader outfile;
            outfile = File.OpenText("Unlocks.txt");
            while (outfile.EndOfStream == false)
            {
                holder[cntr] = outfile.ReadLine();
                VarLocks.unlocks[cntr] = Convert.ToInt32(holder[cntr]);
                cntr++;
            }
            outfile.Close();
            if (VarLocks.unlocks[0] >= 1)
                VarLocks.enSpec1 = true;
            if (VarLocks.unlocks[1] >= 1)
                VarLocks.enHRBlue = true;
            if (VarLocks.unlocks[2] >= 1)
                VarLocks.enHRRed = true;
            if (VarLocks.unlocks[3] >= 1)
                VarLocks.enGreen = true;
            if (VarLocks.unlocks[4] >= 1)
                VarLocks.enOrange = true;
            if (VarLocks.unlocks[5] >= 1)
                VarLocks.enPurple = true;
        }

        private void BestiaryCheck()
        {
            int cntr = 0;
            string[] holder; holder = new string[6];
            VarLocks.bestiary = new int[6];

            StreamReader outfile;
            outfile = File.OpenText("Bestiary.txt");
            while (outfile.EndOfStream == false)
            {
                holder[cntr] = outfile.ReadLine();
                VarLocks.bestiary[cntr] = Convert.ToInt32(holder[cntr]);
                cntr++;
            }
            outfile.Close();
            if (VarLocks.bestiary[0] >= 1)
                VarLocks.besRed = true;
            if (VarLocks.bestiary[1] >= 1)
                VarLocks.besBlue = true;
            if (VarLocks.bestiary[2] >= 1)
                VarLocks.besYellow = true;
            if (VarLocks.bestiary[3] >= 1)
                VarLocks.besGreen = true;
            if (VarLocks.bestiary[4] >= 1)
                VarLocks.besOrange = true;
            if (VarLocks.bestiary[5] >= 1)
                VarLocks.besPurple = true;
        }
    }
}
