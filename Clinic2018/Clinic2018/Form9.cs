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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int A = Convert.ToInt32(textBox1.Text);
            int B = Convert.ToInt32(textBox2.Text);

            int div = A - B;

            if(A < B)
            {
                MessageBox.Show("ยาเกินกำหนด");
            }
            else
            {
                MessageBox.Show("Stock");
            }
        //    MessageBox.Show(""+div);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int A = Convert.ToInt32(textBox3.Text);
            int B = Convert.ToInt32(textBox4.Text);
            if(A < 120  && B < 80)
            {
                MessageBox.Show("ปกติ");
            }else if (A < 129  &&  B < 84)
            {
                MessageBox.Show("ค่อนข้างสูง");
            }else if (A < 139  &&  B < 89)
            {
                MessageBox.Show("สูงกว่าปกติ");
            }
            else if (A < 159  &&  B < 99)
            {
                MessageBox.Show("ความดันโลหิตสูงระดับ 1");
            }else if (A > 160 && B < 109)
            {
                MessageBox.Show("ความดันโลหิตสูงระดับ 2");
            }else
            {
                MessageBox.Show("ไม่สามารถวัดความดันโลหิตได้");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            double A = Convert.ToDouble(textBox5.Text);
            double B = Convert.ToDouble(textBox6.Text);
            double k = B * B;
            double h = A/k;

          double r = h;
            if (h < 18.5)
            {
                MessageBox.Show("ผอมเกินไป");
            }else if (h < 22.9)
            {
                MessageBox.Show("น้ำหนักปกติ เหมาะสม");
            }else if (h < 24.9)
            {
                MessageBox.Show("น้ำหนักเกิน");
            }
            else if (h < 29.9)
            {
                MessageBox.Show("อ้วน");
            }
            else if (h > 30)
            {
                MessageBox.Show("อ้วนมาก");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox7.Text == "")
            {
                MessageBox.Show("ข้อมูลว่าง");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
