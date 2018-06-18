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
    public partial class Form7 : Form
    {
        Timer t = new Timer();

        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = label2.Text;

         

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();

            //double aa = Convert.ToDouble(label1.Text);
            string time = label1.Text;
            if (time == "19.35")
            {
                label2.Text = "เช้า";
            //    MessageBox.Show("เช้า");

            }
            else if (time == "19.36")
            {
                label2.Text = "บ่าย";
              //  MessageBox.Show("บ่าย");
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_TextChanged(object sender, EventArgs e)
        {

            double aa = Convert.ToDouble(label1.Text);
            string time = label1.Text;
            if (aa <= 20.09)
            {
                label2.Text = "เช้า";
                //    MessageBox.Show("เช้า");

            }
            else if (aa >= 20.10)
            {
                label2.Text = "บ่าย";
                //  MessageBox.Show("บ่าย");
            }
        }
    }
}
