using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace Clinic2018
{

    public partial class clinc_nurse_service : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-J5O17QF\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets=true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
        Timer t = new Timer();
        public clinc_nurse_service()
        {
            InitializeComponent();

            conn.Open();
            string query = ("select queue_visit_record.qvr_record,queue_visit_record.qvr_time,opd.opd_name,opd.opd_idcard,opd.opd_address,opd.opd_telmobile,opd.opd_id from queue_visit_record inner join opd on opd.opd_id = queue_visit_record.opd_id where queue_visit_record.qvr_status = 1");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
     
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
          


                    dataGridView1.Rows[n].Cells[0].Value = item["qvr_record"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["qvr_time"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["opd_name"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["opd_idcard"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["opd_id"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item["opd_address"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item["opd_id"].ToString();
                dataGridView1.Rows[n].Cells[7].Value = item["opd_telmobile"].ToString();
         


            }
            query = (" select visit_record.vr_id,visit_record.vr_weight,visit_record.vr_height,visit_record.vr_systolic,visit_record.vr_diastolic,visit_record.vr_hearth_rate,visit_record.vr_date,visit_record.vr_remark,visit_record.opd_id from visit_record where vr_status = 0");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView3.Rows.Add();



                dataGridView3.Rows[n].Cells[0].Value = item["vr_id"].ToString();
                dataGridView3.Rows[n].Cells[1].Value = item["vr_weight"].ToString();
                dataGridView3.Rows[n].Cells[2].Value = item["vr_height"].ToString();
                dataGridView3.Rows[n].Cells[3].Value = item["vr_systolic"].ToString();
                dataGridView3.Rows[n].Cells[4].Value = item["vr_diastolic"].ToString();
                dataGridView3.Rows[n].Cells[5].Value = item["vr_hearth_rate"].ToString();
                dataGridView3.Rows[n].Cells[6].Value = item["vr_date"].ToString();
                dataGridView3.Rows[n].Cells[7].Value = item["vr_remark"].ToString();
                dataGridView3.Rows[n].Cells[8].Value = item["opd_id"].ToString();



            }
            conn.Close();
        }

        int selectedRow;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            lblidcard.Text = row.Cells[3].Value.ToString();
            lblsername.Text = row.Cells[2].Value.ToString();
            lblopd.Text = row.Cells[4].Value.ToString();

        }

        private void clinc_nurse_service_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet2.queue_visit_record' table. You can move, or remove it, as needed.
            //    this.queue_visit_recordTableAdapter.Fill(this.dataSet2.queue_visit_record);
            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
            lblday.Text = DateTime.Now.ToString("dddd", new CultureInfo("th-TH"));
            conn.Open();
            /*
            string query = ("select schedule_work_doctor.swd_id,empdoc.emp_doc_name,empdoc.emp_doc_specialist,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.swd_end_time,schedule_work_doctor.swd_note,schedule_work_doctor.room_id from employee_doctor empdoc inner join schedule_work_doctor on schedule_work_doctor.emp_doc_id  = empdoc.emp_doc_id inner join room on room.room_id = schedule_work_doctor.room_id inner join time_attendance on time_attendance.emp_doc_id = empdoc.emp_doc_id where swd_status_room = 1 AND room.room_status = 1 AND swd_day_work = '" + lblday.Text + "' AND remark = 'เข้างาน'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView2.Rows.Add();



                dataGridView2.Rows[n].Cells[0].Value = item["swd_id"].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item["emp_doc_name"].ToString();
                dataGridView2.Rows[n].Cells[2].Value = item["emp_doc_specialist"].ToString();
                dataGridView2.Rows[n].Cells[3].Value = item["swd_day_work"].ToString();
                dataGridView2.Rows[n].Cells[4].Value = item["swd_start_time"].ToString();
                dataGridView2.Rows[n].Cells[5].Value = item["swd_end_time"].ToString();
                dataGridView2.Rows[n].Cells[6].Value = item["swd_note"].ToString();
                dataGridView2.Rows[n].Cells[7].Value = item["room_id"].ToString();

            }

            */
            conn.Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = ("insert into visit_record (vr_weight,vr_height,vr_systolic,vr_diastolic,vr_hearth_rate,vr_date,vr_status,vr_remark,opd_id) values ('"+txtw.Text+"','"+txth.Text+"','"+txts1.Text+"','"+txts2.Text+"','"+txthearth.Text+"',SYSDATETIME(),0,'"+txtremark.Text+"',"+lblopd.Text+");");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            query = ("Update queue_visit_record set qvr_status = 0 where opd_id = '" + lblopd.Text + "'");

            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            clinc_nurse_service m4 = new clinc_nurse_service();
            m4.Show();
            clinc_nurse_service clnlog = new clinc_nurse_service();
            clnlog.Close();
            Visible = false;
            MessageBox.Show("บันทึกข้อมูลซักประวัติเรียบร้อย");






            /*string query = ("insert into visit_record (vr_weight,vr_height,vr_systolic,vr_diastolic,vr_hearth_rate,vr_date,vr_remark,opd_id) values ('" + txtw.Text + "','" + txth.Text + "','" + txts1.Text + "','" + txts2.Text + "','" + txthearth.Text + "',SYSDATETIME(),'" + txtremark.Text + "'," + lblopd.Text + ");");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            MessageBox.Show("บันทึกข้อมูลซักประวัติเรียบร้อย");*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = ("insert into queue_diag_room(qdr_date,qdr_time_sent,status_queue,swd_id,opd_id)values (SYSDATETIME(), SYSDATETIME(),1,'" + lblswd.Text + "','" + lblopdid.Text + "');");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            Queue<int> collection = new Queue<int>();

            query = ("select count(*) from queue_diag_room inner join opd on opd.opd_id = queue_diag_room.opd_id inner join schedule_work_doctor on schedule_work_doctor.swd_id = queue_diag_room.swd_id inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where  queue_diag_room.status_queue = 1 AND schedule_work_doctor.swd_id = '" + lblswd.Text + "'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            //  sdr = cmd.ExecuteReader();
            int queue = (int)cmd.ExecuteScalar();
            collection.Enqueue(queue);

            foreach (int value in collection)
            {
                if (value <= 9)
                {
                    query = ("Update queue_diag_room Set qdr_record = '" + value + "' where opd_id = '" + lblopdid.Text + "'");
                    //  
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);

                    query = ("Update visit_record set vr_status = 1 where opd_id = '" + lblopdid.Text + "'");
                    //  
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);


                    clinc_nurse_service s2 = new clinc_nurse_service();
                    s2.Show();
                    sent_room clnlog = new sent_room();
                    clnlog.Close();
                    Visible = false;
                    MessageBox.Show("ส่งเข้าห้องตรวจเรียบร้อย   คุณคิวที่    " + value);
                }
                else
                {
                    MessageBox.Show("คิวห้องตรวจเต็ม");
                }
            
            }
            conn.Close();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView3.Rows[selectedRow];
            lblopdid.Text = row.Cells[8].Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView2.Rows[selectedRow];
            lblswd.Text = row.Cells[0].Value.ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void t_Tick(object sender, EventArgs e)
        {
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            //   int ss = DateTime.Now.Second;

            String time = "";

            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ".";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            /*
            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }
            */
           timelbl.Text = time;

        }

        private void timelbl_TextChanged(object sender, EventArgs e)
        {
            try
            {




          
            lblday.Text = DateTime.Now.ToString("dddd", new CultureInfo("th-TH"));
            conn.Open();





            double time = Convert.ToDouble(timelbl.Text);
              
            if (time <= 12.00)
            {
                    lbltimezone.Text = "เช้า";
/*
                string query = ("select schedule_work_doctor.swd_id,empdoc.emp_doc_name,empdoc.emp_doc_specialist,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.swd_end_time,schedule_work_doctor.swd_note,schedule_work_doctor.room_id from employee_doctor empdoc inner join schedule_work_doctor on schedule_work_doctor.emp_doc_id  = empdoc.emp_doc_id inner join room on room.room_id = schedule_work_doctor.room_id inner join time_attendance on time_attendance.emp_doc_id = empdoc.emp_doc_id where swd_status_room = 1 AND room.room_status = 1 AND swd_day_work = '" + lblday.Text + "' AND remark = 'เข้างาน' AND swd_timezone = 'เช้า'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView2.Rows.Add();

                        

                    dataGridView2.Rows[n].Cells[0].Value = item["swd_id"].ToString();
                    dataGridView2.Rows[n].Cells[1].Value = item["emp_doc_name"].ToString();
                    dataGridView2.Rows[n].Cells[2].Value = item["emp_doc_specialist"].ToString();
                    dataGridView2.Rows[n].Cells[3].Value = item["swd_day_work"].ToString();
                    dataGridView2.Rows[n].Cells[4].Value = item["swd_start_time"].ToString();
                    dataGridView2.Rows[n].Cells[5].Value = item["swd_end_time"].ToString();
                    dataGridView2.Rows[n].Cells[6].Value = item["swd_note"].ToString();
                    dataGridView2.Rows[n].Cells[7].Value = item["room_id"].ToString();
             
               }
              
            */
            }
            else if (time >= 12.01)
            {
                    lbltimezone.Text = "บ่าย";
                    /*
                                    string query = ("select schedule_work_doctor.swd_id,empdoc.emp_doc_name,empdoc.emp_doc_specialist,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.swd_end_time,schedule_work_doctor.swd_note,schedule_work_doctor.room_id from employee_doctor empdoc inner join schedule_work_doctor on schedule_work_doctor.emp_doc_id  = empdoc.emp_doc_id inner join room on room.room_id = schedule_work_doctor.room_id inner join time_attendance on time_attendance.emp_doc_id = empdoc.emp_doc_id where swd_status_room = 1 AND room.room_status = 1 AND swd_day_work = '" + lblday.Text + "' AND remark = 'เข้างาน' AND swd_timezone = 'บ่าย'");
                                    cmd = new SqlCommand(query, conn);
                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    sda.Fill(dt);

                                    foreach (DataRow item in dt.Rows)
                                    {
                                        int n = dataGridView2.Rows.Add();



                                        dataGridView2.Rows[n].Cells[0].Value = item["swd_id"].ToString();
                                        dataGridView2.Rows[n].Cells[1].Value = item["emp_doc_name"].ToString();
                                        dataGridView2.Rows[n].Cells[2].Value = item["emp_doc_specialist"].ToString();
                                        dataGridView2.Rows[n].Cells[3].Value = item["swd_day_work"].ToString();
                                        dataGridView2.Rows[n].Cells[4].Value = item["swd_start_time"].ToString();
                                        dataGridView2.Rows[n].Cells[5].Value = item["swd_end_time"].ToString();
                                        dataGridView2.Rows[n].Cells[6].Value = item["swd_note"].ToString();
                                        dataGridView2.Rows[n].Cells[7].Value = item["room_id"].ToString();

                                    }
                                    */

                }

            conn.Close();

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OKCancel);
            }
        }

        private void timelbl_Click(object sender, EventArgs e)
        {

        }

        private void lbltimezone_TextChanged(object sender, EventArgs e)
        {
            string timezone = lbltimezone.Text;
            string today = DateTime.Now.ToString("yyyy-MM-dd", new CultureInfo("th-TH"));
            if (timezone == "เช้า")
            {
          

                string query = ("select schedule_work_doctor.swd_id,empdoc.emp_doc_name,empdoc.emp_doc_specialist,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.swd_end_time,schedule_work_doctor.swd_note,schedule_work_doctor.room_id from employee_doctor empdoc inner join schedule_work_doctor on schedule_work_doctor.emp_doc_id  = empdoc.emp_doc_id inner join room on room.room_id = schedule_work_doctor.room_id inner join time_attendance on time_attendance.emp_doc_id = empdoc.emp_doc_id where swd_status_room = 1 AND room.room_status = 1 AND swd_day_work = '" + lblday.Text + "' AND remark = 'เข้างาน' AND swd_timezone = 'เช้า' AND swd_date_work = '"+today+"'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView2.Rows.Add();



                    dataGridView2.Rows[n].Cells[0].Value = item["swd_id"].ToString();
                    dataGridView2.Rows[n].Cells[1].Value = item["emp_doc_name"].ToString();
                    dataGridView2.Rows[n].Cells[2].Value = item["emp_doc_specialist"].ToString();
                    dataGridView2.Rows[n].Cells[3].Value = item["swd_day_work"].ToString();
                    dataGridView2.Rows[n].Cells[4].Value = item["swd_start_time"].ToString();
                    dataGridView2.Rows[n].Cells[5].Value = item["swd_end_time"].ToString();
                    dataGridView2.Rows[n].Cells[6].Value = item["swd_note"].ToString();
                    dataGridView2.Rows[n].Cells[7].Value = item["room_id"].ToString();

                }
            }
            else if (timezone == "บ่าย")
            {
     
                                   string query = ("select schedule_work_doctor.swd_id,empdoc.emp_doc_name,empdoc.emp_doc_specialist,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.swd_end_time,schedule_work_doctor.swd_note,schedule_work_doctor.room_id from employee_doctor empdoc inner join schedule_work_doctor on schedule_work_doctor.emp_doc_id  = empdoc.emp_doc_id inner join room on room.room_id = schedule_work_doctor.room_id inner join time_attendance on time_attendance.emp_doc_id = empdoc.emp_doc_id where swd_status_room = 1 AND room.room_status = 1 AND swd_day_work = '" + lblday.Text + "' AND remark = 'เข้างาน' AND swd_timezone = 'บ่าย'  AND swd_date_work = '" + today + "'");
                                   cmd = new SqlCommand(query, conn);
                                   sda = new SqlDataAdapter(cmd);
                                   dt = new DataTable();
                                   sda.Fill(dt);

                                   foreach (DataRow item in dt.Rows)
                                   {
                                       int n = dataGridView2.Rows.Add();



                                       dataGridView2.Rows[n].Cells[0].Value = item["swd_id"].ToString();
                                       dataGridView2.Rows[n].Cells[1].Value = item["emp_doc_name"].ToString();
                                       dataGridView2.Rows[n].Cells[2].Value = item["emp_doc_specialist"].ToString();
                                       dataGridView2.Rows[n].Cells[3].Value = item["swd_day_work"].ToString();
                                       dataGridView2.Rows[n].Cells[4].Value = item["swd_start_time"].ToString();
                                       dataGridView2.Rows[n].Cells[5].Value = item["swd_end_time"].ToString();
                                       dataGridView2.Rows[n].Cells[6].Value = item["swd_note"].ToString();
                                       dataGridView2.Rows[n].Cells[7].Value = item["room_id"].ToString();

                                   }
                                   
            }

        }
        /*
private void lbltime_TextChanged(object sender, EventArgs e)
{
lblday.Text = DateTime.Now.ToString("dddd", new CultureInfo("th-TH"));
conn.Open();





double time = Convert.ToDouble(lbltime.Text);
if (time <= 08.30)
{

string query = ("select schedule_work_doctor.swd_id,empdoc.emp_doc_name,empdoc.emp_doc_specialist,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.swd_end_time,schedule_work_doctor.swd_note,schedule_work_doctor.room_id from employee_doctor empdoc inner join schedule_work_doctor on schedule_work_doctor.emp_doc_id  = empdoc.emp_doc_id inner join room on room.room_id = schedule_work_doctor.room_id inner join time_attendance on time_attendance.emp_doc_id = empdoc.emp_doc_id where swd_status_room = 1 AND room.room_status = 1 AND swd_day_work = '" + lblday.Text + "' AND remark = 'เข้างาน' AND swd_timezone = 'เช้า'");
cmd = new SqlCommand(query, conn);
sda = new SqlDataAdapter(cmd);
dt = new DataTable();
sda.Fill(dt);

foreach (DataRow item in dt.Rows)
{
int n = dataGridView2.Rows.Add();



dataGridView2.Rows[n].Cells[0].Value = item["swd_id"].ToString();
dataGridView2.Rows[n].Cells[1].Value = item["emp_doc_name"].ToString();
dataGridView2.Rows[n].Cells[2].Value = item["emp_doc_specialist"].ToString();
dataGridView2.Rows[n].Cells[3].Value = item["swd_day_work"].ToString();
dataGridView2.Rows[n].Cells[4].Value = item["swd_start_time"].ToString();
dataGridView2.Rows[n].Cells[5].Value = item["swd_end_time"].ToString();
dataGridView2.Rows[n].Cells[6].Value = item["swd_note"].ToString();
dataGridView2.Rows[n].Cells[7].Value = item["room_id"].ToString();

}

}
else if (time >= 13.00)
{

string query = ("select schedule_work_doctor.swd_id,empdoc.emp_doc_name,empdoc.emp_doc_specialist,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.swd_end_time,schedule_work_doctor.swd_note,schedule_work_doctor.room_id from employee_doctor empdoc inner join schedule_work_doctor on schedule_work_doctor.emp_doc_id  = empdoc.emp_doc_id inner join room on room.room_id = schedule_work_doctor.room_id inner join time_attendance on time_attendance.emp_doc_id = empdoc.emp_doc_id where swd_status_room = 1 AND room.room_status = 1 AND swd_day_work = '" + lblday.Text + "' AND remark = 'เข้างาน' AND swd_timezone = 'บ่าย'");
cmd = new SqlCommand(query, conn);
sda = new SqlDataAdapter(cmd);
dt = new DataTable();
sda.Fill(dt);

foreach (DataRow item in dt.Rows)
{
int n = dataGridView2.Rows.Add();



dataGridView2.Rows[n].Cells[0].Value = item["swd_id"].ToString();
dataGridView2.Rows[n].Cells[1].Value = item["emp_doc_name"].ToString();
dataGridView2.Rows[n].Cells[2].Value = item["emp_doc_specialist"].ToString();
dataGridView2.Rows[n].Cells[3].Value = item["swd_day_work"].ToString();
dataGridView2.Rows[n].Cells[4].Value = item["swd_start_time"].ToString();
dataGridView2.Rows[n].Cells[5].Value = item["swd_end_time"].ToString();
dataGridView2.Rows[n].Cells[6].Value = item["swd_note"].ToString();
dataGridView2.Rows[n].Cells[7].Value = item["room_id"].ToString();

}
}

conn.Close();
}

private void lbltime_Click(object sender, EventArgs e)
{

}
*/


        /*
private void button3_Click(object sender, EventArgs e)
{

   sent_room s2 = new sent_room();
   s2.Show();
   clinc_nurse_service clnlog = new clinc_nurse_service();
   clnlog.Close();
   Visible = false;
}
*/
    }
}
