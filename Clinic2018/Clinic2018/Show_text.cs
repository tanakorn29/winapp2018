using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace Clinic2018
{
    public partial class Show_text : Form
    {
        public Show_text()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-26BM5UJ\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
        internal string Setlabel
        {
            set { label1.Text = "ค่าที่ได้รับ :" + " "+ value; }
       
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {

        }

        private void bunifuTextbox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

           string query = ("select Count(*) from queue_visit_record inner join opd on opd.opd_id = queue_visit_record.opd_id inner join employee_ru on employee_ru.emp_ru_id = queue_visit_record.emp_ru_id where queue_visit_record.qvr_status = 1");
            conn.Open();
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
        //    sdr = cmd.ExecuteReader();
            int queue = (int)cmd.ExecuteScalar();
            textBox1.Text = "" + queue;
       //     Font h1 = new Font(bf_bold, 18);

        }
    }
}
