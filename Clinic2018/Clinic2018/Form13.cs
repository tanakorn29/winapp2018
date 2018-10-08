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
    public partial class Form13 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-92251HH\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets=true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            conn.Open();

           string query = ("select disease from disease where disease LIKE '%" + textBox1.Text + "%'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                string test = sdr.GetString(0);

                MyCollection.Add(test);
            }

            textBox1.AutoCompleteCustomSource = MyCollection;

            query = ("select symtoms_dis  from symtoms  inner join disease on disease.disease_id = symtoms.disease_id where symtoms_dis LIKE '%" + textBox2.Text + "%'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                string test = sdr.GetString(0);

                MyCollection.Add(test);
            }

            textBox2.AutoCompleteCustomSource = MyCollection;

            /*
                   string query = ("select symtoms_dis  from symtoms  inner join disease on disease.disease_id = symtoms.disease_id where symtoms_dis LIKE '%" + textBox1.Text + "%'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);

                    while (sdr.Read())
                    {
                        string disease = sdr.GetString(0);

                        MyCollection.Add(disease);
                    }
                    textBox1.AutoCompleteCustomSource = MyCollection;
        */

            conn.Close();
        
        }
    }
}
