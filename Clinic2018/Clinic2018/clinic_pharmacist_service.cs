using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic2018
{
    public partial class clinic_pharmacist_service : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-J5O17QF\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets=true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
        public clinic_pharmacist_service()
        {
            InitializeComponent();
            conn.Open();
            string  query = ("select treatment_record.treatr_id,opd.opd_name,treatment_record.treatr_medi_queue from opd inner join treatment_record on treatment_record.opd_id = opd.opd_id where treatr_status = 2");
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

            }

            query = ("select medi_id,medi_name,medi_qty,medi_unit,medi_qty_type from medical");
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
                dataGridView1.Rows[n].Cells[4].Value = item["medi_qty_type"].ToString();

            }

 
            conn.Close();
        }
        int selectedRow;
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView3.Rows[selectedRow];

        //    textBox1.Text = row.Cells[0].Value.ToString();
          //  textBox2.Text = row.Cells[1].Value.ToString();
            // textBox3.Text = row.Cells[2].Value.ToString();
            txttrea.Text = row.Cells[0].Value.ToString();
          //  textBox4.Text = row.Cells[0].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();

            string query = ("select count(*) from treatment_record inner join appointment on appointment.opd_id = treatment_record.opd_id where treatr_id = '"+textBox4.Text+"' AND status_approve = 1");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            int app_count = (int)cmd.ExecuteScalar();
            if(app_count == 1)
            {
                MessageBox.Show("มีการนัดหมาย");
            }else
            {
                query = ("select count(*) from opd inner join treatment_record on treatment_record.opd_id = opd.opd_id inner join medicine_use on medicine_use.treatr_id = treatment_record.treatr_id inner join medical on medical.medi_id = medicine_use.medi_id where medicine_use.medi_use_status = 2 AND treatment_record.treatr_id = '" + txttrea.Text + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                int count_app = (int)cmd.ExecuteScalar();
                if (count_app > 0)
                {
                    query = ("Select count(*) from treatment_record inner join medicine_use on medicine_use.treatr_id = treatment_record.treatr_id inner join medical on medical.medi_id = medicine_use.medi_id where medicine_use.medi_use_status = 2 AND treatment_record.treatr_id =  '" + txttrea.Text + "' AND medical.medi_name = '" + textBox2.Text + "'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);

                    int count_select = (int)cmd.ExecuteScalar();
                    if (count_select == 1)
                    {
                        query = ("select medi_qty from medical where medi_name = '" + textBox2.Text + "'");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);
                        sdr = cmd.ExecuteReader();

                        if (sdr.Read())
                        {
                            int nummed = Convert.ToInt32(sdr["medi_qty"].ToString());
                            // int cut_stock = nummed - Convert.ToInt32(textBox3.Text);
                            if (nummed < 5)
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
                            else if (nummed > 5)
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









                            }






                        }

                    }
                    else
                    {

                        MessageBox.Show("กรุณาเลือกยาที่จ่าย");
                    }
                        
       

                }
                else
                {
                    query = ("Update treatment_record set treatr_status = 0 where treatr_id = '"+ txttrea.Text + "'");
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
      
            }

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

        private void mspToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clinic_pharmacist_ms cliapp = new clinic_pharmacist_ms();
            cliapp.Show();
        }

        private void txttrea_TextChanged(object sender, EventArgs e)
        {
            conn.Open();


            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            string query = ("select medical.medi_name, medicine_use.medi_num,treatment_record.treatr_id, opd.opd_name from opd inner join treatment_record on treatment_record.opd_id = opd.opd_id inner join medicine_use on medicine_use.treatr_id = treatment_record.treatr_id inner join medical on medical.medi_id = medicine_use.medi_id where medicine_use.medi_use_status = 2 AND treatment_record.treatr_id = '"+ txttrea.Text + "'");
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









            conn.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView2.Rows[selectedRow];
            textBox4.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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



        }

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

        private void lblnum_TextChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(lblnum.Text);
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
    }
}
