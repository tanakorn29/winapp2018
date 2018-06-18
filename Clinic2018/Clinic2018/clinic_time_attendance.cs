using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Clinic2018
{
    public partial class clinic_time_attendance : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-J5O17QF\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
        Timer t = new Timer();

        public clinic_time_attendance()
        {
            InitializeComponent();
            /*
            string query = ("select id_time, start_time, end_time, date_work, remark,emp_ru_id, emp_doc_id from time_attendance");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();



                dataGridView1.Rows[n].Cells[0].Value = item["id_time"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["start_time"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["end_time"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["date_work"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["remark"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item["emp_ru_id"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item["emp_doc_id"].ToString();

            }
            */
            textBox1.Clear();
            textBox1.Refresh();
         
        }

        private void clinic_time_attendance_Load(object sender, EventArgs e)
        {
            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();


            label2.Text = DateTime.Now.ToString("dddd d MMMM yyyy", new CultureInfo("th-TH"));

       
            
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
            label1.Text = time;

        }


    
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                int num_text = 13;
               
                textBox1.MaxLength = num_text;
                
                double time = Convert.ToDouble(label1.Text);
              
                    // MessageBox.Show("เข้างาน");
                    if(num_text < 14)
                {
                    string query = ("select emp_ru_name,emp_ru_id from employee_ru where emp_ru_idcard = '" + textBox1.Text + "'");
                    cmd = new SqlCommand(query, conn);
                    conn.Open();
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);
                    sdr = cmd.ExecuteReader();

                    if (sdr.Read())
                    {
                        int emp_id = Convert.ToInt32(sdr["emp_ru_id"].ToString());
                        string emp_ru_name = sdr["emp_ru_name"].ToString();
                        query = ("select count(*) from time_attendance where remark = 'เข้างาน' AND emp_ru_id = '" + emp_id + "'");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);

                        int status_work = (int)cmd.ExecuteScalar();
                        if (status_work < 1)
                        {

                            query = ("insert time_attendance (start_time,end_time,date_work,remark,emp_ru_id,emp_doc_id) values(SYSDATETIME(),'',SYSDATETIME(),'เข้างาน','" + emp_id + "','')");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);




                            /*   clinic_time_attendance m2 = new clinic_time_attendance();
                                    m2.Show();
                                    clinic_time_attendance clnlog = new clinic_time_attendance();
                                    clnlog.Close();
                                    Visible = false;*/
                            //  MessageBox.Show("เข้างานเรียบร้อย");
                       
              
                            lblemp.Text = emp_ru_name + "   เข้างานเรียบร้อย";

                            /*
                                                       query = ("select employee_ru.emp_ru_name,time_attendance.remark from employee_ru inner join time_attendance on time_attendance.emp_ru_id = employee_ru.emp_ru_id where employee_ru.emp_ru_id = '"+ emp_id + "' AND time_attendance.remark = 'เข้างาน'");
                                                       cmd = new SqlCommand(query, conn);
                                                       conn.Open();
                                                       sda = new SqlDataAdapter(cmd);
                                                       dt = new DataTable();
                                                       sda.Fill(dt);
                                                       sdr = cmd.ExecuteReader();
                                                       if (sdr.Read())
                                                       {

                                                          string emp_name = sdr["emp_ru_name"].ToString();
                                                           string remark = sdr["remark"].ToString();
                                                           MessageBox.Show("เข้างานเรียบร้อย");
                                                           lblemp.Text = "  dddddd  " + emp_name + " dddddddddddddddd   " + remark;

                                                       }
                                                       */





                        }
                        else
                        {

                            int emp_id1 = Convert.ToInt32(sdr["emp_ru_id"].ToString());
                            string emp_ru_name1 = sdr["emp_ru_name"].ToString();
                            query = ("UPDATE time_attendance SET end_time = SYSDATETIME(),remark = 'ออกจากงาน' where emp_ru_id = '" + emp_id1 + "'");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();

                            sda.Fill(dt);
                            /*    clinic_time_attendance m2 = new clinic_time_attendance();
                                   m2.Show();
                                   clinic_time_attendance clnlog = new clinic_time_attendance();
                                   clnlog.Close();
                                   Visible = false;*/
                            //  MessageBox.Show("ออกจากงานเรียบร้อย");
                   
                            lblemp.Text = emp_ru_name1 + "   ออกจากงานเรียบร้อย";

                        }
                        /*
                            query = ("insert time_attendance (start_time,end_time,date_work,remark,emp_ru_id,emp_doc_id) values(SYSDATETIME(),'',SYSDATETIME(),'เข้างาน','" + emp_id + "','')");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);*/
               

                  

                    }
                    /*
                    query = ("select count(*) from queue_diag_room inner join schedule_work_doctor on schedule_work_doctor.swd_id = queue_diag_room.swd_id inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where employee_doctor.emp_doc_idcard = '"+ textBox1.Text + "' AND queue_diag_room.status_queue = 1");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);
                    int queue_diag_count = (int)cmd.ExecuteScalar();
                    if(queue_diag_count >= 1)
                    {
                        MessageBox.Show("ยังมีคนไข้รอคิวอยู่");
                    }
                    else
                    {

                        MessageBox.Show("ไม่มีคนไข้รอคิวอยู่");
                    }
                    */
           
                                        query = ("select emp_doc_name,emp_doc_id from employee_doctor where emp_doc_idcard ='" + textBox1.Text + "'");
                                        cmd = new SqlCommand(query, conn);
                                        sda = new SqlDataAdapter(cmd);
                                        dt = new DataTable();
                                        sda.Fill(dt);
                                        sdr = cmd.ExecuteReader();
                                        if (sdr.Read())
                                        {
                                            int emp_doc_id = Convert.ToInt32(sdr["emp_doc_id"].ToString());
                                            string emp_doc_name = sdr["emp_doc_name"].ToString();
                        query = ("select count(*) from queue_diag_room inner join schedule_work_doctor on schedule_work_doctor.swd_id = queue_diag_room.swd_id inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where employee_doctor.emp_doc_id = '" + emp_doc_id + "' AND queue_diag_room.status_queue = 1");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);
                        int queue_diag_count = (int)cmd.ExecuteScalar();
                        if (queue_diag_count >= 1)
                        {
                            MessageBox.Show("ยังมีคนไข้รอคิวอยู่");
                        }
                        else
                        {

                            query = ("select count(*) from time_attendance where remark = 'เข้างาน' AND emp_doc_id = '" + emp_doc_id + "'");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);

                            int status_work_doc = (int)cmd.ExecuteScalar();
                            if (status_work_doc < 1)
                            {
                                query = ("insert time_attendance (start_time,end_time,date_work,remark,emp_ru_id,emp_doc_id) values(SYSDATETIME(),'',SYSDATETIME(),'เข้างาน','','" + emp_doc_id + "')");
                                cmd = new SqlCommand(query, conn);

                                sda = new SqlDataAdapter(cmd);
                                dt = new DataTable();
                                sda.Fill(dt);
                                query = ("UPDATE room SET room.room_status = 1 FROM room  INNER JOIN schedule_work_doctor ON room.room_id = schedule_work_doctor.room_id INNER JOIN employee_doctor ON employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where emp_doc_idcard = '" + textBox1.Text + "'");
                                cmd = new SqlCommand(query, conn);
                                sda = new SqlDataAdapter(cmd);
                                dt = new DataTable();

                                sda.Fill(dt);


                                lblemp.Text = emp_doc_name + "   เข้างานเรียบร้อย";

                            }
                            else
                            {
                                int emp_doc_id1 = Convert.ToInt32(sdr["emp_doc_id"].ToString());
                                query = ("UPDATE time_attendance SET end_time = SYSDATETIME(),remark = 'ออกจากงาน' where emp_doc_id = '" + emp_doc_id1 + "'");
                                cmd = new SqlCommand(query, conn);
                                sda = new SqlDataAdapter(cmd);
                                dt = new DataTable();

                                sda.Fill(dt);
                                query = ("UPDATE room SET room.room_status = 0 FROM room  INNER JOIN schedule_work_doctor ON room.room_id = schedule_work_doctor.room_id INNER JOIN employee_doctor ON employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where emp_doc_idcard = '" + textBox1.Text + "'");
                                cmd = new SqlCommand(query, conn);
                                sda = new SqlDataAdapter(cmd);
                                dt = new DataTable();

                                sda.Fill(dt);


                                lblemp.Text = emp_doc_name + "   ออกจากงานเรียบร้อย";

                            }
                        }

                        /*
                                            query = ("select count(*) from time_attendance where remark = 'เข้างาน' AND emp_doc_id = '" + emp_doc_id + "'");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);

                                            int status_work_doc = (int)cmd.ExecuteScalar();
                                            if (status_work_doc < 1)
                                            {
                                                query = ("insert time_attendance (start_time,end_time,date_work,remark,emp_ru_id,emp_doc_id) values(SYSDATETIME(),'',SYSDATETIME(),'เข้างาน','','" + emp_doc_id + "')");
                                                cmd = new SqlCommand(query, conn);

                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);
                                                query = ("UPDATE room SET room.room_status = 1 FROM room  INNER JOIN schedule_work_doctor ON room.room_id = schedule_work_doctor.room_id INNER JOIN employee_doctor ON employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where emp_doc_idcard = '" + textBox1.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();

                                                sda.Fill(dt);


                                                lblemp.Text = emp_doc_name + "   เข้างานเรียบร้อย";

                                            }
                                            else
                                            {
                                                int emp_doc_id1 = Convert.ToInt32(sdr["emp_doc_id"].ToString());
                                                query = ("UPDATE time_attendance SET end_time = SYSDATETIME(),remark = 'ออกจากงาน' where emp_doc_id = '" + emp_doc_id1 + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();

                                                sda.Fill(dt);
                                                query = ("UPDATE room SET room.room_status = 0 FROM room  INNER JOIN schedule_work_doctor ON room.room_id = schedule_work_doctor.room_id INNER JOIN employee_doctor ON employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where emp_doc_idcard = '" + textBox1.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();

                                                sda.Fill(dt);


                                                lblemp.Text = emp_doc_name + "   ออกจากงานเรียบร้อย";

                                            }
                                            */

                    }
                                         
                }
                else
                                    {
                                        textBox1.Clear();
                                    }
                    
                    conn.Close();

              /*
                else if (time >= 12.01)
                {
                    //   MessageBox.Show("ออกงาน");

                    string query = ("select emp_ru_id from employee_ru where emp_ru_idcard = '" + textBox1.Text + "'");
                    cmd = new SqlCommand(query, conn);
                    conn.Open();
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);
                    sdr = cmd.ExecuteReader();

                    if (sdr.Read())
                    {
                        int emp_id = Convert.ToInt32(sdr["emp_ru_id"].ToString());
                        query = ("UPDATE time_attendance SET end_time = SYSDATETIME(),remark = 'ออกจากงาน' where emp_ru_id = '" + emp_id + "'");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();

                        sda.Fill(dt);
                        clinic_time_attendance m2 = new clinic_time_attendance();
                        m2.Show();
                        clinic_time_attendance clnlog = new clinic_time_attendance();
                        clnlog.Close();
                        Visible = false;
                        MessageBox.Show("ออกจากงานเรียบร้อย");

                    }

                    query = ("select emp_doc_id from employee_doctor where emp_doc_idcard ='" + textBox1.Text + "'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);
                    sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        int emp_doc_id = Convert.ToInt32(sdr["emp_doc_id"].ToString());
                        query = ("UPDATE time_attendance SET end_time = SYSDATETIME(),remark = 'ออกจากงาน' where emp_doc_id = '" + emp_doc_id + "'");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();

                        sda.Fill(dt);
                        query = ("UPDATE room SET room.room_status = 0 FROM room  INNER JOIN schedule_work_doctor ON room.room_id = schedule_work_doctor.room_id INNER JOIN employee_doctor ON employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where emp_doc_idcard = '" + textBox1.Text + "'");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();

                        sda.Fill(dt);
                        clinic_time_attendance m2 = new clinic_time_attendance();
                        m2.Show();
                        clinic_time_attendance clnlog = new clinic_time_attendance();
                        clnlog.Close();
                        Visible = false;
                        MessageBox.Show("ออกจากงานเรียบร้อย");

                    }

                    conn.Close();

                }*/

            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OKCancel);
            }
         

            /*
            string query = ("insert time_attendance (start_time,end_time,date_work,remark,emp_ru_id,emp_doc_id) values(SYSDATETIME(),SYSDATETIME(),SYSDATETIME(),'',1,1)");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);*/


        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "กรอกรหัส";

                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "บัตรประชาชน")
            {
                textBox1.Text = "";

                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
     
        }

        private void textBox1_CursorChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
           
        }

        private void textBox1_Move(object sender, EventArgs e)
        {
     
        }

        private void lblemp_TextChanged(object sender, EventArgs e)
        {
            /*       clinic_time_attendance m2 = new clinic_time_attendance();
                     m2.Show();
                     clinic_time_attendance clnlog = new clinic_time_attendance();
                     clnlog.Close();
            
            Visible = false;*/

            //  textBox1.Text = "44444444444";
        
        }

        private void lblemp_ControlRemoved(object sender, ControlEventArgs e)
        {
         
        }
    }
}
