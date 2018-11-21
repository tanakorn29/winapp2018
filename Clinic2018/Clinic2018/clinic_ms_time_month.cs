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
    public partial class clinic_ms_time_month : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-92251HH\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
        public clinic_ms_time_month()
        {
            InitializeComponent();

            conn.Open();

           string month = DateTime.Now.ToString("MMMM", new CultureInfo("th-TH"));

            string query = ("select swd_month_work from schedule_work_doctor Order by swd_id DESC");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();

            sda.Fill(dt);

            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                string month_work = sdr["swd_month_work"].ToString();


                query = ("select employee_doctor.emp_doc_id,employee_doctor.emp_doc_name from schedule_work_doctor inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where schedule_work_doctor.swd_status_room = 1 AND schedule_work_doctor.swd_month_work = '"+month_work+"' group by employee_doctor.emp_doc_id,employee_doctor.emp_doc_name");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();




                    dataGridView1.Rows[n].Cells[0].Value = item["emp_doc_id"].ToString();

                    

                    dataGridView1.Rows[n].Cells[1].Value = item["emp_doc_name"].ToString();




                }

                query = ("select schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_date_work,schedule_work_doctor.swd_start_time from schedule_work_doctor where schedule_work_doctor.swd_status_room = 0 AND schedule_work_doctor.room_id = 1 AND schedule_work_doctor.swd_month_work = '" + month_work+ "' group by schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_date_work,schedule_work_doctor.swd_start_time ORDER BY swd_date_work ASC");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView2.Rows.Add();




                    dataGridView2.Rows[n].Cells[0].Value = item["swd_day_work"].ToString();

                    DateTime date = Convert.ToDateTime(item["swd_date_work"].ToString());
                    string date_swd = date.ToString("yyyy-MM-dd");
                    dataGridView2.Rows[n].Cells[1].Value = date_swd;

                    dataGridView2.Rows[n].Cells[2].Value = item["swd_start_time"].ToString();



                }

            }


            conn.Close();
        }

        private void clinic_ms_time_month_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();


                string doc_id = textBox1.Text;
                string date = textBox3.Text;
                string time = textBox4.Text;
                if(doc_id == "" || date == ""  || time == "")
                {
            

                    MessageBox.Show("การจัดตารางไม่สำเร็จ");
          
      
                }
                else
                {
                   string query = ("select count(*) from schedule_work_doctor where swd_date_work = '" + textBox3.Text + "' AND room_id = 2 AND room_id = 3 AND emp_doc_id = '" + textBox1.Text+"'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();

                    sda.Fill(dt);

                    int swd_count1 = (int)cmd.ExecuteScalar();
                    if(swd_count1 < 1)
                    {
                   
              query = ("Update schedule_work_doctor set emp_doc_id = " + textBox1.Text + ",swd_status_room = 1  where swd_date_work = '" + textBox3.Text + "' and room_id = 1 AND swd_start_time = '"+textBox4.Text+"' ");
          cmd = new SqlCommand(query, conn);
          sda = new SqlDataAdapter(cmd);
          dt = new DataTable();

          sda.Fill(dt);
          clinic_ms_time_month doc1 = new clinic_ms_time_month();
          doc1.Show();

          clinic_ms_time_month clnlog = new clinic_ms_time_month();
          clnlog.Close();
          Visible = false;
               MessageBox.Show("การจัดตารางเสร็จสิ้น");
               
                    }
                    else
                    {
                        MessageBox.Show("ไม่สามารถลงตารางปฏิบัติงานได้");
                    }
       
                }


                conn.Close();


            }
            catch (Exception)
            {
                MessageBox.Show("ไม่มีข้อมูลการจัดตารางงาน");
            }
 
        }
        int selectedRow;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];

            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView2.Rows[selectedRow];

            textBox3.Text = row.Cells[1].Value.ToString();
            textBox4.Text = row.Cells[2].Value.ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
