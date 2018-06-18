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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbltest.Text = comboBox1.SelectedItem.ToString();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("HTML");
            comboBox1.SelectedIndex = 0;
        }
    }
}
