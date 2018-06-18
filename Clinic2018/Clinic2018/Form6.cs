using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic2018
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //   DateTime date1 = new DateTime(DateTimePickerFormat.Custom);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //    dateTimePicker1.CustomFormat = "dddd";
           string day = dateTimePicker1.Value.ToString("dddd");
            string month = dateTimePicker1.Value.ToString("MMMM");
            string year = dateTimePicker1.Value.ToString("yyyy");
            MessageBox.Show(year);
        }

        private void Form6_Load(object sender, EventArgs e)
        {
          //  dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //dateTimePicker1.CustomFormat = "dddd d MMMM yyyy";
        }
    }
}
