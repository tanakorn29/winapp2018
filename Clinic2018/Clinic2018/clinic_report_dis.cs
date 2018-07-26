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
    public partial class clinic_report_dis : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-92251HH\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets=true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
        public clinic_report_dis()
        {
            InitializeComponent();
            conn.Open();

            string query = ("select disease_group.disease_group_id,disease_group.disease_group,disease.disease,count(treatment_record.disease_id) from disease_group inner join disease on disease.disease_group_id = disease_group.disease_group_id inner join treatment_record on treatment_record.disease_id = disease.disease_id group by disease_group.disease_group_id,disease_group.disease_group,disease.disease");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                int group_id = sdr.GetInt32(0);
                string group_name = sdr.GetString(1);
                string dis_name= sdr.GetString(2);
                int count = sdr.GetInt32(3);
                listView1.Items.Add(group_id + Environment.NewLine + group_name + Environment.NewLine + dis_name + Environment.NewLine + count);

            }



            conn.Close();
        }

        private void clinic_report_dis_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
