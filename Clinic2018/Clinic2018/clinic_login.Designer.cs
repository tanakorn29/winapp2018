﻿namespace Clinic2018
{
    partial class clinic_login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(clinic_login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.B_login = new Bunifu.Framework.UI.BunifuThinButton2();
            this.T_Username = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.T_Password = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.P_password = new System.Windows.Forms.PictureBox();
            this.P_username = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.P_password)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P_username)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 269);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("TH SarabunPSK", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(24, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "ระบบบริหารจัดการงานบริการงานแพทย์และอนามัย";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TH SarabunPSK", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(5, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Medical and Health Care Management System";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Clinic2018.Properties.Resources.มหาวิทยาลัยรามคำแหง_21;
            this.pictureBox1.Location = new System.Drawing.Point(53, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 152);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.B_login);
            this.groupBox1.Controls.Add(this.T_Username);
            this.groupBox1.Controls.Add(this.T_Password);
            this.groupBox1.Controls.Add(this.P_password);
            this.groupBox1.Controls.Add(this.P_username);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(259, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 237);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(304, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "X";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // B_login
            // 
            this.B_login.ActiveBorderThickness = 1;
            this.B_login.ActiveCornerRadius = 20;
            this.B_login.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.B_login.ActiveForecolor = System.Drawing.Color.White;
            this.B_login.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.B_login.BackColor = System.Drawing.SystemColors.Highlight;
            this.B_login.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_login.BackgroundImage")));
            this.B_login.ButtonText = "login";
            this.B_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_login.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_login.ForeColor = System.Drawing.Color.SeaGreen;
            this.B_login.IdleBorderThickness = 1;
            this.B_login.IdleCornerRadius = 20;
            this.B_login.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(210)))), ((int)(((byte)(66)))));
            this.B_login.IdleForecolor = System.Drawing.Color.White;
            this.B_login.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(210)))), ((int)(((byte)(66)))));
            this.B_login.Location = new System.Drawing.Point(211, 157);
            this.B_login.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.B_login.Name = "B_login";
            this.B_login.Size = new System.Drawing.Size(87, 41);
            this.B_login.TabIndex = 11;
            this.B_login.Tag = "111";
            this.B_login.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.B_login.Click += new System.EventHandler(this.B_login_Click);
            // 
            // T_Username
            // 
            this.T_Username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.T_Username.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.T_Username.ForeColor = System.Drawing.Color.White;
            this.T_Username.HintForeColor = System.Drawing.Color.Empty;
            this.T_Username.HintText = "";
            this.T_Username.isPassword = false;
            this.T_Username.LineFocusedColor = System.Drawing.Color.White;
            this.T_Username.LineIdleColor = System.Drawing.Color.White;
            this.T_Username.LineMouseHoverColor = System.Drawing.Color.White;
            this.T_Username.LineThickness = 3;
            this.T_Username.Location = new System.Drawing.Point(72, 50);
            this.T_Username.Margin = new System.Windows.Forms.Padding(4);
            this.T_Username.Name = "T_Username";
            this.T_Username.Size = new System.Drawing.Size(226, 33);
            this.T_Username.TabIndex = 9;
            this.T_Username.Text = "Username";
            this.T_Username.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.T_Username.Enter += new System.EventHandler(this.T_Username_Enter);
            this.T_Username.Leave += new System.EventHandler(this.T_Username_Leave);
            // 
            // T_Password
            // 
            this.T_Password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.T_Password.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.T_Password.ForeColor = System.Drawing.Color.White;
            this.T_Password.HintForeColor = System.Drawing.Color.Empty;
            this.T_Password.HintText = "";
            this.T_Password.isPassword = true;
            this.T_Password.LineFocusedColor = System.Drawing.Color.White;
            this.T_Password.LineIdleColor = System.Drawing.Color.White;
            this.T_Password.LineMouseHoverColor = System.Drawing.Color.White;
            this.T_Password.LineThickness = 3;
            this.T_Password.Location = new System.Drawing.Point(72, 113);
            this.T_Password.Margin = new System.Windows.Forms.Padding(4);
            this.T_Password.Name = "T_Password";
            this.T_Password.Size = new System.Drawing.Size(226, 33);
            this.T_Password.TabIndex = 10;
            this.T_Password.Text = "Password";
            this.T_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.T_Password.Enter += new System.EventHandler(this.T_Password_Enter);
            this.T_Password.Leave += new System.EventHandler(this.T_Password_Leave);
            // 
            // P_password
            // 
            this.P_password.Image = ((System.Drawing.Image)(resources.GetObject("P_password.Image")));
            this.P_password.Location = new System.Drawing.Point(36, 116);
            this.P_password.Name = "P_password";
            this.P_password.Size = new System.Drawing.Size(29, 30);
            this.P_password.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.P_password.TabIndex = 7;
            this.P_password.TabStop = false;
            // 
            // P_username
            // 
            this.P_username.Image = global::Clinic2018.Properties.Resources.ic_user;
            this.P_username.Location = new System.Drawing.Point(36, 53);
            this.P_username.Name = "P_username";
            this.P_username.Size = new System.Drawing.Size(29, 30);
            this.P_username.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.P_username.TabIndex = 8;
            this.P_username.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("TH SarabunPSK", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(112, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "00.00";
            // 
            // clinic_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 269);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "clinic_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "clinic_login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.P_password)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P_username)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Bunifu.Framework.UI.BunifuThinButton2 B_login;
        private Bunifu.Framework.UI.BunifuMaterialTextbox T_Username;
        private Bunifu.Framework.UI.BunifuMaterialTextbox T_Password;
        private System.Windows.Forms.PictureBox P_password;
        private System.Windows.Forms.PictureBox P_username;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}