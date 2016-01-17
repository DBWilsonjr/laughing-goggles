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
        int pTempHP, pDam, pEvd, pWin, pLoss, btnNum, combo, cd3; int enTempHP, enLAtk, fgtCnt;
        public int bonHP, bonDam, bonEvd;
        bool pDead = false, mDead = false, gOver = false, gWin = false;

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

            avatar.BUFFBIT = 0;
            avatar.BUFFVAL = 0;
            avatar.DEBUFFBIT = 0;
            avatar.DEBUFFVAL = 0;

            btnATK1.Text = Globals.s1Name; 
            toolTip1.SetToolTip(btnATK1, Globals.s1Tip);
            btnATK2.Text = Globals.s2Name;
            toolTip1.SetToolTip(btnATK2, Globals.s2Tip);
            btnATK3.Text = Globals.s3Name;
            toolTip1.SetToolTip(btnATK3, Globals.s3Tip);
            btnATK4.Text = Globals.s4Name;
            toolTip1.SetToolTip(btnATK4, Globals.s4Tip);
            fgtCnt++;
        }

        private void btnATK1_Click(object sender, EventArgs e)
        {
            //button 1 can double/triple/infinite attack; multiple uses add to combo counter, increasing chances of multiple hits
            pDam = avatar.FORCE + bonDam + avatar.ABILITY1;
            btnNum = 1;
            combo += 1;
            
            ActualGame();
        }

        private void btnATK2_Click(object sender, EventArgs e)
        {
            pDam = avatar.FORCE + bonDam + avatar.ABILITY2;
            if (avatar.BUFFBIT == 2)
                pEvd = avatar.EVADE + bonEvd + avatar.BUFFVAL;
            else
                pEvd = avatar.EVADE + bonEvd;
            btnNum = 2;
            combo = 0;

            ActualGame();
        }

        private void btnATK3_Click(object sender, EventArgs e)
        {
            if (avatar.ABILITY3 == 303 || avatar.ABILITY3 == 306)
                pDam = avatar.FORCE + bonDam + 6;
            else
                pDam = avatar.FORCE + bonDam;
            if (avatar.BUFFBIT == 2)
                pEvd = avatar.EVADE + bonEvd + avatar.BUFFVAL;
            else
                pEvd = avatar.EVADE + bonEvd;
            btnNum = 3;
            combo = 0;

            ActualGame();
        }

        private void btnATK4_Click(object sender, EventArgs e)
        {
            pDam = avatar.FORCE + bonDam + avatar.ABILITY4;
            if (avatar.BUFFBIT == 2)
                pEvd = avatar.EVADE + bonEvd + avatar.BUFFVAL;
            else
                pEvd = avatar.EVADE + bonEvd;
            btnNum = 4;
            combo = 0;

            ActualGame();
        }

        public void PlayerCreate()
        {
            int[] playclass = {0,1,5,9,12,13,17};
            if (Globals.pColor == "Red")
            {
                avatar.COLOR = 1;
                groupBox1.BackColor = Color.Crimson;
            }
            if (Globals.pColor == "Blue")
            {
                avatar.COLOR = 2;
                groupBox1.BackColor = Color.MediumBlue;
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
            avatar.ABILITY3 = Globals.ab3;
            avatar.ABILITY4 = Globals.ab4;
        }

        public void EnemyFinder()
        {
            Random enFind = new Random();
            int enGen, enTable;
            if (Globals.Difficulty - fgtCnt <= 0)
            {
                enGen = enFind.Next(1, 30) - fgtCnt;
            }
            else
            {
                enGen = enFind.Next(4, 30) - fgtCnt;
            }
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
            }
            if (enGen == 4 || enGen == 7 || enGen == 10) //Green
            {
                enTable = enFind.Next(1, 15);
                lblEnName.Text = cDS1.tblGreen.Rows[enTable - 1].ItemArray[0].ToString();
                Enemy.HEALTH = Convert.ToInt32(cDS1.tblGreen.Rows[enTable - 1].ItemArray[1]);
                Enemy.FORCE = Convert.ToInt32(cDS1.tblGreen.Rows[enTable - 1].ItemArray[2]);
                Enemy.EVADE = Convert.ToInt32(cDS1.tblGreen.Rows[enTable - 1].ItemArray[3]);
                Enemy.COLOR = 4;
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
                Enemy.FORCE = Convert.ToInt32(cDS1.tblBoss.Rows[enTable - 1].ItemArray[2]);
                Enemy.EVADE = Convert.ToInt32(cDS1.tblBoss.Rows[enTable - 1].ItemArray[3]);
                Enemy.COLOR = 3;
                Enemy.TEMPLEDAM = Convert.ToInt32(cDS1.tblBoss.Rows[enTable - 1].ItemArray[4]);
                Enemy.ABILITY1 = Convert.ToInt32(cDS1.tblBoss.Rows[enTable - 1].ItemArray[5]);
                Enemy.ABILITY2 = Convert.ToInt32(cDS1.tblBoss.Rows[enTable - 1].ItemArray[6]);
                Enemy.ABILITY3 = Convert.ToInt32(cDS1.tblBoss.Rows[enTable - 1].ItemArray[7]);
                Enemy.ABILITY4 = Convert.ToInt32(cDS1.tblBoss.Rows[enTable - 1].ItemArray[8]);
            }
        }

        public void ActualGame()
        {
            Random cmbCntr = new Random();
            //IF not (frozen) THEN do ELSE skip all this
            if (avatar.DEBUFFBIT != 4 || avatar.DEBUFFBIT != 5)
            {
                //IF not (paralyzed) AND win coin flip THEN do ELSE skip all this
                if (avatar.DEBUFFBIT != 3 || avatar.DEBUFFBIT == 3 && cmbCntr.Next(1, 100) < 50)
                {
                    //apply buff benefits, drop buff counters, dots don't kill
                    if (avatar.BUFFBIT == 7 && avatar.BUFFTIME >=1)
                    {
                        if (pTempHP + avatar.BUFFVAL >= avatar.HEALTH)
                        {
                            pTempHP = avatar.HEALTH;
                            rtbEventLog.AppendText("You have fully recovered your health!");
                        }
                        else
                        {
                            pTempHP += avatar.BUFFVAL;
                            rtbEventLog.AppendText("You regenerate for " + avatar.BUFFVAL + " HP.");
                        }
                    }
                    if (avatar.DEBUFFBIT == 1)
                    {
                        if (pTempHP - avatar.DEBUFFVAL <= 0)
                        {
                            pTempHP = 1;
                            rtbEventLog.AppendText("You struggle against the nearly lethal pain surging through your body!");
                        }
                        else
                        {
                            pTempHP -= avatar.DEBUFFVAL;
                            rtbEventLog.AppendText("Lingering effects damage you for " + avatar.DEBUFFVAL + " HP.");
                        }
                    }
                    if (Enemy.BUFFBIT == 7)
                    {
                        if (enTempHP + Enemy.BUFFVAL >= Enemy.HEALTH)
                        {
                            enTempHP = Enemy.HEALTH;
                            rtbEventLog.AppendText(lblEnName.Text.ToString() + " has regenerated to full health!");
                        }
                        else
                        {
                            enTempHP += Enemy.BUFFVAL;
                            rtbEventLog.AppendText(lblEnName.Text.ToString() + " regenerates for " + Enemy.BUFFVAL + " HP.");
                        }
                    }
                    if (Enemy.DEBUFFBIT == 1)
                    {
                        if (enTempHP - Enemy.DEBUFFVAL <= 0)
                        {
                            enTempHP = 1;
                            rtbEventLog.AppendText(lblEnName.Text.ToString() + " nearly succumbs to the darkness!");
                        }
                        else
                        {
                            enTempHP -= Enemy.DEBUFFVAL;
                            rtbEventLog.AppendText(lblEnName.Text.ToString() + " is damaged for " + Enemy.DEBUFFVAL + " HP.");
                        }
                    }
                    if (avatar.BUFFTIME >= 1)
                        avatar.BUFFTIME -= 1;
                    if (avatar.DEBUFFTIME >= 1)
                        avatar.DEBUFFTIME -= 1;
                    if (Enemy.BUFFTIME >= 1)
                        Enemy.BUFFTIME -= 1;
                    if (Enemy.DEBUFFTIME >= 1)
                        Enemy.DEBUFFTIME -= 1;

                    if (btnNum == 3)
                    {
                        if (avatar.ABILITY3 == 301)
                        {
                            Buff(1, 50, 5);
                            rtbEventLog.AppendText("You prepare to defend yourself from attacks!");
                        }
                        else if (avatar.ABILITY3 == 302)
                        {
                            Buff(1, 20, 5);
                            rtbEventLog.AppendText("The song makes you feel more durable!");
                        }
                        else if (avatar.ABILITY3 == 303)
                        {
                            Buff(4, 0, 0);
                            rtbEventLog.AppendText("Some of your wounds have been recovered!");
                        }
                        else if (avatar.ABILITY3 == 304)
                        {
                            Buff(9, 4, 5);
                            pTempHP -= 20;
                            if (pTempHP <= 0)
                                pTempHP = 1;
                            rtbEventLog.AppendText("Your attack power is increased!");
                        }
                        else if (avatar.ABILITY3 == 308)
                        {
                            int[] cbAbil = {1,2,4,5,7,9};
                            int[] cbval = {5,7,9};
                            int[] cbtime = { 3, 4, 5 };
                            int cbsav1, cbsav2, cbsav3;
                            Random cball = new Random();
                            cbsav1 = cball.Next(0, 7);
                            cbsav2 = cball.Next(1, 4);
                            cbsav3 = cball.Next(1, 4);
                            Buff(cbAbil[cbsav1], cbAbil[cbsav2], cbAbil[cbsav3]);
                            if (cbAbil[cbsav1] == 0)
                                rtbEventLog.AppendText("You feel protected!");
                            else if (cbAbil[cbsav1] == 1)
                                rtbEventLog.AppendText("You feel lighter on your feet!");
                            else if (cbAbil[cbsav1] == 2)
                                rtbEventLog.AppendText("You feel restored!");
                            else if (cbAbil[cbsav1] == 3)
                                rtbEventLog.AppendText("You feel prickly!");
                            else if (cbAbil[cbsav1] == 4)
                                rtbEventLog.AppendText("You feel wrapped in recovering energy!");
                            else if (cbAbil[cbsav1] == 5)
                                rtbEventLog.AppendText("You feel stronger!");
                        }
                        else if (avatar.ABILITY3 == 320)
                        {
                            Debuff(1,15,7, avatar.COLOR, Enemy.COLOR);
                        }
                        else if (avatar.ABILITY3 == 321)
                        {
                            Debuff(1, 45, 3, avatar.COLOR, Enemy.COLOR);
                        }
                        else if (avatar.ABILITY3 == 322)
                        {
                            Random wand = new Random();
                            int waDam, waTime;
                            waDam = wand.Next(5, 61);
                            waTime = wand.Next(2, 9);
                            Debuff(1, waDam, waTime, avatar.COLOR, Enemy.COLOR);
                        }
                    }
                    else
                    do
                    {
                        if (avatar.ABILITY4 == 411)
                            DamageCalc(pDam, 1, avatar.BUFFBIT, Enemy.EVADE, Enemy.COLOR, Enemy.BUFFBIT);
                        else if (avatar.ABILITY4 == 412)
                            DamageCalc(pDam, 2, avatar.BUFFBIT, Enemy.EVADE, Enemy.COLOR, Enemy.BUFFBIT);
                        else if (avatar.ABILITY4 == 413)
                            DamageCalc(pDam, 3, avatar.BUFFBIT, Enemy.EVADE, Enemy.COLOR, Enemy.BUFFBIT);
                        else if (avatar.ABILITY4 == 414)
                            DamageCalc(pDam, 4, avatar.BUFFBIT, Enemy.EVADE, Enemy.COLOR, Enemy.BUFFBIT);
                        else if (avatar.ABILITY4 == 415)
                            DamageCalc(pDam, 5, avatar.BUFFBIT, Enemy.EVADE, Enemy.COLOR, Enemy.BUFFBIT);
                        else if (avatar.ABILITY4 == 416)
                            DamageCalc(pDam, 6, avatar.BUFFBIT, Enemy.EVADE, Enemy.COLOR, Enemy.BUFFBIT);
                        else if (avatar.ABILITY3 == 307)
                            DamageCalc(pDam, avatar.COLOR, avatar.BUFFBIT, 0, Enemy.COLOR, Enemy.BUFFBIT);
                        else if (avatar.ABILITY3 == 308)
                        {
                            Random tarot = new Random();
                            int tdam;
                            tdam = tarot.Next(0, 7) - 2;
                            pDam += tdam;
                            DamageCalc(pDam, avatar.COLOR, avatar.BUFFBIT, 0, Enemy.COLOR, Enemy.BUFFBIT);
                        }
                        else
                        DamageCalc(pDam, avatar.COLOR, avatar.BUFFBIT, Enemy.EVADE, Enemy.COLOR, Enemy.BUFFBIT);

                        enTempHP -= DamResult;
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
                            //power-up dialog
                            PowerUp lvlform = new PowerUp();
                            lvlform.ShowDialog();
                            rtbEventLog.AppendText("Defeated " + lblEnName.Text.ToString() + "!");
                            UnlockStuff();
                            if (pgbProt.Value >= 10)
                            {
                                gWin = true;
                            }
                        }
                    }
                    while (btnNum == 1 && cmbCntr.Next(1, 100) + combo >= 85 && mDead !=true);

                }
                else
                    rtbEventLog.AppendText("You are paralyzed and cannot move.");
            }
            else
            {
                if (avatar.DEBUFFBIT == 4)
                    rtbEventLog.AppendText("You are stunned and cannot move.");
                if (avatar.DEBUFFBIT == 5)
                    rtbEventLog.AppendText("You are frozen and cannot move.");
            }
            if (mDead != true && Enemy.DEBUFFBIT != 4 || Enemy.DEBUFFBIT != 5)
            {
                if (mDead != true && Enemy.DEBUFFBIT != 3 || Enemy.DEBUFFBIT == 3 && cmbCntr.Next(1, 100) < 50)
                {
                    EnemyDamCalc(Enemy.FORCE, Enemy.COLOR, Enemy.BUFFBIT, pEvd, avatar.COLOR, avatar.BUFFBIT);
                    pTempHP -= DamResult;
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
                            pgbTemple.Value -= Enemy.TEMPLEDAM;
                            if (pgbTemple.Value <= 0)
                            {
                                gOver = true;
                            }
                        }
                    }
                }
                else
                    rtbEventLog.AppendText(lblEnName.Text.ToString() + " is paralyzed and cannot move.\n");
            }
            else
            {
                if (Enemy.DEBUFFBIT == 4)
                    rtbEventLog.AppendText(lblEnName.Text.ToString() + " is stunned and cannot move.\n");
                if (Enemy.DEBUFFBIT == 5)
                    rtbEventLog.AppendText(lblEnName.Text.ToString() + " is frozen and cannot move.\n");
            }
            if (gWin == true)
            {
                MessageBox.Show("Congratulations! You have won the game!", "A winnar is you!");
                this.Close();
            }
            if (gOver == true)
            {
                MessageBox.Show("You have lost the game", "Game Over");
                this.Close();
            }
            else
                Restart();
        }

        public int EnemyDamCalc(int uDamage, int uColor, int uBuff, int tEvd, int tColor, int tBuff)
        {
            double Damage = 0;
            int[] colAry = { 0, 2, 3, 1, 5, 6, 4 };
            Random MonHit = new Random();
            //Roll random 1-4 to choose attack, if previous was 3 then follow with 4
            if (enLAtk == 3)
            {
                enLAtk = 4;
            }
            else
            {
                enLAtk = MonHit.Next(1, 4);
            }
            //Roll toHit, 1d20 vs tEvd, if miss then skip to end and return 0
            if (tBuff != 3)
            {
                if (tColor == colAry[uColor])
                {
                    if (MonHit.Next(1, 21) + 3 > tEvd)
                    {
                        Damage = Math.Floor((Convert.ToDouble(uDamage) * (MonHit.Next(92, 104) / 10)) * 1.25);
                        DamResult = Convert.ToInt32(Damage);
                    }
                    else
                    {
                        rtbEventLog.AppendText(lblEnName.Text.ToString() + " misses you with its attack!\n");
                        DamResult = 0;
                    }
                }
                if (uColor == colAry[tColor])
                {
                    if (MonHit.Next(1, 21) - 3 > tEvd)
                    {
                        Damage = Math.Floor((Convert.ToDouble(uDamage) * (MonHit.Next(92, 104) / 10)) * .75);
                        DamResult = Convert.ToInt32(Damage);
                    }
                    else
                    {
                        rtbEventLog.AppendText(lblEnName.Text.ToString() + " misses you with its attack!\n");
                        DamResult = 0;
                    }
                }
                else
                {
                    if (MonHit.Next(1, 21) > tEvd)
                    {
                        Damage = Math.Floor((Convert.ToDouble(uDamage) * (MonHit.Next(92, 104) / 10)));
                        DamResult = Convert.ToInt32(Damage);
                    }
                    else
                    {
                        rtbEventLog.AppendText(lblEnName.Text.ToString() + " misses you with its attack!\n");
                        DamResult = 0;
                    }
                }
                if (uBuff == 9 || uBuff == 10)
                {
                    DamResult += Enemy.BUFFVAL;
                }
                if (tBuff == 1 || tBuff == 10)
                {
                    DamResult -= avatar.BUFFVAL;
                }
                rtbEventLog.AppendText(lblEnName.Text.ToString() + " hits you for " + DamResult + " damage!\n");
            }
            else
            {
                DamResult = 0;
                rtbEventLog.AppendText("You evade the attack attack!\n");
            }
            
            return DamResult;
        }
        
        public int DamageCalc (int uDamage, int uColor, int uBuff, int tEvd, int tColor, int tBuff)
        {
            double Damage = 0;
            int[] colAry = {0,2,3,1,5,6,4};
            Random rand = new Random();

            if (tBuff != 3)
            {
                if (tColor == colAry[uColor] && avatar.DEBUFFBIT != 6)
                {
                    if (rand.Next(1, 21) + 3 > tEvd)
                    {
                        Damage = Math.Floor((Convert.ToDouble(uDamage) * (rand.Next(92, 104) / 10)) * 1.25);
                        DamResult = Convert.ToInt32(Damage);
                    }
                    else
                    {
                        rtbEventLog.AppendText("You missed the " + lblEnName.Text.ToString() + "!\n");
                        DamResult = 0;
                    }
                }
                if (uColor == colAry[tColor])
                {
                    if (rand.Next(1, 21) - 3 > tEvd)
                    {
                        Damage = Math.Floor((Convert.ToDouble(uDamage) * (rand.Next(92, 104) / 10)) * .75);
                        DamResult = Convert.ToInt32(Damage);
                    }
                    else
                    {
                        rtbEventLog.AppendText("You missed the " + lblEnName.Text.ToString() + "!\n");
                        DamResult = 0;
                    }
                }
                else
                {
                    if (rand.Next(1, 21) > tEvd)
                    {
                        Damage = Math.Floor((Convert.ToDouble(uDamage) * (rand.Next(92, 104) / 10)));
                        DamResult = Convert.ToInt32(Damage);
                    }
                    else
                    {
                        rtbEventLog.AppendText("You missed the " + lblEnName.Text.ToString() + "!\n");
                        DamResult = 0;
                    }
                }
                if (uBuff == 9 || uBuff == 10)
                {
                    DamResult += avatar.BUFFVAL;
                }
                if (tBuff == 1 || tBuff == 10)
                {
                    DamResult -= Enemy.BUFFVAL;
                }
                rtbEventLog.AppendText("You deal " + DamResult + " damage to " + lblEnName.Text.ToString() + "!\n");
            }
            else
            {
                DamResult = 0;
                rtbEventLog.AppendText(lblEnName.Text.ToString() + " blocked your attack!\n");
            }
            return DamResult;
        }

        public void Buff(int uAbil, int uAbilityVal, int uAbilTime)
        {
            if (uAbil == 5)
            {
                pTempHP += 200;
                if (pTempHP >= avatar.HEALTH)
                    pTempHP = avatar.HEALTH;
                lblPHP.Text = pTempHP.ToString();
                pgbAvatar.Value = pTempHP;
            }
            else
            {
                avatar.BUFFBIT = uAbil;
                avatar.BUFFVAL = uAbilityVal;
                avatar.BUFFTIME = uAbilTime;
            }
        }

        public void Debuff(int uAbil, int uAbilVal, int uAbilTime, int uColor, int tColor)
        {
            int[] colAry = { 0, 2, 3, 1, 5, 6, 4 };
            Random rand = new Random();

            if (tColor == colAry[uColor] && avatar.DEBUFFBIT != 6)
            {
                if (rand.Next(1, 21) + 3 > 7)
                {
                    Enemy.DEBUFFBIT = uAbil;
                    Enemy.DEBUFFVAL = uAbilVal;
                    Enemy.DEBUFFTIME = uAbilTime;
                    rtbEventLog.AppendText("You curse your target!");
                }
                else
                {
                    rtbEventLog.AppendText("You missed the " + lblEnName.Text.ToString() + "!\n");
                    DamResult = 0;
                }
            }
            if (uColor == colAry[tColor])
            {
                if (rand.Next(1, 21) - 3 > 7)
                {
                    Enemy.DEBUFFBIT = uAbil;
                    Enemy.DEBUFFVAL = uAbilVal;
                    Enemy.DEBUFFTIME = uAbilTime;
                    rtbEventLog.AppendText("You curse your target!");
                }
                else
                {
                    rtbEventLog.AppendText("You missed the " + lblEnName.Text.ToString() + "!\n");
                    DamResult = 0;
                }
            }
            else
            {
                if (rand.Next(1, 21) > 7)
                {
                    Enemy.DEBUFFBIT = uAbil;
                    Enemy.DEBUFFVAL = uAbilVal;
                    Enemy.DEBUFFTIME = uAbilTime;
                    rtbEventLog.AppendText("You curse your target!");
                }
                else
                {
                    rtbEventLog.AppendText("You missed the " + lblEnName.Text.ToString() + "!\n");
                }
            }
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
            fgtCnt++;
            mDead = false;
            pDead = false;

            EnemyFinder();

            rtbEventLog.Clear();
            pTempHP = avatar.HEALTH;
            lblPHP.Text = pTempHP.ToString();
            pgbAvatar.Maximum = avatar.HEALTH;
            pgbAvatar.Value = pTempHP;
            enTempHP = Enemy.HEALTH;
            pgbMonster.Maximum = Enemy.HEALTH;
            pgbMonster.Value = enTempHP;
            lblMonHP.Text = enTempHP.ToString();
            lblEnTD.Text = Enemy.TEMPLEDAM.ToString();
            avatar.BUFFBIT = 0;
            avatar.BUFFVAL = 0;
            combo = 0;
            avatar.DEBUFFBIT = 0;
            avatar.DEBUFFVAL = 0;
            enLAtk = 0;
        }

    }
}
