namespace Clinic2018
{
    partial class clinic_calendar
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datadoctorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.สถานะสิทธิ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Picbox = new System.Windows.Forms.PictureBox();
            this.txtss = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtooid = new System.Windows.Forms.TextBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.txttel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtidcard = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.t3 = new System.Windows.Forms.Label();
            this.t2 = new System.Windows.Forms.Label();
            this.t1 = new System.Windows.Forms.Label();
            this.connpatientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.conn_patient = new Clinic2018.conn_patient();
            this.medical_historyTableAdapter1 = new Clinic2018.DataSet1TableAdapters.medical_historyTableAdapter();
            this.dataSet1 = new Clinic2018.DataSet1();
            this.districtsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.districtsTableAdapter = new Clinic2018.DataSet1TableAdapters.districtsTableAdapter();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Picbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.connpatientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conn_patient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.districtsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1320, 588);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.datadoctorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1320, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.exitToolStripMenuItem.Text = "จัดการเวลาการปฏิบัติงาน";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.timeToolStripMenuItem_Click);
            // 
            // datadoctorToolStripMenuItem
            // 
            this.datadoctorToolStripMenuItem.Name = "datadoctorToolStripMenuItem";
            this.datadoctorToolStripMenuItem.Size = new System.Drawing.Size(141, 20);
            this.datadoctorToolStripMenuItem.Text = "จัดการข้อมูลการทำงานแทน";
            this.datadoctorToolStripMenuItem.Click += new System.EventHandler(this.docinputToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("TH SarabunPSK", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(84, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(251, 42);
            this.label3.TabIndex = 10;
            this.label3.Text = "จัดการปฎิบัติงานแพทย์";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "ระบบบริหารจัดการงานบริการงานแพทย์และอนามัย ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox2.Location = new System.Drawing.Point(442, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(571, 385);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ตารางปฏิบัติงาน";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column4,
            this.สถานะสิทธิ,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(6, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(559, 267);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.HeaderText = "แพทย์";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 150F;
            this.Column3.HeaderText = "วันปฎิบัติงาน";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "เวลาปฎิบัติงาน";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // สถานะสิทธิ
            // 
            this.สถานะสิทธิ.HeaderText = "ห้องรักษา";
            this.สถานะสิทธิ.Name = "สถานะสิทธิ";
            this.สถานะสิทธิ.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "หมายเหตุ";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Picbox);
            this.groupBox1.Controls.Add(this.txtss);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtooid);
            this.groupBox1.Controls.Add(this.txtemail);
            this.groupBox1.Controls.Add(this.txttel);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.txtidcard);
            this.groupBox1.Controls.Add(this.txtname);
            this.groupBox1.Controls.Add(this.txtaddress);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.t3);
            this.groupBox1.Controls.Add(this.t2);
            this.groupBox1.Controls.Add(this.t1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(21, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 456);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "เพื่มข้อมูล";
            // 
            // Picbox
            // 
            this.Picbox.BackColor = System.Drawing.SystemColors.Window;
            this.Picbox.Location = new System.Drawing.Point(153, 91);
            this.Picbox.Name = "Picbox";
            this.Picbox.Size = new System.Drawing.Size(168, 44);
            this.Picbox.TabIndex = 15;
            this.Picbox.TabStop = false;
            // 
            // txtss
            // 
            this.txtss.Location = new System.Drawing.Point(153, 354);
            this.txtss.Name = "txtss";
            this.txtss.Size = new System.Drawing.Size(168, 22);
            this.txtss.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(58, 354);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "ความเชี่ยวชาญ :";
            // 
            // txtooid
            // 
            this.txtooid.Location = new System.Drawing.Point(153, 312);
            this.txtooid.Name = "txtooid";
            this.txtooid.Size = new System.Drawing.Size(168, 22);
            this.txtooid.TabIndex = 12;
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(153, 283);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(168, 22);
            this.txtemail.TabIndex = 11;
            // 
            // txttel
            // 
            this.txttel.Location = new System.Drawing.Point(153, 255);
            this.txttel.Name = "txttel";
            this.txttel.Size = new System.Drawing.Size(168, 22);
            this.txttel.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(58, 315);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "หมายเลขวิชาชีพ :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(69, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "E-mail :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(153, 151);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // txtidcard
            // 
            this.txtidcard.Location = new System.Drawing.Point(153, 63);
            this.txtidcard.Name = "txtidcard";
            this.txtidcard.Size = new System.Drawing.Size(168, 22);
            this.txtidcard.TabIndex = 6;
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(153, 28);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(168, 22);
            this.txtname.TabIndex = 5;
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(153, 190);
            this.txtaddress.Multiline = true;
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(168, 50);
            this.txtaddress.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(259, 404);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "บันทึก";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 404);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "ยกเลิก";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(69, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "เบอร์โทรศัพท์ :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(113, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "ที่อยู่ :";
            // 
            // t3
            // 
            this.t3.AutoSize = true;
            this.t3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.t3.Location = new System.Drawing.Point(74, 151);
            this.t3.Name = "t3";
            this.t3.Size = new System.Drawing.Size(73, 16);
            this.t3.TabIndex = 0;
            this.t3.Text = "วันเดือนปีเกิด :";
            // 
            // t2
            // 
            this.t2.AutoSize = true;
            this.t2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.t2.Location = new System.Drawing.Point(24, 63);
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(123, 16);
            this.t2.TabIndex = 0;
            this.t2.Text = "รหัสประจำตัวประชาชน :";
            // 
            // t1
            // 
            this.t1.AutoSize = true;
            this.t1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.t1.Location = new System.Drawing.Point(92, 28);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(55, 16);
            this.t1.TabIndex = 0;
            this.t1.Text = "ชื่อแพทย์ :";
            // 
            // connpatientBindingSource
            // 
            this.connpatientBindingSource.DataSource = this.conn_patient;
            this.connpatientBindingSource.Position = 0;
            // 
            // conn_patient
            // 
            this.conn_patient.DataSetName = "conn_patient";
            this.conn_patient.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // medical_historyTableAdapter1
            // 
            this.medical_historyTableAdapter1.ClearBeforeFill = true;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // districtsBindingSource
            // 
            this.districtsBindingSource.DataMember = "districts";
            this.districtsBindingSource.DataSource = this.dataSet1;
            // 
            // districtsTableAdapter
            // 
            this.districtsTableAdapter.ClearBeforeFill = true;
            // 
            // clinic_calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 588);
            this.Controls.Add(this.panel1);
            this.Name = "clinic_calendar";
            this.Text = "จัดการปฎิบัติงานแพทย์  - ระบบบริหารจัดการงานบริการงานแพทย์และอนามัย  ";
            this.Load += new System.EventHandler(this.clinic_calendar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Picbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.connpatientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conn_patient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.districtsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DataSet1TableAdapters.medical_historyTableAdapter medical_historyTableAdapter1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label t3;
        private System.Windows.Forms.Label t2;
        private System.Windows.Forms.Label t1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn สถานะสิทธิ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtidcard;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtooid;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.TextBox txttel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtss;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox Picbox;
        private System.Windows.Forms.BindingSource connpatientBindingSource;
        private conn_patient conn_patient;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource districtsBindingSource;
        private DataSet1TableAdapters.districtsTableAdapter districtsTableAdapter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datadoctorToolStripMenuItem;
    }
}