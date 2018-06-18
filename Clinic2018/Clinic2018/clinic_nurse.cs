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
    public partial class clinic_nurse : Form
    {
        public clinic_nurse()
        {
            InitializeComponent();
        }

        private void clinic_nurse_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clinc_nurse_service ser = new clinc_nurse_service();
            ser.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clinic_login log = new clinic_login();
            log.Show();
            clinic_nurse main = new clinic_nurse();
            main.Close();
            Visible = false;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clinic_app_service ser = new clinic_app_service();
            ser.Show();
        }
    }
}
