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
    public partial class clinic_timeswd_ms : Form
    {
        Timer t = new Timer();

        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-J5O17QF\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;


        public clinic_timeswd_ms()
        {
            InitializeComponent();
            txtstarttime.Text = "0.00";
            txtendtime.Text = "0.00";
            conn.Open();

       


            string query = ("select schedule_work_doctor.swd_num_week,schedule_work_doctor.swd_month_work,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_date_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.swd_end_time,schedule_work_doctor.swd_note,schedule_work_doctor.room_id,schedule_work_doctor.swd_status_room,schedule_work_doctor.swd_timezone,schedule_work_doctor.swd_status from schedule_work_doctor inner join room on room.room_id = schedule_work_doctor.room_id");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();



                dataGridView1.Rows[n].Cells[0].Value = item["swd_num_week"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["swd_month_work"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["swd_day_work"].ToString();
                CultureInfo ThaiCulture = new CultureInfo("en-US");
                DateTime date = Convert.ToDateTime(item["swd_date_work"].ToString());
                string date_th = date.ToString("yyyy-MM-dd", ThaiCulture);
                dataGridView1.Rows[n].Cells[3].Value = date_th;
                dataGridView1.Rows[n].Cells[4].Value = item["swd_start_time"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item["swd_end_time"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item["swd_note"].ToString();
                dataGridView1.Rows[n].Cells[7].Value = item["room_id"].ToString();
                dataGridView1.Rows[n].Cells[8].Value = item["swd_status_room"].ToString();
                dataGridView1.Rows[n].Cells[9].Value = item["swd_timezone"].ToString();
                dataGridView1.Rows[n].Cells[10].Value = item["swd_status"].ToString();

            }





            conn.Close();

        }

        private void clinic_timeswd_ms_Load(object sender, EventArgs e)
        {
            t.Interval = 1000;
            t.Tick += new EventHandler(this.timer1_Tick);
            t.Start();
            CultureInfo ThaiCulture = new CultureInfo("th-TH");
            //    label10.Text = DateTime.Now.ToString("dddd dd-MM-yyyy", new CultureInfo("th-TH"));
            DateTime today = DateTime.Today;
            string etoday = today.ToString("yyyy-MM-dd", ThaiCulture);
            label10.Text =""+ etoday;
            //   lblmonth.Text = DateTime.Now.ToString("MM", new CultureInfo("th-TH"));
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MMMM-yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd-MMMM-yyyy";
            //dateTimePicker3.Format = DateTimePickerFormat.Custom;
            //dateTimePicker3.CustomFormat = "MMMM";

            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(1, "มกราคม");
            comboSource.Add(2, "กุมพาพันธ์");
            comboSource.Add(3, "มีนาคม");
            comboSource.Add(4, "เมษายน");
            comboSource.Add(5, "พฤษภาคม");
            comboSource.Add(6, "มิถุนายน");
            comboSource.Add(7, "กรกฏาคม");
            comboSource.Add(8, "สิงหาคม");
            comboSource.Add(9, "กันยายน");
            comboSource.Add(10, "ตุลาคม");
            comboSource.Add(11, "พฤศจิกายน");
            comboSource.Add(12, "ธันวาคม");
            comboBox1.DataSource = new BindingSource(comboSource, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;

            String time = "";

            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }

            label9.Text = time;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedItem.ToString() == "ปิด")
            {
                string query = ("Update schedule_work_doctor set swd_status_room = 0 ,swd_date_work = '',emp_doc_id = 0 ,swd_work_place = '',swd_emp_work_place = '',swd_note = '',swd_status = '" + comboBox2.SelectedItem.ToString() + "',swd_end_date = '' ");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();

                sda.Fill(dt);
       
               clinic_timeswd_ms doc1 = new clinic_timeswd_ms();
                doc1.Show();
                clinic_timeswd_ms clnlog = new clinic_timeswd_ms();
                clnlog.Close();
                Visible = false;
                MessageBox.Show("เปลี่ยนเป็นสถานะ  " + comboBox2.SelectedItem.ToString());

             

            }
            else if (comboBox2.SelectedItem.ToString() == "เปิด")
            {
               string query = ("Update schedule_work_doctor set swd_status_room = 0 ,swd_date_work = '',emp_doc_id = 0 ,swd_work_place = '',swd_emp_work_place = '',swd_note = '',swd_status = '" + comboBox2.SelectedItem.ToString() + "',swd_end_date = '' ");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();

                sda.Fill(dt);
         
              clinic_timeswd_ms doc1 = new clinic_timeswd_ms();
                doc1.Show();
                clinic_timeswd_ms clnlog = new clinic_timeswd_ms();
                clnlog.Close();
                Visible = false;
                MessageBox.Show("เปลี่ยนเป็นสถานะ  " + comboBox2.SelectedItem.ToString());


            }
              
        }
        /*
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string month_number = DateTime.Now.ToString("MM", new CultureInfo("th-TH"));
            int month_count = Convert.ToInt32(month_number);

            if (comboBox1.SelectedItem.ToString() == "มกราคม")
            {
               
                    string query = ("Update schedule_work_doctor set swd_month_work = '" + comboBox1.SelectedItem.ToString() + "'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();

                    sda.Fill(dt);
           
            
                
           
              

            }
            else if (comboBox1.SelectedItem.ToString() == "กุมพาพันธ์")
            {
                
                    string query = ("Update schedule_work_doctor set swd_month_work = '" + comboBox1.SelectedItem.ToString() + "'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();

                    sda.Fill(dt);
             
              
                
          
            }
            else if (comboBox1.SelectedItem.ToString() == "มีนาคม")
            {
                string query = ("Update schedule_work_doctor set swd_month_work = '" + comboBox1.SelectedItem.ToString() + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();

                sda.Fill(dt);

            }
            else if (comboBox1.SelectedItem.ToString() == "เมษายน")
            {
                string query = ("Update schedule_work_doctor set swd_month_work = '" + comboBox1.SelectedItem.ToString() + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();

                sda.Fill(dt);

            }
            else if (comboBox1.SelectedItem.ToString() == "พฤษภาคม")
            {
                string query = ("Update schedule_work_doctor set swd_month_work = '" + comboBox1.SelectedItem.ToString() + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();

                sda.Fill(dt);

            }
            else if (comboBox1.SelectedItem.ToString() == "มิถุนายน")
            {
                string query = ("Update schedule_work_doctor set swd_month_work = '" + comboBox1.SelectedItem.ToString() + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();

                sda.Fill(dt);

            }
            else if (comboBox1.SelectedItem.ToString() == "กรกฎาคม")
            {
                string query = ("Update schedule_work_doctor set swd_month_work = '" + comboBox1.SelectedItem.ToString() + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();

                sda.Fill(dt);

            }
            else if (comboBox1.SelectedItem.ToString() == "สิงหาคม")
            {
                string query = ("Update schedule_work_doctor set swd_month_work = '" + comboBox1.SelectedItem.ToString() + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();

                sda.Fill(dt);

            }
            else if (comboBox1.SelectedItem.ToString() == "กันยายน")
            {
                string query = ("Update schedule_work_doctor set swd_month_work = '" + comboBox1.SelectedItem.ToString() + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();

                sda.Fill(dt);

            }
            else if (comboBox1.SelectedItem.ToString() == "ตุลาคม")
            {
                string query = ("Update schedule_work_doctor set swd_month_work = '" + comboBox1.SelectedItem.ToString() + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();

                sda.Fill(dt);

            }
            else if (comboBox1.SelectedItem.ToString() == "พฤศจิกายน")
            {
                string query = ("Update schedule_work_doctor set swd_month_work = '" + comboBox1.SelectedItem.ToString() + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();

                sda.Fill(dt);

            }
            else if (comboBox1.SelectedItem.ToString() == "ธันวาคม")
            {
                string query = ("Update schedule_work_doctor set swd_month_work = '" + comboBox1.SelectedItem.ToString() + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();

                sda.Fill(dt);

            }

  


         clinic_timeswd_ms doc1 = new clinic_timeswd_ms();
            doc1.Show();

            clinic_timeswd_ms clnlog = new clinic_timeswd_ms();
            clnlog.Close();
            Visible = false;
       

            MessageBox.Show("จัดตารางปฏิบัติงานแพทย์ประจำเดือน  " + comboBox1.SelectedItem.ToString());
           
 
        }
        */
        int selectedRow;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
         //   txtday.Text = row.Cells[1].Value.ToString();
         txtweek.Text = row.Cells[0].Value.ToString();
         //   txtmonth.Text = row.Cells[1].Value.ToString();

            string month = row.Cells[1].Value.ToString();
            if (month == "มกราคม")
            {
                txtmonth.Text = "1";
            }else if (month == "กุมพาพันธ์")
            {
                txtmonth.Text = "2";
            }
            else if (month == "มีนาคม")
            {
                txtmonth.Text = "3";
            }
            else if (month == "เมษายน")
            {
                txtmonth.Text = "4";
            }
            else if (month == "พฤษภาคม")
            {
                txtmonth.Text = "5";
            }
            else if (month == "มิถุนายน")
            {
                txtmonth.Text = "6";
            }
            else if (month == "กรกฏาคม")
            {
                txtmonth.Text = "7";
            }
            else if (month == "สิงหาคม")
            {
                txtmonth.Text = "8";
            }
            else if (month == "กันยายน")
            {
                txtmonth.Text = "9";
            }
            else if (month == "ตุลาคม")
            {
                txtmonth.Text = "10";
            }
            else if (month == "พฤศจิกายน")
            {
                txtmonth.Text = "11";
            }
            else if (month == "ธันวาคม")
            {
                txtmonth.Text = "12";
            }
            txtstarttime.Text = row.Cells[4].Value.ToString();
            txtendtime.Text = row.Cells[5].Value.ToString();
            txtremark.Text = row.Cells[6].Value.ToString();
            txtroom.Text = row.Cells[7].Value.ToString();
            txttimezone.Text = row.Cells[9].Value.ToString();
            //lblstatus.Text = row.Cells[8].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                CultureInfo ThaiCulture = new CultureInfo("th-TH");
            DateTime today = DateTime.Today;
            string etoday = today.ToString("yyyy-MM-dd", ThaiCulture);

          //  CultureInfo ThaiCulture = new CultureInfo("th-TH");
            DateTime date = Convert.ToDateTime(dateTimePicker1.Text);
            string date_th = date.ToString("yyyy-MM-dd", ThaiCulture);
            string day = date.ToString("dddd", ThaiCulture);
            int day_count = date.Day;
            int today_count = today.Day;
            int month_select = date.Month;

            int month_count = today.Month;
            int month_swd = Convert.ToInt32(txtmonth.Text);
            if (month_count > month_swd)
            {

                MessageBox.Show("ไม่สามารถจัดตารางได้");
            }else
            {

                if (month_count >= month_select && today_count >= day_count)
                {

                    MessageBox.Show("ไม่สามารถจัดตารางได้");
                }
                else
                {
                    string query = ("Update schedule_work_doctor set  swd_start_time = '" + txtstarttime.Text + "' ,swd_end_time = '" + txtendtime.Text + "',swd_note = '" + txtremark.Text + "' ,swd_date_work = '"+ date_th + "' where room_id = '" + txtroom.Text + "' AND swd_timezone = '" + txttimezone.Text + "' AND swd_day_work = '" + day + "' AND swd_num_week = '"+txtweek.Text+"'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();

                    sda.Fill(dt);
                    clinic_timeswd_ms doc1 = new clinic_timeswd_ms();
                    doc1.Show();
                    clinic_timeswd_ms clnlog = new clinic_timeswd_ms();
                    clnlog.Close();
                    Visible = false;
                    MessageBox.Show("เปลี่ยนแปลงตารางเรียบร้อย");

                }

            }
        


        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            /* CultureInfo ThaiCulture = new CultureInfo("th-TH");
             DateTime date = Convert.ToDateTime(dateTimePicker3.Text);
             string date_th = date.ToString("yyyy-MMMM-dd-dddd", ThaiCulture);
             int month_select = date.Month;
             MessageBox.Show("" + date_th);*/
    
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            string month_number = DateTime.Now.ToString("MM", new CultureInfo("th-TH"));
            int month_count = Convert.ToInt32(month_number);


                string query = ("Update schedule_work_doctor set swd_month_work = '" + comboBox1.SelectedItem.ToString() + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();

                sda.Fill(dt);








/*
            clinic_timeswd_ms doc1 = new clinic_timeswd_ms();
            doc1.Show();

            clinic_timeswd_ms clnlog = new clinic_timeswd_ms();
            clnlog.Close();
            Visible = false;
 

            MessageBox.Show("จัดตารางปฏิบัติงานแพทย์ประจำเดือน  " + comboBox1.SelectedItem.ToString());

            */
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string value = ((KeyValuePair<int, string>)comboBox1.SelectedItem).Value;

            int month = ((KeyValuePair<int, string>)comboBox1.SelectedItem).Key;
            DateTime month_today = DateTime.Today;

            int month_today_count = month_today.Month;

            /*
            string query = ("Update schedule_work_doctor set swd_month_work = '" + value + "'");
               cmd = new SqlCommand(query, conn);
               sda = new SqlDataAdapter(cmd);
               dt = new DataTable();

               sda.Fill(dt);*/

            if(month_today_count >= month)
            {
                MessageBox.Show("ไม่สามารถจัดตารางได้");
            }
            else
            {
                string query = ("Update schedule_work_doctor set swd_month_work = '" + value + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();

                sda.Fill(dt);

                clinic_timeswd_ms doc1 = new clinic_timeswd_ms();
                doc1.Show();

                clinic_timeswd_ms clnlog = new clinic_timeswd_ms();
                clnlog.Close();
                Visible = false;


                MessageBox.Show("จัดตารางปฏิบัติงานแพทย์ประจำเดือน  " + value);
            }
            


            //  int key = ((KeyValuePair<int,string>)comboBox1.SelectedItem).Key;


        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            CultureInfo ThaiCulture = new CultureInfo("th-TH");
            DateTime date_end = Convert.ToDateTime(dateTimePicker2.Text);
            string end_date = date_end.ToString("yyyy-MM-dd", ThaiCulture);
         
            string query = ("Update schedule_work_doctor set swd_end_date = '" + end_date + "'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();

            sda.Fill(dt);
           
            clinic_timeswd_ms doc1 = new clinic_timeswd_ms();
            doc1.Show();
            clinic_timeswd_ms clnlog = new clinic_timeswd_ms();
            clnlog.Close();
            Visible = false;
          //  MessageBox.Show(""+end_date);
        }

        private void lbldate_Click(object sender, EventArgs e)
        {

        }

        private void label10_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            CultureInfo ThaiCulture = new CultureInfo("th-TH");
            DateTime today = DateTime.Today;
            string etoday = today.ToString("yyyy-MM-dd", ThaiCulture);
            label10.Text = "" + etoday;
            string query = ("select swd_end_date from schedule_work_doctor");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();

            //    string end_date = dateTimePicker1.Text;
            if (sdr.Read())
            {
                CultureInfo enCulture = new CultureInfo("en-US");
             //   DateTime end_datetime = Convert.ToDateTime(sdr["swd_end_date"].ToString());
               // string date_th = end_datetime.ToString("yyyy-MMMM-dd-dddd", ThaiCulture);

                string end_date = sdr["swd_end_date"].ToString();
                DateTime end_datetime = Convert.ToDateTime(end_date);
                string date_th = end_datetime.ToString("yyyy-MM-dd", enCulture);
                lbldate.Text = date_th;
                int today_num = today.Day;
                int month_today_num = today.Month;
                int end_day = end_datetime.Day;
                int end_month = end_datetime.Month;
                if (month_today_num >= end_month && today_num >= end_day)
                {
                    query = ("Update schedule_work_doctor set swd_note = '' , swd_status_room = 0 ,emp_doc_id = 0 ,swd_work_place = '',swd_emp_work_place = '' ,swd_status = 'ปิด'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();

                    sda.Fill(dt);
                    conn.Close();


                    MessageBox.Show("เปลี่ยนสถานะ ปิด");
                }
                else
                {
                    // MessageBox.Show("ยังไม่หมดเวลา");
                    query = ("Update schedule_work_doctor set swd_status = 'เปิด'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();

                    sda.Fill(dt);
                    conn.Close();

                    MessageBox.Show("เปลี่ยนสถานะ เปิด");
                }

            }

            conn.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            //  MessageBox.Show("" + comboBox3.SelectedIndex.ToString());
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            string query = ("select schedule_work_doctor.swd_num_week,schedule_work_doctor.swd_month_work,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_date_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.swd_end_time,schedule_work_doctor.swd_note,schedule_work_doctor.room_id,schedule_work_doctor.swd_status_room,schedule_work_doctor.swd_timezone,schedule_work_doctor.swd_status from schedule_work_doctor inner join room on room.room_id = schedule_work_doctor.room_id where swd_timezone = '"+comboBox3.SelectedItem.ToString()+"'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();



                dataGridView1.Rows[n].Cells[0].Value = item["swd_num_week"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["swd_month_work"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["swd_day_work"].ToString();
                CultureInfo ThaiCulture = new CultureInfo("en-US");
                DateTime date = Convert.ToDateTime(item["swd_date_work"].ToString());
                string date_th = date.ToString("yyyy-MM-dd", ThaiCulture);
                dataGridView1.Rows[n].Cells[3].Value = date_th;
                dataGridView1.Rows[n].Cells[4].Value = item["swd_start_time"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item["swd_end_time"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item["swd_note"].ToString();
                dataGridView1.Rows[n].Cells[7].Value = item["room_id"].ToString();
                dataGridView1.Rows[n].Cells[8].Value = item["swd_status_room"].ToString();
                dataGridView1.Rows[n].Cells[9].Value = item["swd_timezone"].ToString();
                dataGridView1.Rows[n].Cells[10].Value = item["swd_status"].ToString();

            }


  
    

            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CultureInfo ThaiCulture = new CultureInfo("th-TH");
            DateTime today = DateTime.Today;
            string etoday = today.ToString("yyyy-MM-dd", ThaiCulture);

            //  CultureInfo ThaiCulture = new CultureInfo("th-TH");
            DateTime date = Convert.ToDateTime(dateTimePicker1.Text);
            string date_th = date.ToString("yyyy-MM-dd", ThaiCulture);
            string day = date.ToString("dddd", ThaiCulture);
            int day_count = date.Day;
            int today_count = today.Day;
            int month_select = date.Month;

            int month_count = today.Month;
            int month_swd = Convert.ToInt32(txtmonth.Text);
        
                    string query = ("Update schedule_work_doctor set  swd_start_time = '' ,swd_end_time = '',swd_note = '" + txtremark.Text + "' ,swd_date_work = '' where room_id = '" + txtroom.Text + "' AND swd_timezone = '" + txttimezone.Text + "' AND swd_day_work = '" + day + "' AND swd_num_week = '" + txtweek.Text + "'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();

                    sda.Fill(dt);
                    clinic_timeswd_ms doc1 = new clinic_timeswd_ms();
                    doc1.Show();
                    clinic_timeswd_ms clnlog = new clinic_timeswd_ms();
                    clnlog.Close();
                    Visible = false;
                    MessageBox.Show("เปลี่ยนแปลงตารางเรียบร้อย");

        }
    }
}
