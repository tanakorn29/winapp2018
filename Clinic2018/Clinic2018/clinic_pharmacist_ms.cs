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
    public partial class clinic_pharmacist_ms : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-92251HH\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
        public clinic_pharmacist_ms()
        {
            InitializeComponent();
            conn.Open();
            string query = ("select medi_name,medi_no,medi_qty,medi_unit,medi_price_unit,medi_price,medi_date_x,medi_date_by  from medical where medi_status_new_stock = 0");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();



                dataGridView1.Rows[n].Cells[0].Value = item["medi_name"].ToString();
        
                dataGridView1.Rows[n].Cells[1].Value = item["medi_no"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["medi_qty"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["medi_unit"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["medi_price_unit"].ToString();
                 dataGridView1.Rows[n].Cells[5].Value = item["medi_price"].ToString();
                DateTime date_start = Convert.ToDateTime(item["medi_date_x"].ToString());
                DateTime date_end = Convert.ToDateTime(item["medi_date_by"].ToString());

                string start = date_start.ToString("yyyy-MM-dd");
                string end = date_end.ToString("yyyy-MM-dd");
                dataGridView1.Rows[n].Cells[6].Value = start;
                dataGridView1.Rows[n].Cells[7].Value = end;

            }

            query = ("select medi_name,medi_no,medi_qty,medi_unit,medi_price_unit,medi_price,medi_date_x,medi_date_by  from medical where medi_status_new_stock = 1 AND medi_status_xby = 1");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView2.Rows.Add();



                dataGridView2.Rows[n].Cells[0].Value = item["medi_name"].ToString();

                dataGridView2.Rows[n].Cells[1].Value = item["medi_no"].ToString();
                dataGridView2.Rows[n].Cells[2].Value = item["medi_qty"].ToString();
                dataGridView2.Rows[n].Cells[3].Value = item["medi_unit"].ToString();
                dataGridView2.Rows[n].Cells[4].Value = item["medi_price_unit"].ToString();
                dataGridView2.Rows[n].Cells[5].Value = item["medi_price"].ToString();
                DateTime date_start = Convert.ToDateTime(item["medi_date_x"].ToString());
                DateTime date_end = Convert.ToDateTime(item["medi_date_by"].ToString());

                string start = date_start.ToString("yyyy-MM-dd");
                string end = date_end.ToString("yyyy-MM-dd");
                dataGridView2.Rows[n].Cells[6].Value = start;
                dataGridView2.Rows[n].Cells[7].Value = end;

            }
/*
            query = ("select medi_name,medi_no,medi_qty,medi_unit,medi_price_unit,medi_price,medi_date_x,medi_date_by  from medical where medi_status_new_stock = 2 AND medi_status_xby = 2");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView3.Rows.Add();



                dataGridView3.Rows[n].Cells[0].Value = item["medi_name"].ToString();

                dataGridView3.Rows[n].Cells[1].Value = item["medi_no"].ToString();
                dataGridView3.Rows[n].Cells[2].Value = item["medi_qty"].ToString();
                dataGridView3.Rows[n].Cells[3].Value = item["medi_unit"].ToString();
                dataGridView3.Rows[n].Cells[4].Value = item["medi_price_unit"].ToString();
                dataGridView3.Rows[n].Cells[5].Value = item["medi_price"].ToString();
                DateTime date_start = Convert.ToDateTime(item["medi_date_x"].ToString());
                DateTime date_end = Convert.ToDateTime(item["medi_date_by"].ToString());

                string start = date_start.ToString("yyyy-MM-dd");
                string end = date_end.ToString("yyyy-MM-dd");
                dataGridView3.Rows[n].Cells[6].Value = start;
                dataGridView3.Rows[n].Cells[7].Value = end;

            }
            */
            txtmedinum.Text = "0";
            txtprice.Text = "0";
            txtpriceunit.Text = "0";
            txtmedino.Text = "0";
            txtmin.Text = "0";
            conn.Close();
        }
        int selectedRow;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            textBox1.Visible = true;
            lblmediunit.Visible = true;
            label3.Visible = true;
            dateTimePicker2.Enabled = true;

            lblmedi.Text = row.Cells[0].Value.ToString();
            lblcount.Text = row.Cells[2].Value.ToString();
            lblmediunit.Text = row.Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           conn.Open();

            try
            {
                CultureInfo ThaiCulture = new CultureInfo("th-TH");

                DateTime date_start = Convert.ToDateTime(label16.Text);
                DateTime date_end = Convert.ToDateTime(dateTimePicker2.Text);
                string start = date_start.ToString("yyyy-MM-dd");
                string end = date_end.ToString("yyyy-MM-dd", ThaiCulture);

                int qty = Convert.ToInt32(lblcount.Text);
                int sub = qty + Convert.ToInt32(textBox1.Text);
           
                string medi_name = lblmedi.Text;
                /*
                string query = ("select medi_name,medi_no,medi_qty,medi_unit,medi_price_unit,medi_price,medi_date_x,medi_date_by,medi_min  from medical where medi_name = '" + medi_name + "'");
                //  string query = ("select medi_name from medical where medi_name = '" + medi_name + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    string medi_name1 = sdr["medi_name"].ToString();
                    string medi_no = sdr["medi_no"].ToString();
                    string medi_qty = sdr["medi_qty"].ToString();
                    string medi_unit = sdr["medi_unit"].ToString();
                    string medi_price_unit = sdr["medi_price_unit"].ToString();
                    string medi_price = sdr["medi_price"].ToString();
                    string medi_date_x = sdr["medi_date_x"].ToString();
                    string medi_date_by = sdr["medi_date_by"].ToString();
                    string min = sdr["medi_min"].ToString();
                    query = ("insert into medical (medi_name,medi_no,medi_qty,medi_unit,medi_price_unit,medi_price,medi_date_x,medi_date_by,medi_status_stock,medi_status_new_stock,medi_status_xby,medi_min) values ('" + medi_name1 + "','" + medi_no + "','" + textBox1.Text + "','" + medi_unit + "','" + medi_price_unit + "','" + medi_price + "','" + start + "','" + end + "',2,1,2,'"+min+"')");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();

                    sda.Fill(dt);

                }
                */

                string query = ("select count(*) from medical where medi_status_stock = 0 OR medi_status_xby = 0 AND medi_name = '" + lblmedi.Text + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                int count = (int)cmd.ExecuteScalar();
                if(count < 1)
                {
                    MessageBox.Show("ไม่สามารถอัพเดตได้");
                }
                else
                {
              
                   query = ("select * from medical where medi_status_new_stock = 0 AND medi_status_xby <= 1 AND medi_name = '" + lblmedi.Text + "'");
                   cmd = new SqlCommand(query, conn);
                   sda = new SqlDataAdapter(cmd);
                   dt = new DataTable();
                   sda.Fill(dt);
                   sdr = cmd.ExecuteReader();
                   if (sdr.Read())
                   {
                       int min = Convert.ToInt32(sdr["medi_min"].ToString());
                       int qty1 = Convert.ToInt32(sdr["medi_qty"].ToString());


                       if (qty1 < min)
                       {
                        //   MessageBox.Show("ปรับปรุงข้อมูล");
                              query = ("UPDATE medical SET medi_qty = '" + sub + "',medi_date_x = '" + start + "',medi_date_by = '" + end + "',medi_status_stock = 1  WHERE medi_name = '" + lblmedi.Text + "'");
                                     cmd = new SqlCommand(query, conn);
                                     sda = new SqlDataAdapter(cmd);
                                     dt = new DataTable();

                                     sda.Fill(dt);

                                     clinic_pharmacist_ms doc1 = new clinic_pharmacist_ms();
                                     doc1.Show();
                                     clinic_pharmacist_ms clnlog = new clinic_pharmacist_ms();
                                     clnlog.Close();
                                     Visible = false;
                                     MessageBox.Show("อัพเดตข้อมูลเรียบร้อย");
                       }
                       else
                       {
                            query = ("UPDATE medical SET medi_qty = '" + sub + "',medi_date_x = '" + start + "',medi_date_by = '" + end + "',medi_status_stock = 1 , medi_status_xby = 1 WHERE medi_name = '" + lblmedi.Text + "'");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();

                            sda.Fill(dt);

                            clinic_pharmacist_ms doc1 = new clinic_pharmacist_ms();
                            doc1.Show();
                            clinic_pharmacist_ms clnlog = new clinic_pharmacist_ms();
                            clnlog.Close();
                            Visible = false;
                            MessageBox.Show("เติมข้อมูลยาเรียบร้อย");
                        }


                    }
                 

                   

                }



            }
            catch (Exception)
            {
                MessageBox.Show("ไม่มีข้อมูลการปรับปรุงยา");
            }
             
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                CultureInfo ThaiCulture = new CultureInfo("th-TH");
                DateTime date_start = Convert.ToDateTime(label16.Text);
                DateTime date_end = Convert.ToDateTime(dateTimePicker3.Text);
                string start = date_start.ToString("yyyy-MM-dd");
                string end = date_end.ToString("yyyy-MM-dd", ThaiCulture);
                string namemedi = txtmedi.Text;
                string medi_no = txtmedino.Text;
                string medi_num = txtmedinum.Text;
                string min = txtmin.Text;
                string unit_medi = comboBox1.SelectedItem.ToString();
                double unit_price = Convert.ToDouble(txtpriceunit.Text);
                double price = Convert.ToDouble(txtprice.Text);
                if (txtmedi.Text == "0" || txtmedino.Text == "0" || txtmedinum.Text == "0" || txtpriceunit.Text == "0" || txtprice.Text == "0" || unit_medi == "")
                {
                    MessageBox.Show("กรุณากรอกข้อมูลให้ครบ");
                }
                else
                {
                    string query = ("insert into medical (medi_name,medi_no,medi_qty,medi_unit,medi_price_unit,medi_price,medi_date_x,medi_date_by,medi_status_stock,medi_status_new_stock,medi_status_xby,medi_min) values ('" + namemedi + "','" + medi_no + "','" + medi_num + "','" + unit_medi + "','" + unit_price + "','" + price + "','" + start + "','" + end + "',1,1,1,'"+min+"')");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();

                    sda.Fill(dt);

                    clinic_pharmacist_ms doc1 = new clinic_pharmacist_ms();
                    doc1.Show();
                    clinic_pharmacist_ms clnlog = new clinic_pharmacist_ms();
                    clnlog.Close();
                    Visible = false;
                    MessageBox.Show("อัพเดตข้อมูลเรียบร้อย");

                }




            }
            catch (Exception)
            {
                MessageBox.Show("กรอกข้อมูลให้เรียบร้อย");
            }


            conn.Close();
        }

        private void clinic_pharmacist_ms_Load(object sender, EventArgs e)
        {
            //  MessageBox.Show("Test");
       

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";

            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "yyyy-MM-dd";

            DateTime today = DateTime.Now;
            string day_today = today.ToString("yyyy-MM-dd", new CultureInfo("th-TH"));
            int day = today.Day;
            int month = today.Month;
            int year = today.Year;

            //   string today = DateTime.Now.ToString("yyyy-MM-dd", new CultureInfo("th-TH"));
            label16.Text = day_today;

          //  MessageBox.Show(day_today);
            conn.Open();
            try
            {
                string query = ("select medi_date_by from medical where medi_status_new_stock = 0 AND medi_date_by >= '"+ day_today + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                  
                    DateTime date_by = Convert.ToDateTime(sdr["medi_date_by"].ToString());
                    string date_byby = date_by.ToString("yyyy-MM-dd");
                    int date_by_day = date_by.Day;
                    int date_by_month = date_by.Month;
                    int year_by = date_by.Year;
          

                    if (day >= date_by_day || month == date_by_month)
                    {
                        query = ("UPDATE medical SET medi_status_xby = 0 ,medi_status_stock = 0,medi_status_new_stock = 0 WHERE medi_date_by <= '" + date_byby + "'");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();

                        sda.Fill(dt);
                    }



                }
            }
            catch (Exception)
            {
                MessageBox.Show("มีข้อผิดพลาด");
            }






            conn.Close();
         
        }

        private void label16_TextChanged(object sender, EventArgs e)
        {
            conn.Open();

            DateTime today = Convert.ToDateTime(label16.Text);
            string day_today = today.ToString("yyyy-MM-dd");
            int day = today.Day;
            int month = today.Month;
            int year = today.Year;
            string query = ("select medi_date_x,medi_date_by from medical where medi_status_new_stock = 1");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
               DateTime date_x = Convert.ToDateTime(sdr["medi_date_x"].ToString());
                DateTime date_by= Convert.ToDateTime(sdr["medi_date_by"].ToString());
                string date_xx = date_x.ToString("yyyy-MM-dd");
                string date_byby = date_by.ToString("yyyy-MM-dd");
                int date_X_th = date_x.Day;
                int date_X_month = date_x.Month;
                int yeay_x = date_x.Year;
                int date_by_day = date_by.Day;
                int date_by_month = date_by.Month;
                int year_by = date_by.Year;
                if (day > date_X_th && month == date_X_month)
                {
                    
                      query = ("UPDATE medical SET medi_status_new_stock = 0 WHERE medi_date_x = '" + date_xx + "'");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();

                        sda.Fill(dt);
                    

                }


            }

/*
            query = ("select medi_date_by from medical where medi_status_new_stock = 0");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                DateTime date_by = Convert.ToDateTime(sdr["medi_date_by"].ToString());
                string date_byby = date_by.ToString("yyyy-MM-dd");
                int date_by_th = date_by.Day;

                if (day_today == date_byby)
                {

                    query = ("UPDATE medical SET medi_status_xby = 0 ,medi_status_stock = 0 WHERE medi_date_by = '" + date_byby + "'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();

                    sda.Fill(dt);
                }
            

            }
       

    */


                conn.Close();
        }

    /* 

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView3.Rows[selectedRow];
            lblmedi.Text = row.Cells[0].Value.ToString();
            lblcount.Text = row.Cells[2].Value.ToString();
            lblmediunit.Text = row.Cells[3].Value.ToString();
            textBox1.Visible = false;
            lblmediunit.Visible = false;
            label3.Visible = false;
            dateTimePicker2.Enabled = false;
            dateTimePicker2.Text = row.Cells[7].Value.ToString();
            lblunit.Text = row.Cells[3].Value.ToString();
            //  textBox1.Text = row.Cells[4].Value.ToString();
        }
        */
    }
}
