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
    public partial class PowerUp : Form
    {
        MainGame mnForm = new MainGame();

        public PowerUp()
        {
            InitializeComponent();

            lblTHP.Text = "Temple Health: " + Globals.templeHP + "/10";
            lblTProt.Text = "Temple Protection: " + Globals.templeProt + "/10";
            lblPHP.Text = "Current Bonus: " + Globals.bonHP.ToString() + "/100";
            lblPAtk.Text = "Current Bonus: " + Globals.bonDam.ToString() + "/5";
            lblPDef.Text = "Current Bonus: " + Globals.bonEvd.ToString() + "/5";

            if (Globals.bonHP < 100)
                button2.Enabled = true;
            else
                button2.Enabled = false;
            if (Globals.bonDam < 5)
                button3.Enabled = true;
            else
                button3.Enabled = false;
            if (Globals.bonEvd < 5)
                button4.Enabled = true;
            else
                button4.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Globals.templeHP < 10)
            {
                Globals.templeHP = 10;
                MessageBox.Show("The temple has been completely restored", "Temple Improved");
                this.Close();
            }
            else
            {
                Globals.templeProt += 1;
                MessageBox.Show("The temple's protection has increased by 1", "Temple Improved");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Globals.bonHP += 20;
            MessageBox.Show("Your health has improved by 20", "Stats Improved");
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Globals.bonDam += 1;
            MessageBox.Show("Your attack has improved by 1", "Stats Improved");
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Globals.bonEvd += 1;
            MessageBox.Show("Your defense has improved by 1", "Stats Improved");
            this.Close();
        }
    }
}
