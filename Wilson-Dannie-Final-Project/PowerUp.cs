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

            lblTHP.Text = "Temple Health: " + mnForm.pgbTemple.Value + "/10";
            lblTProt.Text = "Temple Protection: " + mnForm.pgbProt.Value + "/10";
            lblPHP.Text = "Current Bonus: " + mnForm.bonHP.ToString() + "/100";
            lblPAtk.Text = "Current Bonus: " + mnForm.bonDam.ToString() + "/5";
            lblPDef.Text = "Current Bonus: " + mnForm.bonEvd.ToString() + "/5";

            if (mnForm.bonHP < 100)
                button2.Enabled = true;
            if (mnForm.bonDam < 5)
                button3.Enabled = true;
            if (mnForm.bonEvd < 5)
                button4.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mnForm.pgbTemple.Value < 10)
            {
                mnForm.pgbTemple.Value = 10;
                MessageBox.Show("The temple has been completely restored", "Temple Improved");
                this.Close();
            }
            else
            {
                mnForm.pgbProt.Value += 1;
                MessageBox.Show("The temple's protection has increased by 1", "Temple Improved");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mnForm.bonHP += 20;
            MessageBox.Show("Your health has improved by 20", "Stats Improved");
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mnForm.bonHP += 1;
            MessageBox.Show("Your attack has improved by 1", "Stats Improved");
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mnForm.bonHP += 1;
            MessageBox.Show("Your defense has improved by 1", "Stats Improved");
            this.Close();
        }
    }
}
