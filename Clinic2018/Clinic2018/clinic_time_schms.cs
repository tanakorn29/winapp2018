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
    public partial class clinic_time_schms : Form
    {
        Timer t = new Timer();
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-92251HH\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;

        public clinic_time_schms()
        {
            InitializeComponent();
        }



        private void clinic_time_schms_Load(object sender, EventArgs e)
        {
            t.Interval = 1000;
            t.Tick += new EventHandler(this.timer1_Tick);
            t.Start();
            CultureInfo ThaiCulture = new CultureInfo("th-TH");
            DateTime today = DateTime.Today;
            string etoday = today.ToString("yyyy-MM-dd", ThaiCulture);
            label10.Text = "" + etoday;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
 

            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(0, "กรุณาเลือกเดือน");
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
            conn.Open();
     string query = ("select swd_month_work from schedule_work_doctor Order by swd_id DESC");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();

            sda.Fill(dt);

            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                string month_work = sdr["swd_month_work"].ToString();
             lblmonth1.Text = month_work;
            }

            query = ("select swd_status from schedule_work_doctor Order by swd_id DESC");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();

            sda.Fill(dt);

            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                string month_work = sdr["swd_status"].ToString();
              lblstatus.Text = month_work;
            }
            query = ("select swd_date_work from schedule_work_doctor ORDER BY swd_date_work DESC");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();

            sda.Fill(dt);

            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                string date_work_w = sdr["swd_date_work"].ToString();

                DateTime time_swd = Convert.ToDateTime(date_work_w);
                string day_work_ww4 = time_swd.ToString("yyyy-MM-dd");
       /*         query = ("Update schedule_work_doctor set swd_end_date = '" + day_work_ww4 + "' where swd_status = 'เปิด' AND swd_note = ''");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();

                sda.Fill(dt);
*/
                lbldate.Text = day_work_ww4;
                DateTime today_work = Convert.ToDateTime(label10.Text);
                string today_work1 = time_swd.ToString("yyyy-MM-dd");
                //  MessageBox.Show(""+ day_work_ww4);

                int day_w = time_swd.Day;
                int day_to = today_work.Day;
                int month_w = time_swd.Month;
                int Month_to = today_work.Month;
                string month_th = DateTime.Now.ToString("MMMM", new CultureInfo("th-TH"));
                //   if (day_to == 20 && month_w >= Month_to)
                if(day_to != 20)
                {
                     query = ("Update schedule_work_doctor set swd_end_date = '" + day_work_ww4 + "' where swd_status = 'เปิด' AND swd_month_work = '" + lblmonth1.Text + "' ");
                      cmd = new SqlCommand(query, conn);
                      sda = new SqlDataAdapter(cmd);
                      dt = new DataTable();

                      sda.Fill(dt);


                      query = ("Update schedule_work_doctor set swd_status = 'การจัดตารางงานเสร็จสิ้น', swd_status_chenge = 2 where swd_month_work = '" + month_th + "' ");
                      cmd = new SqlCommand(query, conn);
                      sda = new SqlDataAdapter(cmd);
                      dt = new DataTable();
                      sda.Fill(dt);

                      query = ("Update schedule_work_doctor set swd_status = 'เปิด', swd_status_chenge = 1 where swd_month_work = '" + lblmonth1.Text + "' ");
                      cmd = new SqlCommand(query, conn);
                      sda = new SqlDataAdapter(cmd);
                      dt = new DataTable();

                      sda.Fill(dt);
              //      MessageBox.Show("test");
                }

                /*     else if (day_to >= 1 && day_to <= 19)
                     {



                         query = ("Update schedule_work_doctor set swd_end_date = '" + day_work_ww4 + "' where swd_status = 'เปิด' AND swd_month_work = '" + lblmonth1.Text + "' ");
                         cmd = new SqlCommand(query, conn);
                         sda = new SqlDataAdapter(cmd);
                         dt = new DataTable();

                         sda.Fill(dt);


                         query = ("Update schedule_work_doctor set swd_status = 'การจัดตารางงานเสร็จสิ้น', swd_status_chenge = 2 where swd_month_work = '" + month_th + "' ");
                         cmd = new SqlCommand(query, conn);
                         sda = new SqlDataAdapter(cmd);
                         dt = new DataTable();
                         sda.Fill(dt);

                         query = ("Update schedule_work_doctor set swd_status = 'เปิด', swd_status_chenge = 1 where swd_month_work = '" + lblmonth1.Text + "' ");
                             cmd = new SqlCommand(query, conn);
                             sda = new SqlDataAdapter(cmd);
                             dt = new DataTable();

                             sda.Fill(dt);


                     }*/
                /*          else 
                          {
                            query = ("Update schedule_work_doctor set swd_end_date = '" + day_work_ww4 + "' where swd_status = 'จัดตารางเรียบร้อย'");
                              cmd = new SqlCommand(query, conn);
                              sda = new SqlDataAdapter(cmd);
                              dt = new DataTable();

                              sda.Fill(dt);


                          }*/
            }


            conn.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
            time += ".";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ".";

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

 

        private void label10_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
              

        

    

      
     
        }

    /*    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "ปิด")
            {
           string query = ("Update schedule_work_doctor set swd_status_room = 0 ,emp_doc_id = 0 ,swd_work_place = '',swd_emp_work_place = '',swd_status = '" + comboBox2.SelectedItem.ToString() + "',swd_end_date = '',swd_note = ''  where swd_month_work = '"+lblmonth1.Text+"'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();

                sda.Fill(dt);

                clinic_time_schms doc1 = new clinic_time_schms();
                doc1.Show();
                clinic_time_schms clnlog = new clinic_time_schms();
                clnlog.Close();
                Visible = false;
                MessageBox.Show("เปลี่ยนเป็นสถานะ  " + comboBox2.SelectedItem.ToString());
      


            }
            else if (comboBox2.SelectedItem.ToString() == "เปิด")
            {
             string query = ("Update schedule_work_doctor set swd_status_room = 0 ,emp_doc_id = 0 ,swd_work_place = '',swd_emp_work_place = '',swd_status = '" + comboBox2.SelectedItem.ToString() + "',swd_end_date = '',swd_note = ''  where swd_month_work = '"+lblmonth1.Text+"'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();

                sda.Fill(dt);

                clinic_time_schms doc1 = new clinic_time_schms();
                doc1.Show();
                clinic_time_schms clnlog = new clinic_time_schms();
                clnlog.Close();
                Visible = false;
                MessageBox.Show("เปลี่ยนเป็นสถานะ  " + comboBox2.SelectedItem.ToString());
                

            }
        }
        */
        private void button1_Click(object sender, EventArgs e)
        {

      
            string value = ((KeyValuePair<int, string>)comboBox1.SelectedItem).Value;

            int month = ((KeyValuePair<int, string>)comboBox1.SelectedItem).Key;
            DateTime month_today = DateTime.Today;
            DateTime day_end = Convert.ToDateTime(dateTimePicker1.Text);
            int end_day = day_end.Day;
            int end_month = day_end.Month;
            int day_today = month_today.Day;
            int month_today_count = month_today.Month;
            int month_year_count = month_today.Year;
            int year_end = day_end.Year;
            /*
            string query = ("Update schedule_work_doctor set swd_month_work = '" + value + "'");
               cmd = new SqlCommand(query, conn);
               sda = new SqlDataAdapter(cmd);
               dt = new DataTable();

               sda.Fill(dt);*/
            if (day_today == 20)
            {
                try
                {
                    conn.Open();
                    //  query = ("Update schedule_work_doctor set swd_status = 'จัดตารางงานใหม่',swd_note = 'จัดตารางงานใหม่'");
                    string query = ("select count(schedule_work_doctor.emp_doc_id) from schedule_work_doctor inner join room on room.room_id = schedule_work_doctor.room_id where swd_status = 'เปิด' AND schedule_work_doctor.room_id = 1 AND swd_month_work = '" + lblmonth1.Text + "' AND emp_doc_id = 0 AND swd_date_work = '1900-01-01'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();

                    sda.Fill(dt);

                    int swd_count = (int)cmd.ExecuteScalar();

                    query = ("select count(schedule_work_doctor.emp_doc_id) from schedule_work_doctor inner join room on room.room_id = schedule_work_doctor.room_id where swd_status = 'เปิด' AND schedule_work_doctor.room_id = 1 AND swd_month_work = '" + lblmonth1.Text + "' AND emp_doc_id = 0 ");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();

                    sda.Fill(dt);

                    int swd_count1 = (int)cmd.ExecuteScalar();

                    if (swd_count1 <= swd_count)
                    {
                        query = ("Update schedule_work_doctor set swd_status_chenge = 2 , swd_status = 'การจัดตารางงานเสร็จสิ้น' ");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();

                        sda.Fill(dt); 
                        //       conn.Close();

                        //    MessageBox.Show("เปลี่ยนสถานะ ปิด" + day_work_ww4);

                        clinic_time_schms doc1 = new clinic_time_schms();
                        doc1.Show();

                        clinic_time_schms clnlog = new clinic_time_schms();
                        clnlog.Close();
                        Visible = false;
                        MessageBox.Show("จัดตารางปฏิบัติงานเสร็จสิ้น");





                  

                    }else
                    {
                        clinic_ms_time_month doc1 = new clinic_ms_time_month();
                        doc1.Show();
                    }

                    conn.Close();
                }
                catch (Exception)
                {

                }
          
            }
            else
            {

                MessageBox.Show("ยังไม่ถึงเวลาจัดตารางปฏิบัติงาน","status");


            }
      
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            clinic_room1_swd doc1 = new clinic_room1_swd();
            doc1.Show();
        }

        private void lblmonth1_TextChanged(object sender, EventArgs e)

        {
            string month = lblmonth1.Text;

            if (month == "มกราคม")
            {

            }
            else if (month == "กุมพาพันธ์")
            {
            }
            else if (month == "มีนาคม")
            {

            }
            else if (month == "เมษายน")
            {

            }
            else if (month == "พฤษภาคม")
            {


            }
            else if (month == "มิถุนายน")
            {

            }
            else if (month == "กรกฏาคม")
            {



            }
            else if (month == "สิงหาคม")
            {
      
                
            }
            else if (month == "กันยายน")
            {



            }
            else if (month == "ตุลาคม")
            {


            }
            else if (month == "พฤศจิกายน")
            {

            }
            else if (month == "ธันวาคม")
            {

            }







        }

        private void lbldate_TextChanged(object sender, EventArgs e)
        {

            CultureInfo ThaiCulture = new CultureInfo("th-TH");
           // DateTime today = Convert.ToDateTime(label10.Text);
       
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clinic_time_schms_ms doc1 = new clinic_time_schms_ms();
            doc1.Show();
            /*
           string query = ("Delete schedule_work_doctor");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();

            sda.Fill(dt);
            clinic_time_schms doc1 = new clinic_time_schms();
            doc1.Show();

            clinic_time_schms clnlog = new clinic_time_schms();
            clnlog.Close();
            Visible = false;
            MessageBox.Show("สามารถเปลี่ยนเดือนได้");
            */
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            clinic_room2_swd doc1 = new clinic_room2_swd();
            doc1.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            clinic_room3_swd doc1 = new clinic_room3_swd();
            doc1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clinic_hollyday doc1 = new clinic_hollyday();
            doc1.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string value = ((KeyValuePair<int, string>)comboBox1.SelectedItem).Value;

            int month = ((KeyValuePair<int, string>)comboBox1.SelectedItem).Key;
            DateTime month_today = DateTime.Today;
            DateTime day_end = Convert.ToDateTime(dateTimePicker1.Text);
            int end_day = day_end.Day;
            int end_month = day_end.Month;
            int day_today = month_today.Day;
            int month_today_count = month_today.Month;
            int month_year_count = month_today.Year;
            int year_end = day_end.Year;

            if (day_today != 20)
            {
                if (month_today_count >= month & month_year_count >= year_end)
                {
                    MessageBox.Show("ไม่สามารถกำหนดช่วงเวลาตารางปฏิบัติงานได้");
                }
                else
                {
                    try
                    {
                        conn.Open();
                        //        string query = ("select count(*) from schedule_work_doctor where swd_status = 'เปิด' AND swd_status_chenge = 0");
                        string query = ("select count(*) from schedule_work_doctor where swd_status = 'เปิด' AND swd_status_chenge = 1 AND swd_month_work = '" + lblmonth1.Text + "' ");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();

                        sda.Fill(dt);

                        int swd_count = (int)cmd.ExecuteScalar();
                        /*         query = ("select swd_date_work from schedule_work_doctor ORDER BY swd_date_work DESC");
                                 cmd = new SqlCommand(query, conn);
                                 sda = new SqlDataAdapter(cmd);
                                 dt = new DataTable();

                                 sda.Fill(dt);

                                 sdr = cmd.ExecuteReader();

                                 if (sdr.Read())
                                 {*/

                        string date_work_w = day_end.ToString("yyyy-MM-dd", new CultureInfo("th-TH"));
                        query = ("select count(*) from schedule_work_doctor where swd_status = 'เปิด'AND swd_end_date = '" + date_work_w + "'");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();

                        sda.Fill(dt);

                        int count_swd = (int)cmd.ExecuteScalar();
                        if (count_swd > 1)
                        {
                            MessageBox.Show("มีข้อมูลการปฏิบัติงานแล้ว");
                        }
                        else
                        {
                            if (swd_count > 1)
                            {

                                if (month_today.Date >= day_end.Date)
                                {
                                    MessageBox.Show("ไม่สามารถจัดตารางการปฏิบัติงานได้");
                                }
                                else
                                {
                                    CultureInfo enCulture = new CultureInfo("en-US");
                                    CultureInfo thCulture = new CultureInfo("th-TH");
                                    DateTime year_today = DateTime.Now;
                                    DateTime year_lbl = Convert.ToDateTime(dateTimePicker1.Text);
                                    //   string year_1 = year_today.ToString("yyyy", enCulture);
                                    string year_1 = year_lbl.ToString("yyyy", enCulture);
                                    string date_month = "" + year_1 + "-" + month + "-01";
                                    DateTime month_first = Convert.ToDateTime(date_month);


                                    int day = month_first.Day;
                                    int month_1 = month_first.Month;
                                    // string first = month_first.ToString("" + year_1 + "-" + month + "-dd", enCulture);
                                    string first = month_first.ToString("" + year_1 + "-" + month + "-dd");
                                    int year = month_first.Year;
                                    int result_day = end_day - 1;

                                    for (int i = 0; i <= result_day; i++)
                                    {
                                        DateTime new_birthday;
                                        try
                                        {
                                            new_birthday = new DateTime(year, month_1, day + i);

                                        }
                                        catch
                                        {
                                            new_birthday = new DateTime(year, month + 1, 1);
                                        }

                                        for (int room = 1; room <= 3; room++)
                                        {
                                            if (i <= end_day)
                                            {

                                                string day_work_place = new_birthday.ToString("yyyy-MM-dd", thCulture);
                                                string day_only = new_birthday.ToString("dddd", thCulture);

                                                //    MessageBox.Show(day_work_place + "" +day_only);

                                                //   int day_num = new_birthday.Day;


                                                // MessageBox.Show("" + new_birthday.ToString("yyyy-MM-dd", thCulture) + "         Week      " + new_birthday.ToString("dddd", thCulture) + "   " + day_of_week + "  week  " + num + "  room " + room);

                                                /*         string query = ("insert into schedule_work_doctor (swd_date_work,swd_day_work,room_id,swd_start_time,swd_end_time,swd_timezone,swd_month_work,swd_status,swd_status_room) values('" + day_work_place + "', '" + day_only + "', '" + room + "', '08.30', '11.30', 'เช้า', '" + value + "', 'ปิด','0')");
                                                         cmd = new SqlCommand(query, conn);
                                                         sda = new SqlDataAdapter(cmd);
                                                         dt = new DataTable();

                                                         sda.Fill(dt);

                                                         int queue = (int)cmd.ExecuteScalar();
                                                         */


                                                query = ("insert into schedule_work_doctor (swd_date_work,swd_day_work,room_id,swd_start_time,swd_end_time,swd_timezone,swd_month_work,swd_status,swd_status_room,swd_status_checkwork,swd_status_chenge,emp_doc_id) values('" + day_work_place + "', '" + day_only + "', '" + room + "', '08.30', '11.30', 'เช้า', '" + value + "', 'จัดตารางเรียบร้อย','0',0,0,0)");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();

                                                sda.Fill(dt);

                                                query = ("insert into schedule_work_doctor (swd_date_work,swd_day_work,room_id,swd_start_time,swd_end_time,swd_timezone,swd_month_work,swd_status,swd_status_room,swd_status_checkwork,swd_status_chenge,emp_doc_id) values('" + day_work_place + "', '" + day_only + "', '" + room + "', '13.00', '15.30', 'บ่าย', '" + value + "', 'จัดตารางเรียบร้อย','0',0,0,0)");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();

                                                sda.Fill(dt);








                                                /*         lstBirthDays.Items.Add(day_work_place + " : " +
                                                         day_only + "" + room + "" + "เช้า");
                                                         lstBirthDays.Items.Add(day_work_place + " : " +
                                                     day_only + "" + room + "" + "บ่าย");*/
                                                /*
                                                                            clinic_time_schms doc1 = new clinic_time_schms();
                                                                            doc1.Show();

                                                                            clinic_time_schms clnlog = new clinic_time_schms();
                                                                            clnlog.Close();
                                                                            Visible = false;

                                                    */

                                            }













                                        }










                                    }

                                    clinic_time_schms doc1 = new clinic_time_schms();
                                    doc1.Show();

                                    clinic_time_schms clnlog = new clinic_time_schms();
                                    clnlog.Close();
                                    Visible = false;
                                    MessageBox.Show("จัดตารางปฏิบัติงานแพทย์ประจำเดือน  " + value);
                                }

                            }
                            else
                            {
                                MessageBox.Show("ไม่สามารถเปลี่ยนเดือนได้");
                            }



                        }



                        conn.Close();



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OKCancel);
                    }


                }







            }
            else
            {
                MessageBox.Show("ไม่มีข้อมูลลงเวลาตารางการปฏิบัติงาน", "status");
            }


        }
    }
}
