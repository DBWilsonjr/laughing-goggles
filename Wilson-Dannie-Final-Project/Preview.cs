using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wilson_Dannie_Final_Project
{
    public partial class Preview : Form
    {
        public Preview()
        {
            InitializeComponent();
            if (lblClass.Text.ToString() == "Huskarl")
                pcbHero.Image = Properties.Resources.redc;
            if (lblClass.Text.ToString() == "Seige Archer")
                pcbHero.Image = Properties.Resources.bluec;
            if (lblClass.Text.ToString() == "Oracle")
                pcbHero.Image = Properties.Resources.yellowc;
            if (lblClass.Text.ToString() == "Dryad")
                pcbHero.Image = Properties.Resources.greenc;
            if (lblClass.Text.ToString() == "Predator")
                pcbHero.Image = Properties.Resources.orangec;
            if (lblClass.Text.ToString() == "Legionaire")
                pcbHero.Image = Properties.Resources.Purplec;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Creator createForm = new Creator();
            this.Hide();
            createForm.ShowDialog();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Creator creForm = new Creator();
            MainGame mnform = new MainGame();
            if (creForm.radEasy.Checked == true)
                Globals.Difficulty = 10;
            if (creForm.radNorm.Checked == true)
                Globals.Difficulty = 5;
            if (creForm.radHard.Checked == true)
                Globals.Difficulty = 0;
            Globals.pClass = lblClass.Text.ToString();
            Globals.s3Name = lblSkill3.Text.ToString();
            Globals.s3Tip = lblS3Desc.Text.ToString();
            Globals.s4Name = lblSkill4.Text.ToString();
            Globals.s4Tip = lblS4Desc.Text.ToString();
            mnform.lblPlayerClass.Text = lblName.Text.ToString() + " the " + lblClass.Text.ToString();
            if (lblClass.Text.ToString() == "Huskarl")
            {
                Globals.placa = 1;
                mnform.pcbHero.Image = Properties.Resources.redc;
            }
            if (lblClass.Text.ToString() == "Seige Archer")
            {
                mnform.pcbHero.Image = Properties.Resources.bluec;
                Globals.placa = 2;
            }
            if (lblClass.Text.ToString() == "Oracle")
            {
                mnform.pcbHero.Image = Properties.Resources.yellowc;
                Globals.placa = 3;
            }
            if (lblClass.Text.ToString() == "Dryad")
            {
                mnform.pcbHero.Image = Properties.Resources.greenc;
                Globals.placa = 4;
            }
            if (lblClass.Text.ToString() == "Predator")
            {
                mnform.pcbHero.Image = Properties.Resources.orangec;
                Globals.placa = 5;
            }
            if (lblClass.Text.ToString() == "Legionaire")
            {
                mnform.pcbHero.Image = Properties.Resources.Purplec;
                Globals.placa = 6;
            }
            switch (lblSkill3.Text.ToString())
            {
                case "Defend": Globals.ab3 = 301; break;
                case "Bleed Attack": Globals.ab3 = 320; break;
                case "Steel Song": Globals.ab3 = 302; break;
                case "Piercing Arrows": Globals.ab3 = 303; break;
                case "Poison Arrows": Globals.ab3 = 321; break;
                case "Tarot Card": Globals.ab3 = 330; break;
                case "Divination": Globals.ab3 = 308; break;
                case "Cursing Strike": Globals.ab3 = 322; break;
                case "Healing Light": Globals.ab3 = 304; break;
                case "Blood Letting": Globals.ab3 = 305; break;
                case "Hollowed Shot": Globals.ab3 = 306; break;
                case "Sudden Shot": Globals.ab3 = 307; break;

            }

            switch (lblSkill4.Text.ToString())
            {
                case "Red Strike": Globals.ab4 = 411; break;
                case "Blue Strike": Globals.ab4 = 412; break;
                case "Yellow Strike": Globals.ab4 = 413; break;
                case "Green Strike": Globals.ab4 = 414; break;
                case "Orange Strike": Globals.ab4 = 415; break;
                case "Purple Strike": Globals.ab4 = 416; break;
            }

            this.Hide();
            mnform.ShowDialog();
        }
    }
}
