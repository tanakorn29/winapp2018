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
    public partial class Clinic_doctor2 : Form
    {
        public Clinic_doctor2()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clinic_login log = new clinic_login();
            log.Show();
            Clinic_doctor main = new Clinic_doctor();
            main.Close();
            Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clinic_doctor_service2 ser = new clinic_doctor_service2();
            ser.Show();
        }
    }
}
