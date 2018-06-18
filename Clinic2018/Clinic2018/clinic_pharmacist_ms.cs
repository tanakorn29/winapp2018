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
    public partial class clinic_pharmacist_ms : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-J5O17QF\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        public clinic_pharmacist_ms()
        {
            InitializeComponent();
            conn.Open();
            string query = (" select medi_name,medi_no,medi_qty,medi_unit,medi_price_unit,medi_price from medical");
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
                //  dataGridView1.Rows[n].Cells[4].Value = item["room_id"].ToString();


            }




            conn.Close();
        }
        int selectedRow;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            lblmedi.Text = row.Cells[0].Value.ToString();
            lblcount.Text = row.Cells[2].Value.ToString();
            lblmediunit.Text = row.Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                int qty = Convert.ToInt32(lblcount.Text);
                int sub = qty + Convert.ToInt32(textBox1.Text);
                string query = ("UPDATE medical SET medi_qty = '" + sub + "'  WHERE medi_name = '" + lblmedi.Text + "'");
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
            catch (Exception ex)
            {
                MessageBox.Show("มีข้อผิดพลาด");
            }
   

            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
         
                string namemedi = txtmedi.Text;
                int medi_no = Convert.ToInt32(txtmedino.Text);
                int medi_num = Convert.ToInt32(txtmedinum.Text);
                string type_me = textBox2.Text; 
                string unit_medi = txtmediunit.Text;
                double unit_price = Convert.ToDouble(txtpriceunit.Text);
                double price = Convert.ToDouble(txtprice.Text);
                string query = ("insert into medical (medi_name,medi_no,medi_qty_type,medi_qty,medi_unit,medi_price_unit,medi_price) values ('" + namemedi+"','"+medi_no+"','"+ type_me + "','"+ medi_num + "','"+ unit_medi+"','"+unit_price+"','"+price+"')");
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

         


            conn.Close();
        }

        private void clinic_pharmacist_ms_Load(object sender, EventArgs e)
        {
          //  MessageBox.Show("Test");
        }
    }
}
