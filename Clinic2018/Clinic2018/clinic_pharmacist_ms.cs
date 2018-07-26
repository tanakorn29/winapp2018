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

        public clinic_pharmacist_ms()
        {
            InitializeComponent();
            conn.Open();
            string query = (" select medi_name,medi_no,medi_qty,medi_unit,medi_price_unit,medi_price,medi_date_x,medi_date_by  from medical");
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

                CultureInfo ThaiCulture = new CultureInfo("th-TH");

                DateTime date_start = Convert.ToDateTime(dateTimePicker1.Text);
                DateTime date_end = Convert.ToDateTime(dateTimePicker2.Text);
                string start = date_start.ToString("yyyy-MM-dd", ThaiCulture);
                string end = date_end.ToString("yyyy-MM-dd", ThaiCulture);

                int qty = Convert.ToInt32(lblcount.Text);
                int sub = qty + Convert.ToInt32(textBox1.Text);
                string query = ("UPDATE medical SET medi_qty = '" + sub + "',medi_date_x = '"+start+"',medi_date_by = '"+end+"'   WHERE medi_name = '" + lblmedi.Text + "'");
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
          CultureInfo ThaiCulture = new CultureInfo("th-TH");
            DateTime date_start = Convert.ToDateTime(dateTimePicker4.Text);
            DateTime date_end = Convert.ToDateTime(dateTimePicker3.Text);
            string start = date_start.ToString("yyyy-MM-dd", ThaiCulture);
            string end = date_end.ToString("yyyy-MM-dd", ThaiCulture);
            string namemedi = txtmedi.Text;
                int medi_no = Convert.ToInt32(txtmedino.Text);
                int medi_num = Convert.ToInt32(txtmedinum.Text);
                string type_me = textBox2.Text; 
                string unit_medi = comboBox1.SelectedItem.ToString();
                double unit_price = Convert.ToDouble(txtpriceunit.Text);
                double price = Convert.ToDouble(txtprice.Text);
                string query = ("insert into medical (medi_name,medi_no,medi_qty_type,medi_qty,medi_unit,medi_price_unit,medi_price,medi_date_x,medi_date_by) values ('" + namemedi+"','"+medi_no+"','"+ type_me + "','"+ medi_num + "','"+ unit_medi+"','"+unit_price+"','"+price+"','"+start+"','"+end+"')");
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
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";

            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "yyyy-MM-dd";

            dateTimePicker4.Format = DateTimePickerFormat.Custom;
            dateTimePicker4.CustomFormat = "yyyy-MM-dd";
        }
    }
}
