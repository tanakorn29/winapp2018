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
    public partial class clinic_pharmacist : Form
    {
        public clinic_pharmacist()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clinic_login log = new clinic_login();
            log.Show();
            clinic_pharmacist main = new clinic_pharmacist();
            main.Close();
            Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           clinic_pharmacist_service log = new clinic_pharmacist_service();
            log.Show();
        }
    }
}
