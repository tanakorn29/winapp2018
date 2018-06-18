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
    public partial class Clinic_boss : Form
    {
        public Clinic_boss()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clinic_user_control user = new clinic_user_control();
            user.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clinic_login log = new clinic_login();
            log.Show();
            Clinic_boss main = new Clinic_boss();
            main.Close();
            Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clinic_calendar user = new clinic_calendar();
            user.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
