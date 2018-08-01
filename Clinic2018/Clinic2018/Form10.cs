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
    public partial class Form10 : Form
    {
        Timer t = new Timer();
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            //   int ss = DateTime.Now.Second;

            String time = "";

            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ".";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            /*
            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }
            */
            label1.Text = time;

        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            double time = Convert.ToDouble(label1.Text);
            if (time >= 08.00 && time <= 12.00)
            {
                label2.Text = "เช้า";
            }
            else if (time >= 12.01 && time <= 15.30)
            {
                label2.Text = "บ่าย";
            }else
            {
                label2.Text = "";
            }
        }
    }
}
