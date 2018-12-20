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
    public partial class clinic_schedule_now_today : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-92251HH\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
        public clinic_schedule_now_today()
        {
            InitializeComponent();
        }

        private void clinic_schedule_now_today_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("yyyy-MM-dd", new CultureInfo("th-TH"));

        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            string query = ("select schedule_work_doctor.swd_id,employee_doctor.emp_doc_id,employee_doctor.emp_doc_name,specialist.emp_doc_specialist,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_date_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.room_id,schedule_work_doctor.swd_note from schedule_work_doctor inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id inner join specialist on specialist.emp_doc_specialistid = employee_doctor.emp_doc_specialistid where schedule_work_doctor.swd_date_work = '"+label1.Text+"'");
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
       
            //     comboBox1.Refresh();
        }

        private void txtspecialist_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                int doc_id = Convert.ToInt32(id_doc.Text);


                string query = ("SELECT emp_doc_name FROM employee_doctor inner join specialist on specialist.emp_doc_specialistid = employee_doctor.emp_doc_specialistid  WHERE specialist.emp_doc_specialist = '" + txtspecialist.Text + "' AND emp_doc_id IN(SELECT emp_doc_id FROM employee_doctor WHERE emp_doc_id < '" + id_doc.Text + "' OR emp_doc_id > '" + id_doc.Text + "' AND specialist.emp_doc_specialist = '" + txtspecialist.Text + "')");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                  //  dataGridView1.Rows.Clear();
                 //   dataGridView1.Refresh();
                    string name = sdr.GetString(0);
                    // string emp_doc_name = sdr["emp_doc_name"].ToString();
                    comboBox1.Items.Add(name);
                  //  comboBox1.Refresh();

                }

            }
            catch (Exception)
            {
             //   comboBox1.Refresh();
            }

            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
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
                    int doc_id = Convert.ToInt32(sdr["emp_doc_id"].ToString());
           
                    query = ("select schedule_work_doctor.room_id from schedule_work_doctor inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id inner join specialist on specialist.emp_doc_specialistid = employee_doctor.emp_doc_specialistid where schedule_work_doctor.swd_date_work = '" + txttime.Text + "' AND schedule_work_doctor.emp_doc_id = '" + doc_id + "'");
                    cmd = new SqlCommand(query, conn);

                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);
                    sdr = cmd.ExecuteReader();
                    if(sdr.Read())
                    {
                        int room_id = Convert.ToInt32(sdr["room_id"].ToString());
                        int room_swd = Convert.ToInt32(txtroom.Text);

                        if (room_id == room_swd)
                        {



                                query = ("Update schedule_work_doctor set swd_note = 'ทำงานแทน',swd_status_room = 1,swd_emp_work_place = '" + txtdoctorname.Text + "',emp_doc_id = '"+doc_id+"' where swd_id = '" + txtswd.Text + "'");
                                     cmd = new SqlCommand(query, conn);
                                     sda = new SqlDataAdapter(cmd);
                                     dt = new DataTable();
                                     sda.Fill(dt);

                            query = ("select swd_id,swd_date_work from schedule_work_doctor inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where swd_note = 'ทำงานแทน' AND schedule_work_doctor.swd_emp_work_place = '" + txtdoctorname.Text + "'");
                            cmd = new SqlCommand(query, conn);

                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);
                            sdr = cmd.ExecuteReader();
                            while (sdr.Read())
                            {
                                int swd_id = sdr.GetInt32(0);
                                DateTime date_sed = sdr.GetDateTime(1);
                                string date_swd = date_sed.ToString("yyyy-MM-dd");
                                query = ("select count(appointment.app_date) from appointment  inner join employee_doctor on employee_doctor.emp_doc_id = appointment.emp_doc_id where app_date = '" + date_swd + "' AND employee_doctor.emp_doc_name = '" + txtdoctorname.Text + "'");
                                cmd = new SqlCommand(query, conn);
                                sda = new SqlDataAdapter(cmd);
                                dt = new DataTable();
                                sda.Fill(dt);
                                int count_app = (int)cmd.ExecuteScalar();
                                if (count_app >= 1)
                                {

                                    query = ("update appointment SET appointment.status_approve = 6,appointment.swd_id = '" + swd_id + "' from appointment inner join employee_doctor on employee_doctor.emp_doc_id = appointment.emp_doc_id where employee_doctor.emp_doc_name = '" + txtdoctorname.Text + "' AND appointment.app_date = '" + date_swd + "'");
                                    cmd = new SqlCommand(query, conn);
                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    sda.Fill(dt);


                                    clinic_schedule_now_today doc2 = new clinic_schedule_now_today();
                                    doc2.Show();
                                    clinic_schedule_now_today clnlog11 = new clinic_schedule_now_today();
                                    clnlog11.Close();
                                    Visible = false;
                                }
                            }

                            clinic_schedule_now_today doc11 = new clinic_schedule_now_today();
                            doc11.Show();
                            clinic_schedule_now_today clnlog1 = new clinic_schedule_now_today();
                            clnlog1.Close();
                            Visible = false;
                          //  MessageBox.Show(" " + room_id);

                        }
                        else
                        {
                            MessageBox.Show("แพทย์มีข้อมูลการทำงานแล้ว");
                        }

                    }else
                    {

                        query = ("Update schedule_work_doctor set swd_note = 'ทำงานแทน',swd_status_room = 1,swd_emp_work_place = '" + txtdoctorname.Text + "',emp_doc_id = '" + doc_id + "' where swd_id = '" + txtswd.Text + "'");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);


                        query = ("select swd_id,swd_date_work from schedule_work_doctor inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where swd_note = 'ทำงานแทน' AND schedule_work_doctor.swd_emp_work_place = '" + txtdoctorname.Text + "'");
                        cmd = new SqlCommand(query, conn);

                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);
                        sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            int swd_id = sdr.GetInt32(0);
                            DateTime date_sed = sdr.GetDateTime(1);
                            string date_swd = date_sed.ToString("yyyy-MM-dd");
                            query = ("select count(appointment.app_date) from appointment  inner join employee_doctor on employee_doctor.emp_doc_id = appointment.emp_doc_id where app_date = '" + date_swd + "' AND employee_doctor.emp_doc_name = '" + txtdoctorname.Text + "'");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);
                            int count_app = (int)cmd.ExecuteScalar();
                            if (count_app >= 1)
                            {

                             query = ("update appointment SET appointment.status_approve = 6,appointment.swd_id = '" + swd_id + "' from appointment inner join employee_doctor on employee_doctor.emp_doc_id = appointment.emp_doc_id where employee_doctor.emp_doc_name = '" + txtdoctorname.Text + "' AND appointment.app_date = '" + date_swd + "'");
                                       cmd = new SqlCommand(query, conn);
                                       sda = new SqlDataAdapter(cmd);
                                       dt = new DataTable();
                                       sda.Fill(dt);
               

                                clinic_schedule_now_today doc2 = new clinic_schedule_now_today();
                                doc2.Show();
                                clinic_schedule_now_today clnlog1 = new clinic_schedule_now_today();
                                clnlog1.Close();
                                Visible = false;
                            }
                        }
                     


                        clinic_schedule_now_today doc1 = new clinic_schedule_now_today();
                        doc1.Show();
                        clinic_schedule_now_today clnlog = new clinic_schedule_now_today();
                        clnlog.Close();
                        Visible = false;
                    }

                }




                conn.Close();
            }catch(Exception)
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
