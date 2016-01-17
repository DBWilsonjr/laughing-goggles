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
    public partial class Creator : Form
    {
        Preview preForm = new Preview();

        public Creator()
        {
            InitializeComponent();

            if (VarLocks.enPurple == true)
            {
                //listBox1.Items.Add("Knight");
                listBox1.Items.Add("Legionaire");
                //listBox1.Items.Add("Engineer");
                lsbSpecial.Items.Add("Purple Strike");
            }

            if (VarLocks.enGreen == true)
            {
                //listBox1.Items.Add("Stalker");
                //listBox1.Items.Add("Sentinel");
                listBox1.Items.Add("Dryad");
                lsbSpecial.Items.Add("Green Strike");
            }

            if (VarLocks.enOrange == true)
            {
                listBox1.Items.Add("Predator");
                //listBox1.Items.Add("Crusader");
                //listBox1.Items.Add("Seer");
                lsbSpecial.Items.Add("Orange Strike");
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string charOp1;
            charOp1 = listBox1.SelectedItem.ToString();
            if (charOp1 == "Huskarl")
            {
                preForm.lblClass.Text = "Huskarl";

                lsbColor.Enabled = true;
                lsbColor.Items.Clear();
                lsbColor.Items.Add("Red");
                if (VarLocks.enOrange == true)
                    lsbColor.Items.Add("Orange");
                if (VarLocks.enPurple == true)
                    lsbColor.Items.Add("Purple");

                lsbWeapon.Enabled = true;
                lsbWeapon.Items.Clear();
                lsbWeapon.Items.Add("Mace");
                lsbWeapon.Items.Add("Handaxe");
                lsbWeapon.Items.Add("Hammer");

                lsbOffhand.Enabled = true;
                lsbOffhand.Items.Clear();
                lsbOffhand.Items.Add("Shield");
                lsbOffhand.Items.Add("Dagger");
                lsbOffhand.Items.Add("Steel Song");

                lsbSpecial.Enabled = true;
            }

            else if (charOp1 == "Seige Archer")
            {
                preForm.lblClass.Text = "Seige Archer";

                lsbColor.Enabled = true;
                lsbColor.Items.Clear();
                lsbColor.Items.Add("Blue");
                if (VarLocks.enGreen == true)
                    lsbColor.Items.Add("Green");
                if (VarLocks.enPurple == true)
                    lsbColor.Items.Add("Purple");

                lsbWeapon.Enabled = true;
                lsbWeapon.Items.Clear();
                lsbWeapon.Items.Add("Bow");
                lsbWeapon.Items.Add("Sling");
                lsbWeapon.Items.Add("Gun");

                lsbOffhand.Enabled = true;
                lsbOffhand.Items.Clear();
                lsbOffhand.Items.Add("Piercing Arrows");
                lsbOffhand.Items.Add("Poison Arrows");
                lsbOffhand.Items.Add("Shield");

                lsbSpecial.Enabled = true;
            }

            else if (charOp1 == "Oracle")
            {
                preForm.lblClass.Text = "Oracle";

                lsbColor.Enabled = true;
                lsbColor.Items.Clear();
                lsbColor.Items.Add("Yellow");
                if (VarLocks.enGreen == true)
                    lsbColor.Items.Add("Green");
                if (VarLocks.enOrange == true)
                    lsbColor.Items.Add("Orange");

                lsbWeapon.Enabled = true;
                lsbWeapon.Items.Clear();
                lsbWeapon.Items.Add("Staff");
                lsbWeapon.Items.Add("Spear");

                lsbOffhand.Enabled = true;
                lsbOffhand.Items.Clear();
                lsbOffhand.Items.Add("Tarot");
                lsbOffhand.Items.Add("Crystal");

                lsbSpecial.Enabled = true;
            }

            else if (charOp1 == "Dryad")
            {
                preForm.lblClass.Text = "Dryad";

                lsbColor.Enabled = true;
                lsbColor.Items.Clear();
                lsbColor.Items.Add("Green");
                lsbColor.Items.Add("Blue");
                lsbColor.Items.Add("Yellow");

                lsbWeapon.Enabled = true;
                lsbWeapon.Items.Clear();
                lsbWeapon.Items.Add("Staff");
                lsbWeapon.Items.Add("Bow");

                lsbOffhand.Enabled = true;
                lsbOffhand.Items.Clear();
                lsbOffhand.Items.Add("Wand");
                lsbOffhand.Items.Add("Poison Arrows");
                lsbOffhand.Items.Add("Piercing Arrows");

                lsbSpecial.Enabled = true;
            }

            else if (charOp1 == "Predator")
            {
                preForm.lblClass.Text = "Predator";

                lsbColor.Enabled = true;
                lsbColor.Items.Clear();
                lsbColor.Items.Add("Orange");
                lsbColor.Items.Add("Red");
                lsbColor.Items.Add("Yellow");

                lsbWeapon.Enabled = true;
                lsbWeapon.Items.Clear();
                lsbWeapon.Items.Add("Sword");
                lsbWeapon.Items.Add("Hammer");
                lsbWeapon.Items.Add("Mace");

                lsbOffhand.Enabled = true;
                lsbOffhand.Items.Clear();
                lsbOffhand.Items.Add("Shield");
                lsbOffhand.Items.Add("Scripture");
                lsbOffhand.Items.Add("Athame");

                lsbSpecial.Enabled = true;
            }

            else if (charOp1 == "Legionaire")
            {
                preForm.lblClass.Text = "Legionaire";

                lsbColor.Enabled = true;
                lsbColor.Items.Clear();
                lsbColor.Items.Add("Purple");
                lsbColor.Items.Add("Red");
                lsbColor.Items.Add("Blue");

                lsbWeapon.Enabled = true;
                lsbWeapon.Items.Clear();
                lsbWeapon.Items.Add("Sword");
                lsbWeapon.Items.Add("Gun");
                lsbWeapon.Items.Add("Handaxe");

                lsbOffhand.Enabled = true;
                lsbOffhand.Items.Clear();
                lsbOffhand.Items.Add("Shield");
                lsbOffhand.Items.Add("Hollow Bullet");
                lsbOffhand.Items.Add("Lightning Bullet");

                lsbSpecial.Enabled = true;
            }
        }

        private void lsbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string charOp2;
            charOp2 = lsbColor.SelectedItem.ToString();
            if (charOp2 == "Red")
            {
                preForm.lblColor.Text = "Red";
                Globals.pColor = "Red";
            }
            if (charOp2 == "Blue")
            {
                preForm.lblColor.Text = "Blue";
                Globals.pColor = "Blue";
            }
            if (charOp2 == "Yellow")
            {
                preForm.lblColor.Text = "Yellow";
                Globals.pColor = "Yellow";
            }
            if (charOp2 == "Green")
            {
                preForm.lblColor.Text = "Green";
                Globals.pColor = "Green";
            }
            if (charOp2 == "Orange")
            {
                preForm.lblColor.Text = "Orange";
                Globals.pColor = "Orange";
            }
            if (charOp2 == "Purple")
            {
                preForm.lblColor.Text = "Purple";
                Globals.pColor = "Purple";
            }

        }

        private void lsbWeapon_SelectedIndexChanged(object sender, EventArgs e)
        {
            string charOp3;
            charOp3 = lsbWeapon.SelectedItem.ToString();
            if (charOp3 == "Sword")
            {
                preForm.lblSkill1.Text = "Slash";
                Globals.s1Name = "Slash";
                preForm.lblS1Desc.Text = "A basic swinging attack with a blade";
                Globals.s1Tip = "A basic swinging attack with a blade";
                preForm.lblSkill2.Text = "Broadsweep";
                Globals.s2Name = "Broadsweep";
                preForm.lblS2Desc.Text = "A wide-arcing attack that cuts through armor";
                Globals.s2Tip = "A wide-arcing attack that cuts through armor";
            }
            if (charOp3 == "Handaxe")
            {
                preForm.lblSkill1.Text = "Slash";
                Globals.s1Name = "Slash";
                preForm.lblS1Desc.Text = "A basic swinging attack with a blade";
                Globals.s1Tip = "A basic swinging attack with a blade";
                preForm.lblSkill2.Text = "Cleave";
                Globals.s2Name = "Cleave";
                preForm.lblS2Desc.Text = "A heavy cutting attack";
                Globals.s2Tip = "A heavy cutting attack";
            }
            if (charOp3 == "Spear")
            {
                preForm.lblSkill1.Text = "Stab";
                Globals.s1Name = "Stab";
                preForm.lblS1Desc.Text = "A quick  thrust with a pointed weapon";
                Globals.s1Tip = "A quick  thrust with a pointed weapon";
                preForm.lblSkill2.Text = "Lunge";
                Globals.s2Name = "Lunge";
                preForm.lblS2Desc.Text = "A charging attack aimed to impale";
                Globals.s2Tip = "A charging attack aimed to impale";
            }
            if (charOp3 == "Mace")
            {
                preForm.lblSkill1.Text = "Bash";
                Globals.s1Name = "Bash";
                preForm.lblS1Desc.Text = "A smashing attack";
                Globals.s1Tip = "A smashing attack";
                preForm.lblSkill2.Text = "Grand Slam";
                Globals.s2Name = "Grand Slam";
                preForm.lblS2Desc.Text = "A wild swing at full strength";
                Globals.s2Tip = "A wild swing at full strength";
            }
            if (charOp3 == "Hammer")
            {
                preForm.lblSkill1.Text = "Bash";
                Globals.s1Name = "Bash";
                preForm.lblS1Desc.Text = "A smashing attack";
                Globals.s1Tip = "A smashing attack";
                preForm.lblSkill2.Text = "Bonecrusher";
                Globals.s2Name = "Bonecrusher";
                preForm.lblS2Desc.Text = "A mighty downward smash";
                Globals.s2Tip = "A mighty downward smash";
            }
            if (charOp3 == "Staff")
            {
                preForm.lblSkill1.Text = "Bash";
                Globals.s1Name = "Bash";
                preForm.lblS1Desc.Text = "A smashing attack";
                Globals.s1Tip = "A smashing attack";
                preForm.lblSkill2.Text = "Charged Strike";
                Globals.s2Name = "Charged Strike";
                preForm.lblS2Desc.Text = "Magical power channeled through the staff";
                Globals.s2Tip = "Magical power channeled through the staff";
            }
            if (charOp3 == "Bow")
            {
                preForm.lblSkill1.Text = "Shot";
                Globals.s1Name = "Shot";
                preForm.lblS1Desc.Text = "A simple shooting attack";
                Globals.s1Tip = "A simple shooting attack";
                preForm.lblSkill2.Text = "Aimed Shot";
                Globals.s2Name = "Aimed Shot";
                preForm.lblS2Desc.Text = "A targetted attack at the enemy's weakpoint";
                Globals.s2Tip = "A targetted attack at the enemy's weakpoint";
            }
            if (charOp3 == "Sling")
            {
                preForm.lblSkill1.Text = "Shot";
                Globals.s1Name = "Shot";
                preForm.lblS1Desc.Text = "A simple shooting attack";
                Globals.s1Tip = "A basic swinging attack with a blade";
                preForm.lblSkill2.Text = "Head Shot";
                Globals.s2Name = "Head Shot";
                preForm.lblS2Desc.Text = "A shot aimed right between the eyes";
                Globals.s2Tip = "A shot aimed right between the eyes";
            }
            if (charOp3 == "Gun")
            {
                preForm.lblSkill1.Text = "Shot";
                Globals.s1Name = "Shot";
                preForm.lblS1Desc.Text = "A simple shooting attack";
                Globals.s1Tip = "A simple shooting attack";
                preForm.lblSkill2.Text = "Spread Shot";
                Globals.s2Name = "Spread Shot";
                preForm.lblS2Desc.Text = "A wide-area attack intend to land hits";
                Globals.s2Tip = "A wide-area attack intended to land hits";
            }
        }

        private void lsbOffhand_SelectedIndexChanged(object sender, EventArgs e)
        {
            string charOp4;
            charOp4 = lsbOffhand.SelectedItem.ToString();
            if (charOp4 == "Shield")
            {
                preForm.lblSkill3.Text = "Defend";
                preForm.lblS3Desc.Text = "Protects the shieldbearer from damage";
                Globals.s3Name = "Defend";
                Globals.s3Tip = "Protects the shieldbearer from damage";
            }
            if (charOp4 == "Dagger")
            {
                preForm.lblSkill3.Text = "Bleed Attack";
                preForm.lblS3Desc.Text = "Causes bleeding damage over time";
                Globals.s3Name = "Bleed Attack";
                Globals.s3Tip = "Causes bleeding damage over time";
            }
            if (charOp4 == "Steel Song")
            {
                preForm.lblSkill3.Text = "Steel Song";
                preForm.lblS3Desc.Text = "Gives the singer resistance to damage for 4 rounds";
                Globals.s3Name = "Steel Song";
                Globals.s3Tip = "Gives the singer resistance to damage for 4 turns";
            }
            if (charOp4 == "Piercing Arrows")
            {
                preForm.lblSkill3.Text = "Piercing Shot";
                preForm.lblS3Desc.Text = "Deals extra damage to the enemy";
                Globals.s3Name = "Piercing Shot";
                Globals.s3Tip = "Deals extra damage to the enemy";
            }
            if (charOp4 == "Poison Arrows")
            {
                preForm.lblSkill3.Text = "Poisoned Shot";
                preForm.lblS3Desc.Text = "Poisons the enemy, causing damage over time";
                Globals.s3Name = "Poisoned shot";
                Globals.s3Tip = "Poisons the enemy, causing damage over time";
            }
            if (charOp4 == "Tarot")
            {
                preForm.lblSkill3.Text = "Tarot Card";
                preForm.lblS3Desc.Text = "Causes a variety of damaging effects";
                Globals.s3Name = "Tarot Card";
                Globals.s3Tip = "Causes a variety of damaging effects";
            }
            if (charOp4 == "Crystal")
            {
                preForm.lblSkill3.Text = "Divination";
                preForm.lblS3Desc.Text = "Adds a random buff";
                Globals.s3Name = "Divination";
                Globals.s3Tip = "Adds a random buff";
            }
            if (charOp4 == "Wand")
            {
                preForm.lblSkill3.Text = "Cursing Strike";
                preForm.lblS3Desc.Text = "Hits the target with a random curse";
                Globals.s3Name = "Cursing Strike";
                Globals.s3Tip = "Hits the target with a random curse";
            }
            if (charOp4 == "Scripture")
            {
                preForm.lblSkill3.Text = "Healing Light";
                preForm.lblS3Desc.Text = "Recovers a large amount of health";
                Globals.s3Name = "Healing Light";
                Globals.s3Tip = "Recovers a large amount of health";
            }
            if (charOp4 == "Athame")
            {
                preForm.lblSkill3.Text = "Blood Letting";
                preForm.lblS3Desc.Text = "Boosts attack power at the expense of health";
                Globals.s3Name = "Blood Letting";
                Globals.s3Tip = "Boosts attack power at the expense of health";
            }
            if (charOp4 == "Hollow Bullet")
            {
                preForm.lblSkill3.Text = "Hollowed Shot";
                preForm.lblS3Desc.Text = "A shot designed to cause extra pain";
                Globals.s3Name = "Hollowed shot";
                Globals.s3Tip = "A shot designed to cause extra pain";
            }
            if (charOp4 == "Lightning Bullet")
            {
                preForm.lblSkill3.Text = "Sudden Shot";
                preForm.lblS3Desc.Text = "A shot that always finds its target";
                Globals.s3Name = "Sudden Shot";
                Globals.s3Tip = "A shot that always finds its target";
            }
           
        }

        private void lsbSpecial_SelectedIndexChanged(object sender, EventArgs e)
        {
            string charOp5;
            charOp5 = lsbSpecial.SelectedItem.ToString();
            if (charOp5 == "Red Strike")
            {
                preForm.lblSkill4.Text = "Red Strike";
                Globals.s4Name = "Red Strike";
                preForm.lblS4Desc.Text = "A red-colored attack";
                Globals.s4Tip = "a red-colored attack";
            }
            if (charOp5 == "Blue Strike")
            {
                preForm.lblSkill4.Text = "Blue Strike";
                Globals.s4Name = "Blue Strike";
                preForm.lblS4Desc.Text = "A blue-colored attack";
                Globals.s4Tip = "a blue-colored attack";
            }
            if (charOp5 == "Yellow Strike")
            {
                preForm.lblSkill4.Text = "Yellow Strike";
                Globals.s4Name = "Yellow Strike";
                preForm.lblS4Desc.Text = "A yellow-colored attack";
                Globals.s4Tip = "a yellow-colored attack";
            }
            if (charOp5 == "Green Strike")
            {
                preForm.lblSkill4.Text = "Green Strike";
                Globals.s4Name = "Green Strike";
                preForm.lblS4Desc.Text = "A green-colored attack";
                Globals.s4Tip = "a green-colored attack";
            }
            if (charOp5 == "Orange Strike")
            {
                preForm.lblSkill4.Text = "Orange Strike";
                Globals.s4Name = "Orange Strike";
                preForm.lblS4Desc.Text = "A orange-colored attack";
                Globals.s4Tip = "a orange-colored attack";
            }
            if (charOp5 == "Purple Strike")
            {
                preForm.lblSkill4.Text = "Purple Strike";
                Globals.s4Name = "Purple Strike";
                preForm.lblS4Desc.Text = "A purple-colored attack";
                Globals.s4Tip = "a purple-colored attack";
            }

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            listBox1.ClearSelected();
            lsbColor.Enabled = false;
            lsbColor.Items.Clear();
            lsbWeapon.Enabled = false;
            lsbWeapon.Items.Clear();
            lsbOffhand.Enabled = false;
            lsbOffhand.Items.Clear();
            lsbSpecial.Enabled = false;
            lsbSpecial.ClearSelected();
            radEasy.Checked = false;
            radNorm.Checked = false;
            radHard.Checked = false;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && listBox1.SelectedIndex != -1 && lsbColor.SelectedIndex != -1 && lsbWeapon.SelectedIndex != -1 && lsbOffhand.SelectedIndex != -1 && lsbSpecial.SelectedIndex != -1 && radEasy.Checked == true || radNorm.Checked == true || radHard.Checked == true)
            {
                preForm.lblName.Text = txtName.Text.ToString();
                this.Hide();
                preForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please enter a name and fill in all fields", "Missing inputs");
            }
        }
    }
}
