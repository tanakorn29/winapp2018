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
    public partial class clinic_schedule : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-J5O17QF\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
        public clinic_schedule()
        {
            InitializeComponent();
            string query = ("select schedule_work_doctor.swd_id,employee_doctor.emp_doc_id,employee_doctor.emp_doc_name,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_date_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.room_id,schedule_work_doctor.swd_note from schedule_work_doctor inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where schedule_work_doctor.swd_status_room = 2");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();

                dataGridView1.Rows[n].Cells[0].Value = item["swd_id"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["emp_doc_id"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["emp_doc_name"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["swd_day_work"].ToString();
                CultureInfo ThaiCulture = new CultureInfo("en-US");
                DateTime date_work = Convert.ToDateTime(item["swd_date_work"].ToString());
                string work_swd = date_work.ToString("yyyy-MM-dd", ThaiCulture);

                dataGridView1.Rows[n].Cells[4].Value = work_swd;
                dataGridView1.Rows[n].Cells[5].Value = item["swd_start_time"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item["room_id"].ToString();
                dataGridView1.Rows[n].Cells[7].Value = item["swd_note"].ToString();



            }


            query = ("select schedule_work_doctor.swd_id,employee_doctor.emp_doc_id,employee_doctor.emp_doc_name,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_date_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.room_id,schedule_work_doctor.swd_note from schedule_work_doctor inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where schedule_work_doctor.swd_status_room = 3");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView2.Rows.Add();

                dataGridView2.Rows[n].Cells[0].Value = item["swd_id"].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item["emp_doc_id"].ToString();
                dataGridView2.Rows[n].Cells[2].Value = item["emp_doc_name"].ToString();
                dataGridView2.Rows[n].Cells[3].Value = item["swd_day_work"].ToString();
                CultureInfo ThaiCulture = new CultureInfo("en-US");
                DateTime date_work = Convert.ToDateTime(item["swd_date_work"].ToString());
                string work_swd = date_work.ToString("yyyy-MM-dd", ThaiCulture);

                dataGridView2.Rows[n].Cells[4].Value = work_swd;
                dataGridView2.Rows[n].Cells[5].Value = item["swd_start_time"].ToString();
                dataGridView2.Rows[n].Cells[6].Value = item["room_id"].ToString();
                dataGridView2.Rows[n].Cells[7].Value = item["swd_note"].ToString();



            }



            query = ("select emp_doc_name from employee_doctor");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                // int n = dataGridView1.Rows.Add();

                comboBox1.Items.Add(item["emp_doc_name"].ToString());


            }



        }




        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = ("select * from employee_doctor where emp_doc_name = '" + comboBox1.SelectedItem.ToString() + "'");
            cmd = new SqlCommand(query, conn);

            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                CultureInfo ThaiCulture = new CultureInfo("th-TH");
                int doc_id = Convert.ToInt32(sdr["emp_doc_id"].ToString());
    

                query = ("Update schedule_work_doctor set swd_note = 'รอการอนุมัติทำงานแทน',swd_status_room = 4, swd_emp_work_place = '" + comboBox1.SelectedItem.ToString() + "',emp_doc_id ='"+ doc_id + "' where swd_id = '" + txtswd.Text + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);


                clinic_schedule m3 = new clinic_schedule();
                m3.Show();
                clinic_schedule clnlog = new clinic_schedule();
                clnlog.Close();
                Visible = false;







            }



            conn.Close();
        }
        int selectedRow;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            txtswd.Text = row.Cells[0].Value.ToString();
            txtday.Text = row.Cells[3].Value.ToString();
            txttime.Text = row.Cells[4].Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView2.Rows[selectedRow];
            txtswdwork1.Text = row.Cells[0].Value.ToString();
            txtname1.Text = row.Cells[2].Value.ToString();
            txtday1.Text = row.Cells[3].Value.ToString();
            txtdateswd.Text = row.Cells[4].Value.ToString();
            txttime1.Text = row.Cells[5].Value.ToString();
        }

   

        private void button1_Click(object sender, EventArgs e)
        {

            conn.Open();
            string query = ("select * from employee_doctor where emp_doc_name = '" + txtname1.Text + "'");
            cmd = new SqlCommand(query, conn);

            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                CultureInfo ThaiCulture = new CultureInfo("th-TH");
                int doc_id = Convert.ToInt32(sdr["emp_doc_id"].ToString());
                // MessageBox.Show("" + doc_id);


                query = ("Update schedule_work_doctor set swd_note = '',swd_status_room = 1,swd_emp_work_place = '" + txtname1.Text + "',emp_doc_id = '"+ doc_id + "' where swd_id = '" + txtswdwork1.Text + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                query = ("select swd_id from schedule_work_doctor where swd_status_room = 1  AND swd_id = '" + txtswdwork1.Text + "'");
                cmd = new SqlCommand(query, conn);

                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    int swd_id = Convert.ToInt32(sdr["swd_id"].ToString());
                    //  query = ("update appointment SET status_approve = 3 ,swd_id = '" + swd_id + "' inner join employee_doctor on employee_doctor.emp_doc_id = appointment.emp_doc_id where employee_doctor.emp_doc_name = '"+ txtname1.Text + "'");
                   query = ("update appointment SET appointment.status_approve = 3,appointment.swd_id = '" + swd_id + "' from appointment inner join employee_doctor on employee_doctor.emp_doc_id = appointment.emp_doc_id where employee_doctor.emp_doc_name = '" + txtname1.Text + "'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);

                    MessageBox.Show("อนุมัติการเลื่อนปฏิบัติงานเรียบร้อย");
                    clinic_schedule m3 = new clinic_schedule();
                    m3.Show();
                    clinic_schedule clnlog = new clinic_schedule();
                    clnlog.Close();
                    Visible = false;


                }







            }



            conn.Close();

        }

        private void clinic_schedule_Load(object sender, EventArgs e)
        {


      
        }

        private void txttime1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
