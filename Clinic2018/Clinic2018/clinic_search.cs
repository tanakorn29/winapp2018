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
    public partial class clinic_search : Form
    {
        public clinic_search()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
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
        }
        Timer t = new Timer();
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-J5O17QF\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = 13;

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            lb11.Text = "";
            lb22.Text = "";
            lb33.Text = "";
            lb44.Text = "";
            lb55.Text = "";
            statusapp.Text = "";
            //     string query = ("select * from employee_ru eru, opd, privilege where eru.emp_ru_idcard = opd.emp_ru_id and opd.emp_ru_id = privilege.emp_ru_idcard and eru.emp_ru_idcard = '" + textBox1.Text + "'");
            //  string query = ("select * from employee_ru inner join privilege on privilege.emp_ru_id = employee_ru.emp_ru_id inner join opd on opd.emp_ru_id = employee_ru.emp_ru_id where employee_ru.emp_ru_idcard = '" + textBox1.Text + "'");
            string query = ("select employee_ru.emp_ru_idcard,employee_ru.emp_ru_name,employee_ru.emp_ru_birthday,employee_ru.emp_ru_telmobile,privilege.privil_status,appointment.status_approve from employee_ru FULL join privilege on privilege.emp_ru_id = employee_ru.emp_ru_id FULL join opd on opd.emp_ru_id = employee_ru.emp_ru_id FULL join appointment on appointment.opd_id = opd.opd_id where employee_ru.emp_ru_idcard = '" + textBox1.Text + "'");


         //   string query = ("select * from employee_ru inner join privilege on privilege.emp_ru_id = employee_ru.emp_ru_id  where employee_ru.emp_ru_idcard = '" + textBox1.Text + "'");
          //  string query = ("select * from opd   inner join privilege on privilege.opd_id = opd.opd_id    where opd.opd_idcard = '" + textBox1.Text + "'");
            //     string query = ("select * from employee_ru inner join privilege on privilege.emp_ru_id = employee_ru.emp_ru_id where employee_ru.emp_ru_idcard = '" + textBox1.Text + "'");
            //   string query = ("select * from employee_ru inner join opd on opd.emp_ru_id = employee_ru.emp_ru_id where employee_ru.emp_ru_idcard = '"+textBox1.Text+"'");
            cmd = new SqlCommand(query, conn);

            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            //   SqlDataReader sba = cmd.ExecuteReader();
            // sdr = cmd.ExecuteReader();
            sda.Fill(dt);

            //------------------------------ปิงปอง--------------------------------------
            if (textBox1.Text == cmd.Connection.Database || textBox1.MaxLength == 13)
            {
                // if (sba.Read())
                //{
                //  string position = sba["privil_status"].ToString();
                // if(position == "อนุญาต")
                //{
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    string privil_status = item["privil_status"].ToString();
                    if (privil_status == "ได้รับสิทธิการรักษา")
                    {
                     

                            dataGridView1.Rows[n].Cells[0].Value = item["emp_ru_idcard"].ToString();
                        dataGridView1.Rows[n].Cells[1].Value = item["emp_ru_name"].ToString();
                        DateTime birthday = Convert.ToDateTime(item["emp_ru_birthday"].ToString());
                        string date_birth = String.Format("{0:yyyy-MM-dd}", birthday);
                        dataGridView1.Rows[n].Cells[2].Value = date_birth;
                        dataGridView1.Rows[n].Cells[3].Value = item["emp_ru_telmobile"].ToString();
                        dataGridView1.Rows[n].Cells[4].Value = item["privil_status"].ToString();

                        string status_approve = item["status_approve"].ToString();
                        if(status_approve == "2")
                        {

                            dataGridView1.Rows[n].Cells[5].Value = "มีการนัดหมายการรักษา";
                        }
                        else if (status_approve == "")
                        {
                            dataGridView1.Rows[n].Cells[5].Value = "ไม่มีการนัดหมายการรักษา";
                        }
                      
                    }
                    else
                    {
                        MessageBox.Show("ยังไม่ได้รับสิทธิการรักษา");
                    }


                }
            }



            //  }

            //    }else
            //    {
            //        MessageBox.Show("ยังไม่ได้รับสิทธิการรักษา");
            //    }



            //    if (textBox1.Text != cmd.Connection.Database || textBox1.MaxLength == 13)

            //       {
            //            clinic_approve cliapp = new clinic_approve();
            //            cliapp.Show();
            //       }
            //------------------------------ปิงปอง--------------------------------------


            //------------------------------ไม่ได้ใช้ เก็บไว้ --------------------------------------
            /*select eru.emp_ru_idcard, eru.emp_ru_name, privilege.privil_status
            from employee_ru eru
            inner join opd on eru.emp_ru_idcard = opd.emp_ru_id
            inner join privilege on opd.emp_ru_id = privilege.emp_ru_idcard

            select eru.emp_ru_idcard, eru.emp_ru_name, privilege.privil_status 
            from employee_ru eru, opd, privilege
            where eru.emp_ru_idcard = opd.emp_ru_id
            and opd.emp_ru_id = privilege.emp_ru_idcard
            and eru.emp_ru_idcard = '1859900128488'*/
            //------------------------------ไม่ได้ใช้ เก็บไว้ --------------------------------------

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            //------------------------------ไม่ได้ใช้ เก็บไว้ --------------------------------------
            /*if (textBox1.MaxLength == null)
            {
                textBox1.Clear();
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
            }
            else
            {
                clinic_approve cliapp = new clinic_approve();
                cliapp.Close();
            }*/
            //------------------------------ไม่ได้ใช้ เก็บไว้ --------------------------------------
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*string query = ("update queue_visit_record set opd_idcard = '"+ dt DataGridTextBoxColumn + "'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);*/
        }

        int selectedRow;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                lb11.Text = row.Cells[0].Value.ToString();
                lb22.Text = row.Cells[1].Value.ToString();
                lb33.Text = row.Cells[2].Value.ToString();
                lb44.Text = row.Cells[3].Value.ToString();
                lb55.Text = row.Cells[4].Value.ToString();
                statusapp.Text = row.Cells[5].Value.ToString();
            }
            catch (Exception)
            {
              //  MessageBox.Show("กำลังดำเนินกา");
            }

        }

        private void bt1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            lb11.Text = "";
            lb22.Text = "";
            lb33.Text = "";
            lb44.Text = "";
            lb55.Text = "";
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime today_th = DateTime.Today;
                string today = today_th.ToString("yyyy-MM-dd", new CultureInfo("th-TH"));
                if (lb11.Text != cmd.Connection.Database &&
                    lb22.Text != cmd.Connection.Database &&
                    lb33.Text != cmd.Connection.Database &&
                    lb44.Text != cmd.Connection.Database &&
                    lb55.Text != cmd.Connection.Database &&
                    statusapp.Text != cmd.Connection.Database)
                {
                    Queue<int> collection = new Queue<int>();
                    /*       collection.Enqueue(1);
                           collection.Enqueue(2);
                           collection.Enqueue(3);
                           collection.Enqueue(4);
                           collection.Enqueue(5);
                           collection.Enqueue(6);
                           collection.Enqueue(7);
                           collection.Enqueue(8);
                           collection.Enqueue(9);
                           collection.Enqueue(10);*/


                    conn.Open();
                    string query = ("select * from employee_ru inner join privilege on privilege.emp_ru_id = employee_ru.emp_ru_id inner join opd on opd.emp_ru_id = employee_ru.emp_ru_id where employee_ru.emp_ru_idcard = '" + textBox1.Text + "'");
                                        cmd = new SqlCommand(query, conn);

                                        sda = new SqlDataAdapter(cmd);
                                        dt = new DataTable();
                                        sda.Fill(dt);
                                        sdr = cmd.ExecuteReader();
                                        if (sdr.Read())
                                        {
                                            int emp_ru_id = Convert.ToInt32(sdr["emp_ru_id"].ToString());
                                            int opd_id = Convert.ToInt32(sdr["opd_id"].ToString());
             
                            query = ("select Count(*) from appointment where opd_id = '"+opd_id+ "' AND status_approve = 2");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);

                        int app_count = (int)cmd.ExecuteScalar();
                        if(app_count == 1)
                        {
                            query = ("insert into queue_visit_record(qvr_record,qvr_time,qvr_date,qvr_status,emp_ru_id,vr_id,opd_id) values(' ', '"+lbltime.Text+"', SYSDATETIME(),5,'" + emp_ru_id + " ',' ','" + opd_id + " ')");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);
                            DialogResult dialogResult = MessageBox.Show("ส่งคิวการนัดหมาย", "คุณต้องการส่งคิวการนัดหมายหรือไม่", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                query = ("select appointment.app_date from appointment where opd_id = '" + opd_id + "' AND status_approve = 2");
                                cmd = new SqlCommand(query, conn);

                                sda = new SqlDataAdapter(cmd);
                                dt = new DataTable();
                                sda.Fill(dt);
                                sdr = cmd.ExecuteReader();
                                if (sdr.Read())
                                {
                                    string date = sdr["app_date"].ToString();
                                    DateTime date_app = Convert.ToDateTime(date);
                                    int date_day = date_app.Day;
                                    int today_day = today_th.Day;

                                    if(today_day >= date_day)
                                    {
                                        query = ("select Count(*) from queue_visit_record inner join opd on opd.opd_id = queue_visit_record.opd_id inner join employee_ru on employee_ru.emp_ru_id = queue_visit_record.emp_ru_id where queue_visit_record.qvr_status = 5");
                                        cmd = new SqlCommand(query, conn);
                                        sda = new SqlDataAdapter(cmd);
                                        dt = new DataTable();
                                        sda.Fill(dt);
                                        //  sdr = cmd.ExecuteReader();
                                        int queue = (int)cmd.ExecuteScalar();
                                        collection.Enqueue(queue);

                                        foreach (int value in collection)
                                        {
                                            query = ("Update queue_visit_record set qvr_record = '" + value + "' where emp_ru_id = '" + emp_ru_id + "'");
                                            //  
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);
                                            clinic_search m3 = new clinic_search();
                                            m3.Show();
                                            clinic_search clnlog = new clinic_search();
                                            clnlog.Close();
                                            Visible = false;
                                            MessageBox.Show("ส่วนของการนัดหมาย คิวที่    " + value + " ");
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("ยังไม่ถึงเวลานัดหมาย");
                                    }
                                 


                                }
                                /*
                                query = ("select Count(*) from queue_visit_record inner join opd on opd.opd_id = queue_visit_record.opd_id inner join employee_ru on employee_ru.emp_ru_id = queue_visit_record.emp_ru_id where queue_visit_record.qvr_status = 5");
                                cmd = new SqlCommand(query, conn);
                                sda = new SqlDataAdapter(cmd);
                                dt = new DataTable();
                                sda.Fill(dt);
                                //  sdr = cmd.ExecuteReader();
                                int queue = (int)cmd.ExecuteScalar();
                                collection.Enqueue(queue);

                                foreach (int value in collection)
                                {
                                    query = ("Update queue_visit_record set qvr_record = '" + value + "' where emp_ru_id = '" + emp_ru_id + "'");
                                    //  
                                    cmd = new SqlCommand(query, conn);
                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    sda.Fill(dt);
                                    clinic_search m3 = new clinic_search();
                                    m3.Show();
                                    clinic_search clnlog = new clinic_search();
                                    clnlog.Close();
                                    Visible = false;
                                    MessageBox.Show("ส่วนของการนัดหมาย คิวที่    " + value + " ");
                                }


                            */



                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                clinic_search m3 = new clinic_search();
                                m3.Show();
                                clinic_search clnlog = new clinic_search();
                                clnlog.Close();
                                Visible = false;
                            }
                        }
                        else
                        {
                            query = ("insert into queue_visit_record(qvr_record,qvr_time,qvr_date,qvr_status,emp_ru_id,vr_id,opd_id) values(' ', '" + lbltime.Text + "', SYSDATETIME(),1,'" + emp_ru_id + " ',' ','" + opd_id + " ')");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);
                            DialogResult dialogResult = MessageBox.Show("ส่งคิวการซักประวัติ", "คุณต้องการส่งคิวการซักประวัติหรือไม่", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                query = ("select Count(*) from queue_visit_record inner join opd on opd.opd_id = queue_visit_record.opd_id inner join employee_ru on employee_ru.emp_ru_id = queue_visit_record.emp_ru_id where queue_visit_record.qvr_status = 1");
                                cmd = new SqlCommand(query, conn);
                                sda = new SqlDataAdapter(cmd);
                                dt = new DataTable();
                                sda.Fill(dt);
                                //  sdr = cmd.ExecuteReader();
                                int queue = (int)cmd.ExecuteScalar();
                                collection.Enqueue(queue);

                                foreach (int value in collection)
                                {
                                    query = ("Update queue_visit_record set qvr_record = '" + value + "' where emp_ru_id = '" + emp_ru_id + "'");
                                    //  
                                    cmd = new SqlCommand(query, conn);
                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    sda.Fill(dt);
                                    clinic_search m3 = new clinic_search();
                                    m3.Show();
                                    clinic_search clnlog = new clinic_search();
                                    clnlog.Close();
                                    Visible = false;
                                    MessageBox.Show("คิวที่    " + value);
                                }






                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                clinic_search m3 = new clinic_search();
                                m3.Show();
                                clinic_search clnlog = new clinic_search();
                                clnlog.Close();
                                Visible = false;
                            }
                        }

                        /*
                                                query = ("insert into queue_visit_record(qvr_record,qvr_time,qvr_date,qvr_status,emp_ru_id,vr_id,opd_id) values(' ', SYSDATETIME(), SYSDATETIME(),1,'" + emp_ru_id + " ',' ','" + opd_id + " ')");
                                                                    cmd = new SqlCommand(query, conn);
                                                                    sda = new SqlDataAdapter(cmd);
                                                                    dt = new DataTable();
                                                                    sda.Fill(dt);
                                                                    DialogResult dialogResult = MessageBox.Show("ส่งคิวการซักประวัติ", "คุณต้องการส่งคิวการซักประวัติหรือไม่", MessageBoxButtons.YesNo);
                                                                    if (dialogResult == DialogResult.Yes)
                                                                    {
                                                                        query = ("select Count(*) from queue_visit_record inner join opd on opd.opd_id = queue_visit_record.opd_id inner join employee_ru on employee_ru.emp_ru_id = queue_visit_record.emp_ru_id where queue_visit_record.qvr_status = 1");
                                                                        cmd = new SqlCommand(query, conn);
                                                                        sda = new SqlDataAdapter(cmd);
                                                                        dt = new DataTable();
                                                                        sda.Fill(dt);
                                                                        //  sdr = cmd.ExecuteReader();
                                                                        int queue = (int)cmd.ExecuteScalar();
                                                                        collection.Enqueue(queue);

                                                                        foreach (int value in collection)
                                                                        {
                                                                            query = ("Update queue_visit_record set qvr_record = '" + value + "' where emp_ru_id = '" + emp_ru_id + "'");
                                                                            //  
                                                                            cmd = new SqlCommand(query, conn);
                                                                            sda = new SqlDataAdapter(cmd);
                                                                            dt = new DataTable();
                                                                            sda.Fill(dt);

                                                                            MessageBox.Show("คิวที่    " + value);
                                                                        }






                                                                    }
                                                                    else if (dialogResult == DialogResult.No)
                                                                    {
                                                                        clinic_search m3 = new clinic_search();
                                                                        m3.Show();
                                                                        clinic_search clnlog = new clinic_search();
                                                                        clnlog.Close();
                                                                        Visible = false;
                                                                    }
                                                                      */
                                     }



                    /*

                                    string query = ("insert into queue_visit_record(qvr_record,qvr_time,qvr_date,qvr_status,emp_ru_id,vr_id,opd_idcard) values(' ', SYSDATETIME(), SYSDATETIME(),1,' ',' ',' ')");
                                    cmd = new SqlCommand(query, conn);
                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    sda.Fill(dt);
                                    */
                    //dataGridView1.Rows[n].Cells[0].Value = item["emp_ru_idcard"].ToString();



                    textBox1.MaxLength = 13;
                    textBox1.Clear();
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();

                    lb11.Text = "";
                    lb22.Text = "";
                    lb33.Text = "";
                    lb44.Text = "";
                    lb55.Text = "";
                    statusapp.Text = ""; 



                    conn.Close();
            }
                else
                {
                    MessageBox.Show("ตรวจสอบข้อมูลอีกครั้ง");
                }
         
              


            }
            catch (Exception ex)
            {
            MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OKCancel);
            }


            //----------------------------------------------------------------------
            /*try
            {
                drd = cmd.ExecuteReader();
                MessageBox.Show("Save");
                while (drd.Read())
                {

                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/

            //----------------------------------------------------------------------

            /*string query = (" ");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);*/


        }



        private void conferm_Click(object sender, EventArgs e)
        {
            clinic_approve cliapp = new clinic_approve();
            cliapp.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lb11_TextChanged(object sender, EventArgs e)
        {
          //  lbl6.Text = "รับข้อความ";
  /*
            conn.Open();
            string query = ("select opd.opd_id from opd where opd.opd_idcard LIKE'%"+lb11.Text+"%'");
            cmd = new SqlCommand(query, conn);

            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                int opd_id = Convert.ToInt32(sdr["opd_id"].ToString());
                query = ("select status_approve from appointment where opd_id = '" + opd_id+"'");
                cmd = new SqlCommand(query, conn);

                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                     statusapp.Text = sdr["status_approve"].ToString();
            


                //    lbl6.Text = "รับข้อความ";
                }
             //   statusapp.Text = "";


            }



            conn.Close();
      */
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
       /*     time += ".";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }
            **/
            lbltime.Text = time;
        }

        private void clinic_search_Load(object sender, EventArgs e)
        {
            t.Interval = 1000;
            t.Tick += new EventHandler(this.timer1_Tick);
            t.Start();
            //heddgtesrg4rggasdfaaaaruohiuih8niho;hi;hg;ohguo;h;il.ijhgywe4tg4rfsdfewrwsefwesafte
        }
    }
}


