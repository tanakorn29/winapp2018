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
    public partial class clinic_login : Form
    {
        public clinic_login()
        {
            InitializeComponent();
        }
        Timer t = new Timer();
        private void B_login_Click(object sender, EventArgs e)
        {
           try
            {
                string day = DateTime.Now.ToString("dddd", new CultureInfo("th-TH"));

                double time = Convert.ToDouble(label4.Text);
                if (time >= 08.00 && time <= 12.00)
                {
                  //  MessageBox.Show("เช้า");sadsdasdsafsaไกดหหหหหหหหdededededหหหดำไหด
                    
                    SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-92251HH\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
                    SqlCommand cmd = new SqlCommand("select employee_ru.emp_ru_name,position.pos_name,time_attendance.remark from employee_ru inner join user_control on user_control.emp_ru_id = employee_ru.emp_ru_id inner join position on position.pos_id = employee_ru.pos_id inner join time_attendance on time_attendance.emp_ru_id = employee_ru.emp_ru_id  where uct_user=@uct_user and uct_password=@uct_password ORDER BY id_time DESC", conn);
                    SqlCommand cmd1 = new SqlCommand("select employee_doctor.emp_doc_name,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_date_work,schedule_work_doctor.room_id,time_attendance.remark from employee_doctor inner join user_control on user_control.emp_doc_id = employee_doctor.emp_doc_id inner join schedule_work_doctor on schedule_work_doctor.emp_doc_id = employee_doctor.emp_doc_id  inner join time_attendance on time_attendance.emp_doc_id = employee_doctor.emp_doc_id where uct_user=@uct_user and uct_password=@uct_password and swd_day_work = '" + day+ "' and swd_timezone = 'เช้า' ORDER BY id_time,room_id DESC", conn);
                    conn.Open();


                    cmd.Parameters.AddWithValue("@uct_user", T_Username.Text);
                    cmd.Parameters.AddWithValue("@uct_password", T_Password.Text);
                    cmd1.Parameters.AddWithValue("@uct_user", T_Username.Text);
                    cmd1.Parameters.AddWithValue("@uct_password", T_Password.Text);

                    SqlDataReader dr = cmd.ExecuteReader();
                    SqlDataReader dr1 = cmd1.ExecuteReader();

                    if (dr.HasRows == true)
                    {
                        if (dr.Read())
                        {
                            string position = dr["pos_name"].ToString();
                            string time_remark = dr["remark"].ToString();
                            if (time_remark == "เข้างาน")
                            {
                                if (position == "เวชระเบียน")
                                {
                                    MessageBox.Show("ยินดีต้อนรับ" + dr["emp_ru_name"].ToString());

                                    clinic_main_v2 m1 = new clinic_main_v2();
                                    m1.Show();
                                    clinic_login clnlog = new clinic_login();
                                    clnlog.Close();
                                    Visible = false;

                                }
                                else if (position == "พยาบาล")
                                {
                                    MessageBox.Show("ยินดีต้อนรับ" + dr["emp_ru_name"].ToString());

                                    clinic_nurse m2 = new clinic_nurse();
                                    m2.Show();
                                    clinic_login clnlog = new clinic_login();
                                    clnlog.Close();
                                    Visible = false;
                                }
                                else if (position == "หัวหน้า")
                                {
                                    MessageBox.Show("ยินดีต้อนรับ" + dr["emp_ru_name"].ToString());

                                    Clinic_boss m3 = new Clinic_boss();
                                    m3.Show();
                                    clinic_login clnlog = new clinic_login();
                                    clnlog.Close();
                                    Visible = false;
                                }
                                else if (position == "เภสัชกรณ์")
                                {
                                    MessageBox.Show("ยินดีต้อนรับ" + dr["emp_ru_name"].ToString());

                                    clinic_pharmacist m4 = new clinic_pharmacist();
                                    m4.Show();
                                    clinic_login clnlog = new clinic_login();
                                    clnlog.Close();
                                    Visible = false;
                                }




                            }
                            else
                            {
                                MessageBox.Show("คุณยังไม่ได้เข้างาน");
                            }











                        }

                    }
                    else if (dr1.HasRows == true)
                    {
                        if (dr1.Read())
                        {
                            string today = DateTime.Now.ToString("yyyy-MM-dd", new CultureInfo("th-TH"));
                            string time_remark = dr1["remark"].ToString();
                            string date_work = dr1["swd_date_work"].ToString();
                            if(today != date_work)
                            {
                                if (time_remark == "เข้างาน")
                                {

                                    if (dr1["room_id"].ToString() == "1")
                                    {
                                        MessageBox.Show("ยินดีต้อนรับ" + dr1["emp_doc_name"].ToString());

                                        Clinic_doctor doc1 = new Clinic_doctor();
                                        doc1.Show();
                                        clinic_login clnlog = new clinic_login();
                                        clnlog.Close();
                                        Visible = false;


                                    }

                                    else if (dr1["room_id"].ToString() == "2")
                                    {
                                        MessageBox.Show("ยินดีต้อนรับ" + dr1["emp_doc_name"].ToString());

                                        Clinic_doctor2 doc1 = new Clinic_doctor2();
                                        doc1.Show();
                                        clinic_login clnlog = new clinic_login();
                                        clnlog.Close();
                                        Visible = false;
                                    }

                                    else if (dr1["room_id"].ToString() == "3")
                                    {
                                        MessageBox.Show("ยินดีต้อนรับ" + dr1["emp_doc_name"].ToString());
                                        clinic_doctor3 doc1 = new clinic_doctor3();
                                        doc1.Show();
                                        clinic_login clnlog = new clinic_login();
                                        clnlog.Close();
                                        Visible = false;
                                    }

                                    else
                                    {
                                        MessageBox.Show("ยังไม่ได้ลงตารางปฏิบัติงาน");
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("ยังไม่ได้เข้างาน");
                                }


                            }
                            else
                            {
                                MessageBox.Show("ไม่ได้อยู่ในวันปฏิบัติงานนี้");
                            }
                      


                        }


                    }
                    else
                    {
                        MessageBox.Show("Check Username and Password agin!!");
                    }

                    

                }else if(time >= 12.01 && time <= 15.30)
                {
                    // MessageBox.Show("บ่าย");

                    SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-92251HH\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets=true; User ID = sa; Password = 1234");
                    SqlCommand cmd = new SqlCommand("select employee_ru.emp_ru_name,position.pos_name,time_attendance.remark from employee_ru inner join user_control on user_control.emp_ru_id = employee_ru.emp_ru_id inner join position on position.pos_id = employee_ru.pos_id inner join time_attendance on time_attendance.emp_ru_id = employee_ru.emp_ru_id  where uct_user=@uct_user and uct_password=@uct_password ORDER BY id_time DESC", conn);
                    SqlCommand cmd1 = new SqlCommand("select employee_doctor.emp_doc_name,schedule_work_doctor.swd_day_work ,schedule_work_doctor.room_id,time_attendance.remark from employee_doctor inner join user_control on user_control.emp_doc_id = employee_doctor.emp_doc_id inner join schedule_work_doctor on schedule_work_doctor.emp_doc_id = employee_doctor.emp_doc_id  inner join time_attendance on time_attendance.emp_doc_id = employee_doctor.emp_doc_id where uct_user=@uct_user and uct_password=@uct_password and swd_day_work = '" + day + "' and swd_timezone = 'บ่าย' ORDER BY id_time DESC", conn);
                    conn.Open();


                    cmd.Parameters.AddWithValue("@uct_user", T_Username.Text);
                    cmd.Parameters.AddWithValue("@uct_password", T_Password.Text);
                    cmd1.Parameters.AddWithValue("@uct_user", T_Username.Text);
                    cmd1.Parameters.AddWithValue("@uct_password", T_Password.Text);

                    SqlDataReader dr = cmd.ExecuteReader();
                    SqlDataReader dr1 = cmd1.ExecuteReader();

                    if (dr.HasRows == true)
                    {
                        if (dr.Read())
                        {
                            string position = dr["pos_name"].ToString();
                            string time_remark = dr["remark"].ToString();
                            if (time_remark == "เข้างาน")
                            {
                                if (position == "เวชระเบียน")
                                {
                                    MessageBox.Show("ยินดีต้อนรับ" + dr["emp_ru_name"].ToString());

                                    clinic_main_v2 m1 = new clinic_main_v2();
                                    m1.Show();
                                    clinic_login clnlog = new clinic_login();
                                    clnlog.Close();
                                    Visible = false;

                                }
                                else if (position == "พยาบาล")
                                {
                                    MessageBox.Show("ยินดีต้อนรับ" + dr["emp_ru_name"].ToString());

                                    clinic_nurse m2 = new clinic_nurse();
                                    m2.Show();
                                    clinic_login clnlog = new clinic_login();
                                    clnlog.Close();
                                    Visible = false;
                                }
                                else if (position == "หัวหน้า")
                                {
                                    MessageBox.Show("ยินดีต้อนรับ" + dr["emp_ru_name"].ToString());

                                    Clinic_boss m3 = new Clinic_boss();
                                    m3.Show();
                                    clinic_login clnlog = new clinic_login();
                                    clnlog.Close();
                                    Visible = false;
                                }
                                else if (position == "เภสัชกรณ์")
                                {
                                    MessageBox.Show("ยินดีต้อนรับ" + dr["emp_ru_name"].ToString());

                                    clinic_pharmacist m4 = new clinic_pharmacist();
                                    m4.Show();
                                    clinic_login clnlog = new clinic_login();
                                    clnlog.Close();
                                    Visible = false;
                                }




                            }
                            else
                            {
                                MessageBox.Show("คุณยังไม่ได้เข้างาน");
                            }











                        }

                    }
                    else if (dr1.HasRows == true)
                    {
                        if (dr1.Read())
                        {
                            string time_remark = dr1["remark"].ToString();
                            if (time_remark == "เข้างาน")
                            {

                                if (dr1["room_id"].ToString() == "1")
                                {
                                    MessageBox.Show("ยินดีต้อนรับ" + dr1["emp_doc_name"].ToString());

                                    Clinic_doctor doc1 = new Clinic_doctor();
                                    doc1.Show();
                                    clinic_login clnlog = new clinic_login();
                                    clnlog.Close();
                                    Visible = false;


                                }

                                else if (dr1["room_id"].ToString() == "2")
                                {
                                    MessageBox.Show("ยินดีต้อนรับ" + dr1["emp_doc_name"].ToString());

                                    Clinic_doctor2 doc1 = new Clinic_doctor2();
                                    doc1.Show();
                                    clinic_login clnlog = new clinic_login();
                                    clnlog.Close();
                                    Visible = false;
                                }

                                else if (dr1["room_id"].ToString() == "3")
                                {
                                    MessageBox.Show("ยินดีต้อนรับ" + dr1["emp_doc_name"].ToString());
                                    clinic_doctor3 doc1 = new clinic_doctor3();
                                    doc1.Show();
                                    clinic_login clnlog = new clinic_login();
                                    clnlog.Close();
                                    Visible = false;
                                }

                                else
                                {
                                    MessageBox.Show("ยังไม่ได้ลงตารางปฏิบัติงาน");
                                }

                            }
                            else
                            {
                                MessageBox.Show("ยังไม่ได้เข้างาน");
                            }


                        }


                    }
                    else
                    {
                        MessageBox.Show("Check Username and Password agin!!");
                    }

         

                }





            }
            catch (Exception ex)
          {
              MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OKCancel);
           }
        }
        

        private void T_Username_Enter(object sender, EventArgs e)
        {
            if (T_Username.Text == "Username")
            {
                T_Username.Text = "";

                T_Username.ForeColor = Color.Black;
            }
        }

        private void T_Username_Leave(object sender, EventArgs e)
        {
            if (T_Username.Text == "")
            {
                T_Username.Text = "Username";

                T_Username.ForeColor = Color.Silver;
            }
        }

        private void T_Password_Enter(object sender, EventArgs e)
        {
            if (T_Password.Text == "Password")
            {
                T_Password.Text = "";

                T_Password.ForeColor = Color.Black;
            }
        }

        private void T_Password_Leave(object sender, EventArgs e)
        {
            if (T_Password.Text == "")
            {
                T_Password.Text = "Password";

                T_Password.ForeColor = Color.Silver;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
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
            label4.Text = time;

        }
        /*private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "บัตรประชาชน")
            {
                textBox1.Text = "";

                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "บัตรประชาชน";

                textBox1.ForeColor = Color.Silver;
            }
        }*/

    }
}
