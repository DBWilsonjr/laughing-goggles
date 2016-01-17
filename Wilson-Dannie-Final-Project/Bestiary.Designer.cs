namespace Wilson_Dannie_Final_Project
{
    partial class Bestiary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label enemyLabel;
            System.Windows.Forms.Label enemyLabel1;
            System.Windows.Forms.Label enemyLabel2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label enemyLabel3;
            System.Windows.Forms.Label enemyLabel4;
            this.btnClose = new System.Windows.Forms.Button();
            this.charDataSet = new Wilson_Dannie_Final_Project.CharDataSet();
            this.tblBlueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblBlueTableAdapter = new Wilson_Dannie_Final_Project.CharDataSetTableAdapters.tblBlueTableAdapter();
            this.tableAdapterManager = new Wilson_Dannie_Final_Project.CharDataSetTableAdapters.TableAdapterManager();
            this.tblGreenTableAdapter = new Wilson_Dannie_Final_Project.CharDataSetTableAdapters.tblGreenTableAdapter();
            this.tblOrangeTableAdapter = new Wilson_Dannie_Final_Project.CharDataSetTableAdapters.tblOrangeTableAdapter();
            this.tblPurpleTableAdapter = new Wilson_Dannie_Final_Project.CharDataSetTableAdapters.tblPurpleTableAdapter();
            this.tblRedTableAdapter = new Wilson_Dannie_Final_Project.CharDataSetTableAdapters.tblRedTableAdapter();
            this.tblYellowTableAdapter = new Wilson_Dannie_Final_Project.CharDataSetTableAdapters.tblYellowTableAdapter();
            this.lsbBlue = new System.Windows.Forms.ListBox();
            this.tblGreenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lsbGreen = new System.Windows.Forms.ListBox();
            this.tblOrangeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lsbOrange = new System.Windows.Forms.ListBox();
            this.tblPurpleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lsbPurple = new System.Windows.Forms.ListBox();
            this.tblRedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lsbRed = new System.Windows.Forms.ListBox();
            this.tblYellowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lsbYellow = new System.Windows.Forms.ListBox();
            this.lblRedMes = new System.Windows.Forms.Label();
            this.lblBluMes = new System.Windows.Forms.Label();
            this.lblYelMes = new System.Windows.Forms.Label();
            this.lblGreMes = new System.Windows.Forms.Label();
            this.lblOraMes = new System.Windows.Forms.Label();
            this.lblPurMes = new System.Windows.Forms.Label();
            enemyLabel = new System.Windows.Forms.Label();
            enemyLabel1 = new System.Windows.Forms.Label();
            enemyLabel2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            enemyLabel3 = new System.Windows.Forms.Label();
            enemyLabel4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.charDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBlueBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblGreenBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblOrangeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPurpleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRedBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblYellowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // enemyLabel
            // 
            enemyLabel.AutoSize = true;
            enemyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            enemyLabel.ForeColor = System.Drawing.Color.ForestGreen;
            enemyLabel.Location = new System.Drawing.Point(22, 265);
            enemyLabel.Name = "enemyLabel";
            enemyLabel.Size = new System.Drawing.Size(104, 20);
            enemyLabel.TabIndex = 2;
            enemyLabel.Text = "Green Foes";
            // 
            // enemyLabel1
            // 
            enemyLabel1.AutoSize = true;
            enemyLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            enemyLabel1.ForeColor = System.Drawing.Color.DarkOrange;
            enemyLabel1.Location = new System.Drawing.Point(196, 265);
            enemyLabel1.Name = "enemyLabel1";
            enemyLabel1.Size = new System.Drawing.Size(113, 20);
            enemyLabel1.TabIndex = 4;
            enemyLabel1.Text = "Orange Foes";
            // 
            // enemyLabel2
            // 
            enemyLabel2.AutoSize = true;
            enemyLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            enemyLabel2.ForeColor = System.Drawing.Color.MediumPurple;
            enemyLabel2.Location = new System.Drawing.Point(387, 265);
            enemyLabel2.Name = "enemyLabel2";
            enemyLabel2.Size = new System.Drawing.Size(105, 20);
            enemyLabel2.TabIndex = 6;
            enemyLabel2.Text = "Purple Foes";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.MediumBlue;
            label1.Location = new System.Drawing.Point(207, 22);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(90, 20);
            label1.TabIndex = 8;
            label1.Text = "Blue Foes";
            // 
            // enemyLabel3
            // 
            enemyLabel3.AutoSize = true;
            enemyLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            enemyLabel3.ForeColor = System.Drawing.Color.Crimson;
            enemyLabel3.Location = new System.Drawing.Point(25, 22);
            enemyLabel3.Name = "enemyLabel3";
            enemyLabel3.Size = new System.Drawing.Size(87, 20);
            enemyLabel3.TabIndex = 9;
            enemyLabel3.Text = "Red Foes";
            // 
            // enemyLabel4
            // 
            enemyLabel4.AutoSize = true;
            enemyLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            enemyLabel4.ForeColor = System.Drawing.Color.Yellow;
            enemyLabel4.Location = new System.Drawing.Point(387, 22);
            enemyLabel4.Name = "enemyLabel4";
            enemyLabel4.Size = new System.Drawing.Size(106, 20);
            enemyLabel4.TabIndex = 11;
            enemyLabel4.Text = "Yellow Foes";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 519);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // charDataSet
            // 
            this.charDataSet.DataSetName = "CharDataSet";
            this.charDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblBlueBindingSource
            // 
            this.tblBlueBindingSource.DataMember = "tblBlue";
            this.tblBlueBindingSource.DataSource = this.charDataSet;
            // 
            // tblBlueTableAdapter
            // 
            this.tblBlueTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.tblBlueTableAdapter = this.tblBlueTableAdapter;
            this.tableAdapterManager.tblBossTableAdapter = null;
            this.tableAdapterManager.tblGreenTableAdapter = this.tblGreenTableAdapter;
            this.tableAdapterManager.tblOrangeTableAdapter = this.tblOrangeTableAdapter;
            this.tableAdapterManager.tblPlayersTableAdapter = null;
            this.tableAdapterManager.tblPurpleTableAdapter = this.tblPurpleTableAdapter;
            this.tableAdapterManager.tblRedTableAdapter = this.tblRedTableAdapter;
            this.tableAdapterManager.tblYellowTableAdapter = this.tblYellowTableAdapter;
            this.tableAdapterManager.UpdateOrder = Wilson_Dannie_Final_Project.CharDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tblGreenTableAdapter
            // 
            this.tblGreenTableAdapter.ClearBeforeFill = true;
            // 
            // tblOrangeTableAdapter
            // 
            this.tblOrangeTableAdapter.ClearBeforeFill = true;
            // 
            // tblPurpleTableAdapter
            // 
            this.tblPurpleTableAdapter.ClearBeforeFill = true;
            // 
            // tblRedTableAdapter
            // 
            this.tblRedTableAdapter.ClearBeforeFill = true;
            // 
            // tblYellowTableAdapter
            // 
            this.tblYellowTableAdapter.ClearBeforeFill = true;
            // 
            // lsbBlue
            // 
            this.lsbBlue.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblBlueBindingSource, "Enemy", true));
            this.lsbBlue.DataSource = this.tblBlueBindingSource;
            this.lsbBlue.DisplayMember = "Enemy";
            this.lsbBlue.Enabled = false;
            this.lsbBlue.FormattingEnabled = true;
            this.lsbBlue.Location = new System.Drawing.Point(186, 45);
            this.lsbBlue.Name = "lsbBlue";
            this.lsbBlue.Size = new System.Drawing.Size(130, 199);
            this.lsbBlue.TabIndex = 2;
            this.lsbBlue.Visible = false;
            // 
            // tblGreenBindingSource
            // 
            this.tblGreenBindingSource.DataMember = "tblGreen";
            this.tblGreenBindingSource.DataSource = this.charDataSet;
            // 
            // lsbGreen
            // 
            this.lsbGreen.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblGreenBindingSource, "Enemy", true));
            this.lsbGreen.DataSource = this.tblGreenBindingSource;
            this.lsbGreen.DisplayMember = "Enemy";
            this.lsbGreen.Enabled = false;
            this.lsbGreen.FormattingEnabled = true;
            this.lsbGreen.Location = new System.Drawing.Point(12, 288);
            this.lsbGreen.Name = "lsbGreen";
            this.lsbGreen.Size = new System.Drawing.Size(130, 199);
            this.lsbGreen.TabIndex = 3;
            this.lsbGreen.Visible = false;
            // 
            // tblOrangeBindingSource
            // 
            this.tblOrangeBindingSource.DataMember = "tblOrange";
            this.tblOrangeBindingSource.DataSource = this.charDataSet;
            // 
            // lsbOrange
            // 
            this.lsbOrange.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblOrangeBindingSource, "Enemy", true));
            this.lsbOrange.DataSource = this.tblOrangeBindingSource;
            this.lsbOrange.DisplayMember = "Enemy";
            this.lsbOrange.Enabled = false;
            this.lsbOrange.FormattingEnabled = true;
            this.lsbOrange.Location = new System.Drawing.Point(186, 288);
            this.lsbOrange.Name = "lsbOrange";
            this.lsbOrange.Size = new System.Drawing.Size(130, 199);
            this.lsbOrange.TabIndex = 5;
            this.lsbOrange.Visible = false;
            // 
            // tblPurpleBindingSource
            // 
            this.tblPurpleBindingSource.DataMember = "tblPurple";
            this.tblPurpleBindingSource.DataSource = this.charDataSet;
            // 
            // lsbPurple
            // 
            this.lsbPurple.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblPurpleBindingSource, "Enemy", true));
            this.lsbPurple.DataSource = this.tblPurpleBindingSource;
            this.lsbPurple.DisplayMember = "Enemy";
            this.lsbPurple.Enabled = false;
            this.lsbPurple.FormattingEnabled = true;
            this.lsbPurple.Location = new System.Drawing.Point(377, 288);
            this.lsbPurple.Name = "lsbPurple";
            this.lsbPurple.Size = new System.Drawing.Size(130, 199);
            this.lsbPurple.TabIndex = 7;
            this.lsbPurple.Visible = false;
            // 
            // tblRedBindingSource
            // 
            this.tblRedBindingSource.DataMember = "tblRed";
            this.tblRedBindingSource.DataSource = this.charDataSet;
            // 
            // lsbRed
            // 
            this.lsbRed.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblRedBindingSource, "Enemy", true));
            this.lsbRed.DataSource = this.tblRedBindingSource;
            this.lsbRed.DisplayMember = "Enemy";
            this.lsbRed.Enabled = false;
            this.lsbRed.FormattingEnabled = true;
            this.lsbRed.Location = new System.Drawing.Point(12, 45);
            this.lsbRed.Name = "lsbRed";
            this.lsbRed.Size = new System.Drawing.Size(130, 199);
            this.lsbRed.TabIndex = 10;
            this.lsbRed.Visible = false;
            // 
            // tblYellowBindingSource
            // 
            this.tblYellowBindingSource.DataMember = "tblYellow";
            this.tblYellowBindingSource.DataSource = this.charDataSet;
            // 
            // lsbYellow
            // 
            this.lsbYellow.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblYellowBindingSource, "Enemy", true));
            this.lsbYellow.DataSource = this.tblYellowBindingSource;
            this.lsbYellow.DisplayMember = "Enemy";
            this.lsbYellow.Enabled = false;
            this.lsbYellow.FormattingEnabled = true;
            this.lsbYellow.Location = new System.Drawing.Point(377, 45);
            this.lsbYellow.Name = "lsbYellow";
            this.lsbYellow.Size = new System.Drawing.Size(130, 199);
            this.lsbYellow.TabIndex = 12;
            this.lsbYellow.Visible = false;
            // 
            // lblRedMes
            // 
            this.lblRedMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRedMes.Location = new System.Drawing.Point(9, 45);
            this.lblRedMes.Name = "lblRedMes";
            this.lblRedMes.Size = new System.Drawing.Size(133, 199);
            this.lblRedMes.TabIndex = 13;
            this.lblRedMes.Text = "You must defeat more foes to reveal this information.";
            // 
            // lblBluMes
            // 
            this.lblBluMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBluMes.Location = new System.Drawing.Point(183, 45);
            this.lblBluMes.Name = "lblBluMes";
            this.lblBluMes.Size = new System.Drawing.Size(133, 199);
            this.lblBluMes.TabIndex = 14;
            this.lblBluMes.Text = "You must defeat more foes to reveal this information.";
            // 
            // lblYelMes
            // 
            this.lblYelMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYelMes.Location = new System.Drawing.Point(374, 45);
            this.lblYelMes.Name = "lblYelMes";
            this.lblYelMes.Size = new System.Drawing.Size(133, 199);
            this.lblYelMes.TabIndex = 15;
            this.lblYelMes.Text = "You must defeat more foes to reveal this information.";
            // 
            // lblGreMes
            // 
            this.lblGreMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreMes.Location = new System.Drawing.Point(12, 288);
            this.lblGreMes.Name = "lblGreMes";
            this.lblGreMes.Size = new System.Drawing.Size(133, 199);
            this.lblGreMes.TabIndex = 16;
            this.lblGreMes.Text = "You must defeat more foes to reveal this information.";
            // 
            // lblOraMes
            // 
            this.lblOraMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOraMes.Location = new System.Drawing.Point(183, 288);
            this.lblOraMes.Name = "lblOraMes";
            this.lblOraMes.Size = new System.Drawing.Size(133, 199);
            this.lblOraMes.TabIndex = 17;
            this.lblOraMes.Text = "You must defeat more foes to reveal this information.";
            // 
            // lblPurMes
            // 
            this.lblPurMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurMes.Location = new System.Drawing.Point(374, 288);
            this.lblPurMes.Name = "lblPurMes";
            this.lblPurMes.Size = new System.Drawing.Size(133, 199);
            this.lblPurMes.TabIndex = 18;
            this.lblPurMes.Text = "You must defeat more foes to reveal this information.";
            // 
            // Bestiary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 555);
            this.Controls.Add(this.lblPurMes);
            this.Controls.Add(this.lblOraMes);
            this.Controls.Add(this.lblGreMes);
            this.Controls.Add(this.lblYelMes);
            this.Controls.Add(this.lblBluMes);
            this.Controls.Add(this.lblRedMes);
            this.Controls.Add(enemyLabel4);
            this.Controls.Add(this.lsbYellow);
            this.Controls.Add(enemyLabel3);
            this.Controls.Add(this.lsbRed);
            this.Controls.Add(label1);
            this.Controls.Add(enemyLabel2);
            this.Controls.Add(this.lsbPurple);
            this.Controls.Add(enemyLabel1);
            this.Controls.Add(this.lsbOrange);
            this.Controls.Add(enemyLabel);
            this.Controls.Add(this.lsbGreen);
            this.Controls.Add(this.lsbBlue);
            this.Controls.Add(this.btnClose);
            this.Name = "Bestiary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bestiary";
            this.Load += new System.EventHandler(this.Bestiary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.charDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBlueBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblGreenBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblOrangeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPurpleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRedBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblYellowBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.BindingSource tblBlueBindingSource;
        private CharDataSetTableAdapters.tblBlueTableAdapter tblBlueTableAdapter;
        private System.Windows.Forms.ListBox lsbBlue;
        private CharDataSetTableAdapters.tblGreenTableAdapter tblGreenTableAdapter;
        private CharDataSetTableAdapters.tblOrangeTableAdapter tblOrangeTableAdapter;
        private System.Windows.Forms.ListBox lsbGreen;
        private System.Windows.Forms.BindingSource tblOrangeBindingSource;
        private CharDataSetTableAdapters.tblPurpleTableAdapter tblPurpleTableAdapter;
        private System.Windows.Forms.ListBox lsbOrange;
        private System.Windows.Forms.BindingSource tblPurpleBindingSource;
        private System.Windows.Forms.ListBox lsbPurple;
        private CharDataSetTableAdapters.tblRedTableAdapter tblRedTableAdapter;
        private System.Windows.Forms.BindingSource tblRedBindingSource;
        private System.Windows.Forms.ListBox lsbRed;
        private CharDataSetTableAdapters.tblYellowTableAdapter tblYellowTableAdapter;
        private System.Windows.Forms.BindingSource tblYellowBindingSource;
        private System.Windows.Forms.ListBox lsbYellow;
        private System.Windows.Forms.Label lblRedMes;
        private System.Windows.Forms.Label lblBluMes;
        private System.Windows.Forms.Label lblYelMes;
        private System.Windows.Forms.Label lblGreMes;
        private System.Windows.Forms.Label lblOraMes;
        private System.Windows.Forms.Label lblPurMes;
        private CharDataSet charDataSet;
        private CharDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource tblGreenBindingSource;
    }
}