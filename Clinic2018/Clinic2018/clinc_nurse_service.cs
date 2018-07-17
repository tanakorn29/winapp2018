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
            query = ("select visit_record.vr_id,visit_record.vr_weight,visit_record.vr_height,visit_record.vr_systolic,visit_record.vr_diastolic,visit_record.vr_hearth_rate,visit_record.vr_date,visit_record.vr_remark,visit_record.opd_id,opd.opd_name from visit_record inner join opd on visit_record.opd_id = opd.opd_id where vr_status = 0");
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
                dataGridView3.Rows[n].Cells[7].Value = item["opd_id"].ToString();
                dataGridView3.Rows[n].Cells[8].Value = item["opd_name"].ToString();
                dataGridView3.Rows[n].Cells[9].Value = item["vr_remark"].ToString();



            }
            conn.Close();
        }

        int selectedRow;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
 
            /*
            int queue = Convert.ToInt32(row.Cells[0].Value.ToString());

            conn.Open();

            string query = ("select queue_visit_record.qvr_status from queue_visit_record inner join opd on opd.opd_id = queue_visit_record.opd_id where queue_visit_record.qvr_record = 1");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {

                int status = Convert.ToInt32(sdr["qvr_status"].ToString());
                if(status >= 1 || status != 1)
                {
                    lblidcard.Text = row.Cells[3].Value.ToString();
                    lblsername.Text = row.Cells[2].Value.ToString();
                    lblopd.Text = row.Cells[4].Value.ToString();
                    MessageBox.Show("test1");
                }else
                {
                    MessageBox.Show("test2");
                }


            }




                conn.Close();
            */



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
            string query = ("select queue_visit_record.qvr_record from queue_visit_record inner join opd on opd.opd_id = queue_visit_record.opd_id where queue_visit_record.qvr_status = 1");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                int queue = Convert.ToInt32(sdr["qvr_record"].ToString());

                label12.Text = "" + queue;
            }

            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();

            query = ("select symtoms_dis from symtoms where symtoms_dis LIKE '%" + textBox1.Text + "%'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                string test = sdr.GetString(0);

                MyCollection.Add(test);
            }
           textBox1.AutoCompleteCustomSource = MyCollection;
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
            conn.Open();
            string query = ("select count(*) from symtoms where symtoms_dis LIKE'%"+ textBox1.Text+"%'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            int sym_data_count = (int)cmd.ExecuteScalar();
             if(sym_data_count < 1)
            {
                query = ("insert into visit_record (vr_weight,vr_height,vr_systolic,vr_diastolic,vr_hearth_rate,vr_date,vr_status,vr_remark,opd_id) values ('" + txtw.Text + "','" + txth.Text + "','" + txts1.Text + "','" + txts2.Text + "','" + txthearth.Text + "',SYSDATETIME(),0,'" + textBox1.Text + "'," + lblopd.Text + ");");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                query = ("Update queue_visit_record set qvr_status = 0 where opd_id = '" + lblopd.Text + "'");

                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                query = ("insert into symtoms (symtoms_dis) values ('"+ textBox1.Text+"');");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                
            }
            else
            {
                query = ("insert into visit_record (vr_weight,vr_height,vr_systolic,vr_diastolic,vr_hearth_rate,vr_date,vr_status,vr_remark,opd_id) values ('" + txtw.Text + "','" + txth.Text + "','" + txts1.Text + "','" + txts2.Text + "','" + txthearth.Text + "',SYSDATETIME(),0,'" + textBox1.Text + "'," + lblopd.Text + ");");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                query = ("Update queue_visit_record set qvr_status = 0 where opd_id = '" + lblopd.Text + "'");

                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);





   
            }

            conn.Close();

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
            string timezone = lbltimezone.Text;
            string today = DateTime.Now.ToString("yyyy-MM-dd", new CultureInfo("th-TH"));
            if (timezone == "เช้า")
            {

                string query = ("select specialist.emp_doc_specialistid from employee_doctor empdoc inner join specialist on specialist.emp_doc_specialistid = empdoc.emp_doc_specialistid inner join schedule_work_doctor on schedule_work_doctor.emp_doc_id = empdoc.emp_doc_id inner join room on room.room_id = schedule_work_doctor.room_id inner join time_attendance on time_attendance.emp_doc_id = empdoc.emp_doc_id where swd_status_room = 1 AND room.room_status = 1 AND swd_day_work = '" + lblday.Text + "' AND remark = 'เข้างาน' AND swd_timezone = 'เช้า' AND swd_date_work = '" + today + "' AND swd_id = '" + lblswd.Text + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {

                    int id = Convert.ToInt32(sdr["emp_doc_specialistid"].ToString());
                    //   MessageBox.Show("" + id);
                    query = ("select count(*) from symtoms where emp_doc_specialistid LIKE'%" + id + "%'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);

                    int sym_data_count = (int)cmd.ExecuteScalar();
                    if (sym_data_count < 1)
                    {

                        query = ("insert into queue_diag_room(qdr_date,qdr_time_sent,status_queue,swd_id,opd_id)values (SYSDATETIME(), SYSDATETIME(),1,'" + lblswd.Text + "','" + lblopdid.Text + "');");
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
                                clinc_nurse_service clnlog = new clinc_nurse_service();
                                clnlog.Close();
                                Visible = false;



                                MessageBox.Show("ส่งเข้าห้องตรวจเรียบร้อย   คุณคิวที่    " + value);

                            }
                            else
                            {
                                MessageBox.Show("คิวห้องตรวจเต็ม");
                            }

                        }



                    }
                    else
                    {


                        query = ("insert into queue_diag_room(qdr_date,qdr_time_sent,status_queue,swd_id,opd_id)values (SYSDATETIME(), SYSDATETIME(),1,'" + lblswd.Text + "','" + lblopdid.Text + "');");
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
                                query = ("select vr_remark from visit_record where opd_id = '" + lblopdid.Text + "' ORDER BY vr_date ASC");
                                cmd = new SqlCommand(query, conn);
                                sda = new SqlDataAdapter(cmd);
                                dt = new DataTable();
                                sda.Fill(dt);
                                sdr = cmd.ExecuteReader();
                                if (sdr.Read())
                                {


                                    string remark = sdr["vr_remark"].ToString();


                                    query = ("Update symtoms set emp_doc_specialistid = '" + id + "' where symtoms_dis = '" + remark + "' ");
                                    //  
                                    cmd = new SqlCommand(query, conn);
                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    sda.Fill(dt);

                                    //   MessageBox.Show(remark + "  "  + id);


                                }

                                clinc_nurse_service s2 = new clinc_nurse_service();
                                s2.Show();
                                clinc_nurse_service clnlog = new clinc_nurse_service();
                                clnlog.Close();
                                Visible = false;



                                MessageBox.Show("ส่งเข้าห้องตรวจเรียบร้อย   คุณคิวที่    " + value);

                            }
                            else
                            {
                                MessageBox.Show("คิวห้องตรวจเต็ม");
                            }

                        }
                    }

                }

            }
            else if (timezone == "บ่าย")
            {

               string query = ("select specialist.emp_doc_specialistid from employee_doctor empdoc inner join specialist on specialist.emp_doc_specialistid = empdoc.emp_doc_specialistid inner join schedule_work_doctor on schedule_work_doctor.emp_doc_id = empdoc.emp_doc_id inner join room on room.room_id = schedule_work_doctor.room_id inner join time_attendance on time_attendance.emp_doc_id = empdoc.emp_doc_id where swd_status_room = 1 AND room.room_status = 1 AND swd_day_work = '" + lblday.Text + "' AND remark = 'เข้างาน' AND swd_timezone = 'บ่าย' AND swd_date_work = '" + today + "' AND swd_id = '" + lblswd.Text + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {

                    int id = Convert.ToInt32(sdr["emp_doc_specialistid"].ToString());
                    //   MessageBox.Show("" + id);
                    query = ("select count(*) from symtoms where emp_doc_specialistid LIKE'%" + id + "%'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);

                    int sym_data_count = (int)cmd.ExecuteScalar();
                    if (sym_data_count < 1)
                    {

                        query = ("insert into queue_diag_room(qdr_date,qdr_time_sent,status_queue,swd_id,opd_id)values (SYSDATETIME(), SYSDATETIME(),1,'" + lblswd.Text + "','" + lblopdid.Text + "');");
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
                                clinc_nurse_service clnlog = new clinc_nurse_service();
                                clnlog.Close();
                                Visible = false;



                                MessageBox.Show("ส่งเข้าห้องตรวจเรียบร้อย   คุณคิวที่    " + value);

                            }
                            else
                            {
                                MessageBox.Show("คิวห้องตรวจเต็ม");
                            }

                        }



                    }
                    else
                    {


                        query = ("insert into queue_diag_room(qdr_date,qdr_time_sent,status_queue,swd_id,opd_id)values (SYSDATETIME(), SYSDATETIME(),1,'" + lblswd.Text + "','" + lblopdid.Text + "');");
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
                                query = ("select vr_remark from visit_record where opd_id = '" + lblopdid.Text + "' ORDER BY vr_date ASC");
                                cmd = new SqlCommand(query, conn);
                                sda = new SqlDataAdapter(cmd);
                                dt = new DataTable();
                                sda.Fill(dt);
                                sdr = cmd.ExecuteReader();
                                if (sdr.Read())
                                {


                                    string remark = sdr["vr_remark"].ToString();


                                    query = ("Update symtoms set emp_doc_specialistid = '" + id + "' where symtoms_dis = '" + remark + "' ");
                                    //  
                                    cmd = new SqlCommand(query, conn);
                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    sda.Fill(dt);

                                    //   MessageBox.Show(remark + "  "  + id);


                                }

                                clinc_nurse_service s2 = new clinc_nurse_service();
                                s2.Show();
                                clinc_nurse_service clnlog = new clinc_nurse_service();
                                clnlog.Close();
                                Visible = false;



                                MessageBox.Show("ส่งเข้าห้องตรวจเรียบร้อย   คุณคิวที่    " + value);

                            }
                            else
                            {
                                MessageBox.Show("คิวห้องตรวจเต็ม");
                            }

                        }
                    }

                }

            }
            conn.Close();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView3.Rows[selectedRow];
            lblopdid.Text = row.Cells[7].Value.ToString();
            string remark = row.Cells[9].Value.ToString();
         //   string remark = "อุจจาระเป็นเลือด";
        

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView2.Rows[selectedRow];
            lblswd.Text = row.Cells[0].Value.ToString();
            lbldocname.Text = row.Cells[1].Value.ToString();
            lblroom.Text = row.Cells[6].Value.ToString();

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
          

                string query = ("select schedule_work_doctor.swd_id,empdoc.emp_doc_name,specialist.emp_doc_specialist,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.swd_end_time,schedule_work_doctor.room_id from employee_doctor empdoc inner join specialist on specialist.emp_doc_specialistid = empdoc.emp_doc_specialistid inner join schedule_work_doctor on schedule_work_doctor.emp_doc_id  = empdoc.emp_doc_id inner join room on room.room_id = schedule_work_doctor.room_id inner join time_attendance on time_attendance.emp_doc_id = empdoc.emp_doc_id where swd_status_room = 1 AND room.room_status = 1 AND swd_day_work = '" + lblday.Text + "' AND remark = 'เข้างาน' AND swd_timezone = 'เช้า' AND swd_date_work = '"+today+"'");
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
                  
                    dataGridView2.Rows[n].Cells[6].Value = item["room_id"].ToString();

                }
            }
            else if (timezone == "บ่าย")
            {
     
                                   string query = ("select schedule_work_doctor.swd_id,empdoc.emp_doc_name,specialist.emp_doc_specialist,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.swd_end_time,schedule_work_doctor.room_id from employee_doctor empdoc inner join specialist on specialist.emp_doc_specialistid = empdoc.emp_doc_specialistid inner join schedule_work_doctor on schedule_work_doctor.emp_doc_id  = empdoc.emp_doc_id inner join room on room.room_id = schedule_work_doctor.room_id inner join time_attendance on time_attendance.emp_doc_id = empdoc.emp_doc_id where swd_status_room = 1 AND room.room_status = 1 AND swd_day_work = '" + lblday.Text + "' AND remark = 'เข้างาน' AND swd_timezone = 'บ่าย'  AND swd_date_work = '" + today + "'");
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
                                  
                                       dataGridView2.Rows[n].Cells[6].Value = item["room_id"].ToString();

                                   }
                                   
            }
            
        }

        private void label12_TextChanged(object sender, EventArgs e)
        {
            //  lblidcard.Text = "1";
          
         
                string query = ("select opd.opd_idcard,opd.opd_name,opd.opd_id from queue_visit_record inner join opd on opd.opd_id = queue_visit_record.opd_id where queue_visit_record.qvr_status = 1");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {


                    lblidcard.Text = sdr["opd_idcard"].ToString();
                    lblsername.Text = sdr["opd_name"].ToString();
                    lblopd.Text = sdr["opd_id"].ToString();


                }
     //********hgojoihohihnh;oh;lgligkjfjytlhjlkkjk[;lkok***************************************************************************************45454545454545454566566656565545juihuhnfggggggghjrewet
        


        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
           /*
            string query = ("select symtoms_dis from symtoms where symtoms_dis LIKE '%" + textBox1.Text + "%'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                string systoms = sdr["symtoms_dis"].ToString();
                txtremark.Text = systoms;

            }else
            {
                txtremark.Clear();
            }


            */


            conn.Close();
        }

        private void lblopdid_TextChanged(object sender, EventArgs e)
        {

            conn.Open();
            string query = ("select visit_record.vr_remark from visit_record inner join opd on visit_record.opd_id = opd.opd_id where vr_status = 0 AND opd.opd_id = '"+lblopdid.Text+"'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {

                string timezone = lbltimezone.Text;
                string today = DateTime.Now.ToString("yyyy-MM-dd", new CultureInfo("th-TH"));
                if (timezone == "เช้า")
                {
                    //  dataGridView2.Rows.Clear();
                    // dataGridView2.Refresh();

                    string remark = sdr["vr_remark"].ToString();
                    string re1 = "" + remark;

                    // MessageBox.Show(re1);
                    query = ("select schedule_work_doctor.swd_id,empdoc.emp_doc_name,schedule_work_doctor.room_id from employee_doctor empdoc inner join specialist on specialist.emp_doc_specialistid = empdoc.emp_doc_specialistid inner join schedule_work_doctor on schedule_work_doctor.emp_doc_id  = empdoc.emp_doc_id inner join room on room.room_id = schedule_work_doctor.room_id inner join time_attendance on time_attendance.emp_doc_id = empdoc.emp_doc_id inner join symtoms on symtoms.emp_doc_specialistid = specialist.emp_doc_specialistid where swd_status_room = 1 AND room.room_status = 1 AND swd_day_work = '" + lblday.Text + "' AND remark = 'เข้างาน' AND swd_timezone = 'เช้า' AND swd_date_work = '" + today + "' AND symtoms_dis LIKE '%" + re1 + "%'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);
                    sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {

                        int swd_id = Convert.ToInt32(sdr["swd_id"].ToString());
                        string docname = sdr["emp_doc_name"].ToString();
                        int room = Convert.ToInt32(sdr["room_id"].ToString());
                        lblswd.Text = "" + swd_id;
                        lbldocname.Text = docname;
                        lblroom.Text = "" + room;
                        // MessageBox.Show(remark);

                    }
                    else
                    {
                        //  MessageBox.Show(remark);

                    }


                } if(timezone == "บ่าย")
                {
                    //  dataGridView2.Rows.Clear();
                    // dataGridView2.Refresh();
                    string remark = sdr["vr_remark"].ToString();
                    string re1 = "" + remark;

                    // MessageBox.Show(re1);
                    query = ("select schedule_work_doctor.swd_id,empdoc.emp_doc_name,schedule_work_doctor.room_id from employee_doctor empdoc inner join specialist on specialist.emp_doc_specialistid = empdoc.emp_doc_specialistid inner join schedule_work_doctor on schedule_work_doctor.emp_doc_id  = empdoc.emp_doc_id inner join room on room.room_id = schedule_work_doctor.room_id inner join time_attendance on time_attendance.emp_doc_id = empdoc.emp_doc_id inner join symtoms on symtoms.emp_doc_specialistid = specialist.emp_doc_specialistid where swd_status_room = 1 AND room.room_status = 1 AND swd_day_work = '" + lblday.Text + "' AND remark = 'เข้างาน' AND swd_timezone = 'บ่าย' AND swd_date_work = '" + today + "' AND symtoms_dis LIKE '%" + re1 + "%'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);
                    sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {

                        int swd_id = Convert.ToInt32(sdr["swd_id"].ToString());
                        string docname = sdr["emp_doc_name"].ToString();
                        int room = Convert.ToInt32(sdr["room_id"].ToString());
                        lblswd.Text = "" + swd_id;
                        lbldocname.Text = docname;
                        lblroom.Text = "" + room;
                        // MessageBox.Show(remark);

                    }
                    else
                    {
                        //  MessageBox.Show(remark);

                    }
                }

            }

            conn.Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            //   lblsymtoms.Text += textBox1.Text + Environment.NewLine;
            //textBox1.Clear();
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
