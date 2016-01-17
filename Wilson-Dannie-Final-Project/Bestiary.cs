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
    public partial class Bestiary : Form
    {
        public Bestiary()
        {
            InitializeComponent();
            if (VarLocks.besRed == true)
            {
                lblRedMes.Visible = false;
                lsbRed.Visible = true;
            }
            if (VarLocks.besBlue == true)
            {
                lblBluMes.Visible = false;
                lsbBlue.Visible = true;
            }
            if (VarLocks.besYellow == true)
            {
                lblYelMes.Visible = false;
                lsbYellow.Visible = true;
            }
            if (VarLocks.besGreen == true)
            {
                lblGreMes.Visible = false;
                lsbGreen.Visible = true;
            }
            if (VarLocks.besOrange == true)
            {
                lblOraMes.Visible = false;
                lsbOrange.Visible = true;
            }
            if (VarLocks.besPurple == true)
            {
                lblPurMes.Visible = false;
                lsbPurple.Visible = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tblBlueBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tblBlueBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.charDataSet);

        }

        private void Bestiary_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'charDataSet.tblYellow' table. You can move, or remove it, as needed.
            this.tblYellowTableAdapter.Fill(this.charDataSet.tblYellow);
            // TODO: This line of code loads data into the 'charDataSet.tblRed' table. You can move, or remove it, as needed.
            this.tblRedTableAdapter.Fill(this.charDataSet.tblRed);
            // TODO: This line of code loads data into the 'charDataSet.tblPurple' table. You can move, or remove it, as needed.
            this.tblPurpleTableAdapter.Fill(this.charDataSet.tblPurple);
            // TODO: This line of code loads data into the 'charDataSet.tblOrange' table. You can move, or remove it, as needed.
            this.tblOrangeTableAdapter.Fill(this.charDataSet.tblOrange);
            // TODO: This line of code loads data into the 'charDataSet.tblGreen' table. You can move, or remove it, as needed.
            this.tblGreenTableAdapter.Fill(this.charDataSet.tblGreen);
            // TODO: This line of code loads data into the 'charDataSet.tblBlue' table. You can move, or remove it, as needed.
            this.tblBlueTableAdapter.Fill(this.charDataSet.tblBlue);

        }
    }
}
