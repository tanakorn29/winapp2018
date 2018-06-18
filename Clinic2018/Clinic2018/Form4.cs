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
    public partial class Form4 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-26BM5UJ\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
        public Form4()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = ("Update schedule_work_doctor set swd_note = '" + comboBox1.SelectedItem.ToString() + "'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
        
            MessageBox.Show("เปลี่ยนสถานะ  " + comboBox1.SelectedItem.ToString() + "  เรียบร้อย");
        }
    }
}
