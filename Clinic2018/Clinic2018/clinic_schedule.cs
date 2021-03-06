﻿using System;
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
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-92251HH\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
        public clinic_schedule()
        {
            InitializeComponent();
            //     label12.Text = "เลือกข้อมูลแพทย์";
            conn.Open();
            string query = ("select schedule_work_doctor.swd_id,employee_doctor.emp_doc_id,employee_doctor.emp_doc_name,specialist.emp_doc_specialist,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_date_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.room_id,schedule_work_doctor.swd_note from schedule_work_doctor inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id inner join specialist on specialist.emp_doc_specialistid = employee_doctor.emp_doc_specialistid where schedule_work_doctor.swd_status_room = 2");
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
                dataGridView1.Rows[n].Cells[3].Value = item["emp_doc_specialist"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["swd_day_work"].ToString();
                CultureInfo ThaiCulture = new CultureInfo("en-US");
                DateTime date_work = Convert.ToDateTime(item["swd_date_work"].ToString());
                string work_swd = date_work.ToString("yyyy-MM-dd", ThaiCulture);

                dataGridView1.Rows[n].Cells[5].Value = work_swd;
                dataGridView1.Rows[n].Cells[6].Value = item["swd_start_time"].ToString();
                dataGridView1.Rows[n].Cells[7].Value = item["room_id"].ToString();
                dataGridView1.Rows[n].Cells[8].Value = item["swd_note"].ToString();



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


            /*      query = ("select emp_doc_name from employee_doctor  inner join specialist on specialist.emp_doc_specialistid = employee_doctor.emp_doc_specialistid where specialist.emp_doc_specialist = '"+ txtspecialist.Text+"' ");
                  cmd = new SqlCommand(query, conn);
                  sda = new SqlDataAdapter(cmd);
                  dt = new DataTable();
                  sda.Fill(dt);

                  foreach (DataRow item in dt.Rows)
                  {
                      // int n = dataGridView1.Rows.Add();

                      comboBox1.Items.Add(item["emp_doc_name"].ToString());


                  }*/

      /*     query = ("select emp_doc_name from employee_doctor  inner join specialist on specialist.emp_doc_specialistid = employee_doctor.emp_doc_specialistid where specialist.emp_doc_specialist = '" + txtspecialist.Text + "' ORDER BY emp_doc_id DESC ");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                string emp_doc_name = sdr.GetString(0);
                // string emp_doc_name = sdr["emp_doc_name"].ToString();
                comboBox1.Items.Add(emp_doc_name);
            }*/
            /*
                        query = (" select employee_doctor.emp_doc_name from schedule_work_doctor inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id inner join specialist on specialist.emp_doc_specialistid = employee_doctor.emp_doc_specialistid where schedule_work_doctor.swd_status_room = 4 Group by employee_doctor.emp_doc_name");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);
                        sdr = cmd.ExecuteReader();
                        if (sdr.Read())
                        {

                            comboBox2.Items.Add(sdr["emp_doc_name"].ToString());

                        }else
                        {
                            comboBox2.Items.Add("");
                        }

                        // int n = dataGridView1.Rows.Add();
                        */
            conn.Close();





        }




        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
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

                  string doc_name = sdr["emp_doc_name"].ToString();
                    query = ("select schedule_work_doctor.room_id from schedule_work_doctor inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id inner join specialist on specialist.emp_doc_specialistid = employee_doctor.emp_doc_specialistid where schedule_work_doctor.swd_date_work = '" + txttime.Text + "' AND schedule_work_doctor.emp_doc_id = '" + doc_id + "'");
                    cmd = new SqlCommand(query, conn);

                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);
                    sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        int room_id = Convert.ToInt32(sdr["room_id"].ToString());
                        int room_swd = Convert.ToInt32(txtroom.Text);
                        if (room_id == room_swd)
                        {
                            if (doc_name == txtdoctorname.Text)
                            {
                                MessageBox.Show("ไม่สามารถส่งคำขอทำงานแทนได้");
                            }
                            else
                            {
                                query = ("Update schedule_work_doctor set swd_note = 'รอการอนุมัติทำงานแทน',swd_status_room = 4, swd_emp_work_place = '" + txtdoctorname.Text + "',emp_doc_id ='" + doc_id + "' where swd_id = '" + txtswd.Text + "'");
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
                        }
                        else
                        {
                            MessageBox.Show("แพทย์มีข้อมูลการทำงานแล้ว");
                        }

                    }else
                    {
                        query = ("Update schedule_work_doctor set swd_note = 'รอการอนุมัติทำงานแทน',swd_status_room = 4, swd_emp_work_place = '" + txtdoctorname.Text + "',emp_doc_id ='" + doc_id + "' where swd_id = '" + txtswd.Text + "'");
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








                }


            }
            catch (Exception)
            {
                MessageBox.Show("กรุณาเลือกข้อมูลแพทย์ที่ทำงานแทน");
            }



            conn.Close();
        }
        int selectedRow;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            txtswd.Text = row.Cells[0].Value.ToString();
            txtday.Text = row.Cells[4].Value.ToString();
            txttime.Text = row.Cells[5].Value.ToString();
            id_doc.Text = row.Cells[1].Value.ToString();
            txtspecialist.Text = row.Cells[3].Value.ToString();
            txtdoctorname.Text = row.Cells[2].Value.ToString();
            txtroom.Text = row.Cells[7].Value.ToString();
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
            /*   if (label12.Text == "" && comboBox2.SelectedItem.ToString() == "" && txtswdwork1.Text == null || txtname1.Text == null || txtday1.Text == null || txtdateswd.Text == null || txttime1.Text == null)
               {


                   MessageBox.Show("ไม่มีข้อมูลการแลกเวรปฏิบัติงาน");

               }
               else
               {*/
            try
            {
                string query = ("select count(schedule_work_doctor.swd_emp_work_place) from schedule_work_doctor inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id inner join specialist on specialist.emp_doc_specialistid = employee_doctor.emp_doc_specialistid where schedule_work_doctor.swd_status_room = 4 AND schedule_work_doctor.swd_emp_work_place = '" + txtname1.Text + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                int count = (int)cmd.ExecuteScalar();
                if (count < 1)
                {


                    query = ("select * from employee_doctor where emp_doc_name = '" + txtname1.Text + "'");
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


                        query = ("Update schedule_work_doctor set swd_note = 'เลื่อนปฏิบัติงาน',swd_status_room = 1,swd_emp_work_place = '" + txtname1.Text + "',emp_doc_id = '" + doc_id + "' where swd_id = '" + txtswdwork1.Text + "'");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);
                        query = ("select swd_id,swd_date_work from schedule_work_doctor inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where swd_note = 'ทำงานแทน' AND schedule_work_doctor.swd_emp_work_place = '"+txtname1.Text+"'");
                        cmd = new SqlCommand(query, conn);

                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);
                        sdr = cmd.ExecuteReader();
                       while (sdr.Read())
                        {
                            /*          int swd_id = Convert.ToInt32(sdr["swd_id"].ToString());
                                   DateTime date_sed = Convert.ToDateTime(sdr["swd_date_work"].ToString());
                                      string date_swd = date_sed.ToString("yyyy-MM-dd");*/
                     int swd_id = sdr.GetInt32(0);

                      DateTime date_sed = sdr.GetDateTime(1);
                         string date_swd = date_sed.ToString("yyyy-MM-dd");
                            query = ("select count(appointment.app_date) from appointment  inner join employee_doctor on employee_doctor.emp_doc_id = appointment.emp_doc_id where app_date = '" + date_swd + "' AND employee_doctor.emp_doc_name = '"+txtname1.Text+"'");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);
                            int count_app = (int)cmd.ExecuteScalar();
                            if(count_app >= 1)
                            {
                                    query = ("update appointment SET appointment.status_approve = 3,appointment.swd_id = '" + swd_id + "' from appointment inner join employee_doctor on employee_doctor.emp_doc_id = appointment.emp_doc_id where employee_doctor.emp_doc_name = '" + txtname1.Text + "' AND appointment.app_date = '"+date_swd+"'");
                                    cmd = new SqlCommand(query, conn);
                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    sda.Fill(dt);
                                    
                         //    MessageBox.Show("เลื่อน");
                            }
                            //  query = ("update appointment SET status_approve = 3 ,swd_id = '" + swd_id + "' inner join employee_doctor on employee_doctor.emp_doc_id = appointment.emp_doc_id where employee_doctor.emp_doc_name = '"+ txtname1.Text + "'");




                        }



                        MessageBox.Show("อนุมัติการเลื่อนปฏิบัติงานเรียบร้อย");
                        clinic_schedule m3 = new clinic_schedule();
                        m3.Show();
                        clinic_schedule clnlog = new clinic_schedule();
                        clnlog.Close();
                        Visible = false;



                    }








                }
                else
                {
                    MessageBox.Show("ยังไม่มีการอนุมัติการแลกตารางปฏิบัติงาน");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ยังไม่มีข้อมูลการอนุมัติการปฏิบัติงาน");
            }
                 
        
                /*
           
                */
     
            conn.Close();

            /*
            conn.Open();
            try
            {

                string name = label12.Text;
                if (label12.Text == "อนุมัตเรียบร้อยแล้ว" && comboBox2.SelectedItem.ToString() == "" && txtswdwork1.Text == null && txtname1.Text == null && txtday1.Text == null && txtdateswd.Text == null && txttime1.Text == null)
                {

                    MessageBox.Show("กรุณาเลือกแพทย์");

                }
                else
                {



                    string query = ("select count(*) from schedule_work_doctor inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id inner join specialist on specialist.emp_doc_specialistid = employee_doctor.emp_doc_specialistid where schedule_work_doctor.swd_status_room = 4 AND emp_doc_name = '" + name + "' Group by employee_doctor.emp_doc_name");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);
                    int count = (int)cmd.ExecuteScalar();
                    if (count < 1)
                    {


                        query = ("select * from employee_doctor where emp_doc_name = '" + txtname1.Text + "'");
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


                            query = ("Update schedule_work_doctor set swd_note = '',swd_status_room = 1,swd_emp_work_place = '" + txtname1.Text + "',emp_doc_id = '" + doc_id + "' where swd_id = '" + txtswdwork1.Text + "'");
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








                    }
                    else
                    {
                        MessageBox.Show("ยังไม่มีการอนุมัติการแลกตารางปฏิบัติงาน");
                    }











                }




            }
            catch (Exception)
            {
                MessageBox.Show("มีข้อผิดพลาด");
            }
     




            conn.Close();
            */

        }

        private void clinic_schedule_Load(object sender, EventArgs e)
        {
       /*     Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(1, "กรุณาเลือกข้อมูลแพทย์");

            comboBox2.DataSource = new BindingSource(comboSource, null);
            comboBox2.DisplayMember = "Value";
            comboBox2.ValueMember = "Key";
            */

        }

        private void txttime1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtspecialist_TextChanged(object sender, EventArgs e)
        {
            conn.Open();

            // string query = ("select emp_doc_name from employee_doctor  inner join specialist on specialist.emp_doc_specialistid = employee_doctor.emp_doc_specialistid where specialist.emp_doc_specialist = '" + txtspecialist.Text + "' ORDER BY emp_doc_id DESC ");
            int doc_id = Convert.ToInt32(id_doc.Text);
            comboBox1.Items.Clear();
            comboBox1.Refresh();
            string query = ("SELECT emp_doc_name FROM employee_doctor inner join specialist on specialist.emp_doc_specialistid = employee_doctor.emp_doc_specialistid  WHERE specialist.emp_doc_specialist = '"+txtspecialist.Text+"' AND emp_doc_id IN(SELECT emp_doc_id FROM employee_doctor WHERE emp_doc_id < '"+id_doc.Text+"' OR emp_doc_id > '"+ id_doc.Text + "' AND specialist.emp_doc_specialist = '"+txtspecialist.Text+"')");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                string name = sdr.GetString(0);
                // string emp_doc_name = sdr["emp_doc_name"].ToString();
                comboBox1.Items.Add(name);
            }
            /*
           string query = ("select emp_doc_name from employee_doctor  inner join specialist on specialist.emp_doc_specialistid = employee_doctor.emp_doc_specialistid where specialist.emp_doc_specialist = '" + txtspecialist.Text + "' ORDER BY emp_doc_id DESC ");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                // int n = dataGridView1.Rows.Add();
                string name = sdr["emp_doc_name"].ToString();
                query = ("select emp_doc_name from employee_doctor where emp_doc_name = '" + name + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                       string emp_doc_name = sdr.GetString(0);
                   // string emp_doc_name = sdr["emp_doc_name"].ToString();
                   comboBox1.Items.Add(emp_doc_name);
                }


            }

            */

            conn.Close();
        }
        /*
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            string name_doctor = comboBox2.SelectedItem.ToString();
            string query = ("select employee_doctor.emp_doc_name from schedule_work_doctor inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id inner join specialist on specialist.emp_doc_specialistid = employee_doctor.emp_doc_specialistid where schedule_work_doctor.swd_status_room = 4 AND emp_doc_name = '" + name_doctor + "' Group by employee_doctor.emp_doc_name");
            cmd = new SqlCommand(query, conn);

            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {

                label12.Text = (sdr["emp_doc_name"].ToString());








            }else
            {
         //       label12.Text ="อนุมัตเรียบร้อยแล้ว";
            }

            conn.Close();
        }
        */
        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtdoctorname_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
