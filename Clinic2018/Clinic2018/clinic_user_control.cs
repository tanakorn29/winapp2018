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
    public partial class clinic_user_control : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-J5O17QF\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets=true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        public clinic_user_control()
        {
            InitializeComponent();
            string query = ("select employee_ru.emp_ru_id,employee_ru.emp_ru_name,employee_ru.emp_ru_birthday,employee_ru.emp_ru_idcard,position.pos_name from employee_ru inner join position on position.pos_id = employee_ru.pos_id");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();



                dataGridView1.Rows[n].Cells[0].Value = item["emp_ru_id"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["emp_ru_name"].ToString();
               DateTime  birthday = Convert.ToDateTime(item["emp_ru_birthday"].ToString());
               string date_birth = String.Format("{0:yyyy-MM-dd}", birthday);
                dataGridView1.Rows[n].Cells[2].Value = date_birth;

                dataGridView1.Rows[n].Cells[3].Value = item["emp_ru_idcard"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["pos_name"].ToString();
         
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = ("Insert into user_control(uct_user, uct_password, emp_ru_id) values('"+lblidcard.Text+"', '"+lblbirthday.Text+"', '"+lblempid.Text+"'); ");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();

            sda.Fill(dt);

             query = ("Insert into privilege(privil_status,emp_ru_idcard, emp_ru_id) values('','" + lblidcard.Text+"', '"+lblempid.Text+"'); ");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();

            sda.Fill(dt);
            conn.Close();
            MessageBox.Show("เพิ่มข้อมูลเข้าใช้งานเรียบร้อย");
        }
        int selectedRow;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            lblempid.Text = row.Cells[0].Value.ToString();
            lblidcard.Text = row.Cells[3].Value.ToString();
            lblbirthday.Text = row.Cells[2].Value.ToString();
        }
    }
}
