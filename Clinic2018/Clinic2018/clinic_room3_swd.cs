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
    public partial class clinic_room3_swd : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-BP7LPPN\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
        public clinic_room3_swd()
        {
            InitializeComponent();
            conn.Open();
            //  MessageBox.Show("" + comboBox3.SelectedIndex.ToString());

            string query = ("select schedule_work_doctor.swd_month_work,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_date_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.swd_end_time,schedule_work_doctor.swd_note,schedule_work_doctor.room_id,schedule_work_doctor.swd_status_room,schedule_work_doctor.swd_timezone,schedule_work_doctor.swd_status from schedule_work_doctor inner join room on room.room_id = schedule_work_doctor.room_id where schedule_work_doctor.room_id = 3");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();




                dataGridView1.Rows[n].Cells[0].Value = item["swd_month_work"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["swd_day_work"].ToString();
                CultureInfo ThaiCulture = new CultureInfo("en-US");
                DateTime date = Convert.ToDateTime(item["swd_date_work"].ToString());
                string date_th = date.ToString("yyyy-MM-dd", ThaiCulture);
                dataGridView1.Rows[n].Cells[2].Value = date_th;
                dataGridView1.Rows[n].Cells[3].Value = item["swd_start_time"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["swd_end_time"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item["swd_note"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item["room_id"].ToString();
                dataGridView1.Rows[n].Cells[7].Value = item["swd_status_room"].ToString();
                dataGridView1.Rows[n].Cells[8].Value = item["swd_timezone"].ToString();
                dataGridView1.Rows[n].Cells[9].Value = item["swd_status"].ToString();

            }





            conn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            //  MessageBox.Show("" + comboBox3.SelectedIndex.ToString());
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            string query = ("select schedule_work_doctor.swd_month_work,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_date_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.swd_end_time,schedule_work_doctor.swd_note,schedule_work_doctor.room_id,schedule_work_doctor.swd_status_room,schedule_work_doctor.swd_timezone,schedule_work_doctor.swd_status from schedule_work_doctor inner join room on room.room_id = schedule_work_doctor.room_id where swd_timezone = '" + comboBox3.SelectedItem.ToString() + "' AND schedule_work_doctor.room_id = 3");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();




                dataGridView1.Rows[n].Cells[0].Value = item["swd_month_work"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["swd_day_work"].ToString();
                CultureInfo ThaiCulture = new CultureInfo("en-US");
                DateTime date = Convert.ToDateTime(item["swd_date_work"].ToString());
                string date_th = date.ToString("yyyy-MM-dd", ThaiCulture);
                dataGridView1.Rows[n].Cells[2].Value = date_th;
                dataGridView1.Rows[n].Cells[3].Value = item["swd_start_time"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["swd_end_time"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item["swd_note"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item["room_id"].ToString();
                dataGridView1.Rows[n].Cells[7].Value = item["swd_status_room"].ToString();
                dataGridView1.Rows[n].Cells[8].Value = item["swd_timezone"].ToString();
                dataGridView1.Rows[n].Cells[9].Value = item["swd_status"].ToString();

            }





            conn.Close();
        }
    }
}
