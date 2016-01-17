namespace Wilson_Dannie_Final_Project
{
    partial class PowerUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PowerUp));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTHP = new System.Windows.Forms.Label();
            this.lblTProt = new System.Windows.Forms.Label();
            this.lblPHP = new System.Windows.Forms.Label();
            this.lblPAtk = new System.Windows.Forms.Label();
            this.lblPDef = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 5;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(16, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 56);
            this.button1.TabIndex = 0;
            this.button1.Text = "Repair/Protect Temple";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(16, 222);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 56);
            this.button2.TabIndex = 1;
            this.button2.Text = "Improve Health";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(16, 284);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 56);
            this.button3.TabIndex = 2;
            this.button3.Text = "Improve Attack";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(16, 346);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(115, 56);
            this.button4.TabIndex = 3;
            this.button4.Text = "Improve Defense";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 132);
            this.label1.TabIndex = 4;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // lblTHP
            // 
            this.lblTHP.AutoSize = true;
            this.lblTHP.Location = new System.Drawing.Point(148, 160);
            this.lblTHP.Name = "lblTHP";
            this.lblTHP.Size = new System.Drawing.Size(35, 13);
            this.lblTHP.TabIndex = 5;
            this.lblTHP.Text = "label2";
            // 
            // lblTProt
            // 
            this.lblTProt.AutoSize = true;
            this.lblTProt.Location = new System.Drawing.Point(148, 182);
            this.lblTProt.Name = "lblTProt";
            this.lblTProt.Size = new System.Drawing.Size(35, 13);
            this.lblTProt.TabIndex = 6;
            this.lblTProt.Text = "label3";
            // 
            // lblPHP
            // 
            this.lblPHP.AutoSize = true;
            this.lblPHP.Location = new System.Drawing.Point(148, 244);
            this.lblPHP.Name = "lblPHP";
            this.lblPHP.Size = new System.Drawing.Size(35, 13);
            this.lblPHP.TabIndex = 7;
            this.lblPHP.Text = "label4";
            // 
            // lblPAtk
            // 
            this.lblPAtk.AutoSize = true;
            this.lblPAtk.Location = new System.Drawing.Point(148, 306);
            this.lblPAtk.Name = "lblPAtk";
            this.lblPAtk.Size = new System.Drawing.Size(35, 13);
            this.lblPAtk.TabIndex = 8;
            this.lblPAtk.Text = "label5";
            // 
            // lblPDef
            // 
            this.lblPDef.AutoSize = true;
            this.lblPDef.Location = new System.Drawing.Point(148, 368);
            this.lblPDef.Name = "lblPDef";
            this.lblPDef.Size = new System.Drawing.Size(35, 13);
            this.lblPDef.TabIndex = 9;
            this.lblPDef.Text = "label6";
            // 
            // PowerUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 432);
            this.Controls.Add(this.lblPDef);
            this.Controls.Add(this.lblPAtk);
            this.Controls.Add(this.lblPHP);
            this.Controls.Add(this.lblTProt);
            this.Controls.Add(this.lblTHP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "PowerUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PowerUp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTHP;
        private System.Windows.Forms.Label lblTProt;
        private System.Windows.Forms.Label lblPHP;
        private System.Windows.Forms.Label lblPAtk;
        private System.Windows.Forms.Label lblPDef;
    }
}