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
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-92251HH\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
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

            try
            {
                /* select time_attendance.emp_ru_id  from time_attendance
 inner join user_control on user_control.emp_ru_id = time_attendance.emp_ru_id
  inner join employee_ru on employee_ru.emp_ru_id = user_control.emp_ru_id 
 inner join position on position.pos_id = employee_ru.pos_id 
 where pos_name = 'พยาบาล' AND time_attendance.remark = 'เข้างาน' ORDER BY id_time DESC
*/
                /*      string query = ("select time_attendance.emp_ru_id  from time_attendance inner join user_control on user_control.emp_ru_id = time_attendance.emp_ru_id inner join employee_ru on employee_ru.emp_ru_id = user_control.emp_ru_id inner join position on position.pos_id = employee_ru.pos_id where  time_attendance.remark = 'เข้างาน' ORDER BY id_time DESC");
                            cmd = new SqlCommand(query, conn);
                            conn.Open();
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);
                            sdr = cmd.ExecuteReader();

                            if (sdr.Read())
                            {
                                int emp_id = Convert.ToInt32(sdr["emp_ru_id"].ToString());
                                label6.Text = Convert.ToString(emp_id);
                            }
                conn.Close();*/
            }
            catch (Exception)
            {

            }
            label2.Text = DateTime.Now.ToString("yyyy-MM-dd", new CultureInfo("th-TH"));

       
            
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
                    string query = ("select emp_ru_name,emp_ru_id,pos_id from employee_ru where emp_ru_idcard = '" + textBox1.Text + "'");
                    cmd = new SqlCommand(query, conn);
                    conn.Open();
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);
                    sdr = cmd.ExecuteReader();

                    if (sdr.Read())
                    {
                        int emp_id = Convert.ToInt32(sdr["emp_ru_id"].ToString());

                        int pos_id = Convert.ToInt32(sdr["pos_id"].ToString());
                        string emp_ru_name = sdr["emp_ru_name"].ToString();

                        if(pos_id == 3)
                        {

                            query = ("select count(*) from visit_record inner join opd on visit_record.opd_id = opd.opd_id where vr_status = 0");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);

                            int visit_work = (int)cmd.ExecuteScalar();

                            query = ("select count(*) from queue_visit_record inner join opd on opd.opd_id = queue_visit_record.opd_id where queue_visit_record.qvr_status = 1 OR queue_visit_record.qvr_status = 5");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);

                            int queue_visit_count = (int)cmd.ExecuteScalar();


                            query = ("select count(*) from appointment where status_approve = 1");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);

                            int status_work = (int)cmd.ExecuteScalar();
                            if(queue_visit_count < 1)
                            {
                                if (visit_work < 1)
                                {

                                    if (status_work < 1)
                                    {
                                        query = ("select count(*) from time_attendance where remark = 'เข้างาน' AND emp_ru_id = '" + emp_id + "' AND date_work = '" + label2.Text + "'");
                                        cmd = new SqlCommand(query, conn);
                                        sda = new SqlDataAdapter(cmd);
                                        dt = new DataTable();
                                        sda.Fill(dt);

                                        int status_work1 = (int)cmd.ExecuteScalar();
                                        if (time >= 06.00 && time <= 16.29)
                                        {
                                            if (status_work1 < 1)
                                            {


                                                if (time >= 06.00 && time <= 08.31)
                                                {

                                                    query = ("insert time_attendance (start_time,end_time,date_work,remark,status_remark,emp_ru_id,emp_doc_id) values('" + label1.Text + "','','" + label2.Text + "','เข้างาน','ก่อนเวลางาน','" + emp_id + "','')");
                                                    cmd = new SqlCommand(query, conn);
                                                    sda = new SqlDataAdapter(cmd);
                                                    dt = new DataTable();
                                                    sda.Fill(dt);







                                                    lblemp.Text = emp_ru_name + "   เข้างานเรียบร้อย";
                                                    lblstatus_app.Text = "มาก่อนเวลา";





                                                }
                                                else
                                                {
                     
                                                        query = ("insert time_attendance (start_time,end_time,date_work,remark,status_remark,emp_ru_id,emp_doc_id) values('" + label1.Text + "','','" + label2.Text + "','เข้างาน','สาย','" + emp_id + "','')");
                                                        cmd = new SqlCommand(query, conn);
                                                        sda = new SqlDataAdapter(cmd);
                                                        dt = new DataTable();
                                                        sda.Fill(dt);







                                                        lblemp.Text = emp_ru_name + "   เข้างานเรียบร้อย";
                                                        lblstatus_app.Text = "คุณมาสาย";
                                                }


                                          






                                            }
                                            else
                                            {

                                                MessageBox.Show("ไม่สามารถออกจากงานได้");

                                            }
                                        }
                                        else if (time >= 16.30 && time <= 23.59)
                                        {
                                            query = ("select count(*) from time_attendance where remark = 'ออกจากงาน' AND emp_ru_id = '" + emp_id + "' AND date_work = '" + label2.Text + "'");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);

                                            int status_work2 = (int)cmd.ExecuteScalar();
                                            if (status_work2 < 1)
                                            {
                                                int emp_id1 = Convert.ToInt32(sdr["emp_ru_id"].ToString());
                                                string emp_ru_name1 = sdr["emp_ru_name"].ToString();
                                                query = ("UPDATE time_attendance SET end_time = '" + label1.Text + "',remark = 'ออกจากงาน' where emp_ru_id = '" + emp_id1 + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();

                                                sda.Fill(dt);
                                       
                                                    query = ("select employee_ru.emp_ru_id from user_control inner join employee_ru on employee_ru.emp_ru_id = user_control.emp_ru_id inner join position on position.pos_id = employee_ru.pos_id where employee_ru.emp_ru_id > '"+ emp_id1 + "' and pos_name = 'พยาบาล'");
                                                    cmd = new SqlCommand(query, conn);
                                                    sda = new SqlDataAdapter(cmd);
                                                    dt = new DataTable();
                                                    sda.Fill(dt);
                                                    sdr = cmd.ExecuteReader();
                                                    while (sdr.Read())
                                                    {
                                                        int employees_id = sdr.GetInt32(0);
                                                    query = ("select count(*) from time_attendance where date_work = '" + label2.Text + "' AND emp_ru_id = '" + employees_id + "'");
                                                    cmd = new SqlCommand(query, conn);
                                                    sda = new SqlDataAdapter(cmd);
                                                    dt = new DataTable();
                                                    sda.Fill(dt);

                                                    int count_add_check = (int)cmd.ExecuteScalar();
                                                    if(count_add_check < 1)
                                                    {
                                                        query = ("select count(*) from time_attendance where date_work = '" + label2.Text + "' AND remark = 'เข้างาน' AND emp_ru_id = '" + employees_id + "'");
                                                        cmd = new SqlCommand(query, conn);
                                                        sda = new SqlDataAdapter(cmd);
                                                        dt = new DataTable();
                                                        sda.Fill(dt);

                                                        int time_add_c = (int)cmd.ExecuteScalar();
                                                        if (time_add_c < 1)
                                                        {
                                                            query = ("insert time_attendance (start_time,end_time,date_work,remark,status_remark,emp_ru_id,emp_doc_id) values('','','" + label2.Text + "','ยังไม่มีการเข้างาน','ขาด','" + employees_id + "','')");
                                                            cmd = new SqlCommand(query, conn);

                                                            sda = new SqlDataAdapter(cmd);
                                                            dt = new DataTable();
                                                            sda.Fill(dt);

                                                        }

                                                    }


                                                }

                                                query = ("select employee_ru.emp_ru_id from user_control inner join employee_ru on employee_ru.emp_ru_id = user_control.emp_ru_id inner join position on position.pos_id = employee_ru.pos_id where employee_ru.emp_ru_id < '" + emp_id1 + "' and pos_name = 'พยาบาล'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);
                                                sdr = cmd.ExecuteReader();
                                                while (sdr.Read())
                                                {
                                                    int employees_id = sdr.GetInt32(0);
                                                    query = ("select count(*) from time_attendance where date_work = '" + label2.Text + "' AND emp_ru_id = '" + employees_id + "'");
                                                    cmd = new SqlCommand(query, conn);
                                                    sda = new SqlDataAdapter(cmd);
                                                    dt = new DataTable();
                                                    sda.Fill(dt);

                                                    int count_add_check = (int)cmd.ExecuteScalar();
                                                    if (count_add_check < 1)
                                                    {
                                                        query = ("select count(*) from time_attendance where date_work = '" + label2.Text + "' AND remark = 'เข้างาน' AND emp_ru_id = '" + employees_id + "'");
                                                        cmd = new SqlCommand(query, conn);
                                                        sda = new SqlDataAdapter(cmd);
                                                        dt = new DataTable();
                                                        sda.Fill(dt);

                                                        int time_add_c = (int)cmd.ExecuteScalar();
                                                        if (time_add_c < 1)
                                                        {
                                                            query = ("insert time_attendance (start_time,end_time,date_work,remark,status_remark,emp_ru_id,emp_doc_id) values('','','" + label2.Text + "','ยังไม่มีการเข้างาน','ขาด','" + employees_id + "','')");
                                                            cmd = new SqlCommand(query, conn);

                                                            sda = new SqlDataAdapter(cmd);
                                                            dt = new DataTable();
                                                            sda.Fill(dt);

                                                        }

                                                    }

                                                }

                                                lblemp.Text = emp_ru_name1 + "   ออกจากงานเรียบร้อย";
                                            }
                                            else
                                            {
                                                MessageBox.Show("มีข้อมูลออกจากงานเรียบร้อยแล้ว");
                                            }


                                        }
                                        else
                                        {
                                            MessageBox.Show("ยังไม่ถึงเวลาเข้างาน");
                                        }



                                    }
                                    else
                                    {
                                        MessageBox.Show("การนัดหมายยังไม่เสร็จสิ้น");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("ข้อมูลซักประวัติยังไม่เสร็จสิ้น");
                                }
                            }
                            else
                            {
                                MessageBox.Show("ยังมีคิวรอการซักประวัติคนไข้อยู่");
                            }
                   


                        }else if(pos_id == 4)
                        {
                            query = ("select count(*) from opd inner join treatment_record on treatment_record.opd_id = opd.opd_id where treatr_status = 2");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);

                            int count = (int)cmd.ExecuteScalar();

                            if (count < 1)
                            {
                                query = ("select count(*) from time_attendance where remark = 'เข้างาน' AND emp_ru_id = '" + emp_id + "' AND date_work = '" + label2.Text + "'");
                                cmd = new SqlCommand(query, conn);
                                sda = new SqlDataAdapter(cmd);
                                dt = new DataTable();
                                sda.Fill(dt);

                                int status_work1 = (int)cmd.ExecuteScalar();
                                if (time >= 06.00 && time <= 16.29)
                                {
                                    if (status_work1 < 1)
                                    {

                                        //  MessageBox.Show("เข้างาน");
                                        if (time >= 06.00 && time <= 08.31)
                                        {

                                            query = ("insert time_attendance (start_time,end_time,date_work,remark,status_remark,emp_ru_id,emp_doc_id) values('" + label1.Text + "','','" + label2.Text + "','เข้างาน','ก่อนเวลางาน','" + emp_id + "','')");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);







                                            lblemp.Text = emp_ru_name + "   เข้างานเรียบร้อย";
                                            lblstatus_app.Text = "มาก่อนเวลา";
                                        }else
                                        {
                                            query = ("insert time_attendance (start_time,end_time,date_work,remark,status_remark,emp_ru_id,emp_doc_id) values('" + label1.Text + "','','" + label2.Text + "','เข้างาน','สาย','" + emp_id + "','')");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);







                                            lblemp.Text = emp_ru_name + "   เข้างานเรียบร้อย";
                                            lblstatus_app.Text = "คุณมาสาย";
                                        }
                                         







                                    }
                                    else
                                    {

                                        MessageBox.Show("ไม่สามารถออกจากงานได้");
                                    }

                                }
                                else if (time >= 16.30 && time <= 23.59)
                                {

                                    query = ("select count(*) from time_attendance where remark = 'ออกจากงาน' AND emp_ru_id = '" + emp_id + "' AND date_work = '" + label2.Text + "'");
                                    cmd = new SqlCommand(query, conn);
                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    sda.Fill(dt);

                                    int status_work2 = (int)cmd.ExecuteScalar();
                                    if (status_work2 < 1)
                                    {
                                        int emp_id1 = Convert.ToInt32(sdr["emp_ru_id"].ToString());
                                        string emp_ru_name1 = sdr["emp_ru_name"].ToString();
                                        query = ("UPDATE time_attendance SET end_time = '" + label1.Text + "',remark = 'ออกจากงาน' where emp_ru_id = '" + emp_id1 + "'");
                                        cmd = new SqlCommand(query, conn);
                                        sda = new SqlDataAdapter(cmd);
                                        dt = new DataTable();

                                        sda.Fill(dt);

                                        query = ("select employee_ru.emp_ru_id from user_control inner join employee_ru on employee_ru.emp_ru_id = user_control.emp_ru_id inner join position on position.pos_id = employee_ru.pos_id where employee_ru.emp_ru_id > '" + emp_id1 + "' and pos_name = 'เภสัชกรณ์'");
                                        cmd = new SqlCommand(query, conn);
                                        sda = new SqlDataAdapter(cmd);
                                        dt = new DataTable();
                                        sda.Fill(dt);
                                        sdr = cmd.ExecuteReader();
                                        while (sdr.Read())
                                        {
                                            int employees_id = sdr.GetInt32(0);
                                            query = ("select count(*) from time_attendance where date_work = '" + label2.Text + "' AND emp_ru_id = '" + employees_id + "'");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);

                                            int count_add_check = (int)cmd.ExecuteScalar();
                                            if (count_add_check < 1)
                                            {
                                                query = ("select count(*) from time_attendance where date_work = '" + label2.Text + "' AND remark = 'เข้างาน' AND emp_ru_id = '" + employees_id + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);

                                                int time_add_c = (int)cmd.ExecuteScalar();
                                                if (time_add_c < 1)
                                                {
                                                    query = ("insert time_attendance (start_time,end_time,date_work,remark,status_remark,emp_ru_id,emp_doc_id) values('','','" + label2.Text + "','ยังไม่มีการเข้างาน','ขาด','" + employees_id + "','')");
                                                    cmd = new SqlCommand(query, conn);

                                                    sda = new SqlDataAdapter(cmd);
                                                    dt = new DataTable();
                                                    sda.Fill(dt);

                                                }

                                            }


                                        }

                                        query = ("select employee_ru.emp_ru_id from user_control inner join employee_ru on employee_ru.emp_ru_id = user_control.emp_ru_id inner join position on position.pos_id = employee_ru.pos_id where employee_ru.emp_ru_id < '" + emp_id1 + "' and pos_name = 'เภสัชกรณ์'");
                                        cmd = new SqlCommand(query, conn);
                                        sda = new SqlDataAdapter(cmd);
                                        dt = new DataTable();
                                        sda.Fill(dt);
                                        sdr = cmd.ExecuteReader();
                                        while (sdr.Read())
                                        {
                                            int employees_id = sdr.GetInt32(0);
                                            query = ("select count(*) from time_attendance where date_work = '" + label2.Text + "' AND emp_ru_id = '" + employees_id + "'");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);

                                            int count_add_check = (int)cmd.ExecuteScalar();
                                            if (count_add_check < 1)
                                            {
                                                query = ("select count(*) from time_attendance where date_work = '" + label2.Text + "' AND remark = 'เข้างาน' AND emp_ru_id = '" + employees_id + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);

                                                int time_add_c = (int)cmd.ExecuteScalar();
                                                if (time_add_c < 1)
                                                {
                                                    query = ("insert time_attendance (start_time,end_time,date_work,remark,status_remark,emp_ru_id,emp_doc_id) values('','','" + label2.Text + "','ยังไม่มีการเข้างาน','ขาด','" + employees_id + "','')");
                                                    cmd = new SqlCommand(query, conn);

                                                    sda = new SqlDataAdapter(cmd);
                                                    dt = new DataTable();
                                                    sda.Fill(dt);

                                                }

                                            }

                                        }

                                        lblemp.Text = emp_ru_name1 + "   ออกจากงานเรียบร้อย";
                                    }
                                    else
                                    {
                                        MessageBox.Show("มีข้อมูลออกจากงานเรียบร้อยแล้ว");
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("ยังไม่ถึงเวลาเข้างาน");
                                }
                        

                            }
                            else
                            {
                                MessageBox.Show("การจ่ายยายังไม่เสร็จสิ้น");
                            }
                        }
                        else
                        {
                            query = ("select count(*) from time_attendance where remark = 'เข้างาน' AND emp_ru_id = '" + emp_id + "' AND date_work = '" + label2.Text + "'");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);

                            int status_work1 = (int)cmd.ExecuteScalar();
                            if (time >= 06.00 && time <= 16.29)
                            {
                                if (status_work1 < 1)
                                {

                                    //  MessageBox.Show("เข้างาน");


                                    if (time >= 06.00 && time <= 08.31)
                                    {

                                        query = ("insert time_attendance (start_time,end_time,date_work,remark,status_remark,emp_ru_id,emp_doc_id) values('" + label1.Text + "','','" + label2.Text + "','เข้างาน','ก่อนเวลางาน','" + emp_id + "','')");
                                        cmd = new SqlCommand(query, conn);
                                        sda = new SqlDataAdapter(cmd);
                                        dt = new DataTable();
                                        sda.Fill(dt);







                                        lblemp.Text = emp_ru_name + "   เข้างานเรียบร้อย";
                                        lblstatus_app.Text = "มาก่อนเวลา";
                                    }
                                    else
                                    {
                                        query = ("insert time_attendance (start_time,end_time,date_work,remark,status_remark,emp_ru_id,emp_doc_id) values('" + label1.Text + "','','" + label2.Text + "','เข้างาน','สาย','" + emp_id + "','')");
                                        cmd = new SqlCommand(query, conn);
                                        sda = new SqlDataAdapter(cmd);
                                        dt = new DataTable();
                                        sda.Fill(dt);







                                        lblemp.Text = emp_ru_name + "   เข้างานเรียบร้อย";
                                        lblstatus_app.Text = "คุณมาสาย";
                                    }






                                }
                                else
                                {

                                    MessageBox.Show("ไม่สามารถออกจากงานได้");
                                }

                            }
                            else if (time >= 16.30 && time <= 23.59)
                            {

                                query = ("select count(*) from time_attendance where remark = 'ออกจากงาน' AND emp_ru_id = '" + emp_id + "' AND date_work = '" + label2.Text + "'");
                                cmd = new SqlCommand(query, conn);
                                sda = new SqlDataAdapter(cmd);
                                dt = new DataTable();
                                sda.Fill(dt);

                                int status_work2 = (int)cmd.ExecuteScalar();
                                if (status_work2 < 1)
                                {
                                    int emp_id1 = Convert.ToInt32(sdr["emp_ru_id"].ToString());
                                    string emp_ru_name1 = sdr["emp_ru_name"].ToString();
                                    query = ("UPDATE time_attendance SET end_time = '" + label1.Text + "',remark = 'ออกจากงาน' where emp_ru_id = '" + emp_id1 + "'");
                                    cmd = new SqlCommand(query, conn);
                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();

                                    sda.Fill(dt);


                                    lblemp.Text = emp_ru_name1 + "   ออกจากงานเรียบร้อย";
                                    query = ("select employee_ru.emp_ru_id from user_control inner join employee_ru on employee_ru.emp_ru_id = user_control.emp_ru_id inner join position on position.pos_id = employee_ru.pos_id where employee_ru.emp_ru_id > '" + emp_id1 + "'");
                                    cmd = new SqlCommand(query, conn);
                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    sda.Fill(dt);
                                    sdr = cmd.ExecuteReader();
                                    while (sdr.Read())
                                    {
                                        int employees_id = sdr.GetInt32(0);
                                        query = ("select count(*) from time_attendance where date_work = '" + label2.Text + "' AND emp_ru_id = '" + employees_id + "'");
                                        cmd = new SqlCommand(query, conn);
                                        sda = new SqlDataAdapter(cmd);
                                        dt = new DataTable();
                                        sda.Fill(dt);

                                        int count_add_check = (int)cmd.ExecuteScalar();
                                        if (count_add_check < 1)
                                        {
                                            query = ("select count(*) from time_attendance where date_work = '" + label2.Text + "' AND remark = 'เข้างาน' AND emp_ru_id = '" + employees_id + "'");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);

                                            int time_add_c = (int)cmd.ExecuteScalar();
                                            if (time_add_c < 1)
                                            {
                                                query = ("insert time_attendance (start_time,end_time,date_work,remark,status_remark,emp_ru_id,emp_doc_id) values('','','" + label2.Text + "','ยังไม่มีการเข้างาน','ขาด','" + employees_id + "','')");
                                                cmd = new SqlCommand(query, conn);

                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);

                                            }

                                        }


                                    }

                                    query = ("select employee_ru.emp_ru_id from user_control inner join employee_ru on employee_ru.emp_ru_id = user_control.emp_ru_id inner join position on position.pos_id = employee_ru.pos_id where employee_ru.emp_ru_id < '" + emp_id1 + "'");
                                    cmd = new SqlCommand(query, conn);
                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    sda.Fill(dt);
                                    sdr = cmd.ExecuteReader();
                                    while (sdr.Read())
                                    {
                                        int employees_id = sdr.GetInt32(0);
                                        query = ("select count(*) from time_attendance where date_work = '" + label2.Text + "' AND emp_ru_id = '" + employees_id + "'");
                                        cmd = new SqlCommand(query, conn);
                                        sda = new SqlDataAdapter(cmd);
                                        dt = new DataTable();
                                        sda.Fill(dt);

                                        int count_add_check = (int)cmd.ExecuteScalar();
                                        if (count_add_check < 1)
                                        {
                                            query = ("select count(*) from time_attendance where date_work = '" + label2.Text + "' AND remark = 'เข้างาน' AND emp_ru_id = '" + employees_id + "'");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);

                                            int time_add_c = (int)cmd.ExecuteScalar();
                                            if (time_add_c < 1)
                                            {
                                                query = ("insert time_attendance (start_time,end_time,date_work,remark,status_remark,emp_ru_id,emp_doc_id) values('','','" + label2.Text + "','ยังไม่มีการเข้างาน','ขาด','" + employees_id + "','')");
                                                cmd = new SqlCommand(query, conn);

                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);

                                            }

                                        }

                                    }
                                }
                                else
                                {
                                    MessageBox.Show("มีข้อมูลออกจากงานเรียบร้อยแล้ว");
                                }

                            }
                            else
                            {
                                MessageBox.Show("ยังไม่ถึงเวลาเข้างาน");
                            }



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

          /*              query = ("select swd_end_time from schedule_work_doctor where swd_status_room = 1 AND swd_date_work = '"+label2.Text+"' AND emp_doc_id = '"+ emp_doc_id + "'");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);
                        sdr = cmd.ExecuteReader();

                        if (sdr.Read())
                        {
                            double swd_end_time = Convert.ToDouble(sdr["swd_end_time"].ToString());




                        }*/


                        if (time >= 06.00 && time <= 11.29)
                        {
                            query = ("select count(emp_doc_id) from schedule_work_doctor where swd_status_room = 1 AND swd_date_work = '" + label2.Text + "' AND emp_doc_id = '" + emp_doc_id + "' AND swd_timezone = 'เช้า'");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);
                            int swd_count = (int)cmd.ExecuteScalar();
                            if (swd_count < 1)
                            {
                                MessageBox.Show("ไม่สามารถเข้างานได้กรุณาตรวจสอบอีกครั้ง");
                            }
                            else
                            {
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

                                    query = ("select count(*) from time_attendance where remark = 'เข้างาน' AND emp_doc_id = '" + emp_doc_id + "' AND date_work = '" + label2.Text + "'");
                                    cmd = new SqlCommand(query, conn);
                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    sda.Fill(dt);

                                    int status_work_doc = (int)cmd.ExecuteScalar();
                              

                                        if (status_work_doc < 1)
                                    {

                                        if (time >= 06.00 && time <= 08.31)
                                        {

                                            query = ("insert time_attendance (start_time,end_time,date_work,remark,status_remark,emp_ru_id,emp_doc_id) values('" + label1.Text + "','','" + label2.Text + "','เข้างาน','ก่อนเวลางาน','','" + emp_doc_id + "')");
                                            cmd = new SqlCommand(query, conn);

                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);


                               /*             query = ("select count(*) from time_attendance where remark = 'ยังไม่มีการเข้างาน' AND date_work = '" + label2.Text + "' AND emp_doc_id = '" + emp_doc_id + "'");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);

                                            int count_add = (int)cmd.ExecuteScalar();
                                            if(count_add < 1)
                                            {
                                       


                                                query = ("select count(*) from schedule_work_doctor where swd_date_work = '" + label2.Text + "' AND swd_status_room = 1 AND schedule_work_doctor.emp_doc_id < '" + emp_doc_id + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);

                                                int count_c = (int)cmd.ExecuteScalar();
                                                if (count_c < 1)
                                                {
                                                    query = ("select  emp_doc_id from schedule_work_doctor where swd_date_work = '" + label2.Text + "' AND swd_status_room = 1 AND schedule_work_doctor.emp_doc_id > '" + emp_doc_id + "' Group by emp_doc_id");
                                                    cmd = new SqlCommand(query, conn);
                                                    sda = new SqlDataAdapter(cmd);
                                                    dt = new DataTable();
                                                    sda.Fill(dt);
                                                    sdr = cmd.ExecuteReader();
                                                    while (sdr.Read())
                                                    {
                                                        int doc_id = sdr.GetInt32(0);
                                                        query = ("insert time_attendance (start_time,end_time,date_work,remark,status_remark,emp_ru_id,emp_doc_id) values('','','" + label2.Text + "','ยังไม่มีการเข้างาน','ขาด','','" + doc_id + "')");
                                                        cmd = new SqlCommand(query, conn);

                                                        sda = new SqlDataAdapter(cmd);
                                                        dt = new DataTable();
                                                        sda.Fill(dt);
                                                    }
                                                }
                                                else
                                                {
                                                    query = ("select  emp_doc_id from schedule_work_doctor where swd_date_work = '" + label2.Text + "' AND swd_status_room = 1 AND schedule_work_doctor.emp_doc_id < '" + emp_doc_id + "' Group by emp_doc_id");
                                                    cmd = new SqlCommand(query, conn);
                                                    sda = new SqlDataAdapter(cmd);
                                                    dt = new DataTable();
                                                    sda.Fill(dt);
                                                    sdr = cmd.ExecuteReader();
                                                    while (sdr.Read())
                                                    {
                                                        int doc_id = sdr.GetInt32(0);
                                                        query = ("insert time_attendance (start_time,end_time,date_work,remark,status_remark,emp_ru_id,emp_doc_id) values('','','" + label2.Text + "','ยังไม่มีการเข้างาน','ขาด','','" + doc_id + "')");
                                                        cmd = new SqlCommand(query, conn);

                                                        sda = new SqlDataAdapter(cmd);
                                                        dt = new DataTable();
                                                        sda.Fill(dt);
                                                    }
                                                }*/

                                                query = ("UPDATE room SET room.room_status = 1 FROM room  INNER JOIN schedule_work_doctor ON room.room_id = schedule_work_doctor.room_id INNER JOIN employee_doctor ON employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where emp_doc_idcard = '" + textBox1.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();

                                                sda.Fill(dt);

                                                //     query = ("Update schedule_work_doctor set swd_status_checkwork = 1 where emp_doc_id = '" + emp_doc_id + "' AND swd_date_work <= '" + label2.Text + "'");

                                                query = ("Update schedule_work_doctor set swd_status_checkwork = 1 where  swd_date_work <= '" + label2.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();

                                                sda.Fill(dt);

                                                lblemp.Text = emp_doc_name + "   เข้างานเรียบร้อย";
                                                lblstatus_app.Text = "มาก่อนเวลา";
                                         /*   }else
                                            {
                                                query = ("Update time_attendance set start_time = '"+label1.Text+"',end_time = '',remark = 'เข้างาน',status_remark = 'ก่อนเวลางาน' where emp_doc_id = '"+emp_doc_id+"' AND date_work = '"+label2.Text+"'");
                                                cmd = new SqlCommand(query, conn);

                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);
                                                query = ("UPDATE room SET room.room_status = 1 FROM room  INNER JOIN schedule_work_doctor ON room.room_id = schedule_work_doctor.room_id INNER JOIN employee_doctor ON employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where emp_doc_idcard = '" + textBox1.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();

                                                sda.Fill(dt);

                                                //     query = ("Update schedule_work_doctor set swd_status_checkwork = 1 where emp_doc_id = '" + emp_doc_id + "' AND swd_date_work <= '" + label2.Text + "'");

                                                query = ("Update schedule_work_doctor set swd_status_checkwork = 1 where  swd_date_work <= '" + label2.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();

                                                sda.Fill(dt);

                                                lblemp.Text = emp_doc_name + "   เข้างานเรียบร้อย";
                                                lblstatus_app.Text = "มาก่อนเวลา";
                                            }*/
                                 
                                        }
                                        else
                                        {
                                            query = ("insert time_attendance (start_time,end_time,date_work,remark,status_remark,emp_ru_id,emp_doc_id) values('" + label1.Text + "','','" + label2.Text + "','เข้างาน','สาย','','" + emp_doc_id + "')");
                                            cmd = new SqlCommand(query, conn);

                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);

                                            query = ("UPDATE room SET room.room_status = 1 FROM room  INNER JOIN schedule_work_doctor ON room.room_id = schedule_work_doctor.room_id INNER JOIN employee_doctor ON employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where emp_doc_idcard = '" + textBox1.Text + "'");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();

                                            sda.Fill(dt);

                                            query = ("Update schedule_work_doctor set swd_status_checkwork = 1 where  swd_date_work <= '" + label2.Text + "'");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();

                                            sda.Fill(dt);

                                            lblemp.Text = emp_doc_name + "   เข้างานเรียบร้อย";
                                            lblstatus_app.Text = "คุณมาสาย";
                                            /*      query = ("select count(*) from time_attendance where remark = 'ยังไม่มีการเข้างาน' AND date_work = '" + label2.Text + "' AND emp_doc_id = '" + emp_doc_id + "'");
                                                  cmd = new SqlCommand(query, conn);
                                                  sda = new SqlDataAdapter(cmd);
                                                  dt = new DataTable();
                                                  sda.Fill(dt);

                                                  int count_add = (int)cmd.ExecuteScalar();
                                                  if (count_add < 1)
                                                  {





                                                      query = ("select count(*) from schedule_work_doctor where swd_date_work = '" + label2.Text + "' AND swd_status_room = 1 AND schedule_work_doctor.emp_doc_id < '" + emp_doc_id + "'");
                                                      cmd = new SqlCommand(query, conn);
                                                      sda = new SqlDataAdapter(cmd);
                                                      dt = new DataTable();
                                                      sda.Fill(dt);

                                                      int count_c = (int)cmd.ExecuteScalar();
                                                      if (count_c < 1)
                                                      {
                                                          query = ("select  emp_doc_id from schedule_work_doctor where swd_date_work = '" + label2.Text + "' AND swd_status_room = 1 AND schedule_work_doctor.emp_doc_id > '" + emp_doc_id + "' Group by emp_doc_id");
                                                          cmd = new SqlCommand(query, conn);
                                                          sda = new SqlDataAdapter(cmd);
                                                          dt = new DataTable();
                                                          sda.Fill(dt);
                                                          sdr = cmd.ExecuteReader();
                                                          while (sdr.Read())
                                                          {
                                                              int doc_id = sdr.GetInt32(0);
                                                              query = ("insert time_attendance (start_time,end_time,date_work,remark,status_remark,emp_ru_id,emp_doc_id) values('','','" + label2.Text + "','ยังไม่มีการเข้างาน','ขาด','','" + doc_id + "')");
                                                              cmd = new SqlCommand(query, conn);

                                                              sda = new SqlDataAdapter(cmd);
                                                              dt = new DataTable();
                                                              sda.Fill(dt);
                                                          }
                                                      }
                                                      else
                                                      {
                                                          query = ("select  emp_doc_id from schedule_work_doctor where swd_date_work = '" + label2.Text + "' AND swd_status_room = 1 AND schedule_work_doctor.emp_doc_id < '" + emp_doc_id + "' Group by emp_doc_id");
                                                          cmd = new SqlCommand(query, conn);
                                                          sda = new SqlDataAdapter(cmd);
                                                          dt = new DataTable();
                                                          sda.Fill(dt);
                                                          sdr = cmd.ExecuteReader();
                                                          while (sdr.Read())
                                                          {
                                                              int doc_id = sdr.GetInt32(0);
                                                              query = ("insert time_attendance (start_time,end_time,date_work,remark,status_remark,emp_ru_id,emp_doc_id) values('','','" + label2.Text + "','ยังไม่มีการเข้างาน','ขาด','','" + doc_id + "')");
                                                              cmd = new SqlCommand(query, conn);

                                                              sda = new SqlDataAdapter(cmd);
                                                              dt = new DataTable();
                                                              sda.Fill(dt);
                                                          }
                                                      }

                                                      query = ("UPDATE room SET room.room_status = 1 FROM room  INNER JOIN schedule_work_doctor ON room.room_id = schedule_work_doctor.room_id INNER JOIN employee_doctor ON employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where emp_doc_idcard = '" + textBox1.Text + "'");
                                                      cmd = new SqlCommand(query, conn);
                                                      sda = new SqlDataAdapter(cmd);
                                                      dt = new DataTable();

                                                      sda.Fill(dt);

                                                      //     query = ("Update schedule_work_doctor set swd_status_checkwork = 1 where emp_doc_id = '" + emp_doc_id + "' AND swd_date_work <= '" + label2.Text + "'");

                                                      query = ("Update schedule_work_doctor set swd_status_checkwork = 1 where  swd_date_work <= '" + label2.Text + "'");
                                                      cmd = new SqlCommand(query, conn);
                                                      sda = new SqlDataAdapter(cmd);
                                                      dt = new DataTable();

                                                      sda.Fill(dt);

                                                      lblemp.Text = emp_doc_name + "   เข้างานเรียบร้อย";
                                                      lblstatus_app.Text = "คุณมาสาย";
                                                  }
                                                  else
                                                  {
                                                      query = ("Update time_attendance set start_time = '" + label1.Text + "',end_time = '',remark = 'เข้างาน',status_remark = 'สาย' where emp_doc_id = '" + emp_doc_id + "' AND date_work = '" + label2.Text + "'");
                                                      cmd = new SqlCommand(query, conn);

                                                      sda = new SqlDataAdapter(cmd);
                                                      dt = new DataTable();
                                                      sda.Fill(dt);
                                                      query = ("UPDATE room SET room.room_status = 1 FROM room  INNER JOIN schedule_work_doctor ON room.room_id = schedule_work_doctor.room_id INNER JOIN employee_doctor ON employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where emp_doc_idcard = '" + textBox1.Text + "'");
                                                      cmd = new SqlCommand(query, conn);
                                                      sda = new SqlDataAdapter(cmd);
                                                      dt = new DataTable();

                                                      sda.Fill(dt);

                                                      //     query = ("Update schedule_work_doctor set swd_status_checkwork = 1 where emp_doc_id = '" + emp_doc_id + "' AND swd_date_work <= '" + label2.Text + "'");

                                                      query = ("Update schedule_work_doctor set swd_status_checkwork = 1 where  swd_date_work <= '" + label2.Text + "'");
                                                      cmd = new SqlCommand(query, conn);
                                                      sda = new SqlDataAdapter(cmd);
                                                      dt = new DataTable();

                                                      sda.Fill(dt);

                                                      lblemp.Text = emp_doc_name + "   เข้างานเรียบร้อย";
                                                      lblstatus_app.Text = "คุณมาสาย";
                                                  }      */
                                        }


                                    }
                                    else
                                    {
                                        MessageBox.Show("ไม่สามารถออกจากงานได้");

                                    }



                                }
                            }




                        }else if (time >= 11.30 && time <= 11.59)
                        {

                            query = ("select count(*) from schedule_work_doctor where swd_date_work = '"+label2.Text+"' AND emp_doc_id = '"+emp_doc_id+"' AND swd_start_time = '13.00'");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);
                            int swd_affternoon_count = (int)cmd.ExecuteScalar();
                            if(swd_affternoon_count < 1)
                            {

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
                                    query = ("select count(*) from time_attendance where remark = 'ออกจากงาน' AND emp_doc_id = '" + emp_doc_id + "' AND date_work = '" + label2.Text + "'");
                                    cmd = new SqlCommand(query, conn);
                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    sda.Fill(dt);

                                    int status_work_doc1 = (int)cmd.ExecuteScalar();
                                    if (status_work_doc1 < 1)
                                    {

                                        int emp_doc_id1 = Convert.ToInt32(sdr["emp_doc_id"].ToString());
                                        query = ("UPDATE time_attendance SET end_time = '" + label1.Text + "',remark = 'ออกจากงาน' where emp_doc_id = '" + emp_doc_id1 + "'");
                                        cmd = new SqlCommand(query, conn);
                                        sda = new SqlDataAdapter(cmd);
                                        dt = new DataTable();

                                        sda.Fill(dt);
                                        query = ("UPDATE room SET room.room_status = 0 FROM room  INNER JOIN schedule_work_doctor ON room.room_id = schedule_work_doctor.room_id INNER JOIN employee_doctor ON employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where emp_doc_idcard = '" + textBox1.Text + "'");
                                        cmd = new SqlCommand(query, conn);
                                        sda = new SqlDataAdapter(cmd);
                                        dt = new DataTable();

                                        sda.Fill(dt);
                                        query = ("select count(*) from schedule_work_doctor where swd_date_work = '" + label2.Text + "' AND swd_status_room = 1 AND schedule_work_doctor.emp_doc_id < '" + emp_doc_id + "' AND swd_timezone = 'เช้า'");
                                        cmd = new SqlCommand(query, conn);
                                        sda = new SqlDataAdapter(cmd);
                                        dt = new DataTable();
                                        sda.Fill(dt);

                                        int count_c = (int)cmd.ExecuteScalar();
                                        if (count_c < 1)
                                        {
                                            query = ("select  emp_doc_id from schedule_work_doctor where swd_date_work = '" + label2.Text + "' AND swd_status_room = 1 AND schedule_work_doctor.emp_doc_id > '" + emp_doc_id + "' AND swd_timezone = 'เช้า' Group by emp_doc_id");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);
                                            sdr = cmd.ExecuteReader();
                                            while (sdr.Read())
                                            {
                                                int doc_id = sdr.GetInt32(0);
                                                query = ("select count(*) from time_attendance where date_work = '" + label2.Text + "' AND emp_doc_id  = '" + doc_id + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);

                                                int count_add_check = (int)cmd.ExecuteScalar();
                                                if(count_add_check < 1)
                                                {

                                                    query = ("insert time_attendance (start_time,end_time,date_work,remark,status_remark,emp_ru_id,emp_doc_id) values('','','" + label2.Text + "','ยังไม่มีการเข้างาน','ขาด','','" + doc_id + "')");
                                                    cmd = new SqlCommand(query, conn);

                                                    sda = new SqlDataAdapter(cmd);
                                                    dt = new DataTable();
                                                    sda.Fill(dt);
                                                }
                                          

                                            }
                                        }
                                        else
                                        {
                                            query = ("select  emp_doc_id from schedule_work_doctor where swd_date_work = '" + label2.Text + "' AND swd_status_room = 1 AND schedule_work_doctor.emp_doc_id < '" + emp_doc_id + "' AND swd_timezone = 'เช้า' Group by emp_doc_id");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);
                                            sdr = cmd.ExecuteReader();
                                            while (sdr.Read())
                                            {
                                                int doc_id = sdr.GetInt32(0);
                                                query = ("select count(*) from time_attendance where date_work = '" + label2.Text + "' AND emp_doc_id  = '" + doc_id + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);

                                                int count_add_check = (int)cmd.ExecuteScalar();
                                                if (count_add_check < 1)
                                                {

                                                    query = ("insert time_attendance (start_time,end_time,date_work,remark,status_remark,emp_ru_id,emp_doc_id) values('','','" + label2.Text + "','ยังไม่มีการเข้างาน','ขาด','','" + doc_id + "')");
                                                    cmd = new SqlCommand(query, conn);

                                                    sda = new SqlDataAdapter(cmd);
                                                    dt = new DataTable();
                                                    sda.Fill(dt);
                                                }
                                            }
                                        }
                                        /*       query = ("Update schedule_work_doctor set swd_status_checkwork = 0 where emp_doc_id = '" + emp_doc_id + "' AND swd_date_work <= '" + label2.Text + "'");
                                               cmd = new SqlCommand(query, conn);
                                               sda = new SqlDataAdapter(cmd);
                                               dt = new DataTable();

                                               sda.Fill(dt);
                                               */
                                        lblemp.Text = emp_doc_name + "   ออกจากงานเรียบร้อย";
                                    }
                                    else
                                    {
                                        MessageBox.Show("มีข้อมูลการออกจากงานเรียบร้อยแล้ว");
                                    }


                                }



                            }
                            else
                            {


                                MessageBox.Show("มีการทำงานช่วงบ่าย");
                            }
             

                        }
                        else if (time >= 12.00 && time <= 16.29)
                        {
                            query = ("select count(emp_doc_id) from schedule_work_doctor where swd_status_room = 1 AND swd_date_work = '" + label2.Text + "' AND emp_doc_id = '" + emp_doc_id + "' AND swd_timezone = 'บ่าย'");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);
                            int swd_count = (int)cmd.ExecuteScalar();
                            if (swd_count < 1)
                            {
                                MessageBox.Show("ไม่สามารถเข้างานได้กรุณาตรวจสอบอีกครั้ง");
                            }
                            else
                            {
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

                                    query = ("select count(*) from time_attendance where remark = 'เข้างาน' AND emp_doc_id = '" + emp_doc_id + "' AND date_work = '" + label2.Text + "'");
                                    cmd = new SqlCommand(query, conn);
                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    sda.Fill(dt);

                                    int status_work_doc = (int)cmd.ExecuteScalar();
                                    if (status_work_doc < 1)
                                    {
                                        if (time >= 12.00 && time <= 13.00)
                                        {
                                           
                                                query = ("insert time_attendance (start_time,end_time,date_work,remark,status_remark,emp_ru_id,emp_doc_id) values('" + label1.Text + "','','" + label2.Text + "','เข้างาน','ก่อนเวลางาน','','" + emp_doc_id + "')");
                                                cmd = new SqlCommand(query, conn);

                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);
                                            
                                       
                                                query = ("UPDATE room SET room.room_status = 1 FROM room  INNER JOIN schedule_work_doctor ON room.room_id = schedule_work_doctor.room_id INNER JOIN employee_doctor ON employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where emp_doc_idcard = '" + textBox1.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();

                                                sda.Fill(dt);

                                                //     query = ("Update schedule_work_doctor set swd_status_checkwork = 1 where emp_doc_id = '" + emp_doc_id + "' AND swd_date_work <= '" + label2.Text + "'");

                                                query = ("Update schedule_work_doctor set swd_status_checkwork = 1 where  swd_date_work <= '" + label2.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();

                                                sda.Fill(dt);

                                                lblemp.Text = emp_doc_name + "   เข้างานเรียบร้อย";
                                                lblstatus_app.Text = "มาก่อนเวลา";
                                            
                                        }
                                        else
                                        {
                                        
                                                query = ("insert time_attendance (start_time,end_time,date_work,remark,status_remark,emp_ru_id,emp_doc_id) values('" + label1.Text + "','','" + label2.Text + "','เข้างาน','สาย','','" + emp_doc_id + "')");
                                                cmd = new SqlCommand(query, conn);

                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);




                                          
                                                query = ("UPDATE room SET room.room_status = 1 FROM room  INNER JOIN schedule_work_doctor ON room.room_id = schedule_work_doctor.room_id INNER JOIN employee_doctor ON employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where emp_doc_idcard = '" + textBox1.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();

                                                sda.Fill(dt);

                                                //     query = ("Update schedule_work_doctor set swd_status_checkwork = 1 where emp_doc_id = '" + emp_doc_id + "' AND swd_date_work <= '" + label2.Text + "'");

                                                query = ("Update schedule_work_doctor set swd_status_checkwork = 1 where  swd_date_work <= '" + label2.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();

                                                sda.Fill(dt);

                                                lblemp.Text = emp_doc_name + "   เข้างานเรียบร้อย";
                                                lblstatus_app.Text = "คุณมาสาย";
                                            
                                  
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("ไม่สามารถออกจากงานได้");

                                    }



                                }
                            }

                        }
                        else if (time >= 16.30 && time <= 23.59)
                        {
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
                                query = ("select count(*) from time_attendance where remark = 'ออกจากงาน' AND emp_doc_id = '" + emp_doc_id + "' AND date_work = '" + label2.Text + "'");
                                cmd = new SqlCommand(query, conn);
                                sda = new SqlDataAdapter(cmd);
                                dt = new DataTable();
                                sda.Fill(dt);

                                int status_work_doc1 = (int)cmd.ExecuteScalar();
                                if (status_work_doc1 < 1)
                                {

                                    int emp_doc_id1 = Convert.ToInt32(sdr["emp_doc_id"].ToString());
                                    query = ("UPDATE time_attendance SET end_time = '" + label1.Text + "',remark = 'ออกจากงาน' where emp_doc_id = '" + emp_doc_id1 + "'");
                                    cmd = new SqlCommand(query, conn);
                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();

                                    sda.Fill(dt);
                                    query = ("UPDATE room SET room.room_status = 0 FROM room  INNER JOIN schedule_work_doctor ON room.room_id = schedule_work_doctor.room_id INNER JOIN employee_doctor ON employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where emp_doc_idcard = '" + textBox1.Text + "'");
                                    cmd = new SqlCommand(query, conn);
                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();

                                    sda.Fill(dt);


                                    query = ("select count(*) from schedule_work_doctor where swd_date_work = '" + label2.Text + "' AND swd_status_room = 1 AND schedule_work_doctor.emp_doc_id < '" + emp_doc_id + "' AND swd_timezone = 'บ่าย'");
                                    cmd = new SqlCommand(query, conn);
                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    sda.Fill(dt);

                                    int count_c = (int)cmd.ExecuteScalar();
                                    if (count_c < 1)
                                    {
                                        query = ("select  emp_doc_id from schedule_work_doctor where swd_date_work = '" + label2.Text + "' AND swd_status_room = 1 AND schedule_work_doctor.emp_doc_id > '" + emp_doc_id + "' AND swd_timezone = 'บ่าย' Group by emp_doc_id");
                                        cmd = new SqlCommand(query, conn);
                                        sda = new SqlDataAdapter(cmd);
                                        dt = new DataTable();
                                        sda.Fill(dt);
                                        sdr = cmd.ExecuteReader();
                                        while (sdr.Read())
                                        {
                                            int doc_id = sdr.GetInt32(0);
                                            query = ("select count(*) from time_attendance where date_work = '" + label2.Text + "' AND emp_doc_id  = '" + doc_id + "'");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);

                                            int count_add_check = (int)cmd.ExecuteScalar();
                                            if (count_add_check < 1)
                                            {

                                                query = ("insert time_attendance (start_time,end_time,date_work,remark,status_remark,emp_ru_id,emp_doc_id) values('','','" + label2.Text + "','ยังไม่มีการเข้างาน','ขาด','','" + doc_id + "')");
                                                cmd = new SqlCommand(query, conn);

                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        query = ("select  emp_doc_id from schedule_work_doctor where swd_date_work = '" + label2.Text + "' AND swd_status_room = 1 AND schedule_work_doctor.emp_doc_id < '" + emp_doc_id + "' AND swd_timezone = 'บ่าย' Group by emp_doc_id");
                                        cmd = new SqlCommand(query, conn);
                                        sda = new SqlDataAdapter(cmd);
                                        dt = new DataTable();
                                        sda.Fill(dt);
                                        sdr = cmd.ExecuteReader();
                                        while (sdr.Read())
                                        {
                                            int doc_id = sdr.GetInt32(0);
                                            query = ("select count(*) from time_attendance where date_work = '" + label2.Text + "' AND emp_doc_id  = '" + doc_id + "'");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);

                                            int count_add_check = (int)cmd.ExecuteScalar();
                                            if (count_add_check < 1)
                                            {

                                                query = ("insert time_attendance (start_time,end_time,date_work,remark,status_remark,emp_ru_id,emp_doc_id) values('','','" + label2.Text + "','ยังไม่มีการเข้างาน','ขาด','','" + doc_id + "')");
                                                cmd = new SqlCommand(query, conn);

                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);
                                            }
                                        }
                                    }
                                    /*            query = ("Update schedule_work_doctor set swd_status_checkwork = 0 where emp_doc_id = '" + emp_doc_id + "' AND swd_date_work <= '" + label2.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();

                                                sda.Fill(dt);*/


                                    lblemp.Text = emp_doc_name + "   ออกจากงานเรียบร้อย";
                                }
                                else
                                {
                                    MessageBox.Show("มีข้อมูลการออกจากงานเรียบร้อยแล้ว");
                                }


                            }
                        }else
                        {
                            MessageBox.Show("ยังไม่ถึงเวลาเข้างาน");
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
                //   MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OKCancel);

                clinic_time_attendance s2 = new clinic_time_attendance();
                s2.Show();
                clinic_time_attendance clnlog = new clinic_time_attendance();
                clnlog.Close();
                Visible = false;
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
