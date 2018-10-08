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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date1 = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime date2 = Convert.ToDateTime(dateTimePicker2.Text);

            if (date1 < date2)
            {
                MessageBox.Show("น้อยกว่า");
            }
            else if(date1 > date2)
            {
                MessageBox.Show("มากกว่า");
            }
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";

        }
    }
}
