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
    public partial class MainGame : Form
    {
        Player avatar = new Player();
        Monster Enemy = new Monster();
        CharDataSet cDS1 = new CharDataSet();
        CharDataSetTableAdapters.tblRedTableAdapter tblRed = new CharDataSetTableAdapters.tblRedTableAdapter();
        CharDataSetTableAdapters.tblBlueTableAdapter tblBlue = new CharDataSetTableAdapters.tblBlueTableAdapter();
        CharDataSetTableAdapters.tblYellowTableAdapter tblYellow = new CharDataSetTableAdapters.tblYellowTableAdapter();
        CharDataSetTableAdapters.tblGreenTableAdapter tblGreen = new CharDataSetTableAdapters.tblGreenTableAdapter();
        CharDataSetTableAdapters.tblOrangeTableAdapter tblOrange = new CharDataSetTableAdapters.tblOrangeTableAdapter();
        CharDataSetTableAdapters.tblPurpleTableAdapter tblPurple = new CharDataSetTableAdapters.tblPurpleTableAdapter();
        CharDataSetTableAdapters.tblBossTableAdapter tblBoss = new CharDataSetTableAdapters.tblBossTableAdapter();
        CharDataSetTableAdapters.tblPlayersTableAdapter tblPlay = new CharDataSetTableAdapters.tblPlayersTableAdapter();

        int DamResult = 0;
        //Dam Result is a global used in damage calcs. TODO: Check if this should be replaced by a return in the damage methods
        int pTempHP, pDam, pEvd, pWin, pLoss, combo, cd3, fgtCnt;
        //pTempHP stands in for player's current HP in combat. pDam, pEvd are used globally to track atk/def stats with buffs and power-up bonus.
        //pWin and pLoss are used to set win/lose conditions in combat. Used in multiple places.
        //combo and cd3 are used with the buttons. combo will likely change in the rewrite. cd3 is cooldown for the 3rd move, needs to be global.
        //fgtCnt is sorta self-explanatory.
        int enTempHP, enLAtk;
        //enTempHP stands in for enemy's current HP in combat. enLAtk tracks the enemy's last action to control how they're used.
        bool pDead = false, mDead = false, mBoss = false, gOver = false, gWin = false;
        //Fairly clear, necessary globals

        public MainGame()
        {
            InitializeComponent();
            //refresh the database
            tblRed.Fill(cDS1.tblRed);
            tblBlue.Fill(cDS1.tblBlue);
            tblYellow.Fill(cDS1.tblYellow);
            tblGreen.Fill(cDS1.tblGreen);
            tblOrange.Fill(cDS1.tblOrange);
            tblPurple.Fill(cDS1.tblPurple);
            tblBoss.Fill(cDS1.tblBoss);
            tblPlay.Fill(cDS1.tblPlayers);
        }

        private void frmLoad(object sender, EventArgs e)
        {
            //Build the player character based on choices from Creator
            PlayerCreate();

            //Make a monster
            EnemyFinder();

            //Initial starting stuff
            lblPWin.Text = pWin.ToString();
            lblPLoss.Text = pLoss.ToString();
            pTempHP = avatar.HEALTH;
            lblPHP.Text = pTempHP.ToString();

            pgbAvatar.Maximum = avatar.HEALTH;
            pgbAvatar.Value = pTempHP;

            enTempHP = Enemy.HEALTH;
            pgbMonster.Maximum = Enemy.HEALTH;
            pgbMonster.Value = enTempHP;
            lblMonHP.Text = enTempHP.ToString();
            lblEnTD.Text = Enemy.TEMPLEDAM.ToString();

            btnATK1.Text = Globals.s1Name;
            toolTip1.SetToolTip(btnATK1, Globals.s1Tip);
            btnATK2.Text = Globals.s2Name;
            toolTip1.SetToolTip(btnATK2, Globals.s2Tip);
            btnATK3.Text = Globals.s3Name;
            toolTip1.SetToolTip(btnATK3, Globals.s3Tip);
            btnATK4.Text = Globals.s4Name;
            toolTip1.SetToolTip(btnATK4, Globals.s4Tip);
            fgtCnt++;
            lblBattle.Text = "Battle\n" + fgtCnt.ToString();
            
        }

        private void lblShow1_Click(object sender, EventArgs e) //Show/Hide information about the first ability
        {
            if (lblDet1.Visible == false)
            {
                lblDet1.Text = Globals.s1Tip + "\nBase Power: " + (avatar.FORCE + Globals.bonDam) + "\nColor: None\nCombo: " + combo.ToString() + "\n";
                lblDet1.Visible = true;
                lblShow1.Text = "Hide";
            }
            else
            {
                lblDet1.Visible = false;
                lblShow1.Text = "Details";
            }
        }

        private void lblShow2_Click(object sender, EventArgs e) //Show/Hide information about the second ability
        {
            if (lblDet2.Visible == false)
            {
                lblDet2.Text = Globals.s2Tip + "\nBase Power: " + (avatar.FORCE + Globals.bonDam + Globals.ab2Val).ToString() + "\nColor: " + Globals.pColor.ToString() + "\n";
                lblDet2.Visible = true;
                lblShow2.Text = "Hide";
            }
            else
            {
                lblDet2.Visible = false;
                lblShow2.Text = "Details";
            }
        }

        private void lblShow3_Click(object sender, EventArgs e) //Show/Hide information about the third ability
        {
            if (lblDet3.Visible == false)
            {
                lblDet3.Text = Globals.s3Tip + "\nCooldown: " + Globals.ab3Cool.ToString();
                lblDet3.Visible = true;
                lblShow3.Text = "Hide";
            }
            else
            {
                lblDet3.Visible = false;
                lblShow3.Text = "Details";
            }
        }

        private void lblShow4_Click(object sender, EventArgs e) //Show/Hide information about the fourth ability
        {
            if (lblDet4.Visible == false)
            {
                lblDet4.Text = Globals.s4Tip + "\nBase Power: " + (avatar.FORCE + Globals.bonDam) + "\nColor: " + Globals.s4Color.ToString() + "\n";
                lblDet4.Visible = true;
                lblShow4.Text = "Hide";
            }
            else
            {
                lblDet4.Visible = false;
                lblShow4.Text = "Details";
            }
        }

        private void btnATK1_Click(object sender, EventArgs e) //Standard attack, colorless, can combo
        {
            int intHit = 0;
            string hitMsg = "";
            pDam = avatar.FORCE + Globals.bonDam;
            combo += 1;
            Random cmbCntr = new Random();

            //Player Phase Start
            rtbEventLog.AppendText("------------- Player Phase\n");
            //Determine if Frozen/Stunned, HoTs/DoTs, de/buff counters
            bool noTurn = false;
            bool player = true;
            StateCheck(avatar.BUFFBIT, avatar.BUFFVAL, avatar.BUFFTIME, avatar.DEBUFFBIT, avatar.DEBUFFVAL, avatar.DEBUFFTIME, player, out noTurn);

            //Player Combat Start
            if (noTurn == false)
            {
                do
                {
                    intHit++;
                    DamageCalc(pDam, 0, avatar.BUFFBIT, Enemy.EVADE, Enemy.COLOR, Enemy.BUFFBIT, out hitMsg);
                    rtbEventLog.AppendText("Strike " + intHit + ": " + hitMsg);
                    WinTest();
                }
                while (cmbCntr.Next(1, 100) + combo >= 88 && intHit < Globals.ab1Cool && mDead != true);
            }
            else
                rtbEventLog.AppendText("You are disabled and cannot act!\n");

            //Enemy Phase Start
            rtbEventLog.AppendText("------------- " + lblEnName.Text + " Phase\n");
            player = false;
            //Check for all the stuff
            StateCheck(Enemy.BUFFBIT, Enemy.BUFFVAL, Enemy.BUFFTIME, Enemy.DEBUFFBIT, Enemy.DEBUFFVAL, Enemy.DEBUFFTIME, player, out noTurn);

            //Enemy Combat Start
            if (noTurn == false && mDead == false)
            {
                EnemyDamCalc(Enemy.FORCE, Enemy.COLOR, Enemy.BUFFBIT, pEvd, avatar.COLOR, avatar.BUFFBIT);
                LoseTest();
            }
            else
                rtbEventLog.AppendText(lblEnName.Text.ToString() + " is debilitated and cannot act.\n");

            //Goto next round, next fight, or Win/Lose game
            Restart();
        }

        private void btnATK2_Click(object sender, EventArgs e) //Standard attack with bonus damage and users Hero's color
        {
            string hitMsg = "";
            combo = 0;
            pDam = avatar.FORCE + Globals.bonDam + avatar.AB2VAL;
            pEvd = avatar.EVADE + Globals.bonEvd + avatar.BUFFVAL[9];

            //Player Phase Start
            rtbEventLog.AppendText("------------- Player Phase\n");
            //Determine if Frozen/Stunned, HoTs/DoTs, de/buff counters
            bool noTurn = false;
            bool player = true;
            StateCheck(avatar.BUFFBIT, avatar.BUFFVAL, avatar.BUFFTIME, avatar.DEBUFFBIT, avatar.DEBUFFVAL, avatar.DEBUFFTIME, player, out noTurn);

            //Player Combat Start
            if (noTurn == false)
            {
                DamageCalc(pDam, avatar.COLOR, avatar.BUFFBIT, Enemy.EVADE, Enemy.COLOR, Enemy.BUFFBIT, out hitMsg);
                rtbEventLog.AppendText(hitMsg);
                WinTest();
            }
            else
                rtbEventLog.AppendText("You are disabled and cannot act!\n");

            //Enemy Phase Start
            rtbEventLog.AppendText("------------- " + lblEnName.Text + " Phase\n");
            player = false;
            //Check for all the stuff
            StateCheck(Enemy.BUFFBIT, Enemy.BUFFVAL, Enemy.BUFFTIME, Enemy.DEBUFFBIT, Enemy.DEBUFFVAL, Enemy.DEBUFFTIME, player, out noTurn);

            //Enemy Combat Start
            if (noTurn == false && mDead == false)
            {
                EnemyDamCalc(Enemy.FORCE, Enemy.COLOR, Enemy.BUFFBIT, pEvd, avatar.COLOR, avatar.BUFFBIT);
                LoseTest();
            }
            else
                rtbEventLog.AppendText(lblEnName.Text.ToString() + " is debilitated and cannot act.\n");

            //Goto next round, next fight, or Win/Lose game
            Restart();
        }

        private void btnATK3_Click(object sender, EventArgs e) //Special attack, can be a variety of things 
        {
            string hitMsg = "";
            combo = 0;
            pDam = avatar.FORCE + Globals.bonDam;
            pEvd = avatar.EVADE + Globals.bonEvd + avatar.BUFFVAL[9];

            //Player Phase Start
            rtbEventLog.AppendText("------------- Player Phase\n");
            //Determine if Frozen/Stunned, HoTs/DoTs, de/buff counters
            bool noTurn = false;
            bool player = true;
            StateCheck(avatar.BUFFBIT, avatar.BUFFVAL, avatar.BUFFTIME, avatar.DEBUFFBIT, avatar.DEBUFFVAL, avatar.DEBUFFTIME, player, out noTurn);

            //Player Combat Start
            if (noTurn == false)
            {
                switch (avatar.ABILITY3)
                {
                    //Buffs
                    case 301: Buff(7, 50, 5); rtbEventLog.AppendText("You prepare to defend yourself from attacks!"); break; //Shield Defend
                    case 302: Buff(7, 20, 5); rtbEventLog.AppendText("The song makes you feel more durable!"); break; //Steel Song Defend
                    case 304: Buff(1, 200, 0); rtbEventLog.AppendText("Some of your wounds have been recovered!"); break; //Healing Light Heal
                    case 305: Buff(5, 4, 5); if (pTempHP - 50 <= 0) pTempHP = 1; else pTempHP -= 50; rtbEventLog.AppendText("Your attack power is increased, at the cost of some health."); break; //Athame Attack/-HP
                    case 308: int[] cbAbil = { 7, 8, 2, 6, 3, 5 }; int[] cbval = { 5, 7, 9 }; int[] cbtime = { 3, 4, 5 }; int cbsav1, cbsav2, cbsav3; Random cball = new Random(); cbsav1 = cball.Next(0, 7); cbsav2 = cball.Next(1, 4); cbsav3 = cball.Next(1, 4); Buff(cbAbil[cbsav1], cbAbil[cbsav2], cbAbil[cbsav3]); if (cbAbil[cbsav1] == 0) rtbEventLog.AppendText("You feel protected!"); else if (cbAbil[cbsav1] == 1) rtbEventLog.AppendText("You feel lighter on your feet!"); else if (cbAbil[cbsav1] == 2) rtbEventLog.AppendText("You feel restored!"); else if (cbAbil[cbsav1] == 3) rtbEventLog.AppendText("You feel prickly!"); else if (cbAbil[cbsav1] == 4) rtbEventLog.AppendText("You feel wrapped in recovering energy!"); else if (cbAbil[cbsav1] == 5) rtbEventLog.AppendText("You feel stronger!"); break; //Divination Random Buff
                    //Debuffs
                    case 320: DamageCalc(3, avatar.COLOR, avatar.BUFFBIT, Enemy.EVADE, Enemy.COLOR, Enemy.BUFFBIT, out hitMsg); rtbEventLog.AppendText(hitMsg); if (DamResult > 0) { Debuff(player, Enemy.DEBUFFBIT, Enemy.DEBUFFVAL, Enemy.DEBUFFTIME, 1, 15, 7, avatar.COLOR, Enemy.COLOR, out hitMsg); rtbEventLog.AppendText(hitMsg); } break; //Bleed Attack DoT
                    case 321: Debuff(player, Enemy.DEBUFFBIT, Enemy.DEBUFFVAL, Enemy.DEBUFFTIME, 1, 45, 3, avatar.COLOR, Enemy.COLOR, out hitMsg); rtbEventLog.AppendText(hitMsg); break; //Poison Arrows DoT
                    case 322: Random wand = new Random(); int waDam, waTime; waDam = wand.Next(5, 61); waTime = wand.Next(2, 9); Debuff(player, Enemy.DEBUFFBIT, Enemy.DEBUFFVAL, Enemy.DEBUFFTIME, 1, waDam, waTime, avatar.COLOR, Enemy.COLOR, out hitMsg); rtbEventLog.AppendText(hitMsg); break; //Cursing Strike Random Debuff
                    //Attacks
                    case 303: DamageCalc(pDam, avatar.COLOR, avatar.BUFFBIT, 0, Enemy.COLOR, Enemy.BUFFBIT, out hitMsg); rtbEventLog.AppendText(hitMsg); break; //Piercing Arrows
                    case 306: pDam += 3; DamageCalc(pDam, avatar.COLOR, avatar.BUFFBIT, 0, Enemy.COLOR, Enemy.BUFFBIT, out hitMsg); rtbEventLog.AppendText(hitMsg); break; //Hollowed Shot
                    case 307: DamageCalc(pDam, avatar.COLOR, avatar.BUFFBIT, 0, Enemy.COLOR, Enemy.BUFFBIT, out hitMsg); rtbEventLog.AppendText(hitMsg); break; //Sudden Shot
                    case 330: Random tarot = new Random(); int tdam; tdam = tarot.Next(0, 7) - 2; pDam += tdam; DamageCalc(pDam, avatar.COLOR, avatar.BUFFBIT, 0, Enemy.COLOR, Enemy.BUFFBIT, out hitMsg); break; //Tarot Cards Random Damage
                    //Attacks + Buff
                    //Attacks + Debuff
                }
                cd3 = Globals.ab3Cool + 1;
            }
            else
                rtbEventLog.AppendText("You are disabled and cannot act!\n");

            //Enemy Phase Start
            rtbEventLog.AppendText("------------- " + lblEnName.Text + " Phase\n");
            player = false;
            //Check for all the stuff
            StateCheck(Enemy.BUFFBIT, Enemy.BUFFVAL, Enemy.BUFFTIME, Enemy.DEBUFFBIT, Enemy.DEBUFFVAL, Enemy.DEBUFFTIME, player, out noTurn);

            //Enemy Combat Start
            if (noTurn == false && mDead == false)
            {
                EnemyDamCalc(Enemy.FORCE, Enemy.COLOR, Enemy.BUFFBIT, pEvd, avatar.COLOR, avatar.BUFFBIT);
                LoseTest();
            }
            else
                rtbEventLog.AppendText(lblEnName.Text.ToString() + " is debilitated and cannot act.\n");

            //Goto next round, next fight, or Win/Lose game
            Restart();
        }

        private void btnATK4_Click(object sender, EventArgs e) //Currently just standard attacks that use a set color
        {
            string hitMsg = "";
            pDam = avatar.FORCE + Globals.bonDam;
            pEvd = avatar.EVADE + Globals.bonEvd + avatar.BUFFVAL[9];
            combo = 0;

            //Player Phase Start
            rtbEventLog.AppendText("------------- Player Phase\n");
            //Determine if Frozen/Stunned, HoTs/DoTs, de/buff counters
            bool noTurn = false;
            bool player = true;
            StateCheck(avatar.BUFFBIT, avatar.BUFFVAL, avatar.BUFFTIME, avatar.DEBUFFBIT, avatar.DEBUFFVAL, avatar.DEBUFFTIME, player, out noTurn);

            //Player Combat Start
            if (noTurn == false)
            {
                switch (avatar.ABILITY4)
                {
                    case 401: DamageCalc(pDam, 1, avatar.BUFFBIT, Enemy.EVADE, Enemy.COLOR, Enemy.BUFFBIT, out hitMsg); break;
                    case 402: DamageCalc(pDam, 2, avatar.BUFFBIT, Enemy.EVADE, Enemy.COLOR, Enemy.BUFFBIT, out hitMsg); break;
                    case 403: DamageCalc(pDam, 3, avatar.BUFFBIT, Enemy.EVADE, Enemy.COLOR, Enemy.BUFFBIT, out hitMsg); break;
                    case 404: DamageCalc(pDam, 4, avatar.BUFFBIT, Enemy.EVADE, Enemy.COLOR, Enemy.BUFFBIT, out hitMsg); break;
                    case 405: DamageCalc(pDam, 5, avatar.BUFFBIT, Enemy.EVADE, Enemy.COLOR, Enemy.BUFFBIT, out hitMsg); break;
                    case 406: DamageCalc(pDam, 6, avatar.BUFFBIT, Enemy.EVADE, Enemy.COLOR, Enemy.BUFFBIT, out hitMsg); break;
                }
                rtbEventLog.AppendText(hitMsg);
                WinTest();
            }
            else
                rtbEventLog.AppendText("You are disabled and cannot act!\n");

            //Enemy Phase Start
            rtbEventLog.AppendText("------------- " + lblEnName.Text + " Phase\n");
            player = false;
            //Check for all the stuff
            StateCheck(Enemy.BUFFBIT, Enemy.BUFFVAL, Enemy.BUFFTIME, Enemy.DEBUFFBIT, Enemy.DEBUFFVAL, Enemy.DEBUFFTIME, player, out noTurn);

            //Enemy Combat Start
            if (noTurn == false && mDead == false)
            {
                EnemyDamCalc(Enemy.FORCE, Enemy.COLOR, Enemy.BUFFBIT, pEvd, avatar.COLOR, avatar.BUFFBIT);
                LoseTest();
            }
            else
                rtbEventLog.AppendText(lblEnName.Text.ToString() + " is debilitated and cannot act.\n");

            //Goto next round, next fight, or Win/Lose game
            Restart();
        }

        public void PlayerCreate()
        {
            int[] playclass = {0,1,5,9,12,13,17}; //what is this for?
            if (Globals.pColor == "Red")
            {
                avatar.COLOR = 1;
                groupBox1.BackColor = Color.Crimson;
            }
            if (Globals.pColor == "Blue")
            {
                avatar.COLOR = 2;
                groupBox1.BackColor = Color.RoyalBlue;
            }
            if (Globals.pColor == "Yellow")
            {
                avatar.COLOR = 3;
                groupBox1.BackColor = Color.Yellow;
            }
            if (Globals.pColor == "Green")
            {
                avatar.COLOR = 4;
                groupBox1.BackColor = Color.ForestGreen;
            }
            if (Globals.pColor == "Orange")
            {
                avatar.COLOR = 5;
                groupBox1.BackColor = Color.DarkOrange;
            }
            if (Globals.pColor == "Purple")
            {
                avatar.COLOR = 6;
                groupBox1.BackColor = Color.MediumPurple;
            }

            avatar.HEALTH = Convert.ToInt32(cDS1.tblPlayers.Rows[playclass[Globals.placa]].ItemArray[1]);
            avatar.FORCE = Convert.ToInt32(cDS1.tblPlayers.Rows[playclass[Globals.placa]].ItemArray[2]);
            avatar.EVADE = Convert.ToInt32(cDS1.tblPlayers.Rows[playclass[Globals.placa]].ItemArray[3]);
            avatar.ABILITY1 = Globals.ab1;
            avatar.ABILITY2 = Globals.ab2;
            avatar.AB2VAL = Globals.ab2Val;
            avatar.ABILITY3 = Globals.ab3;
            avatar.AB3COOL = Globals.ab3Cool;
            avatar.ABILITY4 = Globals.ab4;
        }

        public void EnemyFinder()
        {
            /* EnemyFinder() rolls a d30 to find an enemy for the player to fight. The default spread is 10% boss, 10% Green, Orange, or Purple, and
             * 20% Red, Blue, or Yellow. This both stacks things towards easier enemies (RBY) and makes it more likely that characters made with 0 unlocks
             * always have their abilities as useful. As you win more fights, the roller starts removing numbers from the top end which lowers the RBY pool
             * of enemies, raising the odds of facing POG enemies and bosses. This ensures that eventually a boss will be rolled, but odds are far, far better
             * that the player will be winning enough fights to max out their character and fully protect before that happens. This may or may not be rebalanced.*/
            Random enFind = new Random();
            int enGen, enTable;
            
            //Decide if bosses are potential enemies yet
            if (Globals.Difficulty - fgtCnt <= 0)
            {
                enGen = enFind.Next(1, 30 - fgtCnt);
            }
            else
            {
                enGen = enFind.Next(4, 30 - fgtCnt);
            }

            //Roll for the appropriate enemy
            if (enGen == 1 || enGen == 2 || enGen == 3) //Bosses
            {
                enTable = enFind.Next(1, 20);
                lblEnName.Text = cDS1.tblBoss.Rows[enTable - 1].ItemArray[0].ToString();
                Enemy.HEALTH = Convert.ToInt32(cDS1.tblBoss.Rows[enTable - 1].ItemArray[1]);
                Enemy.FORCE = Convert.ToInt32(cDS1.tblBoss.Rows[enTable - 1].ItemArray[2]);
                Enemy.EVADE = Convert.ToInt32(cDS1.tblBoss.Rows[enTable - 1].ItemArray[3]);
                Enemy.COLOR = Convert.ToInt32(cDS1.tblBoss.Rows[enTable - 1].ItemArray[4]);
                Enemy.TEMPLEDAM = Convert.ToInt32(cDS1.tblBoss.Rows[enTable - 1].ItemArray[5]);
                Enemy.ABILITY1 = Convert.ToInt32(cDS1.tblBoss.Rows[enTable - 1].ItemArray[6]);
                Enemy.ABILITY2 = Convert.ToInt32(cDS1.tblBoss.Rows[enTable - 1].ItemArray[7]);
                Enemy.ABILITY3 = Convert.ToInt32(cDS1.tblBoss.Rows[enTable - 1].ItemArray[8]);
                Enemy.ABILITY4 = Convert.ToInt32(cDS1.tblBoss.Rows[enTable - 1].ItemArray[9]);
                groupBox2.BackColor = Color.Snow;
                mBoss = true;
            }
            if (enGen == 4 || enGen == 7 || enGen == 10) //Green
            {
                enTable = enFind.Next(1, 15);
                lblEnName.Text = cDS1.tblGreen.Rows[enTable - 1].ItemArray[0].ToString();
                Enemy.HEALTH = Convert.ToInt32(cDS1.tblGreen.Rows[enTable - 1].ItemArray[1]);
                Enemy.FORCE = Convert.ToInt32(cDS1.tblGreen.Rows[enTable - 1].ItemArray[2]);
                Enemy.EVADE = Convert.ToInt32(cDS1.tblGreen.Rows[enTable - 1].ItemArray[3]);
                Enemy.COLOR = 4;
                groupBox2.BackColor = Color.ForestGreen;
                Enemy.TEMPLEDAM = Convert.ToInt32(cDS1.tblGreen.Rows[enTable - 1].ItemArray[4]);
                Enemy.ABILITY1 = Convert.ToInt32(cDS1.tblGreen.Rows[enTable - 1].ItemArray[5]);
                Enemy.ABILITY2 = Convert.ToInt32(cDS1.tblGreen.Rows[enTable - 1].ItemArray[6]);
                Enemy.ABILITY3 = Convert.ToInt32(cDS1.tblGreen.Rows[enTable - 1].ItemArray[7]);
                Enemy.ABILITY4 = Convert.ToInt32(cDS1.tblGreen.Rows[enTable - 1].ItemArray[8]);
            }
            if (enGen == 5 || enGen == 8 || enGen == 11) //Orange
            {
                enTable = enFind.Next(1, 15);
                lblEnName.Text = cDS1.tblOrange.Rows[enTable - 1].ItemArray[0].ToString();
                Enemy.HEALTH = Convert.ToInt32(cDS1.tblOrange.Rows[enTable - 1].ItemArray[1]);
                Enemy.FORCE = Convert.ToInt32(cDS1.tblOrange.Rows[enTable - 1].ItemArray[2]);
                Enemy.EVADE = Convert.ToInt32(cDS1.tblOrange.Rows[enTable - 1].ItemArray[3]);
                Enemy.COLOR = 5;
                groupBox2.BackColor = Color.DarkOrange;
                Enemy.TEMPLEDAM = Convert.ToInt32(cDS1.tblOrange.Rows[enTable - 1].ItemArray[4]);
                Enemy.ABILITY1 = Convert.ToInt32(cDS1.tblOrange.Rows[enTable - 1].ItemArray[5]);
                Enemy.ABILITY2 = Convert.ToInt32(cDS1.tblOrange.Rows[enTable - 1].ItemArray[6]);
                Enemy.ABILITY3 = Convert.ToInt32(cDS1.tblOrange.Rows[enTable - 1].ItemArray[7]);
                Enemy.ABILITY4 = Convert.ToInt32(cDS1.tblOrange.Rows[enTable - 1].ItemArray[8]);
            }
            if (enGen == 6 || enGen == 9 || enGen == 12) //Purple
            {
                enTable = enFind.Next(1, 15);
                lblEnName.Text = cDS1.tblPurple.Rows[enTable - 1].ItemArray[0].ToString();
                Enemy.HEALTH = Convert.ToInt32(cDS1.tblPurple.Rows[enTable - 1].ItemArray[1]);
                Enemy.FORCE = Convert.ToInt32(cDS1.tblPurple.Rows[enTable - 1].ItemArray[2]);
                Enemy.EVADE = Convert.ToInt32(cDS1.tblPurple.Rows[enTable - 1].ItemArray[3]);
                Enemy.COLOR = 6;
                groupBox2.BackColor = Color.MediumPurple;
                Enemy.TEMPLEDAM = Convert.ToInt32(cDS1.tblPurple.Rows[enTable - 1].ItemArray[4]);
                Enemy.ABILITY1 = Convert.ToInt32(cDS1.tblPurple.Rows[enTable - 1].ItemArray[5]);
                Enemy.ABILITY2 = Convert.ToInt32(cDS1.tblPurple.Rows[enTable - 1].ItemArray[6]);
                Enemy.ABILITY3 = Convert.ToInt32(cDS1.tblPurple.Rows[enTable - 1].ItemArray[7]);
                Enemy.ABILITY4 = Convert.ToInt32(cDS1.tblPurple.Rows[enTable - 1].ItemArray[8]);
            }
            if (enGen == 13 || enGen == 18 || enGen == 21 || enGen == 24 || enGen == 26 || enGen == 29) //Red
            {
                enTable = enFind.Next(1, 15);
                lblEnName.Text = cDS1.tblRed.Rows[enTable - 1].ItemArray[0].ToString();
                Enemy.HEALTH = Convert.ToInt32(cDS1.tblRed.Rows[enTable - 1].ItemArray[1]);
                Enemy.FORCE = Convert.ToInt32(cDS1.tblRed.Rows[enTable - 1].ItemArray[2]);
                Enemy.EVADE = Convert.ToInt32(cDS1.tblRed.Rows[enTable - 1].ItemArray[3]);
                Enemy.COLOR = 1;
                groupBox2.BackColor = Color.Crimson;
                Enemy.TEMPLEDAM = Convert.ToInt32(cDS1.tblRed.Rows[enTable - 1].ItemArray[4]);
                Enemy.ABILITY1 = Convert.ToInt32(cDS1.tblRed.Rows[enTable - 1].ItemArray[5]);
                Enemy.ABILITY2 = Convert.ToInt32(cDS1.tblRed.Rows[enTable - 1].ItemArray[6]);
                Enemy.ABILITY3 = Convert.ToInt32(cDS1.tblRed.Rows[enTable - 1].ItemArray[7]);
                Enemy.ABILITY4 = Convert.ToInt32(cDS1.tblRed.Rows[enTable - 1].ItemArray[8]);
            }
            if (enGen == 14 || enGen == 17 || enGen == 19 || enGen == 22 || enGen == 27 || enGen == 30) //Blue
            {
                enTable = enFind.Next(1, 15);
                lblEnName.Text = cDS1.tblBlue.Rows[enTable - 1].ItemArray[0].ToString();
                Enemy.HEALTH = Convert.ToInt32(cDS1.tblBlue.Rows[enTable - 1].ItemArray[1]);
                Enemy.FORCE = Convert.ToInt32(cDS1.tblBlue.Rows[enTable - 1].ItemArray[2]);
                Enemy.EVADE = Convert.ToInt32(cDS1.tblBlue.Rows[enTable - 1].ItemArray[3]);
                Enemy.COLOR = 2;
                groupBox2.BackColor = Color.RoyalBlue;
                Enemy.TEMPLEDAM = Convert.ToInt32(cDS1.tblBlue.Rows[enTable - 1].ItemArray[4]);
                Enemy.ABILITY1 = Convert.ToInt32(cDS1.tblBlue.Rows[enTable - 1].ItemArray[5]);
                Enemy.ABILITY2 = Convert.ToInt32(cDS1.tblBlue.Rows[enTable - 1].ItemArray[6]);
                Enemy.ABILITY3 = Convert.ToInt32(cDS1.tblBlue.Rows[enTable - 1].ItemArray[7]);
                Enemy.ABILITY4 = Convert.ToInt32(cDS1.tblBlue.Rows[enTable - 1].ItemArray[8]);
            }
            if (enGen == 15 || enGen == 16 || enGen == 20 || enGen == 23 || enGen == 25 || enGen == 28) //Yellow
            {
                enTable = enFind.Next(1, 15);
                lblEnName.Text = cDS1.tblYellow.Rows[enTable - 1].ItemArray[0].ToString();
                Enemy.HEALTH = Convert.ToInt32(cDS1.tblYellow.Rows[enTable - 1].ItemArray[1]);
                Enemy.FORCE = Convert.ToInt32(cDS1.tblYellow.Rows[enTable - 1].ItemArray[2]);
                Enemy.EVADE = Convert.ToInt32(cDS1.tblYellow.Rows[enTable - 1].ItemArray[3]);
                Enemy.COLOR = 3;
                groupBox2.BackColor = Color.Yellow;
                Enemy.TEMPLEDAM = Convert.ToInt32(cDS1.tblYellow.Rows[enTable - 1].ItemArray[4]);
                Enemy.ABILITY1 = Convert.ToInt32(cDS1.tblYellow.Rows[enTable - 1].ItemArray[5]);
                Enemy.ABILITY2 = Convert.ToInt32(cDS1.tblYellow.Rows[enTable - 1].ItemArray[6]);
                Enemy.ABILITY3 = Convert.ToInt32(cDS1.tblYellow.Rows[enTable - 1].ItemArray[7]);
                Enemy.ABILITY4 = Convert.ToInt32(cDS1.tblYellow.Rows[enTable - 1].ItemArray[8]);
            }
        }

        public void StateCheck(int[] bBit, int[] bVal, int[] bTime, int[] dBit, int[] dVal, int[] dTime, bool player, out bool fsState)
        {
            fsState = false;
            Random rngState = new Random();
            //Because I need somewhere to write this down other than papers I keep losing:
            //Buffs: 1 - Heal, 2 - Cleanse, 3 - Regen, 4 - Restore, 5 - Attack, 6 - Retaliate, 7 - Defend, 8 - Evade, 9 - Full Evade, 10 - Super
            //Debuffs: 1 - Damage over Time, 2 - Root, 3 - Paralyze, 4 - Stun, 5 - Freeze, 6 - Colorblind
            //Someday I'll bother listing off what these are supposed to do, but for now I just need this
            
            //Check HoTs and DoTs
            switch (player)
            {
                case true:
                    if (BuffChk(bBit,3) == true)
                    {
                        if (pTempHP + avatar.BUFFVAL[3] >= avatar.HEALTH + Globals.bonHP) { pTempHP = avatar.HEALTH + Globals.bonHP; rtbEventLog.AppendText("You have fully recovered your health!\n"); pgbAvatar.Value = pTempHP; lblPHP.Text = pTempHP.ToString(); } else { pTempHP += avatar.BUFFVAL[3]; rtbEventLog.AppendText("You regenerate for " + avatar.BUFFVAL[3] + " HP.\n"); pgbAvatar.Value = pTempHP; lblPHP.Text = pTempHP.ToString(); }
					}
                    if (BuffChk(bBit, 4) == true)
                    {
                        if (pTempHP + avatar.BUFFVAL[4] >= avatar.HEALTH + Globals.bonHP) { pTempHP = avatar.HEALTH + Globals.bonHP; rtbEventLog.AppendText("You have fully recovered your health!\n"); pgbAvatar.Value = pTempHP; lblPHP.Text = pTempHP.ToString(); } else { pTempHP += avatar.BUFFVAL[4]; rtbEventLog.AppendText("You regenerate for " + avatar.BUFFVAL[4] + " HP.\n"); pgbAvatar.Value = pTempHP; lblPHP.Text = pTempHP.ToString(); }
                    }
                    if (BuffChk(dBit, 1) == true)
                    {
                        if (pTempHP - avatar.DEBUFFVAL[1] <= 0) { pTempHP = 1; rtbEventLog.AppendText("You struggle against the nearly lethal pain surging through your body!\n"); } else pTempHP -= avatar.DEBUFFVAL[1]; pgbAvatar.Value = pTempHP; lblPHP.Text = pTempHP.ToString(); rtbEventLog.AppendText("Lingering effects damage you for " + avatar.DEBUFFVAL + " HP.\n"); pgbAvatar.Value = pTempHP; lblPHP.Text = pTempHP.ToString();
                    }
                    break;
                case false:
                    if (BuffChk(bBit, 3) == true)
                    {
                        if (enTempHP + Enemy.BUFFVAL[3] >= Enemy.HEALTH) { enTempHP = Enemy.HEALTH; rtbEventLog.AppendText(lblEnName.Text.ToString() + " has regenerated to full health!\n"); pgbMonster.Value = enTempHP; lblMonHP.Text = enTempHP.ToString(); } else { enTempHP += Enemy.BUFFVAL[3]; rtbEventLog.AppendText(lblEnName.Text.ToString() + " regenerates for " + Enemy.BUFFVAL[3] + " HP.\n"); pgbMonster.Value = enTempHP; lblMonHP.Text = enTempHP.ToString(); }
                    }
                    if (BuffChk(bBit, 4) == true)
                    {
                        if (enTempHP + Enemy.BUFFVAL[4] >= Enemy.HEALTH) { enTempHP = Enemy.HEALTH; rtbEventLog.AppendText(lblEnName.Text.ToString() + " has regenerated to full health!\n"); pgbMonster.Value = enTempHP; lblMonHP.Text = enTempHP.ToString(); } else { enTempHP += Enemy.BUFFVAL[4]; rtbEventLog.AppendText(lblEnName.Text.ToString() + " regenerates for " + Enemy.BUFFVAL[4] + " HP.\n"); pgbMonster.Value = enTempHP; lblMonHP.Text = enTempHP.ToString(); }
                    }
                    if (BuffChk(dBit, 1) == true)
                    {
                        if (enTempHP - Enemy.DEBUFFVAL[1] <= 0) { enTempHP = 1; rtbEventLog.AppendText(lblEnName.Text.ToString() + " nearly succumbs to the darkness!\n"); pgbMonster.Value = enTempHP; lblMonHP.Text = enTempHP.ToString(); } else { enTempHP -= Enemy.DEBUFFVAL[1]; rtbEventLog.AppendText(lblEnName.Text.ToString() + " is damaged for " + Enemy.DEBUFFVAL[1] + " HP.\n"); pgbMonster.Value = enTempHP; lblMonHP.Text = enTempHP.ToString(); }
                    }
               break;
            }

            //Check Para/Stun
            if (BuffChk(dBit, 3) == true)
                if (rngState.Next(1, 101) < 50) fsState = true; else fsState = false;
            if (BuffChk(dBit, 4) == true || BuffChk(dBit, 5) == true)
                fsState = true;
        }

        public int EnemyDamCalc(int uDamage, int uColor, int[] uBuff, int tEvd, int tColor, int[] tBuff)
        {
            double Damage = 0;
            int[] colAry = { 0, 2, 3, 1, 5, 6, 4, 7, 8 };
			double[] colComp = { 0, 1 };
            bool tColLow = false;
            bool tColHigh = false;
            bool tEvaYes = BuffChk(tBuff, 9);
            bool tDefYes = BuffChk(tBuff, 7);
            bool tSupYes = BuffChk(uBuff, 10);
            bool eAtkYes = BuffChk(uBuff, 5);
            bool eSupYes = BuffChk(uBuff, 10);
			bool atkHit = false;
            //int[] atkType = { 0, Enemy.ABILITY1, Enemy.ABILITY2, Enemy.ABILITY3, Enemy.ABILITY4 };
            Random MonHit = new Random();
            //Roll to choose between the enemy's attacks
            enLAtk = MonHit.Next(1, Enemy.TEMPLEDAM + 1);
			//Determine color bonus or penalty
            if (colAry[tColor] <= 3)
                tColLow = true;
            else
                tColHigh = true;
			if (colAry[uColor] == tColor || uColor == 7 && tColLow == true || uColor == 8 && tColHigh == true)
			{
                colComp[0] = 3;
				colComp[1] = 1.25;
            }
			else if (colAry[tColor] == uColor)
			{
                colComp[0] = -3;
				colComp[1] = 0.75;
			}
            //Roll toHit, 1d20 vs tEvd, if miss then skip to end and return 0
			if (MonHit.Next(1, 21) + colComp[0] > tEvd)
				atkHit = true;
			else
				atkHit = false;
			//Damage calcs
			if (atkHit == false)
			{
				DamResult = 0;
				rtbEventLog.AppendText(lblEnName.Text.ToString() + " misses you with its attack!\n");
			}
			else if (tEvaYes == true)
			{
				DamResult = 0;
				rtbEventLog.AppendText("You evade " + lblEnName.Text.ToString() + "'s attack!\n");
			}
			else
			{
				//This is where the switch/case will eventually fit
                //switch (atkType[enLAtk]) //To determine the ability that the monster uses, based on the roll done above
                //case 199: uDamage += 2; GOTO default;
                //default:
                Damage = Math.Floor(((Convert.ToDouble(uDamage) * MonHit.Next(89, 107)) / 10) * colComp[1]);
                DamResult = Convert.ToInt32(Damage);
                //Add or subtract damage from Buffs
                if (eAtkYes == true || eSupYes == true)
                    DamResult += Enemy.BUFFVAL[5] + Enemy.BUFFVAL[10];
                if (tDefYes == true || tSupYes == true)
                    DamResult -= avatar.BUFFVAL[7] + avatar.BUFFVAL[10];
                rtbEventLog.AppendText(lblEnName.Text.ToString() + " hits you for " + DamResult + " damage!\n");
                //break;
			}
			
			//Final Damage
			return DamResult;
        }
        
        public int DamageCalc (int uDamage, int uColor, int[] uBuff, int tEvd, int tColor, int[] tBuff, out string hitMsg)
        {
            hitMsg = "";
            double Damage = 0;
            int[] colAry = { 0, 2, 3, 1, 5, 6, 4, 7, 8 }; //add boss colors to the array
            double[] colComp = { 0, 1 };
            bool tDefYes = BuffChk(tBuff, 7);
            bool tSupYes = BuffChk(uBuff, 10);
            bool pAtkYes = BuffChk(uBuff, 5);
            bool pSupYes = BuffChk(uBuff, 10);
            bool atkHit = false;
            Random rand = new Random();

            //Determine color bonus or penalty
            if (colAry[uColor] == tColor && BuffChk(avatar.DEBUFFBIT,6) == false)
            {
                colComp[0] = 3;
                colComp[1] = 1.25;
                hitMsg = "Critical Color Strike!\n";
            }
            else if (colAry[tColor] == uColor || tColor == 7 || tColor == 8)
            {
                colComp[0] = -3;
                colComp[1] = 0.75;
                hitMsg = "Attack Color Resisted.\n";
            }
            //Roll toHit, 1d20 vs tEvd, if miss then skip to end and return 0
            if (rand.Next(1, 21) + colComp[0] > tEvd)
                atkHit = true;
            else
                atkHit = false;
            //Damage Calc
            if (atkHit == false)
            {
                DamResult = 0;
                hitMsg = "Your attack missed the " + lblEnName.Text.ToString() + "!\n";
            }
            else if (tDefYes == true)
            {
                DamResult = 0;
                hitMsg = lblEnName.Text.ToString() + " blocked your attack!\n";
            }
            else
            {
                Damage = Math.Floor(((Convert.ToDouble(uDamage) * rand.Next(89, 107)) / 10) * colComp[1]);
                DamResult = Convert.ToInt32(Damage);
                if (pAtkYes == true || pSupYes == true)
                {
                    DamResult += avatar.BUFFVAL[5] + avatar.BUFFVAL[10];
                }
                if (tSupYes == true)
                    DamResult -= Enemy.BUFFVAL[10];
                hitMsg += "You deal " + DamResult + " damage to " + lblEnName.Text.ToString() + "!\n";
            }
            return DamResult;
        }

        public bool BuffChk(int[] test, int target)
        {
            for (int i = 0; i < test.Length; i++)
            {
                if (test[i] == target)
                {
                    return true;
                }
            }
            return false;
        }

        public void Buff(int uAbil, int uAbilityVal, int uAbilTime)
        {
            if (uAbil == 1 || uAbil == 4)
            {
                pTempHP += uAbilityVal;
                if (pTempHP >= avatar.HEALTH)
                    pTempHP = avatar.HEALTH;
                lblPHP.Text = pTempHP.ToString();
                pgbAvatar.Value = pTempHP;
            }
            else
            {
                avatar.BUFFBIT[uAbil] = uAbil;
                avatar.BUFFVAL[uAbil] = uAbilityVal;
                avatar.BUFFTIME[uAbil] = uAbilTime;
            }
        }

        public void Debuff(bool player, int[] tarBit, int[] tarVal, int[] tarTime, int uAbil, int uAbilVal, int uAbilTime, int uColor, int tColor, out string hitMsg)
        {
            hitMsg = "";
            int[] colAry = { 0, 2, 3, 1, 5, 6, 4, 7, 8 };
            double[] colComp = { 0, 1 };
            bool atkHit = false;
            Random rand = new Random();

            //Determine color bonus or penalty
            if (colAry[uColor] == tColor && BuffChk(avatar.DEBUFFBIT, 6) == false)
            {
                colComp[0] = 3;
                colComp[1] = 1.25;
                hitMsg = "Critical Color Strike!\n";
            }
            else if (colAry[tColor] == uColor || tColor == 7 || tColor == 8)
            {
                colComp[0] = -3;
                colComp[1] = 0.75;
                hitMsg = "Attack Color Resisted.\n";
            }
            //Roll toHit, 1d20 vs tEvd, if miss then skip to end and return 0
            if (rand.Next(1, 21) + colComp[0] > 7)
                atkHit = true;
            else
                atkHit = false;
            //Damage Calc
            if (atkHit == true)
            {
                if (uAbil == 1 && tarBit[uAbil] == 1)
                {
                    double reduce = Math.Floor(Convert.ToDouble(uAbilVal) / 3);
                    tarVal[uAbil] += Convert.ToInt32(reduce);
                    hitMsg = "Your target's pain intensifies!\n";
                }
                else
                {
                    tarBit[uAbil] = uAbil;
                    tarVal[uAbil] += uAbilVal;
                    hitMsg = "You curse your target!\n";
                }
                tarTime[uAbil] += uAbilTime;
            }
            else
                if (player == true)
                    hitMsg = "You fail to debilitate your foe.\n";
                else
                    hitMsg = lblEnName.Text.ToString() + " fails to land its attack.\n";

            if (player == true) 
            {
                Enemy.DEBUFFBIT = tarBit;
                Enemy.DEBUFFVAL = tarVal;
                Enemy.DEBUFFTIME = tarTime;
            }
            else
            {
                avatar.DEBUFFBIT = tarBit;
                avatar.DEBUFFVAL = tarVal;
                avatar.DEBUFFTIME = tarTime;
            }
        }

        public void WinTest()
        {
            enTempHP -= DamResult;
            lblMonHP.Text = enTempHP.ToString();
            if (enTempHP <= 0)
            {
                pgbMonster.Value = 0;
            }
            else
            {
                pgbMonster.Value = enTempHP;
            }
            if (enTempHP <= 0)
            {
                mDead = true;
                pWin++;
                lblPWin.Text = pWin.ToString();
                rtbEventLog.AppendText("Defeated " + lblEnName.Text.ToString() + "!");
                UnlockStuff();
                if (mDead == true && mBoss == true)
                    gWin = true;
                else
                {
                    PowerUp();
                    if (pgbProt.Value >= 10 || enTempHP == 0 && Enemy.TEMPLEDAM == 10)
                    {
                        gWin = true;
                    }
                }
            }
        }

        public void LoseTest()
        {
            pTempHP -= DamResult;
                    lblPHP.Text = pTempHP.ToString();
                    if (pTempHP <= 0)
                        pgbAvatar.Value = 0;
                    else
                        pgbAvatar.Value = pTempHP;
                    if (pTempHP <= 0)
                    {
                        pDead = true;
                        pLoss++;
                        lblPLoss.Text = pLoss.ToString();
                        if (pgbProt.Value >= 1)
                        {
                            pgbProt.Value -= 1;
                        }
                        else
                        {
                            if (pgbTemple.Value - Enemy.TEMPLEDAM <= 0)
                                pgbTemple.Value = 0;
                            else
                                pgbTemple.Value -= Enemy.TEMPLEDAM;
                            if (pgbTemple.Value <= 0)
                            {
                                gOver = true;
                            }
                        }
                    }
        }

        public void PowerUp()
        {
            //Make globals current
            Globals.templeHP = pgbTemple.Value;
            Globals.templeProt = pgbProt.Value;

            //power-up dialog
            PowerUp lvlform = new PowerUp();
            lvlform.ShowDialog();

            //reset health & health displays from level-up
            pgbTemple.Value = Globals.templeHP;
            pgbProt.Value = Globals.templeProt;
            pgbAvatar.Maximum = avatar.HEALTH + Globals.bonHP;
            pTempHP = avatar.HEALTH + Globals.bonHP;
            pgbAvatar.Value = pTempHP;
            lblPHP.Text = pTempHP.ToString();


        }

        public void UnlockStuff()
        {

            if (Enemy.COLOR == 1)
            {
                VarLocks.RedCnt++;
                if (VarLocks.RedCnt == 5 && VarLocks.besRed != true)
                {
                    VarLocks.besRed = true;
                    MessageBox.Show("You've unlocked bestiary entries for red enemies!", "Red Unlocked");
                    Writer(1);
                }
                if (VarLocks.RedCnt == 10 && VarLocks.enHRRed != true)
                {
                    VarLocks.enHRRed = true;
                    MessageBox.Show("You've unlocked History Repeating: Red!", "This Rage is Not Your Destiny");
                    Writer(2);
                }
            }
            if (Enemy.COLOR == 2)
            {
                VarLocks.BluCnt++;
                if (VarLocks.BluCnt == 5 && VarLocks.besBlue != true)
                {
                    VarLocks.besBlue = true;
                    MessageBox.Show("You've unlocked bestiary entries for blue enemies!", "Blue Unlocked");
                    Writer(1);
                }
                if (VarLocks.BluCnt == 10 && VarLocks.enHRBlue != true)
                {
                    VarLocks.enHRBlue = true;
                    MessageBox.Show("You've unlocked History Repeating: Blue!", "You Are Now Unchained");
                    Writer(2);
                }
            }
            if (Enemy.COLOR == 3)
            {
                VarLocks.YelCnt++;
                if (VarLocks.YelCnt == 5 && VarLocks.besYellow != true)
                {
                    VarLocks.besYellow = true;
                    MessageBox.Show("You've unlocked bestiary entries for yellow enemies!", "Yellow Unlocked");
                    Writer(1);
                }
            }
            if (Enemy.COLOR == 4)
            {
                VarLocks.GreCnt++;
                if (VarLocks.GreCnt == 5 && VarLocks.besGreen != true)
                {
                    VarLocks.besGreen = true;
                    MessageBox.Show("You've unlocked bestiary entries for green enemies!", "Green Unlocked");
                    Writer(1);
                }
                if (VarLocks.GreCnt == 10 && VarLocks.enGreen != true)
                {
                    VarLocks.enGreen = true;
                    MessageBox.Show("You've unlocked Green characters and options!", "Show me the green");
                    Writer(2);
                }
            }
            if (Enemy.COLOR == 5)
            {
                VarLocks.OraCnt++;
                if (VarLocks.OraCnt == 5 && VarLocks.besOrange != true)
                {
                    VarLocks.besOrange = true;
                    MessageBox.Show("You've unlocked bestiary entries for orange enemies!", "Orange Unlocked");
                    Writer(1);
                }
                if (VarLocks.OraCnt == 10 && VarLocks.enOrange != true)
                {
                    VarLocks.enOrange = true;
                    MessageBox.Show("You've unlocked Orange characters and options!", "Orange Unlocked!");
                    Writer(2);
                }
            }
            if (Enemy.COLOR == 6)
            {
                VarLocks.PurCnt++;
                if (VarLocks.PurCnt == 5 && VarLocks.besPurple != true)
                {
                    VarLocks.besPurple = true;
                    MessageBox.Show("You've unlocked bestiary entries for purple enemies!", "Purple Unlocked");
                    Writer(1);
                }
                if (VarLocks.PurCnt == 10 && VarLocks.enPurple != true)
                {
                    VarLocks.enPurple = true;
                    MessageBox.Show("You've unlocked Purple characters and options!", "Purple Haze");
                    Writer(2);
                }
            }
        }

        public void Writer(int mode)
        {
            if (mode == 1) //Bestiary unlock bits
            {
                StreamWriter infile;
                infile = File.CreateText("Bestiary.txt");
                if (VarLocks.besRed == true)
                    infile.WriteLine("1");
                else
                    infile.WriteLine("0");
                if (VarLocks.besBlue == true)
                    infile.WriteLine("1");
                else
                    infile.WriteLine("0");
                if (VarLocks.besYellow == true)
                    infile.WriteLine("1");
                else
                    infile.WriteLine("0");
                if (VarLocks.besGreen == true)
                    infile.WriteLine("1");
                else
                    infile.WriteLine("0");
                if (VarLocks.besOrange == true)
                    infile.WriteLine("1");
                else
                    infile.WriteLine("0");
                if (VarLocks.besPurple == true)
                    infile.WriteLine("1");
                else
                    infile.WriteLine("0");
                infile.Close();
            }

            if (mode == 2) //Unlocks unlock bits
            {
                StreamWriter infile;
                infile = File.CreateText("Unlocks.txt");
                if (VarLocks.enSpec1 == true)
                    infile.WriteLine("1");
                else
                    infile.WriteLine("0");
                if (VarLocks.enHRBlue == true)
                    infile.WriteLine("1");
                else
                    infile.WriteLine("0");
                if (VarLocks.enHRRed == true)
                    infile.WriteLine("1");
                else
                    infile.WriteLine("0");
                if (VarLocks.enGreen == true)
                    infile.WriteLine("1");
                else
                    infile.WriteLine("0");
                if (VarLocks.enOrange == true)
                    infile.WriteLine("1");
                else
                    infile.WriteLine("0");
                if (VarLocks.enPurple == true)
                    infile.WriteLine("1");
                else
                    infile.WriteLine("0");
                infile.Close();
            }
        }

        public void Restart()
        {
            if (mDead == true && gWin == true)
            {
                MessageBox.Show("Congratulations! You have won the game!", "A winnar is you!");
                this.Close();
            }

            if (pDead == true && gOver == true)
            {
                MessageBox.Show("You have lost the game", "Game Over");
                this.Close();
            }
            
            if (pDead == true && gWin != true || mDead == true && gOver != true)
            {
                fgtCnt++;
                lblBattle.Text = "Battle\n" + fgtCnt.ToString();
                mDead = false;
                pDead = false;

                rtbEventLog.Clear();
                EnemyFinder();
                if (Enemy.TEMPLEDAM > 3)
                {
                    Globals.templeProt = 0;
                    pgbProt.Value = Globals.templeProt;
                    rtbEventLog.AppendText("The temple's protection is stripped by a mighty blast from the approaching foe!\nThe raid leader has appeared!\n");
                }

                pgbAvatar.Maximum = avatar.HEALTH + Globals.bonHP;
                pTempHP = avatar.HEALTH + Globals.bonHP;
                pgbAvatar.Value = pTempHP;
                lblPHP.Text = pTempHP.ToString();
                enTempHP = Enemy.HEALTH;
                pgbMonster.Maximum = Enemy.HEALTH;
                pgbMonster.Value = enTempHP;
                lblMonHP.Text = enTempHP.ToString();
                lblEnTD.Text = Enemy.TEMPLEDAM.ToString();
                combo = 0;
                cd3 = 0;
                if (btnATK3.Enabled == false)
                    btnATK3.Enabled = true;
                enLAtk = 0;
                lblDet1.Text = Globals.s1Tip + "\nBase Power: " + (avatar.FORCE + Globals.bonDam) + "\nColor: None\nCombo: " + combo.ToString() + "\n";
                lblDet2.Text = Globals.s2Tip + "\nBase Power: " + (avatar.FORCE + Globals.bonDam + Globals.ab2Val).ToString() + "\nColor: " + Globals.pColor.ToString() + "\n";
                lblDet3.Text = Globals.s3Tip + "\nCooldown: " + Globals.ab3Cool.ToString();
                lblDet4.Text = Globals.s4Tip + "\nBase Power: " + (avatar.FORCE + Globals.bonDam) + "\nColor: " + Globals.s4Color.ToString() + "\n";
                //Reset buff states
                for (int i = 0; i < avatar.BUFFBIT.Length; i++)
                {
                    avatar.BUFFBIT[i] = 0;
                    avatar.BUFFVAL[i] = 0;
                    avatar.BUFFTIME[i] = 0;
                    Enemy.BUFFBIT[i] = 0;
                    Enemy.BUFFVAL[i] = 0;
                    Enemy.BUFFTIME[i] = 0;
                }
                //Reset debuff states
                for (int i = 0; i < avatar.DEBUFFBIT.Length; i++)
                {
                    avatar.DEBUFFBIT[i] = 0;
                    avatar.DEBUFFVAL[i] = 0;
                    avatar.DEBUFFTIME[i] = 0;
                    Enemy.DEBUFFBIT[i] = 0;
                    Enemy.DEBUFFVAL[i] = 0;
                    Enemy.DEBUFFTIME[i] = 0;
                }
            }
            else
            {
                rtbEventLog.AppendText(" ******* Next Round    ******** \n");
                if (cd3 >= 1)
                { 
                    btnATK3.Enabled = false;
                    cd3--; 
                }
                else
                    btnATK3.Enabled = true;
                lblDet1.Text = Globals.s1Tip + "\nBase Power: " + (avatar.FORCE + Globals.bonDam) + "\nColor: None\nCombo: " + combo.ToString() + "\n";
                //Drop Buff counters
                for (int i = 0; i < avatar.BUFFBIT.Length; i++)
                {
                    if (avatar.BUFFTIME[i] >= 1)
                    {
                        avatar.BUFFTIME[i] -= 1;
                        if (avatar.BUFFTIME[i] <= 0)
                            avatar.BUFFBIT[i] = 0;
                    }
                    if (Enemy.BUFFTIME[i] >= 1)
                    {
                    Enemy.BUFFTIME[i] -= 1;
                    if (Enemy.BUFFTIME[i] <= 0)
                        Enemy.BUFFBIT[i] = 0;
                    }
                }

                for (int i = 0; i < avatar.DEBUFFBIT.Length; i++)
                {
                    if (avatar.DEBUFFTIME[i] >= 1)
                    {
                        avatar.DEBUFFTIME[i] -= 1;
                        if (avatar.DEBUFFTIME[i] <= 0)
                            avatar.DEBUFFBIT[i] = 0;
                    }
                    if (Enemy.DEBUFFTIME[i] >= 1)
                    {
                        Enemy.DEBUFFTIME[i] -= 1;
                        if (Enemy.DEBUFFTIME[i] <= 0)
                            Enemy.DEBUFFBIT[i] = 0;
                    }
                }
            }
        }

    }
}
