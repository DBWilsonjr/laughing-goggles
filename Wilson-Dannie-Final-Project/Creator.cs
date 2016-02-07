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
            if (listBox1.SelectedIndex != -1)
                charOp1 = listBox1.SelectedItem.ToString();
            else
                charOp1 = "";
            if (charOp1 == "Huskarl")
            {
                lblClass.Text = "Huskarl";
                pcbHero.Image = Properties.Resources.redc;

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
                lblClass.Text = "Seige Archer";
                pcbHero.Image = Properties.Resources.bluec;

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
                lblClass.Text = "Oracle";
                pcbHero.Image = Properties.Resources.yellowc;

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
                lblClass.Text = "Dryad";
                pcbHero.Image = Properties.Resources.greenc;

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
                lblClass.Text = "Predator";
                pcbHero.Image = Properties.Resources.orangec;

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
                lblClass.Text = "Legionaire";
                pcbHero.Image = Properties.Resources.Purplec;

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
            if (lsbColor.SelectedIndex != -1)
                charOp2 = lsbColor.SelectedItem.ToString();
            else
                charOp2 = "";
            if (charOp2 == "Red")
            {
                lblColor.Text = "Red";
                Globals.pColor = "Red";
            }
            if (charOp2 == "Blue")
            {
                lblColor.Text = "Blue";
                Globals.pColor = "Blue";
            }
            if (charOp2 == "Yellow")
            {
                lblColor.Text = "Yellow";
                Globals.pColor = "Yellow";
            }
            if (charOp2 == "Green")
            {
                lblColor.Text = "Green";
                Globals.pColor = "Green";
            }
            if (charOp2 == "Orange")
            {
                lblColor.Text = "Orange";
                Globals.pColor = "Orange";
            }
            if (charOp2 == "Purple")
            {
                lblColor.Text = "Purple";
                Globals.pColor = "Purple";
            }

        }

        private void lsbWeapon_SelectedIndexChanged(object sender, EventArgs e)
        {
            string charOp3;
            if (lsbWeapon.SelectedIndex != -1)
            {
                charOp3 = lsbWeapon.SelectedItem.ToString();
                lblWeapon.Text = charOp3;
            }
            else
                charOp3 = "";
            if (charOp3 == "Sword")
            {
                lblSkill1.Text = "Slash";
                Globals.s1Name = "Slash";
                lblS1Desc.Text = "A basic swinging attack with a blade";
                Globals.s1Tip = "A basic swinging attack with a blade";
                lblSkill2.Text = "Broadsweep";
                Globals.s2Name = "Broadsweep";
                lblS2Desc.Text = "A wide-arcing attack that cuts through armor";
                Globals.s2Tip = "A wide-arcing attack that cuts through armor";
            }
            if (charOp3 == "Handaxe")
            {
                lblSkill1.Text = "Slash";
                Globals.s1Name = "Slash";
                lblS1Desc.Text = "A basic swinging attack with a blade";
                Globals.s1Tip = "A basic swinging attack with a blade";
                lblSkill2.Text = "Cleave";
                Globals.s2Name = "Cleave";
                lblS2Desc.Text = "A heavy cutting attack";
                Globals.s2Tip = "A heavy cutting attack";
            }
            if (charOp3 == "Spear")
            {
                lblSkill1.Text = "Stab";
                Globals.s1Name = "Stab";
                lblS1Desc.Text = "A quick  thrust with a pointed weapon";
                Globals.s1Tip = "A quick  thrust with a pointed weapon";
                lblSkill2.Text = "Lunge";
                Globals.s2Name = "Lunge";
                lblS2Desc.Text = "A charging attack aimed to impale";
                Globals.s2Tip = "A charging attack aimed to impale";
            }
            if (charOp3 == "Mace")
            {
                lblSkill1.Text = "Bash";
                Globals.s1Name = "Bash";
                lblS1Desc.Text = "A smashing attack";
                Globals.s1Tip = "A smashing attack";
                lblSkill2.Text = "Grand Slam";
                Globals.s2Name = "Grand Slam";
                lblS2Desc.Text = "A wild swing at full strength";
                Globals.s2Tip = "A wild swing at full strength";
            }
            if (charOp3 == "Hammer")
            {
                lblSkill1.Text = "Bash";
                Globals.s1Name = "Bash";
                lblS1Desc.Text = "A smashing attack";
                Globals.s1Tip = "A smashing attack";
                lblSkill2.Text = "Bonecrusher";
                Globals.s2Name = "Bonecrusher";
                lblS2Desc.Text = "A mighty downward smash";
                Globals.s2Tip = "A mighty downward smash";
            }
            if (charOp3 == "Staff")
            {
                lblSkill1.Text = "Bash";
                Globals.s1Name = "Bash";
                lblS1Desc.Text = "A smashing attack";
                Globals.s1Tip = "A smashing attack";
                lblSkill2.Text = "Charged Strike";
                Globals.s2Name = "Charged Strike";
                lblS2Desc.Text = "Magical power channeled through the staff";
                Globals.s2Tip = "Magical power channeled through the staff";
            }
            if (charOp3 == "Bow")
            {
                lblSkill1.Text = "Shot";
                Globals.s1Name = "Shot";
                lblS1Desc.Text = "A simple shooting attack";
                Globals.s1Tip = "A simple shooting attack";
                lblSkill2.Text = "Aimed Shot";
                Globals.s2Name = "Aimed Shot";
                lblS2Desc.Text = "A targetted attack at the enemy's weakpoint";
                Globals.s2Tip = "A targetted attack at the enemy's weakpoint";
            }
            if (charOp3 == "Sling")
            {
                lblSkill1.Text = "Shot";
                Globals.s1Name = "Shot";
                lblS1Desc.Text = "A simple shooting attack";
                Globals.s1Tip = "A basic swinging attack with a blade";
                lblSkill2.Text = "Head Shot";
                Globals.s2Name = "Head Shot";
                lblS2Desc.Text = "A shot aimed right between the eyes";
                Globals.s2Tip = "A shot aimed right between the eyes";
            }
            if (charOp3 == "Gun")
            {
                lblSkill1.Text = "Shot";
                Globals.s1Name = "Shot";
                lblS1Desc.Text = "A simple shooting attack";
                Globals.s1Tip = "A simple shooting attack";
                lblSkill2.Text = "Spread Shot";
                Globals.s2Name = "Spread Shot";
                lblS2Desc.Text = "A wide-area attack intend to land hits";
                Globals.s2Tip = "A wide-area attack intended to land hits";
            }
        }

        private void lsbOffhand_SelectedIndexChanged(object sender, EventArgs e)
        {
            string charOp4;
            if (lsbOffhand.SelectedIndex != -1)
            {
                charOp4 = lsbOffhand.SelectedItem.ToString();
                lblOffhand.Text = charOp4;
            }
            else
                charOp4 = "";
            
            if (charOp4 == "Shield")
            {
                lblSkill3.Text = "Defend";
                lblS3Desc.Text = "Protects the shieldbearer from damage";
                Globals.s3Name = "Defend";
                Globals.s3Tip = "Protects the shieldbearer from damage";
            }
            if (charOp4 == "Dagger")
            {
                lblSkill3.Text = "Bleed Attack";
                lblS3Desc.Text = "Causes bleeding damage over time";
                Globals.s3Name = "Bleed Attack";
                Globals.s3Tip = "Causes bleeding damage over time";
            }
            if (charOp4 == "Steel Song")
            {
                lblSkill3.Text = "Steel Song";
                lblS3Desc.Text = "Gives the singer resistance to damage for 4 rounds";
                Globals.s3Name = "Steel Song";
                Globals.s3Tip = "Gives the singer resistance to damage for 4 turns";
            }
            if (charOp4 == "Piercing Arrows")
            {
                lblSkill3.Text = "Piercing Shot";
                lblS3Desc.Text = "Deals extra damage to the enemy";
                Globals.s3Name = "Piercing Shot";
                Globals.s3Tip = "Deals extra damage to the enemy";
            }
            if (charOp4 == "Poison Arrows")
            {
                lblSkill3.Text = "Poisoned Shot";
                lblS3Desc.Text = "Poisons the enemy, causing damage over time";
                Globals.s3Name = "Poisoned shot";
                Globals.s3Tip = "Poisons the enemy, causing damage over time";
            }
            if (charOp4 == "Tarot")
            {
                lblSkill3.Text = "Tarot Card";
                lblS3Desc.Text = "Causes a variety of damaging effects";
                Globals.s3Name = "Tarot Card";
                Globals.s3Tip = "Causes a variety of damaging effects";
            }
            if (charOp4 == "Crystal")
            {
                lblSkill3.Text = "Divination";
                lblS3Desc.Text = "Adds a random buff";
                Globals.s3Name = "Divination";
                Globals.s3Tip = "Adds a random buff";
            }
            if (charOp4 == "Wand")
            {
                lblSkill3.Text = "Cursing Strike";
                lblS3Desc.Text = "Hits the target with a random curse";
                Globals.s3Name = "Cursing Strike";
                Globals.s3Tip = "Hits the target with a random curse";
            }
            if (charOp4 == "Scripture")
            {
                lblSkill3.Text = "Healing Light";
                lblS3Desc.Text = "Recovers a large amount of health";
                Globals.s3Name = "Healing Light";
                Globals.s3Tip = "Recovers a large amount of health";
            }
            if (charOp4 == "Athame")
            {
                lblSkill3.Text = "Blood Letting";
                lblS3Desc.Text = "Boosts attack power at the expense of health";
                Globals.s3Name = "Blood Letting";
                Globals.s3Tip = "Boosts attack power at the expense of health";
            }
            if (charOp4 == "Hollow Bullet")
            {
                lblSkill3.Text = "Hollowed Shot";
                lblS3Desc.Text = "A shot designed to cause extra pain";
                Globals.s3Name = "Hollowed shot";
                Globals.s3Tip = "A shot designed to cause extra pain";
            }
            if (charOp4 == "Lightning Bullet")
            {
                lblSkill3.Text = "Sudden Shot";
                lblS3Desc.Text = "A shot that always finds its target";
                Globals.s3Name = "Sudden Shot";
                Globals.s3Tip = "A shot that always finds its target";
            }
           
        }

        private void lsbSpecial_SelectedIndexChanged(object sender, EventArgs e)
        {
            string charOp5;
            if (lsbSpecial.SelectedIndex != -1)
                charOp5 = lsbSpecial.SelectedItem.ToString();
            else
                charOp5 = "";
            if (charOp5 == "Red Strike")
            {
                lblSkill4.Text = "Red Strike";
                Globals.s4Name = "Red Strike";
                lblS4Desc.Text = "A red-colored attack";
                Globals.s4Tip = "A red-colored attack";
            }
            if (charOp5 == "Blue Strike")
            {
                lblSkill4.Text = "Blue Strike";
                Globals.s4Name = "Blue Strike";
                lblS4Desc.Text = "A blue-colored attack";
                Globals.s4Tip = "A blue-colored attack";
            }
            if (charOp5 == "Yellow Strike")
            {
                lblSkill4.Text = "Yellow Strike";
                Globals.s4Name = "Yellow Strike";
                lblS4Desc.Text = "A yellow-colored attack";
                Globals.s4Tip = "A yellow-colored attack";
            }
            if (charOp5 == "Green Strike")
            {
                lblSkill4.Text = "Green Strike";
                Globals.s4Name = "Green Strike";
                lblS4Desc.Text = "A green-colored attack";
                Globals.s4Tip = "A green-colored attack";
            }
            if (charOp5 == "Orange Strike")
            {
                lblSkill4.Text = "Orange Strike";
                Globals.s4Name = "Orange Strike";
                lblS4Desc.Text = "A orange-colored attack";
                Globals.s4Tip = "A orange-colored attack";
            }
            if (charOp5 == "Purple Strike")
            {
                lblSkill4.Text = "Purple Strike";
                Globals.s4Name = "Purple Strike";
                lblS4Desc.Text = "A purple-colored attack";
                Globals.s4Tip = "A purple-colored attack";
            }

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Focus();
            txtName.Clear();
            listBox1.ClearSelected();
            lblClass.Text = "                            ";
            pcbHero.Image = null;
            lsbColor.Enabled = false;
            lsbColor.Items.Clear();
            lblColor.Text = "                            ";
            lsbWeapon.Enabled = false;
            lsbWeapon.Items.Clear();
            lblWeapon.Text = "                            ";
            lblSkill1.Text = "Name";
            lblS1Desc.Text = "Description";
            lblSkill2.Text = "Name";
            lblS2Desc.Text = "Description";
            lsbOffhand.Enabled = false;
            lsbOffhand.Items.Clear();
            lblOffhand.Text = "                            ";
            lblSkill3.Text = "Name";
            lblS3Desc.Text = "Description";
            lsbSpecial.Enabled = false;
            lsbSpecial.ClearSelected();
            lblSkill4.Text = "Name";
            lblS4Desc.Text = "Description";
            radEasy.Checked = false;
            radNorm.Checked = false;
            radHard.Checked = false;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && listBox1.SelectedIndex != -1 && lsbColor.SelectedIndex != -1 && lsbWeapon.SelectedIndex != -1 && lsbOffhand.SelectedIndex != -1 && lsbSpecial.SelectedIndex != -1 && radEasy.Checked == true || radNorm.Checked == true || radHard.Checked == true)
            {
                MainGame mnform = new MainGame();
                if (radEasy.Checked == true)
                    Globals.Difficulty = 10;
                if (radNorm.Checked == true)
                    Globals.Difficulty = 5;
                if (radHard.Checked == true)
                    Globals.Difficulty = 0;
                Globals.pName = txtName.Text.ToString();
                Globals.pClass = lblClass.Text.ToString();
                mnform.lblPlayerClass.Text = txtName.Text.ToString() + " the " + lblClass.Text.ToString();
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
                switch (lblWeapon.Text.ToString())
                {
                    case "Sword": Globals.ab1 = 101; Globals.ab1Cool = 4; Globals.ab2 = 102; Globals.ab2Val = 2; break;
                    case "Handaxe": Globals.ab1 = 101; Globals.ab1Cool = 3; Globals.ab2 = 103; Globals.ab2Val = 2; break;
                    case "Mace": Globals.ab1 = 104; Globals.ab1Cool = 3; Globals.ab2 = 105; Globals.ab2Val = 3; break;
                    case "Hammer": Globals.ab1 = 104; Globals.ab1Cool = 2; Globals.ab2 = 106; Globals.ab2Val = 4; break;
                    case "Staff": Globals.ab1 = 104; Globals.ab1Cool = 1; Globals.ab2 = 107; Globals.ab2Val = 1; break;
                    case "Spear": Globals.ab1 = 108; Globals.ab1Cool = 4; Globals.ab2 = 110; Globals.ab2Val = 3; break;
                    case "Bow": Globals.ab1 = 111; Globals.ab1Cool = 2; Globals.ab2 = 112; Globals.ab2Val = 2; break;
                    case "Sling": Globals.ab1 = 111; Globals.ab1Cool = 1; Globals.ab2 = 113; Globals.ab2Val = 2; break;
                    case "Gun": Globals.ab1 = 111; Globals.ab1Cool = 3; Globals.ab2 = 114; Globals.ab2Val = 4; break;
                }
                switch (lblSkill3.Text.ToString())
                {
                    //Buffs
                    case "Defend": Globals.ab3 = 301; Globals.ab3Cool = 6; break;
                    case "Steel Song": Globals.ab3 = 302; Globals.ab3Cool = 6; break;
                    case "Healing Light": Globals.ab3 = 304; Globals.ab3Cool = 4; break;
                    case "Blood Letting": Globals.ab3 = 305; Globals.ab3Cool = 6; break;
                    case "Divination": Globals.ab3 = 308; Globals.ab3Cool = 6; break;
                    //Debuffs
                    case "Bleed Attack": Globals.ab3 = 320; Globals.ab3Cool = 3; break;
                    case "Poisoned Shot": Globals.ab3 = 321; Globals.ab3Cool = 3; break;
                    case "Cursing Strike": Globals.ab3 = 322; Globals.ab3Cool = 2; break;
                    //Attacks
                    case "Piercing Shot": Globals.ab3 = 303; Globals.ab3Cool = 0; break;
                    case "Hollowed Shot": Globals.ab3 = 306; Globals.ab3Cool = 0; break;
                    case "Sudden Shot": Globals.ab3 = 307; Globals.ab3Cool = 0; break;
                    case "Tarot Card": Globals.ab3 = 330; Globals.ab3Cool = -1; break;
                    //Attacks + Buff

                    //Attacks + Debuff

                }

                switch (lblSkill4.Text.ToString())
                {
                    case "Red Strike": Globals.ab4 = 401; Globals.ab4Cool = -1; Globals.s4Color = "Red"; break;
                    case "Blue Strike": Globals.ab4 = 402; Globals.ab4Cool = -1; Globals.s4Color = "Blue"; break;
                    case "Yellow Strike": Globals.ab4 = 403; Globals.ab4Cool = -1; Globals.s4Color = "Yellow"; break;
                    case "Green Strike": Globals.ab4 = 404; Globals.ab4Cool = -1; Globals.s4Color = "Green"; break;
                    case "Orange Strike": Globals.ab4 = 405; Globals.ab4Cool = -1; Globals.s4Color = "Orange"; break;
                    case "Purple Strike": Globals.ab4 = 406; Globals.ab4Cool = -1; Globals.s4Color = "Purple"; break;
                }

                this.Hide();
                mnform.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please enter a name and fill in all fields", "Missing inputs");
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
    }
}
