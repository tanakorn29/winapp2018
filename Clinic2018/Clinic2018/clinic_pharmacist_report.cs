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
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-BP7LPPN\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;

        public clinic_pharmacist_report()
        {
            InitializeComponent();
            conn.Open();
           string query = ("select medi_id,medi_name,medi_date_by from medical where medi_qty <= 2 AND medi_qty <= 4 AND medi_qty <= 5");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();



                dataGridView1.Rows[n].Cells[0].Value = item["medi_id"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["medi_name"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["medi_date_by"].ToString();
    
            }





            conn.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
