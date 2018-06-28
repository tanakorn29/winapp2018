namespace Clinic2018
{
    partial class clinic_app_service
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ลำดับคิว = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.เวลา = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ชื่อสกุล = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.รหัสคนไข้ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbltime1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblidapp = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbltime = new System.Windows.Forms.Label();
            this.lbldate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbldocname = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblopdid = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblswdid = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnsent = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.lblday = new System.Windows.Forms.Label();
            this.lbltimezone = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.manuappToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label8 = new System.Windows.Forms.Label();
            this.lblqueue = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "นัดหมายการรักษา";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(46, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1244, 200);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ลำดับการให้บริการ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ลำดับคิว,
            this.เวลา,
            this.ชื่อสกุล,
            this.Column1,
            this.รหัสคนไข้,
            this.Column4,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(29, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1075, 155);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ลำดับคิว
            // 
            this.ลำดับคิว.HeaderText = "ลำดับคิว";
            this.ลำดับคิว.Name = "ลำดับคิว";
            this.ลำดับคิว.ReadOnly = true;
            // 
            // เวลา
            // 
            this.เวลา.HeaderText = "เวลา";
            this.เวลา.Name = "เวลา";
            this.เวลา.ReadOnly = true;
            // 
            // ชื่อสกุล
            // 
            this.ชื่อสกุล.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ชื่อสกุล.HeaderText = "ชื่อสกุล";
            this.ชื่อสกุล.Name = "ชื่อสกุล";
            this.ชื่อสกุล.ReadOnly = true;
            this.ชื่อสกุล.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "รหัสประจำตัวประชาชน";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // รหัสคนไข้
            // 
            this.รหัสคนไข้.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.รหัสคนไข้.HeaderText = "รหัสคนไข้";
            this.รหัสคนไข้.Name = "รหัสคนไข้";
            this.รหัสคนไข้.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "ที่อยู่";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "วันเดือนปีเกิด";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "เบอร์โทร";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // lbltime1
            // 
            this.lbltime1.AutoSize = true;
            this.lbltime1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltime1.Location = new System.Drawing.Point(1240, 27);
            this.lbltime1.Name = "lbltime1";
            this.lbltime1.Size = new System.Drawing.Size(66, 25);
            this.lbltime1.TabIndex = 17;
            this.lbltime1.Text = "00.00";
            this.lbltime1.TextChanged += new System.EventHandler(this.lbltime1_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblidapp);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.lblname);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lbltime);
            this.groupBox3.Controls.Add(this.lbldate);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.lbldocname);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(837, 287);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(492, 175);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ข้อมูลการนัดหมาย";
            // 
            // lblidapp
            // 
            this.lblidapp.AutoSize = true;
            this.lblidapp.Location = new System.Drawing.Point(157, 31);
            this.lblidapp.Name = "lblidapp";
            this.lblidapp.Size = new System.Drawing.Size(0, 13);
            this.lblidapp.TabIndex = 20;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(54, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "รหัสอ้างอิงนัดหมาย:";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(157, 132);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(0, 13);
            this.lblname.TabIndex = 18;
            this.lblname.TextChanged += new System.EventHandler(this.lblname_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(98, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "ชื่อคนไข้ :";
            // 
            // lbltime
            // 
            this.lbltime.AutoSize = true;
            this.lbltime.Location = new System.Drawing.Point(157, 104);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(0, 13);
            this.lbltime.TabIndex = 16;
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Location = new System.Drawing.Point(157, 80);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(0, 13);
            this.lbldate.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "เวลา :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "วันที่ :";
            // 
            // lbldocname
            // 
            this.lbldocname.AutoSize = true;
            this.lbldocname.Location = new System.Drawing.Point(157, 55);
            this.lbldocname.Name = "lbldocname";
            this.lbldocname.Size = new System.Drawing.Size(0, 13);
            this.lbldocname.TabIndex = 13;
            this.lbldocname.TextChanged += new System.EventHandler(this.lbldocname_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(86, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "แพทย์ผู้นัด :";
            // 
            // lblopdid
            // 
            this.lblopdid.AutoSize = true;
            this.lblopdid.Location = new System.Drawing.Point(168, 81);
            this.lblopdid.Name = "lblopdid";
            this.lblopdid.Size = new System.Drawing.Size(0, 13);
            this.lblopdid.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(63, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "รหัสเวชระเบียน :";
            // 
            // lblswdid
            // 
            this.lblswdid.AutoSize = true;
            this.lblswdid.Location = new System.Drawing.Point(168, 45);
            this.lblswdid.Name = "lblswdid";
            this.lblswdid.Size = new System.Drawing.Size(0, 13);
            this.lblswdid.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "รหัสอ้างอิงตารางงาน :";
            // 
            // btnsent
            // 
            this.btnsent.Location = new System.Drawing.Point(213, 133);
            this.btnsent.Name = "btnsent";
            this.btnsent.Size = new System.Drawing.Size(75, 23);
            this.btnsent.TabIndex = 21;
            this.btnsent.Text = "ส่งตรวจ";
            this.btnsent.UseVisualStyleBackColor = true;
            this.btnsent.Click += new System.EventHandler(this.btnsent_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "วัน";
            // 
            // lblday
            // 
            this.lblday.AutoSize = true;
            this.lblday.Location = new System.Drawing.Point(107, 31);
            this.lblday.Name = "lblday";
            this.lblday.Size = new System.Drawing.Size(10, 13);
            this.lblday.TabIndex = 6;
            this.lblday.Text = "-";
            // 
            // lbltimezone
            // 
            this.lbltimezone.AutoSize = true;
            this.lbltimezone.Location = new System.Drawing.Point(605, 31);
            this.lbltimezone.Name = "lbltimezone";
            this.lbltimezone.Size = new System.Drawing.Size(0, 13);
            this.lbltimezone.TabIndex = 7;
            this.lbltimezone.TextChanged += new System.EventHandler(this.lbltimezone_TextChanged);
            this.lbltimezone.Click += new System.EventHandler(this.lbltimezone_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Controls.Add(this.lbltimezone);
            this.groupBox2.Controls.Add(this.lblday);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(46, 342);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(721, 248);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ตารางงานแพทย์";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dataGridView2.Location = new System.Drawing.Point(13, 61);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(702, 159);
            this.dataGridView2.TabIndex = 19;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // Column8
            // 
            this.Column8.HeaderText = "หมายเลขอ้างอิงตารางงาน";
            this.Column8.Name = "Column8";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "ชื่อแพทย์";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "ความเชี่ยวชาญ";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "วันที่มาปฏิบัติงาน";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "เวลาปฏิบัติงาน";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "เวลาเลิกปฏิบัติงาน";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "หมายเหตุ";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "ห้องตรวจ";
            this.Column7.Name = "Column7";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnsent);
            this.groupBox4.Controls.Add(this.lblopdid);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.lblswdid);
            this.groupBox4.Location = new System.Drawing.Point(837, 513);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(492, 181);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ส่งเข้าห้องตรวจ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manuappToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // manuappToolStripMenuItem
            // 
            this.manuappToolStripMenuItem.Name = "manuappToolStripMenuItem";
            this.manuappToolStripMenuItem.Size = new System.Drawing.Size(172, 20);
            this.manuappToolStripMenuItem.Text = "จัดการข้อมูลการนัดหมายการรักษา";
            this.manuappToolStripMenuItem.Click += new System.EventHandler(this.manuappToolStripMenuItem_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(213, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 25);
            this.label8.TabIndex = 28;
            this.label8.Text = "รอคิวการรักษาที่";
            // 
            // lblqueue
            // 
            this.lblqueue.AutoSize = true;
            this.lblqueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblqueue.Location = new System.Drawing.Point(373, 27);
            this.lblqueue.Name = "lblqueue";
            this.lblqueue.Size = new System.Drawing.Size(19, 25);
            this.lblqueue.TabIndex = 29;
            this.lblqueue.Text = "-";
            this.lblqueue.TextChanged += new System.EventHandler(this.lblqueue_TextChanged);
            // 
            // clinic_app_service
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.lblqueue);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lbltime1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "clinic_app_service";
            this.Text = "การนัดหมายการรักษา";
            this.Load += new System.EventHandler(this.clinic_app_service_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbltime1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnsent;
        private System.Windows.Forms.Label lblidapp;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbldocname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblday;
        private System.Windows.Forms.Label lbltimezone;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblopdid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblswdid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ลำดับคิว;
        private System.Windows.Forms.DataGridViewTextBoxColumn เวลา;
        private System.Windows.Forms.DataGridViewTextBoxColumn ชื่อสกุล;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn รหัสคนไข้;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem manuappToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblqueue;
    }
}