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

namespace Clinic2018
{
    public partial class clinic_doctor_show : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-BP7LPPN\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets=true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
        public clinic_doctor_show()
        {
            InitializeComponent();
            conn.Open();
            string query = ("select employee_doctor.emp_doc_id,employee_doctor.emp_doc_name,employee_doctor.emp_doc_idcard,specialist.emp_doc_specialist,employee_doctor.emp_doc_tel,employee_doctor.emp_doc_address,employee_doctor.emp_doc_email from employee_doctor inner join specialist on specialist.emp_doc_specialistid = employee_doctor.emp_doc_specialistid");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();



                dataGridView1.Rows[n].Cells[0].Value = item["emp_doc_id"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["emp_doc_name"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["emp_doc_idcard"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["emp_doc_specialist"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["emp_doc_tel"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item["emp_doc_address"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item["emp_doc_email"].ToString();
         



            }




            conn.Close();

        }

        private void clinic_doctor_show_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
