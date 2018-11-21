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
    public partial class clinic_schedule_now : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-92251HH\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;

        public clinic_schedule_now()
        {
            InitializeComponent();
            conn.Open();
            string query = ("select schedule_work_doctor.swd_id,employee_doctor.emp_doc_id,employee_doctor.emp_doc_name,specialist.emp_doc_specialist,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_date_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.room_id,schedule_work_doctor.swd_note from schedule_work_doctor inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id inner join specialist on specialist.emp_doc_specialistid = employee_doctor.emp_doc_specialistid where schedule_work_doctor.swd_status_room = 8");
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
                dataGridView2.Rows[n].Cells[3].Value = item["emp_doc_specialist"].ToString();
                dataGridView2.Rows[n].Cells[4].Value = item["swd_day_work"].ToString();
                CultureInfo ThaiCulture = new CultureInfo("en-US");
                DateTime date_work = Convert.ToDateTime(item["swd_date_work"].ToString());
                string work_swd = date_work.ToString("yyyy-MM-dd", ThaiCulture);

                dataGridView2.Rows[n].Cells[5].Value = work_swd;
                dataGridView2.Rows[n].Cells[6].Value = item["swd_start_time"].ToString();
                dataGridView2.Rows[n].Cells[7].Value = item["room_id"].ToString();
                dataGridView2.Rows[n].Cells[8].Value = item["swd_note"].ToString();



            }





            conn.Close();
        }


        private void clinic_schedule_now_Load(object sender, EventArgs e)
        {
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            CultureInfo ThaiCulture = new CultureInfo("th-TH");
            DateTime date = Convert.ToDateTime(dateTimePicker2.Text);
            string date_th = date.ToString("yyyy-MM-dd", ThaiCulture);
            DateTime today = DateTime.Now;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            if (today.Date <= date.Date)
            {
                string query = ("select employee_doctor.emp_doc_name , schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_date_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.room_id,schedule_work_doctor.swd_id from schedule_work_doctor inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where schedule_work_doctor.swd_status_room = 1 AND schedule_work_doctor.swd_date_work = '" + date_th + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();


                    dataGridView1.Rows[n].Cells[0].Value = item["swd_id"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item["emp_doc_name"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item["swd_day_work"].ToString();

                    DateTime date1 = Convert.ToDateTime(item["swd_date_work"].ToString());
                    string date_swd = date1.ToString("yyyy-MM-dd");
                    dataGridView1.Rows[n].Cells[3].Value = date_swd;

                    dataGridView1.Rows[n].Cells[4].Value = item["swd_start_time"].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = item["room_id"].ToString();




                }
            }
            // MessageBox.Show(date_th);
        }


        int selectedRow;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                txtswd.Text = row.Cells[0].Value.ToString();
                txtnamedoc.Text = row.Cells[1].Value.ToString();

            }
            catch (Exception)
            {

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                if (txtswd.Text == "" && txtnamedoc.Text == "")
                {
                    MessageBox.Show("ยังไม่มีข้อมูลการทำงานแทน");
                }
                else
                {
                    string query = ("select count(*) from schedule_work_doctor where swd_note = 'รอการทำงานแทน' AND swd_id = '" + txtswd.Text + "'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);
                    int count = (int)cmd.ExecuteScalar();
                    if (count < 1)
                    {
                        query = ("Update schedule_work_doctor set swd_note = 'รอการทำงานแทน',swd_status_room = 8,swd_emp_work_place = '" + txtnamedoc.Text + "' where swd_id = '" + txtswd.Text + "'");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);
                        clinic_schedule_now doc1 = new clinic_schedule_now();
                        doc1.Show();
                        clinic_schedule_now clnlog = new clinic_schedule_now();
                        clnlog.Close();
                        Visible = false;
                    }

                }
                conn.Close();
            }
            catch (Exception)
            {

            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                CultureInfo ThaiCulture = new CultureInfo("th-TH");
                DateTime date = Convert.ToDateTime(dateTimePicker1.Text);
                string date_th = date.ToString("yyyy-MM-dd", ThaiCulture);
                DateTime today = DateTime.Now;
                dataGridView3.Rows.Clear();
                dataGridView3.Refresh();
                if (today.Date <= date.Date)
                {
                    string query = ("select swd_month_work, swd_day_work,swd_date_work, swd_start_time, swd_end_time,room_id from schedule_work_doctor where swd_status_room = 0 AND swd_date_work = '" + date_th + "'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);

                    foreach (DataRow item in dt.Rows)
                    {
                        int n = dataGridView3.Rows.Add();

                        dataGridView3.Rows[n].Cells[0].Value = item["swd_month_work"].ToString();
                        dataGridView3.Rows[n].Cells[1].Value = item["swd_day_work"].ToString();
                        DateTime date1 = Convert.ToDateTime(item["swd_date_work"].ToString());
                        string date_swd = date1.ToString("yyyy-MM-dd");
                        dataGridView3.Rows[n].Cells[2].Value = date_swd;
                        dataGridView3.Rows[n].Cells[3].Value = item["swd_start_time"].ToString();

                        dataGridView3.Rows[n].Cells[4].Value = item["swd_end_time"].ToString();

                        dataGridView3.Rows[n].Cells[5].Value = item["room_id"].ToString();




                    }
                }
            }
            catch (Exception)
            {

            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView2.Rows[selectedRow];
            textBox1.Text = row.Cells[0].Value.ToString();
            txtday.Text = row.Cells[4].Value.ToString();
            txttime.Text = row.Cells[5].Value.ToString();
            txt_time.Text = row.Cells[6].Value.ToString();
            id_doc.Text = row.Cells[1].Value.ToString();
            txtspecialist.Text = row.Cells[3].Value.ToString();
            txtdoctorname.Text = row.Cells[2].Value.ToString();
        }

        private void txtspecialist_TextChanged(object sender, EventArgs e)
        {
            conn.Open();

            // string query = ("select emp_doc_name from employee_doctor  inner join specialist on specialist.emp_doc_specialistid = employee_doctor.emp_doc_specialistid where specialist.emp_doc_specialist = '" + txtspecialist.Text + "' ORDER BY emp_doc_id DESC ");
            int doc_id = Convert.ToInt32(id_doc.Text);

            string query = ("SELECT emp_doc_name FROM employee_doctor inner join specialist on specialist.emp_doc_specialistid = employee_doctor.emp_doc_specialistid  WHERE specialist.emp_doc_specialist = '" + txtspecialist.Text + "' AND emp_doc_id IN(SELECT emp_doc_id FROM employee_doctor WHERE emp_doc_id < '" + id_doc.Text + "' OR emp_doc_id > '" + id_doc.Text + "' AND specialist.emp_doc_specialist = '" + txtspecialist.Text + "')");
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

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                conn.Open();

               string  query = ("SELECT COUNT(*) from schedule_work_doctor where swd_date_work = '"+txtdatenext.Text+"' AND swd_note = 'รอการทำงานแทน' AND emp_doc_id = '"+id_doc.Text+"'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                int count_swd_next_change = (int)cmd.ExecuteScalar();
                if (count_swd_next_change == 1)
                {
                    MessageBox.Show("มีแพทย์ทำงานในห้องตรวจแล้ว");
                }else
                {
                   // MessageBox.Show("มีแพทย์ทำงานในห้องตรวจแล้วppppp");
           
                    query = ("select * from employee_doctor where emp_doc_name = '" + comboBox1.SelectedItem.ToString() + "'");
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
                        if (doc_name == txtdoctorname.Text)
                        {
                            MessageBox.Show("ไม่สามารถส่งคำขอทำงานแทนได้");
                        }
                        else
                        {
                            if (txtdatenext.Text == "" && txttimenext.Text == "")
                            {


                                MessageBox.Show("กรุณาเลือกวันเลื่อนปฏิบัติงาน");



                            }
                            else
                            {
                                query = ("select swd_id from schedule_work_doctor where swd_date_work = '" + txtdatenext.Text + "'");
                                cmd = new SqlCommand(query, conn);

                                sda = new SqlDataAdapter(cmd);
                                dt = new DataTable();
                                sdr = cmd.ExecuteReader();
                                if (sdr.Read())
                                {
                                    int swdid = Convert.ToInt32(sdr["swd_id"].ToString());
                                    query = ("select swd_start_time,swd_status_room, room_id  from schedule_work_doctor where swd_date_work = '" + txtdatenext.Text + "' AND swd_status_room = 0 AND swd_start_time = '" + txttimenext.Text + "'");
                                    cmd = new SqlCommand(query, conn);

                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    sdr = cmd.ExecuteReader();
                                    if (sdr.Read())
                                    {
                                        int room_id = Convert.ToInt32(sdr["room_id"].ToString());
                                        int status_room = Convert.ToInt32(sdr["swd_status_room"].ToString());
                                        string time = sdr["swd_start_time"].ToString();
                                        query = ("select swd_start_time,swd_status_room, room_id ,emp_doc_id from schedule_work_doctor where swd_status_room = 1  AND  swd_date_work = '" + txtdatenext.Text + "' AND emp_doc_id = '" + id_doc.Text + "'");
                                        cmd = new SqlCommand(query, conn);

                                        sda = new SqlDataAdapter(cmd);
                                        dt = new DataTable();
                                        sdr = cmd.ExecuteReader();
                                        if (sdr.Read())
                                        {
                                            int roomiddoc = Convert.ToInt32(sdr["room_id"].ToString());
                                            int docid = Convert.ToInt32(sdr["emp_doc_id"].ToString());
                                            query = ("SELECT COUNT(*) from schedule_work_doctor where swd_status_room = 1  AND room_id = '" + roomiddoc + "' AND swd_date_work = '" + txtdatenext.Text + "'");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);
                                            int count = (int)cmd.ExecuteScalar();
                                            if (count == 2)
                                            {
                                                MessageBox.Show("มีแพทย์ทำงานห้องตรวจแล้ว");
                                            }
                                            else
                                            {
                                                query = ("select swd_id,swd_date_work from schedule_work_doctor inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where swd_note = 'รอการทำงานแทน' AND schedule_work_doctor.swd_emp_work_place = '" + txtdoctorname.Text + "'");
                                                cmd = new SqlCommand(query, conn);

                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);
                                                sdr = cmd.ExecuteReader();
                                                if (sdr.Read())
                                                {
                                                    int swd_id = Convert.ToInt32(sdr["swd_id"].ToString());
                                                    DateTime date_sed = Convert.ToDateTime(sdr["swd_date_work"].ToString());
                                                    string date_swd = date_sed.ToString("yyyy-MM-dd");

                                                    query = ("select count(appointment.app_date) from appointment  inner join employee_doctor on employee_doctor.emp_doc_id = appointment.emp_doc_id where app_date = '" + date_swd + "' AND employee_doctor.emp_doc_name = '" + txtdoctorname.Text + "'");
                                                    cmd = new SqlCommand(query, conn);
                                                    sda = new SqlDataAdapter(cmd);
                                                    dt = new DataTable();
                                                    sda.Fill(dt);
                                                    int count_app = (int)cmd.ExecuteScalar();
                                                    if (count_app >= 1)
                                                    {
                                                        query = ("update appointment SET appointment.status_approve = 3,appointment.swd_id = '" + swd_id + "' from appointment inner join employee_doctor on employee_doctor.emp_doc_id = appointment.emp_doc_id where employee_doctor.emp_doc_name = '" + txtdoctorname.Text + "'");
                                                        cmd = new SqlCommand(query, conn);
                                                        sda = new SqlDataAdapter(cmd);
                                                        dt = new DataTable();
                                                        sda.Fill(dt);

                                                        //    MessageBox.Show("เลื่อน");
                                                    }
                                                }


                                                query = ("Update schedule_work_doctor set swd_note = 'ทำงานแทน',swd_status_room = 1, swd_emp_work_place = '" + txtdoctorname.Text + "',emp_doc_id ='" + doc_id + "' where swd_id = '" + textBox1.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);
                                                query = ("Update schedule_work_doctor set swd_note = 'เลื่อนปฏิบัติงาน',swd_status_room = 1, swd_emp_work_place = '" + txtdoctorname.Text + "',emp_doc_id = '" + id_doc.Text + "' where room_id = '" + roomiddoc + "' AND swd_start_time = '" + txttimenext.Text + "' AND swd_date_work = '" + txtdatenext.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);
                                                MessageBox.Show("เลื่อนปฏิบัติงาน1");

                                                clinic_schedule_now m3 = new clinic_schedule_now();
                                                m3.Show();
                                                clinic_schedule_now clnlog = new clinic_schedule_now();
                                                clnlog.Close();
                                                Visible = false;
                                            }
                                        }
                                        else
                                        {
                                            query = ("select swd_id,swd_date_work from schedule_work_doctor inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where swd_note = 'รอการทำงานแทน' AND schedule_work_doctor.swd_emp_work_place = '" + txtdoctorname.Text + "'");
                                            cmd = new SqlCommand(query, conn);

                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);
                                            sdr = cmd.ExecuteReader();
                                            if (sdr.Read())
                                            {
                                                int swd_id = Convert.ToInt32(sdr["swd_id"].ToString());
                                                DateTime date_sed = Convert.ToDateTime(sdr["swd_date_work"].ToString());
                                                string date_swd = date_sed.ToString("yyyy-MM-dd");

                                                query = ("select count(appointment.app_date) from appointment  inner join employee_doctor on employee_doctor.emp_doc_id = appointment.emp_doc_id where app_date = '" + date_swd + "' AND employee_doctor.emp_doc_name = '" + txtdoctorname.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);
                                                int count_app = (int)cmd.ExecuteScalar();
                                                if (count_app >= 1)
                                                {
                                                    query = ("update appointment SET appointment.status_approve = 3,appointment.swd_id = '" + swd_id + "' from appointment inner join employee_doctor on employee_doctor.emp_doc_id = appointment.emp_doc_id where employee_doctor.emp_doc_name = '" + txtdoctorname.Text + "'");
                                                    cmd = new SqlCommand(query, conn);
                                                    sda = new SqlDataAdapter(cmd);
                                                    dt = new DataTable();
                                                    sda.Fill(dt);

                                                    //    MessageBox.Show("เลื่อน");
                                                }
                                            }


                                            query = ("Update schedule_work_doctor set swd_note = 'ทำงานแทน',swd_status_room = 1, swd_emp_work_place = '" + txtdoctorname.Text + "',emp_doc_id ='" + doc_id + "' where swd_id = '" + textBox1.Text + "'");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);
                                            query = ("Update schedule_work_doctor set swd_note = 'เลื่อนปฏิบัติงาน',swd_status_room = 1, swd_emp_work_place = '" + txtdoctorname.Text + "',emp_doc_id = '" + id_doc.Text + "' where room_id = '" + room_id + "' AND swd_start_time = '" + txttimenext.Text + "' AND swd_date_work = '" + txtdatenext.Text + "'");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);
                                            MessageBox.Show("เลื่อนปฏิบัติงาน1");

                                            clinic_schedule_now m3 = new clinic_schedule_now();
                                            m3.Show();
                                            clinic_schedule_now clnlog = new clinic_schedule_now();
                                            clnlog.Close();
                                            Visible = false;
                                        }
                                    }

                                }


                            }
                        }
                    }
                    
                }
             
               
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("กรุณาเลือกแพทย์ทำงานแทน");
            }




        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView3.Rows[selectedRow];
            txtdatenext.Text = row.Cells[2].Value.ToString();
            txttimenext.Text = row.Cells[3].Value.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txttimenext_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdatenext_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdoc_name_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
