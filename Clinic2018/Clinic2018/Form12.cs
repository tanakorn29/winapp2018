using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic2018
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime d1 = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime d2 = Convert.ToDateTime(dateTimePicker2.Text);
            if(d1.Date >= d2.Date)
            {
                MessageBox.Show("จัดเวรไม่ได้" +d1.Date + "   " + d2.Date);
            }else
            {

                MessageBox.Show("จัดเวรได้" + d1.Date + "   " + d2.Date);
            }
        }
    }
}
