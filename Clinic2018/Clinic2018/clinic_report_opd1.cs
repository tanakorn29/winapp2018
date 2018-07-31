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
    public partial class clinic_report_opd1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-92251HH\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets=true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
        public clinic_report_opd1()
        {
            InitializeComponent();
            conn.Open();
        
            string query = ("select position.pos_name,COUNT(treatment_record.opd_id) from position inner join opd on opd.pos_id = position.pos_id inner join treatment_record on treatment_record.opd_id = opd.opd_id GROUP BY pos_name");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            sdr = cmd.ExecuteReader();
            
                while (sdr.Read())
                {
                
                    int n = dataGridView1.Rows.Add();
                    string pos_name = sdr.GetString(0);

                    int id = sdr.GetInt32(1);
                    string POS = Convert.ToString(id);

                    dataGridView1.Rows[n].Cells[0].Value = pos_name;
                    dataGridView1.Rows[n].Cells[1].Value = POS;
                    //     listView1.Items.Add(pos_name + Environment.NewLine + id);

                
                }   




            /*
                while (sdr.Read())
            {
                string pos_name = sdr.GetString(0);

                int id = sdr.GetInt32(1);
                listView1.Items.Add(pos_name +  Environment.NewLine + id );

            }

    */

            conn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clinic_report_opd1_Load(object sender, EventArgs e)
        {

        }
    }
}
