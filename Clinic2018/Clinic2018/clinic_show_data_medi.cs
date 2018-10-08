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
    public partial class clinic_show_data_medi : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-92251HH\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
        public clinic_show_data_medi()
        {
            InitializeComponent();
            conn.Open();
           string query = ("select medicine_use.medi_use_date,medical.medi_name from medicine_use inner join medical on medical.medi_id = medicine_use.medi_id where medi_use_status = 0");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();

                System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("th-TH");

            
               

                DateTime app_date = Convert.ToDateTime(item["medi_use_date"].ToString());

                string date_app = String.Format("{0:yyyy-MM-dd}", app_date);
                string date_th = app_date.ToString("yyyy-MM-dd");
                dataGridView1.Rows[n].Cells[0].Value = date_th;

                dataGridView1.Rows[n].Cells[1].Value = item["medi_name"].ToString();
  
     

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clinic_show_data_medi_Load(object sender, EventArgs e)
        {

        }
    }
}
