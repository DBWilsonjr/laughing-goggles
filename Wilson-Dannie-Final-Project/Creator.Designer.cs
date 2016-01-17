namespace Wilson_Dannie_Final_Project
{
    partial class Creator
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lsbColor = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lsbWeapon = new System.Windows.Forms.ListBox();
            this.lsbOffhand = new System.Windows.Forms.ListBox();
            this.lsbSpecial = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.radEasy = new System.Windows.Forms.RadioButton();
            this.radNorm = new System.Windows.Forms.RadioButton();
            this.radHard = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(66, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(134, 20);
            this.txtName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Huskarl",
            "Seige Archer",
            "Oracle"});
            this.listBox1.Location = new System.Drawing.Point(80, 61);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 147);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Character Type:";
            // 
            // lsbColor
            // 
            this.lsbColor.Enabled = false;
            this.lsbColor.FormattingEnabled = true;
            this.lsbColor.Location = new System.Drawing.Point(213, 61);
            this.lsbColor.Name = "lsbColor";
            this.lsbColor.Size = new System.Drawing.Size(120, 147);
            this.lsbColor.TabIndex = 5;
            this.toolTip1.SetToolTip(this.lsbColor, "Color impacts a character\'s defense against damage. One\r\ncolor will always do mor" +
        "e damage and another will do less.\r\n\r\nRed > Blue\r\nBlue > Yellow\r\nYellow > Red");
            this.lsbColor.SelectedIndexChanged += new System.EventHandler(this.lsbColor_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(213, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Character Color:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Weapon:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(268, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Special:";
            // 
            // lsbWeapon
            // 
            this.lsbWeapon.Enabled = false;
            this.lsbWeapon.FormattingEnabled = true;
            this.lsbWeapon.Location = new System.Drawing.Point(14, 239);
            this.lsbWeapon.Name = "lsbWeapon";
            this.lsbWeapon.Size = new System.Drawing.Size(120, 160);
            this.lsbWeapon.TabIndex = 9;
            this.lsbWeapon.SelectedIndexChanged += new System.EventHandler(this.lsbWeapon_SelectedIndexChanged);
            // 
            // lsbOffhand
            // 
            this.lsbOffhand.Enabled = false;
            this.lsbOffhand.FormattingEnabled = true;
            this.lsbOffhand.Location = new System.Drawing.Point(142, 239);
            this.lsbOffhand.Name = "lsbOffhand";
            this.lsbOffhand.Size = new System.Drawing.Size(120, 160);
            this.lsbOffhand.TabIndex = 10;
            this.lsbOffhand.SelectedIndexChanged += new System.EventHandler(this.lsbOffhand_SelectedIndexChanged);
            // 
            // lsbSpecial
            // 
            this.lsbSpecial.Enabled = false;
            this.lsbSpecial.FormattingEnabled = true;
            this.lsbSpecial.Items.AddRange(new object[] {
            "Red Strike",
            "Blue Strike",
            "Yellow Strike"});
            this.lsbSpecial.Location = new System.Drawing.Point(268, 239);
            this.lsbSpecial.Name = "lsbSpecial";
            this.lsbSpecial.Size = new System.Drawing.Size(120, 160);
            this.lsbSpecial.TabIndex = 12;
            this.lsbSpecial.SelectedIndexChanged += new System.EventHandler(this.lsbSpecial_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(142, 219);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Off-hand:";
            // 
            // btnMenu
            // 
            this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.Location = new System.Drawing.Point(14, 458);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(120, 50);
            this.btnMenu.TabIndex = 13;
            this.btnMenu.Text = "Return\r\nto Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(268, 458);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(120, 50);
            this.btnConfirm.TabIndex = 14;
            this.btnConfirm.Text = "Confirm Character";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(142, 458);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 50);
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "Reset Choices";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // radEasy
            // 
            this.radEasy.AutoSize = true;
            this.radEasy.Location = new System.Drawing.Point(6, 19);
            this.radEasy.Name = "radEasy";
            this.radEasy.Size = new System.Drawing.Size(78, 17);
            this.radEasy.TabIndex = 16;
            this.radEasy.TabStop = true;
            this.radEasy.Text = "Easy Mode";
            this.toolTip1.SetToolTip(this.radEasy, "Easy Mode give you the most time before bosses may appear. It\'s possible to win t" +
        "he game without ever seeing a boss.");
            this.radEasy.UseVisualStyleBackColor = true;
            // 
            // radNorm
            // 
            this.radNorm.AutoSize = true;
            this.radNorm.Location = new System.Drawing.Point(142, 19);
            this.radNorm.Name = "radNorm";
            this.radNorm.Size = new System.Drawing.Size(88, 17);
            this.radNorm.TabIndex = 17;
            this.radNorm.TabStop = true;
            this.radNorm.Text = "Normal Mode";
            this.toolTip1.SetToolTip(this.radNorm, "The base difficulty. Gives a reasonable amount of time before bosses may appear.");
            this.radNorm.UseVisualStyleBackColor = true;
            // 
            // radHard
            // 
            this.radHard.AutoSize = true;
            this.radHard.Location = new System.Drawing.Point(290, 19);
            this.radHard.Name = "radHard";
            this.radHard.Size = new System.Drawing.Size(78, 17);
            this.radHard.TabIndex = 18;
            this.radHard.TabStop = true;
            this.radHard.Text = "Hard Mode";
            this.toolTip1.SetToolTip(this.radHard, "The Hardest difficulty. Bosses may show up at any moment.");
            this.radHard.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radEasy);
            this.groupBox1.Controls.Add(this.radHard);
            this.groupBox1.Controls.Add(this.radNorm);
            this.groupBox1.Location = new System.Drawing.Point(14, 409);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 43);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose Difficulty";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // Creator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 522);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.lsbSpecial);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lsbOffhand);
            this.Controls.Add(this.lsbWeapon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lsbColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Name = "Creator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Creator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lsbColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lsbWeapon;
        private System.Windows.Forms.ListBox lsbOffhand;
        private System.Windows.Forms.ListBox lsbSpecial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnReset;
        public System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.RadioButton radEasy;
        public System.Windows.Forms.RadioButton radNorm;
        public System.Windows.Forms.RadioButton radHard;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}