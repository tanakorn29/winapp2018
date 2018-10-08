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
    public partial class clinic_pharmacist_service : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-92251HH\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets=true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
        public clinic_pharmacist_service()
        {
            InitializeComponent();
            conn.Open();

            string query = ("select treatment_record.treatr_id,opd.opd_name from opd inner join treatment_record on treatment_record.opd_id = opd.opd_id where treatr_status = 2");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView3.Rows.Add();



                dataGridView3.Rows[n].Cells[0].Value = item["treatr_id"].ToString();
                dataGridView3.Rows[n].Cells[1].Value = item["opd_name"].ToString();


            }

            query = ("select treatment_record.treatr_id,opd.opd_name,treatment_record.treatr_medi_queue from opd inner join treatment_record on treatment_record.opd_id = opd.opd_id where treatr_status = 3 ORDER BY treatr_medi_queue ASC");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();



                dataGridView1.Rows[n].Cells[0].Value = item["treatr_id"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["opd_name"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["treatr_medi_queue"].ToString();

            }


            /*      string query = ("select count(treatr_medi_queue) from treatment_record where treatr_status = 2");
                   cmd = new SqlCommand(query, conn);
                   sda = new SqlDataAdapter(cmd);
                   dt = new DataTable();
                   sda.Fill(dt);

                   int count = (int)cmd.ExecuteScalar();

                   if(count < 1)
                   {


                   }
                   else
                   {*/
            /*    string  query = ("select treatment_record.treatr_id,opd.opd_name,treatment_record.treatr_medi_queue from opd inner join treatment_record on treatment_record.opd_id = opd.opd_id where treatr_status = 2 ORDER BY treatr_medi_queue ASC");
                  cmd = new SqlCommand(query, conn);
                  sda = new SqlDataAdapter(cmd);
                  dt = new DataTable();
                  sda.Fill(dt);

                  foreach (DataRow item in dt.Rows)
                  {
                      int n = dataGridView3.Rows.Add();



                      dataGridView3.Rows[n].Cells[0].Value = item["treatr_id"].ToString();
                      dataGridView3.Rows[n].Cells[1].Value = item["opd_name"].ToString();
                      dataGridView3.Rows[n].Cells[2].Value = item["treatr_medi_queue"].ToString();

                  }*/

            //    }


            /*       query = ("select medi_id,medi_name,medi_qty,medi_unit from medical where medi_status_stock = 1");
                   cmd = new SqlCommand(query, conn);
                   sda = new SqlDataAdapter(cmd);
                   dt = new DataTable();
                   sda.Fill(dt);

                   foreach (DataRow item in dt.Rows)
                   {
                       int n = dataGridView1.Rows.Add();



                       dataGridView1.Rows[n].Cells[0].Value = item["medi_id"].ToString();
                       dataGridView1.Rows[n].Cells[1].Value = item["medi_name"].ToString();
                       dataGridView1.Rows[n].Cells[2].Value = item["medi_qty"].ToString();
                       dataGridView1.Rows[n].Cells[3].Value = item["medi_unit"].ToString();


                   }
                   */

            conn.Close();
        }
        int selectedRow;
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                conn.Open();
                selectedRow = e.RowIndex;
                DataGridViewRow row = dataGridView3.Rows[selectedRow];
                int tre_id = Convert.ToInt32(row.Cells[0].Value.ToString());
                Queue<int> collection = new Queue<int>();
                string query = ("select count(*) from treatment_record inner join appointment on appointment.opd_id = treatment_record.opd_id where treatr_id = '" + tre_id + "' AND status_approve = 1");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                int app_count = (int)cmd.ExecuteScalar();

                if(app_count == 1)
                {
                    MessageBox.Show("มีข้อมูลการนัดหมาย");
                }else
                {
                    query = ("select count(treatr_medi_queue) from treatment_record where treatr_status = 3");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);

                    int queue_ry = (int)cmd.ExecuteScalar();
                 int queue = queue_ry + 1;
                    query = ("Update treatment_record set treatr_medi_queue = '" + queue + "',treatr_status = 3   where treatr_id = '" + tre_id + "'");
                    //  
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);

                    conn.Close();

                    
                    clinic_pharmacist_service m3 = new clinic_pharmacist_service();
                    m3.Show();
                    clinic_pharmacist_service clnlog = new clinic_pharmacist_service();
                    clnlog.Close();
                    Visible = false;


                    MessageBox.Show("คิวการจ่ายยาที่   " + queue);




                }
   

            }
            catch (Exception)
            {

            }
   

            //    textBox1.Text = row.Cells[0].Value.ToString();
            //  textBox2.Text = row.Cells[1].Value.ToString();
            // textBox3.Text = row.Cells[2].Value.ToString();
            //  txttrea.Text = row.Cells[0].Value.ToString();
            //  textBox4.Text = row.Cells[0].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                /*    string query = ("select count(*) from treatment_record inner join appointment on appointment.opd_id = treatment_record.opd_id where treatr_id = '"+textBox4.Text+"' AND status_approve = 1");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);

                    int app_count = (int)cmd.ExecuteScalar();
                    if(app_count == 1)
                    {
                        MessageBox.Show("มีการนัดหมาย");

                        int q = Convert.ToInt32(lblqueue.Text);
                        int p = q + 1;
                        lblqueue.Text = ""+p;

                        query = ("select treatment_record.treatr_id from opd inner join treatment_record on treatment_record.opd_id = opd.opd_id where treatr_status = 2 AND treatment_record.treatr_medi_queue = '"+p+"'");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);
                        sdr = cmd.ExecuteReader();
                        if (sdr.Read())
                        {
                            txttrea.Text = (sdr["treatr_id"].ToString());
                            textBox4.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                        }



                    }
                    else
                    {*/
                /*    query = ("select count(*) from opd inner join treatment_record on treatment_record.opd_id = opd.opd_id inner join medicine_use on medicine_use.treatr_id = treatment_record.treatr_id inner join medical on medical.medi_id = medicine_use.medi_id where medicine_use.medi_use_status = 2 AND treatment_record.treatr_id = '" + txttrea.Text + "'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);

                    int count_app = (int)cmd.ExecuteScalar();
                    if (count_app < 1)
                    {*/
                string query = ("Select count(*) from treatment_record inner join medicine_use on medicine_use.treatr_id = treatment_record.treatr_id inner join medical on medical.medi_id = medicine_use.medi_id where treatment_record.treatr_status = 3 AND treatment_record.treatr_id = '" + txttrea.Text + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                int count_select = (int)cmd.ExecuteScalar();
                if (count_select < 1)
                {
                    MessageBox.Show("ไม่มีข้อมูลการสั่งยา");

                }
                else
                {
                    string today = DateTime.Now.ToString("yyyy-MM-dd", new CultureInfo("th-TH"));
                    query = ("Update treatment_record set treatr_status = 0 where treatr_id = '" + txttrea.Text + "'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);

                    query = ("Update queue_visit_record set qvr_status = 6 where opd_id = '" + txtopdid.Text + "' AND qvr_date = '" + today + "'");

                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);

                    query = ("Update medicine_use set medi_use_status = 0 from treatment_record inner join medicine_use on medicine_use.treatr_id = treatment_record.treatr_id inner join medical on medical.medi_id = medicine_use.medi_id where medicine_use.medi_use_status = 2 AND treatment_record.treatr_id = '" + txttrea.Text + "'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);

                    clinic_pharmacist_service m3 = new clinic_pharmacist_service();
                    m3.Show();
                    clinic_pharmacist_service clnlog = new clinic_pharmacist_service();
                    clnlog.Close();
                    Visible = false;


                    MessageBox.Show("จัดเก็บใบสั่งยาเรียบร้อย");


                }




                /*       }
                       else
                       {
                           //  query = ("Select count(*) from treatment_record inner join medicine_use on medicine_use.treatr_id = treatment_record.treatr_id inner join medical on medical.medi_id = medicine_use.medi_id where medicine_use.medi_use_status = 2 AND treatment_record.treatr_id =  '" + txttrea.Text + "' AND medical.medi_name = '" + textBox2.Text + "'");
                           query = ("Select count(*) from treatment_record inner join medicine_use on medicine_use.treatr_id = treatment_record.treatr_id inner join medical on medical.medi_id = medicine_use.medi_id where medicine_use.medi_use_status = 2 AND treatment_record.treatr_id =  '" + txttrea.Text + "'");
                           cmd = new SqlCommand(query, conn);
                           sda = new SqlDataAdapter(cmd);
                           dt = new DataTable();
                           sda.Fill(dt);

                           int count_select = (int)cmd.ExecuteScalar();
                           if (count_select == 1)
                           {*/
                /*   query = ("select medi_qty,medi_min from medical where medi_name = '" + textBox2.Text + "'");
                   cmd = new SqlCommand(query, conn);
                   sda = new SqlDataAdapter(cmd);
                   dt = new DataTable();
                   sda.Fill(dt);
                   sdr = cmd.ExecuteReader();

                   if (sdr.Read())
                   {
                       int nummed = Convert.ToInt32(sdr["medi_qty"].ToString());
                       int min = Convert.ToInt32(sdr["medi_min"].ToString());*/
                // int cut_stock = nummed - Convert.ToInt32(textBox3.Text);

                //    query = ("Update medicine_use set medi_use_status = 0 from treatment_record inner join medicine_use on medicine_use.treatr_id = treatment_record.treatr_id inner join medical on medical.medi_id = medicine_use.medi_id where medicine_use.medi_use_status = 2 AND treatment_record.treatr_id = '" + textBox4.Text + "' AND medical.medi_name = '" + textBox2.Text + "'");
                /*              query = ("Update medicine_use set medi_use_status = 0 from treatment_record inner join medicine_use on medicine_use.treatr_id = treatment_record.treatr_id inner join medical on medical.medi_id = medicine_use.medi_id where medicine_use.medi_use_status = 2 AND treatment_record.treatr_id = '" + txttrea.Text + "'");
                              cmd = new SqlCommand(query, conn);
                              sda = new SqlDataAdapter(cmd);
                              dt = new DataTable();
                              sda.Fill(dt);



                              clinic_pharmacist_service m3 = new clinic_pharmacist_service();
                              m3.Show();
                              clinic_pharmacist_service clnlog = new clinic_pharmacist_service();
                              clnlog.Close();
                              Visible = false;


                              MessageBox.Show("จ่ายยาเรียบร้อย");*/

                /*
                if (nummed < min)
                {
                    MessageBox.Show("ยาใกล้หมดคลังแล้ว");
                    query = ("Update medical set medi_qty = '" + nummed + "' where medi_name = '" + textBox2.Text + "'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);




                    query = ("Update medicine_use set medi_use_status = 0 from treatment_record inner join medicine_use on medicine_use.treatr_id = treatment_record.treatr_id inner join medical on medical.medi_id = medicine_use.medi_id where medicine_use.medi_use_status = 2 AND treatment_record.treatr_id = '" + textBox4.Text + "' AND medical.medi_name = '" + textBox2.Text + "'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);



                    clinic_pharmacist_service m3 = new clinic_pharmacist_service();
                    m3.Show();
                    clinic_pharmacist_service clnlog = new clinic_pharmacist_service();
                    clnlog.Close();
                    Visible = false;


                    MessageBox.Show("จ่ายยาเรียบร้อย");











                }
                else if (nummed < 0)
                {
                    MessageBox.Show("ยาหมดคลังแล้ว");

                }
                else if (nummed > min)
                {
                    query = ("Update medical set medi_qty = '" + nummed + "' where medi_name = '" + textBox2.Text + "'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);



                    query = ("Update medicine_use set medi_use_status = 0 from treatment_record inner join medicine_use on medicine_use.treatr_id = treatment_record.treatr_id inner join medical on medical.medi_id = medicine_use.medi_id where medicine_use.medi_use_status = 2 AND treatment_record.treatr_id = '" + textBox4.Text + "' AND medical.medi_name = '" + textBox2.Text + "'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);

                    clinic_pharmacist_service m3 = new clinic_pharmacist_service();
                    m3.Show();
                    clinic_pharmacist_service clnlog = new clinic_pharmacist_service();
                    clnlog.Close();
                    Visible = false;


                    MessageBox.Show("จ่ายยาเรียบร้อย");









                }else
                {
                    MessageBox.Show("ttttttttttt");
                }






            }
            */

                /*    }
                    else
                    {

                        MessageBox.Show("กรุณาเลือกยาที่จ่าย");
                        textBox4.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                    }
                    */


                /*       }else
                       {
                           MessageBox.Show("กรุณาเลือกยาที่จ่าย555555555");
                           textBox4.Text = "";
                           textBox2.Text = "";
                           textBox3.Text = "";
                       }*/
                //    }

                /*

                string query = ("select medi_qty from medical where medi_name = '" + textBox2.Text + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    int nummed = Convert.ToInt32(sdr["medi_qty"].ToString());
                    int cut_stock = nummed - Convert.ToInt32(textBox3.Text);
                    if (nummed < 5)
                    {
                        MessageBox.Show("ยาใกล้หมดคลังแล้ว");
                        query = ("Update medical set medi_qty = '" + cut_stock + "' where medi_name = '" + textBox2.Text + "'");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);

                        query = ("UPDATE medicine_use SET medi_use_status = 0 where treatr_id = '" + textBox4.Text + "' AND medi_use_id = '" + textBox1.Text + "'");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);

                        clinic_pharmacist_service m3 = new clinic_pharmacist_service();
                        m3.Show();
                        clinic_pharmacist_service clnlog = new clinic_pharmacist_service();
                        clnlog.Close();
                        Visible = false;


                        MessageBox.Show("จ่ายยาเรียบร้อย");

                    }
                    else if (nummed < 0)
                    {
                        MessageBox.Show("ยาหมดคลังแล้ว");

                    }
                    else if (nummed > 5)
                    {
                        query = ("Update medical set medi_qty = '" + cut_stock + "' where medi_name = '" + textBox2.Text + "'");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);

                        query = ("UPDATE medicine_use SET medi_use_status = 0 where treatr_id = '" + textBox4.Text + "' AND medi_use_id = '" + textBox1.Text + "'");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);

                        clinic_pharmacist_service m3 = new clinic_pharmacist_service();
                        m3.Show();
                        clinic_pharmacist_service clnlog = new clinic_pharmacist_service();
                        clnlog.Close();
                        Visible = false;


                        MessageBox.Show("จ่ายยาเรียบร้อย");


                    }





            }
                    */




                conn.Close();


            }
            catch (Exception)
            {
                MessageBox.Show("มีข้อผิดพลาด");
            }
         
        }

        private void mspToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clinic_pharmacist_ms cliapp = new clinic_pharmacist_ms();
            cliapp.Show();
        }

        private void txttrea_TextChanged(object sender, EventArgs e)
        {
           // conn.Open();


            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            string query = ("select medical.medi_name, medicine_use.medi_num,treatment_record.treatr_id, opd.opd_name from opd inner join treatment_record on treatment_record.opd_id = opd.opd_id inner join medicine_use on medicine_use.treatr_id = treatment_record.treatr_id inner join medical on medical.medi_id = medicine_use.medi_id where medicine_use.medi_use_status = 2 AND treatment_record.treatr_status = 3 AND treatment_record.treatr_id = '" + txttrea.Text + "'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView2.Rows.Add();


                dataGridView2.Rows[n].Cells[0].Value = item["treatr_id"].ToString();
           
                dataGridView2.Rows[n].Cells[1].Value = item["medi_name"].ToString();
                dataGridView2.Rows[n].Cells[2].Value = item["medi_num"].ToString();
         
                dataGridView2.Rows[n].Cells[3].Value = item["opd_name"].ToString();
            }









          //  conn.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView2.Rows[selectedRow];
          /*  textBox4.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();*/
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

   /*     private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {*/
 /*           try
            {
                selectedRow = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                lblname.Text = row.Cells[1].Value.ToString();
                lblnum.Text = row.Cells[2].Value.ToString();
                lblunit.Text = row.Cells[3].Value.ToString();

            }
            catch (Exception)
            {

            }
       */
            /*    if (count_medi < 5)
                {
                    MessageBox.Show("ยาใกล้หมดคลังแล้ว");


                }
                else if (count_medi < 0)
                {
                    MessageBox.Show("ยาหมดคลังแล้ว");

                }
                else if (count_medi > 5)
                {


                    MessageBox.Show("จ่ายยาเรียบร้อย");


                }
                else
                {
                    MessageBox.Show("ยายังไม่หมดคลัง");
                }
                */



    //    }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void clinic_pharmacist_service_Load(object sender, EventArgs e)
        {


            conn.Open();
            //******
            string query = ("select treatment_record.treatr_id,opd.opd_name,treatment_record.treatr_medi_queue from opd inner join treatment_record on treatment_record.opd_id = opd.opd_id where treatr_status = 3 ORDER BY treatr_medi_queue ASC");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                lblqueue.Text = (sdr["treatr_medi_queue"].ToString());
            }



            conn.Close();
            /*  conn.Open();

              string query = ("SELECT SUM(medi_qty) AS medical_count FROM medical");
              cmd = new SqlCommand(query, conn);
              sda = new SqlDataAdapter(cmd);
              dt = new DataTable();
              sda.Fill(dt);
              //  sdr = cmd.ExecuteReader();
              int count = (int)cmd.ExecuteScalar();
              label6.Text = "" + count;
              if (count < 5)
              {
                  MessageBox.Show("ยาใกล้หมดคลังแล้ว");


              }
              else if (count < 0)
              {
                  MessageBox.Show("ยาหมดคลังแล้ว");
              }
              else if (count > 5)
              {
                  MessageBox.Show("จ่ายยาได้ตามปกติ");
              }





              conn.Close();*/
        }

    /*    private void lblnum_TextChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(lblnum.Text);
            string unit_medi = lblunit.Text;
            if(unit_medi == "เม็ด")
            {
                if (num < 5)
                {
                    MessageBox.Show("ยาใกล้หมดคลังแล้ว");


                }
                else if (num < 0)
                {
                    MessageBox.Show("ยาหมดคลังแล้ว");
                }
                else if (num > 5)
                {
                    MessageBox.Show("จ่ายยาได้ตามปกติ");
                }


            }
            else if (unit_medi == "ขวด")
            {

                if (num < 2)
                {
                    MessageBox.Show("ยาใกล้หมดคลังแล้ว");


                }
                else if (num < 0)
                {
                    MessageBox.Show("ยาหมดคลังแล้ว");
                }
                else if (num > 2)
                {
                    MessageBox.Show("จ่ายยาได้ตามปกติ");
                }


            }
            else if(unit_medi == "ถุงเล็ก")
            {
                if (num < 2)
                {
                    MessageBox.Show("ยาใกล้หมดคลังแล้ว");


                }
                else if (num < 0)
                {
                    MessageBox.Show("ยาหมดคลังแล้ว");
                }
                else if (num > 2)
                {
                    MessageBox.Show("จ่ายยาได้ตามปกติ");
                }

            }
            else if (unit_medi == "ชิ้น")
            {
                if (num < 2)
                {
                    MessageBox.Show("ยาใกล้หมดคลังแล้ว");


                }
                else if (num < 0)
                {
                    MessageBox.Show("ยาหมดคลังแล้ว");
                }
                else if (num > 2)
                {
                    MessageBox.Show("จ่ายยาได้ตามปกติ");
                }

            }
            else if (unit_medi == "กล่อง")
            {
                if (num < 5)
                {
                    MessageBox.Show("ยาใกล้หมดคลังแล้ว");


                }
                else if (num < 0)
                {
                    MessageBox.Show("ยาหมดคลังแล้ว");
                }
                else if (num > 5)
                {
                    MessageBox.Show("จ่ายยาได้ตามปกติ");
                }

            }
            else if (unit_medi == "ซอง")
            {
                if (num < 4)
                {
                    MessageBox.Show("ยาใกล้หมดคลังแล้ว");


                }
                else if (num < 0)
                {
                    MessageBox.Show("ยาหมดคลังแล้ว");
                }
                else if (num > 4)
                {
                    MessageBox.Show("จ่ายยาได้ตามปกติ");
                }

            }
            else if (unit_medi == "แผง")
            {
                if (num < 2)
                {
                    MessageBox.Show("ยาใกล้หมดคลังแล้ว");


                }
                else if (num < 0)
                {
                    MessageBox.Show("ยาหมดคลังแล้ว");
                }
                else if (num > 2)
                {
                    MessageBox.Show("จ่ายยาได้ตามปกติ");
                }

            }
       
        }*/

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clinic_pharmacist_report cliapp = new clinic_pharmacist_report();
            cliapp.Show();
        }

        private void lblqueue_TextChanged(object sender, EventArgs e)
        {
     
            string query = ("select treatment_record.treatr_id,opd.opd_name,treatment_record.treatr_medi_queue,opd.opd_id from opd inner join treatment_record on treatment_record.opd_id = opd.opd_id where treatr_status = 3 ORDER BY treatr_medi_queue ASC");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                txttrea.Text = (sdr["treatr_id"].ToString());
                txtopdid.Text = (sdr["opd_id"].ToString());
            }

        }

        private void txtopdid_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                dataGridView3.Rows.Clear();
                dataGridView3.Refresh();

                string query = ("select treatment_record.treatr_id,opd.opd_name from opd inner join treatment_record on treatment_record.opd_id = opd.opd_id where treatr_status = 2 AND treatr_id LIKE '%" + textBox1.Text + "%'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView3.Rows.Add();



                    dataGridView3.Rows[n].Cells[0].Value = item["treatr_id"].ToString();
                    dataGridView3.Rows[n].Cells[1].Value = item["opd_name"].ToString();


                }





      


            }
            catch (Exception)
            {

            }
  
        }
    }
}
