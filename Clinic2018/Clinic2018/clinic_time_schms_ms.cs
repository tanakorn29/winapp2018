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
    public partial class clinic_time_schms_ms : Form
    {
        public clinic_time_schms_ms()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            clinic_room1_now doc1 = new clinic_room1_now();
            doc1.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            clinic_room2_now doc1 = new clinic_room2_now();
            doc1.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            clinic_room3_now doc1 = new clinic_room3_now();
            doc1.Show();
        }
    }
}
