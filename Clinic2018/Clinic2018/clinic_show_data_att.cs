using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic2018
{
    public partial class clinic_show_data_att : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-92251HH\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
        public clinic_show_data_att()
        {
            InitializeComponent();

            conn.Open();
            //  MessageBox.Show("" + comboBox3.SelectedIndex.ToString());

            string query = ("select start_time,end_time,date_work,remark,employee_ru.emp_ru_name from time_attendance inner join employee_ru on employee_ru.emp_ru_id = time_attendance.emp_ru_id");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();




                dataGridView1.Rows[n].Cells[0].Value = item["start_time"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["end_time"].ToString();
                CultureInfo ThaiCulture = new CultureInfo("th-TH");
                DateTime date = Convert.ToDateTime(item["date_work"].ToString());
                string date_th = date.ToString("yyyy-MM-dd", ThaiCulture);
                dataGridView1.Rows[n].Cells[2].Value = date_th;
                dataGridView1.Rows[n].Cells[3].Value = item["remark"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["emp_ru_name"].ToString();

            }

            query = ("select start_time, end_time, date_work, remark, employee_doctor.emp_doc_name from time_attendance inner join employee_doctor on employee_doctor.emp_doc_id = time_attendance.emp_doc_id");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView2.Rows.Add();




                dataGridView2.Rows[n].Cells[0].Value = item["start_time"].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item["end_time"].ToString();
                CultureInfo ThaiCulture = new CultureInfo("th-TH");
                DateTime date = Convert.ToDateTime(item["date_work"].ToString());
                string date_th = date.ToString("yyyy-MM-dd", ThaiCulture);
                dataGridView2.Rows[n].Cells[2].Value = date_th;
                dataGridView2.Rows[n].Cells[3].Value = item["remark"].ToString();
                dataGridView2.Rows[n].Cells[4].Value = item["emp_doc_name"].ToString();

            }



            conn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
