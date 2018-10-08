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
    public partial class Clinic_boss : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-92251HH\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;

        public Clinic_boss()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clinic_user_control user = new clinic_user_control();
            user.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clinic_login log = new clinic_login();
            log.Show();
            Clinic_boss main = new Clinic_boss();
            main.Close();
            Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clinic_calendar user = new clinic_calendar();
            user.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clinic_show_data_att user = new clinic_show_data_att();
            user.Show();
        }

        private void Clinic_boss_Load(object sender, EventArgs e)
        {
            try
            {
                CultureInfo ThaiCulture = new CultureInfo("th-TH");
                DateTime today = DateTime.Today;
                string month_th = today.ToString("yyyy-MM-dd", ThaiCulture);
                DateTime month = Convert.ToDateTime(month_th);
                conn.Open();


                string query = ("select swd_date_work from schedule_work_doctor  Order by swd_id DESC");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();

                sda.Fill(dt);

                sdr = cmd.ExecuteReader();
                int day = today.Day;

                if (sdr.Read())
                {
                    string month_work = sdr["swd_date_work"].ToString();

                    DateTime month_date_last = Convert.ToDateTime(month_work);
                    string month_thai = month_date_last.ToString("yyyy-MM-dd");
                    query = ("select count(*) from schedule_work_doctor where swd_status = 'การจัดตารางงานเสร็จสิ้น' AND swd_date_work = '"+ month_thai + "'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();

                    sda.Fill(dt);

                    int swd_count1 = (int)cmd.ExecuteScalar();

                   
                    if (swd_count1 != 0)
                    {
                        if (day >= 21)
                        {



                            MessageBox.Show("กรุณาจัดช่วงเวลาการทำงาน");
                            clinic_time_schms log = new clinic_time_schms();
                            log.Show();
                            clinic_time_schms main = new clinic_time_schms();
                            main.Close();
                            Visible = false;






                        }
                        else if (day >= 1 && day <= 19)
                        {


                            MessageBox.Show("กรุณาจัดช่วงเวลาการทำงาน");
                            clinic_time_schms log = new clinic_time_schms();
                            log.Show();
                            clinic_time_schms main = new clinic_time_schms();
                            main.Close();
                            Visible = false;




                        }
                    }
      
                }

          /*      query = ("select swd_month_work from schedule_work_doctor where swd_status = 'การจัดตารางงานเสร็จสิ้น' Order by swd_id DESC ");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();

                sda.Fill(dt);

                sdr = cmd.ExecuteReader();
                int day1 = today.Day;

                if (sdr.Read())
                {
                    string month_work = sdr["swd_month_work"].ToString();
                    if (month_work == month)
                    {

                        MessageBox.Show("กรุณาจัดช่วงเวลาการทำงาน");
                        clinic_time_schms log = new clinic_time_schms();
                        log.Show();
                        clinic_time_schms main = new clinic_time_schms();
                        main.Close();
                        Visible = false;



                    }
                }
                */
                conn.Close();

            }
            catch (Exception)
            {

            }
     

        }
    }
}
