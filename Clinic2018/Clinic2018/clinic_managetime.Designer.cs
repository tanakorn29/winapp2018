namespace Clinic2018
{
    partial class clinic_managetime
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.combostatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txttimezone = new System.Windows.Forms.TextBox();
            this.txtroom = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtremark = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtday = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtendtime = new System.Windows.Forms.TextBox();
            this.txtstarttime = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.t2 = new System.Windows.Forms.Label();
            this.t1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox2.Location = new System.Drawing.Point(510, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(626, 469);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ตารางงาน";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(363, 415);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(178, 23);
            this.button4.TabIndex = 16;
            this.button4.Text = "ยกเลิกเวลาปฏิบัติงาน";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(84, 415);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(178, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "เปิดลงทะเบียนเวลาปฏิบัติงาน";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dataGridView1.Location = new System.Drawing.Point(25, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(595, 328);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column5
            // 
            this.Column5.HeaderText = "เดือน";
            this.Column5.Name = "Column5";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "วัน";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "เวลาเริ่มต้นปฏิบัติงาน";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "เวลาสิ้นสุดการปฏิบัติงาน";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "หมายเหตุ";
            this.Column4.Name = "Column4";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "ห้องตรวจ";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "สถานะห้องตรวจ";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "ช่วงเวลา";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "สถานะตาราง";
            this.Column9.Name = "Column9";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.combostatus);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txttimezone);
            this.groupBox1.Controls.Add(this.txtroom);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtremark);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtday);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtendtime);
            this.groupBox1.Controls.Add(this.txtstarttime);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.t2);
            this.groupBox1.Controls.Add(this.t1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(91, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 422);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "จัดการเวลางาน";
            // 
            // combostatus
            // 
            this.combostatus.FormattingEnabled = true;
            this.combostatus.Items.AddRange(new object[] {
            "เปิดลงเวลาการปฏิบัติงาน",
            "ยังไม่เปิดลงเวลาปฏิบัติงาน"});
            this.combostatus.Location = new System.Drawing.Point(153, 25);
            this.combostatus.Name = "combostatus";
            this.combostatus.Size = new System.Drawing.Size(159, 24);
            this.combostatus.TabIndex = 24;
            this.combostatus.SelectedIndexChanged += new System.EventHandler(this.combostatus_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(60, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "สถานะตารางงาน";
            // 
            // txttimezone
            // 
            this.txttimezone.Enabled = false;
            this.txttimezone.Location = new System.Drawing.Point(153, 299);
            this.txttimezone.Name = "txttimezone";
            this.txttimezone.Size = new System.Drawing.Size(168, 22);
            this.txttimezone.TabIndex = 23;
            // 
            // txtroom
            // 
            this.txtroom.Enabled = false;
            this.txtroom.Location = new System.Drawing.Point(153, 258);
            this.txtroom.Name = "txtroom";
            this.txtroom.Size = new System.Drawing.Size(168, 22);
            this.txtroom.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(86, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 16);
            this.label7.TabIndex = 21;
            this.label7.Text = "หมายเหตุ :";
            // 
            // txtremark
            // 
            this.txtremark.Location = new System.Drawing.Point(153, 217);
            this.txtremark.Name = "txtremark";
            this.txtremark.Size = new System.Drawing.Size(168, 22);
            this.txtremark.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(86, 302);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "ช่วงเวลา :";
            // 
            // txtday
            // 
            this.txtday.Enabled = false;
            this.txtday.Location = new System.Drawing.Point(153, 97);
            this.txtday.Name = "txtday";
            this.txtday.Size = new System.Drawing.Size(168, 22);
            this.txtday.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(80, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "ห้องตรวจ :";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "เดือนมกราคม       ",
            "เดือนกุมภาพันธ์    ",
            "เดือนมีนาคม  ",
            "เดือนเมษายน     ",
            "เดือนพฤษภาคม",
            "เดือนมิถุนายน ",
            "เดือนกรกฎาคม  ",
            "เดือนสิงหาคม ",
            "เดือนกันยายน ",
            "เดือนตุลาคม  ",
            "เดือนพฤศจิกายน ",
            "เดือนธันวาคม  "});
            this.comboBox1.Location = new System.Drawing.Point(153, 60);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(159, 24);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(108, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "วัน :";
            // 
            // txtendtime
            // 
            this.txtendtime.Location = new System.Drawing.Point(153, 179);
            this.txtendtime.Name = "txtendtime";
            this.txtendtime.Size = new System.Drawing.Size(168, 22);
            this.txtendtime.TabIndex = 7;
            // 
            // txtstarttime
            // 
            this.txtstarttime.Location = new System.Drawing.Point(153, 137);
            this.txtstarttime.Name = "txtstarttime";
            this.txtstarttime.Size = new System.Drawing.Size(168, 22);
            this.txtstarttime.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(153, 344);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "บันทึก";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(37, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "เวลาสิ้นสุดการทำงาน :";
            // 
            // t2
            // 
            this.t2.AutoSize = true;
            this.t2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.t2.Location = new System.Drawing.Point(24, 137);
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(124, 16);
            this.t2.TabIndex = 0;
            this.t2.Text = "เวลาเริ่มต้นการปฏิบัติงาน:";
            // 
            // t1
            // 
            this.t1.AutoSize = true;
            this.t1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.t1.Location = new System.Drawing.Point(108, 63);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(37, 16);
            this.t1.TabIndex = 0;
            this.t1.Text = "เดือน :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("TH SarabunPSK", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(65, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(300, 42);
            this.label3.TabIndex = 16;
            this.label3.Text = "จัดการเวลาปฎิบัติงานแพทย์";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "ระบบบริหารจัดการงานบริการงานแพทย์และอนามัย ";
            // 
            // clinic_managetime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "clinic_managetime";
            this.Text = "clinic_managetime";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox combostatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txttimezone;
        private System.Windows.Forms.TextBox txtroom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtremark;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtday;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtendtime;
        private System.Windows.Forms.TextBox txtstarttime;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label t2;
        private System.Windows.Forms.Label t1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}