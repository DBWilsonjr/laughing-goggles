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
    public partial class Unlocks : Form
    {
        public Unlocks()
        {
            InitializeComponent();
            if (VarLocks.enSpec1 == true)
            {
                pcbUn1.Image = Properties.Resources.YellowOrb;
                pcbUn1.Refresh();
                lblUnlock1.Text = "Special Ability: Shimmer";
                lblUnDesc1.Text = "Can't remember these lyrics";
            }
            if (VarLocks.enHRBlue == true)
            {
                pcbUn2.Image = Properties.Resources.HRBlue;
                pcbUn2.Refresh();
                lblUnlock2.Text = "Special Abilities: HR Blue";
                lblUnDesc2.Text = "Stand, for you are now unchained";
            }
            if (VarLocks.enHRRed == true)
            {
                pcbUn3.Image = Properties.Resources.HRRed;
                pcbUn3.Refresh();
                lblUnlock3.Text = "Special Abilities: HR Red";
                lblUnDesc3.Text = "This rage is not your destiny";
            }
            if (VarLocks.enGreen == true)
            {
                pcbUn4.Image = Properties.Resources.GreenOrb;
                pcbUn4.Refresh();
                lblUnlock4.Text = "Color unlocked: Green";
                lblUnDesc4.Text = "New color options available";
            }
            if (VarLocks.enOrange == true)
            {
                pcbUn5.Image = Properties.Resources.OrangeOrb;
                pcbUn5.Refresh();
                lblUnlock5.Text = "Color unlocked: Orange";
                lblUnDesc5.Text = "New color options available";
            }
            if (VarLocks.enPurple == true)
            {
                pcbUn6.Image = Properties.Resources.PurpleOrb;
                pcbUn6.Refresh();
                lblUnlock6.Text = "Color unlocked: Purple";
                lblUnDesc6.Text = "New color options available";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
