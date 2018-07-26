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
    public partial class clinic_pharmacist_report : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-92251HH\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;

        public clinic_pharmacist_report()
        {
            InitializeComponent();
            conn.Open();
         





            conn.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            if(comboBox1.SelectedItem.ToString() == "เม็ด")
            {
                string query = ("select medi_id,medi_name,medi_date_by from medical where  medi_qty <= 5 AND medi_unit = 'เม็ด'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();



                    dataGridView1.Rows[n].Cells[0].Value = item["medi_id"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item["medi_name"].ToString();

                    DateTime app_date = Convert.ToDateTime(item["medi_date_by"].ToString());

                    string date_app = String.Format("{0:yyyy-MM-dd}", app_date);

                    dataGridView1.Rows[n].Cells[2].Value = date_app;

                }
            }
            else if (comboBox1.SelectedItem.ToString() == "ขวด")
            {
                string query = ("select medi_id,medi_name,medi_date_by from medical where  medi_qty <= 2 AND medi_unit = 'ขวด'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();



                    dataGridView1.Rows[n].Cells[0].Value = item["medi_id"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item["medi_name"].ToString();

                    DateTime app_date = Convert.ToDateTime(item["medi_date_by"].ToString());

                    string date_app = String.Format("{0:yyyy-MM-dd}", app_date);

                    dataGridView1.Rows[n].Cells[2].Value = date_app;

                }
            }
            else if (comboBox1.SelectedItem.ToString() == "ถุงเล็ก")
            {
                string query = ("select medi_id,medi_name,medi_date_by from medical where  medi_qty <= 2 AND medi_unit = 'ถุงเล็ก'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();



                    dataGridView1.Rows[n].Cells[0].Value = item["medi_id"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item["medi_name"].ToString();

                    DateTime app_date = Convert.ToDateTime(item["medi_date_by"].ToString());

                    string date_app = String.Format("{0:yyyy-MM-dd}", app_date);

                    dataGridView1.Rows[n].Cells[2].Value = date_app;

                }
            }
            else if (comboBox1.SelectedItem.ToString() == "ชิ้น")
            {
                string query = ("select medi_id,medi_name,medi_date_by from medical where  medi_qty <= 2 AND medi_unit = 'ชิ้น'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();



                    dataGridView1.Rows[n].Cells[0].Value = item["medi_id"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item["medi_name"].ToString();

                    DateTime app_date = Convert.ToDateTime(item["medi_date_by"].ToString());

                    string date_app = String.Format("{0:yyyy-MM-dd}", app_date);

                    dataGridView1.Rows[n].Cells[2].Value = date_app;

                }
            }
            else if (comboBox1.SelectedItem.ToString() == "ซอง")
            {
                string query = ("select medi_id,medi_name,medi_date_by from medical where  medi_qty <= 4 AND medi_unit = 'ซอง'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();



                    dataGridView1.Rows[n].Cells[0].Value = item["medi_id"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item["medi_name"].ToString();

                    DateTime app_date = Convert.ToDateTime(item["medi_date_by"].ToString());

                    string date_app = String.Format("{0:yyyy-MM-dd}", app_date);

                    dataGridView1.Rows[n].Cells[2].Value = date_app;

                }
            }
            else if (comboBox1.SelectedItem.ToString() == "แผง")
            {
                string query = ("select medi_id,medi_name,medi_date_by from medical where  medi_qty <= 2 AND medi_unit = 'แผง'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();



                    dataGridView1.Rows[n].Cells[0].Value = item["medi_id"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item["medi_name"].ToString();

                    DateTime app_date = Convert.ToDateTime(item["medi_date_by"].ToString());

                    string date_app = String.Format("{0:yyyy-MM-dd}", app_date);

                    dataGridView1.Rows[n].Cells[2].Value = date_app;

                }
            }
            else if (comboBox1.SelectedItem.ToString() == "กล่อง")
            {
                string query = ("select medi_id,medi_name,medi_date_by from medical where  medi_qty <= 5 AND medi_unit = 'กล่อง'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();



                    dataGridView1.Rows[n].Cells[0].Value = item["medi_id"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item["medi_name"].ToString();

                    DateTime app_date = Convert.ToDateTime(item["medi_date_by"].ToString());

                    string date_app = String.Format("{0:yyyy-MM-dd}", app_date);

                    dataGridView1.Rows[n].Cells[2].Value = date_app;

                }
            }







            conn.Close();
        }
    }
}
