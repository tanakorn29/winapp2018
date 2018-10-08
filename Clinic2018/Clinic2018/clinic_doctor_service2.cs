using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic2018
{
    public partial class clinic_doctor_service2 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-92251HH\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets=true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
        Timer t = new Timer();
        public clinic_doctor_service2()
        {
            InitializeComponent();
            conn.Open();
            string today = DateTime.Now.ToString("yyyy-MM-dd", new CultureInfo("th-TH"));
            string query = ("select queue_diag_room.qdr_record,queue_diag_room.qdr_date,queue_diag_room.qdr_time_sent,schedule_work_doctor.room_id,employee_doctor.emp_doc_name,employee_doctor.emp_doc_id,opd.opd_id,opd.opd_name,position.pos_name from queue_diag_room inner join opd on opd.opd_id = queue_diag_room.opd_id inner join schedule_work_doctor on schedule_work_doctor.swd_id = queue_diag_room.swd_id inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id inner join position on position.pos_id = opd.pos_id where  queue_diag_room.status_queue = 1 AND room_id = 2 AND queue_diag_room.qdr_date = '" + today + "' ");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();



                dataGridView1.Rows[n].Cells[0].Value = item["qdr_record"].ToString();

                DateTime date_qdr = Convert.ToDateTime(item["qdr_date"].ToString());
                string qdr_date = date_qdr.ToString("yyyy-MM-dd");

                dataGridView1.Rows[n].Cells[1].Value = qdr_date;
                dataGridView1.Rows[n].Cells[2].Value = item["qdr_time_sent"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["room_id"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["emp_doc_name"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item["emp_doc_id"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item["opd_id"].ToString();
                dataGridView1.Rows[n].Cells[7].Value = item["opd_name"].ToString();
                dataGridView1.Rows[n].Cells[8].Value = item["pos_name"].ToString();
            }
            /*
            query = ("select disease from disease");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                // int n = dataGridView1.Rows.Add();

                comboBox1.Items.Add(item["disease"].ToString());


            }
            */
            query = ("select medi_id,medi_name,medi_qty,medi_unit from medical");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView2.Rows.Add();



                dataGridView2.Rows[n].Cells[0].Value = item["medi_id"].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item["medi_name"].ToString();
                dataGridView2.Rows[n].Cells[2].Value = item["medi_qty"].ToString();
                dataGridView2.Rows[n].Cells[3].Value = item["medi_unit"].ToString();

            }




            conn.Close();
        }
        int selectedRow;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            lblopdid.Text = row.Cells[6].Value.ToString();
            lblsername.Text = row.Cells[7].Value.ToString();
            // lblopd.Text = row.Cells[7].Value.ToString();
            txtdocid.Text = row.Cells[5].Value.ToString();
            string position = row.Cells[8].Value.ToString();
            lblposition.Text = position;
            */
        }

        private void lblopdid_Click(object sender, EventArgs e)
        {

        }

        private void lblopdid_TextChanged(object sender, EventArgs e)
        {
     
            string query = ("select visit_record.vr_id,visit_record.vr_weight,visit_record.vr_height,visit_record.vr_systolic,visit_record.vr_diastolic,visit_record.vr_hearth_rate,visit_record.vr_date,visit_record.vr_remark,visit_record.opd_id from visit_record where opd_id = '" + lblopdid.Text + "' AND vr_status = 1 ORDER BY vr_id DESC");
            cmd = new SqlCommand(query, conn);

            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {

                txtw.Text = (sdr["vr_weight"].ToString());
                txth.Text = (sdr["vr_height"].ToString());
                txts.Text = (sdr["vr_systolic"].ToString());
                txtd.Text = (sdr["vr_diastolic"].ToString());
                txthert.Text = (sdr["vr_hearth_rate"].ToString());
                txtremark.Text = (sdr["vr_remark"].ToString());





            }

       

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string query = ("select count(treatr_symptom) from treatment_record where emp_doc_id = '"+txtdocid.Text+"' AND opd_id = '"+lblopdid.Text+"' AND treatr_status = 1");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                int ss_count = (int)cmd.ExecuteScalar();
                if (ss_count < 1)
                {
                    if (textBox1.Text == "" || txtdis.Text == "" || txtiddis.Text == "")
                    {
                        MessageBox.Show("กรุณากรอกข้อมูลการรักษาและวินิจฉัยโรค", "สถานะ");
                    }
                    else
                    {
                        string today = DateTime.Now.ToString("yyyy-MM-dd", new CultureInfo("th-TH"));
                        query = ("select count(disease_id)  from symtoms where symtoms_dis = '" + txtremark.Text + "'");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);

                        int s_count = (int)cmd.ExecuteScalar();
                        if (s_count < 1)
                        {
                            query = ("insert into treatment_record (treatr_symptom,treatr_diagnose,treatr_status,disease_id,emp_doc_id,opd_id) values ('" + textBox1.Text + "','" + txtdis.Text + "',1,'" + txtiddis.Text + "','" + txtdocid.Text + "','" + lblopdid.Text + "')");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();

                            sda.Fill(dt);


                            query = ("select employee_doctor.emp_doc_specialistid from employee_doctor where employee_doctor.emp_doc_id = '" + txtdocid.Text + "'");
                            //  
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);
                            sdr = cmd.ExecuteReader();

                            if (sdr.Read())
                            {
                                int id = Convert.ToInt32(sdr["emp_doc_specialistid"].ToString());
                                query = ("insert into symtoms(symtoms_dis,emp_doc_specialistid,disease_id) values ('" + textBox1.Text + "','" + id + "','" + txtiddis.Text + "');");
                                //  
                                cmd = new SqlCommand(query, conn);
                                sda = new SqlDataAdapter(cmd);
                                dt = new DataTable();
                                sda.Fill(dt);

                            }


                            query = ("Update symtoms set disease_id = '" + txtiddis.Text + "' where symtoms_dis = '" + txtremark.Text + "' ");
                            //  
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);


                        }
                        else
                        {


                            query = ("select count(*)  from symtoms where symtoms_dis = '" + textBox1.Text + "'");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);

                            int s_count1 = (int)cmd.ExecuteScalar();
                            if (s_count1 < 1)
                            {
                                query = ("insert into treatment_record (treatr_symptom,treatr_diagnose,treatr_status,disease_id,emp_doc_id,opd_id) values ('" + textBox1.Text + "','" + txtdis.Text + "',1,'" + txtiddis.Text + "','" + txtdocid.Text + "','" + lblopdid.Text + "')");
                                cmd = new SqlCommand(query, conn);
                                sda = new SqlDataAdapter(cmd);
                                dt = new DataTable();
                                sda.Fill(dt);

                                query = ("select employee_doctor.emp_doc_specialistid from employee_doctor where employee_doctor.emp_doc_id = '" + txtdocid.Text + "'");
                                //  
                                cmd = new SqlCommand(query, conn);
                                sda = new SqlDataAdapter(cmd);
                                dt = new DataTable();
                                sda.Fill(dt);
                                sdr = cmd.ExecuteReader();

                                if (sdr.Read())
                                {
                                    int id = Convert.ToInt32(sdr["emp_doc_specialistid"].ToString());
                                    query = ("insert into symtoms(symtoms_dis,emp_doc_specialistid,disease_id) values ('" + textBox1.Text + "','" + id + "','" + txtiddis.Text + "');");
                                    //  
                                    cmd = new SqlCommand(query, conn);
                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    sda.Fill(dt);

                                }


                            }
                            else
                            {
                                query = ("insert into treatment_record (treatr_symptom,treatr_diagnose,treatr_status,disease_id,emp_doc_id,opd_id) values ('" + textBox1.Text + "','" + txtdis.Text + "',1,'" + txtiddis.Text + "','" + txtdocid.Text + "','" + lblopdid.Text + "')");
                                cmd = new SqlCommand(query, conn);
                                sda = new SqlDataAdapter(cmd);
                                dt = new DataTable();
                                sda.Fill(dt);





                            }







                        }
                        clinic_doctor_service2 m3 = new clinic_doctor_service2();
                        m3.Show();
                        clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                        clnlog.Close();
                        Visible = false;

                        MessageBox.Show("บันทึกการรักษาเรียบร้อย");

                    }


                }
                else
                {

                    MessageBox.Show("บันทึกข้อมูลการรักษาเรียบร้อยแล้ว", "สถานะ");


                }


                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OKCancel);
            }


        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            string query = ("select medi_id,medi_name,medi_qty from medical where medi_name LIKE '%" + textBox20.Text + "%'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView2.Rows.Add();



                dataGridView2.Rows[n].Cells[0].Value = item["medi_id"].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item["medi_name"].ToString();
                dataGridView2.Rows[n].Cells[2].Value = item["medi_qty"].ToString();


            }
            /*
                        clinic_doctor_service m3 = new clinic_doctor_service();
                        m3.Show();
                        clinic_doctor_service clnlog = new clinic_doctor_service();
                        clnlog.Close();
                        Visible = false;*/


            conn.Close();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView4.Rows[selectedRow];
            lblidt.Text = row.Cells[0].Value.ToString();
            lblopd.Text = row.Cells[3].Value.ToString();
            lbldoctor.Text = row.Cells[4].Value.ToString();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView3.Rows[selectedRow];
            lblidt.Text = row.Cells[3].Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView2.Rows[selectedRow];
            lblmed.Text = row.Cells[0].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string today = DateTime.Now.ToString("yyyy-MM-dd", new CultureInfo("th-TH"));
                string query = ("select count(*) from medicine_use where medi_id = '" + lblmed.Text + "' AND medi_use_status = 1 AND treatr_id = '" + lblidt.Text + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                int count_med_use = (int)cmd.ExecuteScalar();
                if (count_med_use < 1)
                {
                    query = ("select medi_qty,medi_unit,medi_min from medical where medi_id = '" + lblmed.Text + "'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);
                    sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        int nummed = Convert.ToInt32(sdr["medi_qty"].ToString());
                        int min = Convert.ToInt32(sdr["medi_min"].ToString());
                        string unit_medi = sdr["medi_unit"].ToString();
                        int num_pp = Convert.ToInt32(txtnum.Text);
                        int cut_stock = nummed - num_pp;
                        if (num_pp == 0)
                        {
                            MessageBox.Show("ไม่มีข้อมูลการจ่ายยา");
                        }
                        else
                        {




                            if (unit_medi == "เม็ด")
                            {
                                if (cut_stock == 0 && nummed >= min)
                                {
                                    /*         int A = Convert.ToInt32(txtnum.Text);
                                             int R = A - 5;

                                             query = ("Update medical set medi_qty = 5,medi_status_stock = 0 where medi_id = '" + lblmed.Text + "'");
                                             cmd = new SqlCommand(query, conn);
                                             sda = new SqlDataAdapter(cmd);
                                             dt = new DataTable();
                                             sda.Fill(dt);
                                             query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "',SYSDATETIME(),1,'" + R + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                             cmd = new SqlCommand(query, conn);
                                             sda = new SqlDataAdapter(cmd);
                                             dt = new DataTable();
                                             //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
                                             sda.Fill(dt);
                                             clinic_doctor_service m3 = new clinic_doctor_service();
                                             m3.Show();
                                             clinic_doctor_service clnlog = new clinic_doctor_service();
                                             clnlog.Close();
                                             Visible = false;
                                             */
                                    MessageBox.Show("การจ่ายยาเกินกำหนด");

                                }
                                else
                                {
                                    if (cut_stock <= min)
                                    {

                                        //  MessageBox.Show("ยาใกล้หมดคลังแล้ว");
                                        if (cut_stock >= min)
                                        {

                                            query = ("Update medical set medi_qty = '" + cut_stock + "',medi_status_stock = 0 where medi_id = '" + lblmed.Text + "'");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);
                                            query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "','" + today + "',1,'" + txtnum.Text + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();

                                            sda.Fill(dt);

                                            clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                            m3.Show();
                                            clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                            clnlog.Close();
                                            Visible = false;
                                            MessageBox.Show("จ่ายยาเรียบร้อยแล้ว");
                                        }
                                        else
                                        {

                                            MessageBox.Show("ยาเกินกำหนด");

                                        }


                                    }
                                    else if (cut_stock < 0)
                                    {



                                        clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                        m3.Show();
                                        clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                        clnlog.Close();
                                        Visible = false;
                                        MessageBox.Show("ยาหมดคลังแล้ว");
                                    }
                                    else if (cut_stock >= min)
                                    {
                                        if (nummed < num_pp)
                                        {

                                            MessageBox.Show("ยาเกินกำหนด");
                                        }
                                        else
                                        {
                                            if (cut_stock <= min)
                                            {
                                                query = ("Update medical set medi_qty = '" + cut_stock + "',medi_status_stock = 0 where medi_id = '" + lblmed.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);
                                                query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "','" + today + "',1,'" + txtnum.Text + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
                                                sda.Fill(dt);

                                                clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                                m3.Show();
                                                clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                                clnlog.Close();
                                                Visible = false;
                                                MessageBox.Show("จ่ายยาเรียบร้อยแล้ว");
                                            }
                                            else
                                            {
                                                query = ("Update medical set medi_qty = '" + cut_stock + "' where medi_id = '" + lblmed.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);


                                                query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "','" + today + "',1,'" + txtnum.Text + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
                                                sda.Fill(dt);




                                                clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                                m3.Show();
                                                clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                                clnlog.Close();
                                                Visible = false;

                                                MessageBox.Show("จ่ายยาเรียบร้อย");

                                            }
                                            /*

                                            */
                                        }

                                    }
                                    else
                                    {

                                        clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                        m3.Show();
                                        clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                        clnlog.Close();
                                        Visible = false;

                                        MessageBox.Show("ไม่สามารถสั่งยาได้");
                                    }

                                }






                            }
                            else if (unit_medi == "ขวด")
                            {

                                if (cut_stock == 0 && nummed >= min)
                                {
                                    /*
                                    int A = Convert.ToInt32(txtnum.Text);
                                    int R = A - 2;

                                    query = ("Update medical set medi_qty = 2,medi_status_stock = 0 where medi_id = '" + lblmed.Text + "'");
                                    cmd = new SqlCommand(query, conn);
                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    sda.Fill(dt);

                                    query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "',SYSDATETIME(),1,'" + R + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                    cmd = new SqlCommand(query, conn);
                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
                                    sda.Fill(dt);
                                    clinic_doctor_service m3 = new clinic_doctor_service();
                                    m3.Show();
                                    clinic_doctor_service clnlog = new clinic_doctor_service();
                                    clnlog.Close();
                                    Visible = false;
                                    */
                                    MessageBox.Show("การจ่ายยาเกินกำหนด");

                                }
                                else
                                {
                                    if (cut_stock <= min)
                                    {

                                        if (cut_stock >= min)
                                        {

                                            query = ("Update medical set medi_qty = '" + cut_stock + "',medi_status_stock = 0 where medi_id = '" + lblmed.Text + "'");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);
                                            query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "','" + today + "',1,'" + txtnum.Text + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();

                                            sda.Fill(dt);

                                            clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                            m3.Show();
                                            clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                            clnlog.Close();
                                            Visible = false;

                                            MessageBox.Show("จ่ายยาเรียบร้อยแล้ว");
                                        }
                                        else
                                        {

                                            MessageBox.Show("ยาเกินกำหนด");

                                        }

                                    }
                                    else if (cut_stock < 0)
                                    {
                                        /*   query = ("Update medical set medi_qty = 0 where medi_id = '" + lblmed.Text + "'");
                                           cmd = new SqlCommand(query, conn);
                                           sda = new SqlDataAdapter(cmd);
                                           dt = new DataTable();
                                           sda.Fill(dt);*/

                                        clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                        m3.Show();
                                        clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                        clnlog.Close();
                                        Visible = false;

                                        MessageBox.Show("ยาหมดคลังแล้ว");
                                    }
                                    else if (cut_stock >= min)
                                    {
                                        if (nummed < num_pp)
                                        {
                                            MessageBox.Show("ยาเกินกำหนด");
                                        }
                                        else
                                        {

                                            if (cut_stock <= min)
                                            {
                                                query = ("Update medical set medi_qty = '" + cut_stock + "',medi_status_stock = 0 where medi_id = '" + lblmed.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);
                                                query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "','" + today + "',1,'" + txtnum.Text + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
                                                sda.Fill(dt);

                                                clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                                m3.Show();
                                                clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                                clnlog.Close();
                                                Visible = false;
                                                MessageBox.Show("จ่ายยาเรียบร้อยแล้ว");
                                            }
                                            else
                                            {
                                                query = ("Update medical set medi_qty = '" + cut_stock + "' where medi_id = '" + lblmed.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);


                                                query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "','" + today + "',1,'" + txtnum.Text + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
                                                sda.Fill(dt);




                                                clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                                m3.Show();
                                                clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                                clnlog.Close();
                                                Visible = false;

                                                MessageBox.Show("จ่ายยาเรียบร้อย");

                                            }
                                        }

                                    }



                                }


                            }
                            else if (unit_medi == "ถุงเล็ก")
                            {
                                if (cut_stock == 0 && nummed >= min)
                                {
                                    /*
                                    int A = Convert.ToInt32(txtnum.Text);
                                    int R = A - 2;

                                    query = ("Update medical set medi_qty = 2,medi_status_stock = 0 where medi_id = '" + lblmed.Text + "'");
                                    cmd = new SqlCommand(query, conn);
                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    sda.Fill(dt);
                                    query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "',SYSDATETIME(),1,'" + R + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                    cmd = new SqlCommand(query, conn);
                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
                                    sda.Fill(dt);
                                    clinic_doctor_service m3 = new clinic_doctor_service();
                                    m3.Show();
                                    clinic_doctor_service clnlog = new clinic_doctor_service();
                                    clnlog.Close();
                                    Visible = false;
                                    */
                                    MessageBox.Show("การจ่ายยาเกินกำหนด");

                                }
                                else
                                {
                                    if (cut_stock <= min)
                                    {
                                        if (cut_stock >= min)
                                        {

                                            query = ("Update medical set medi_qty = '" + cut_stock + "',medi_status_stock = 0 where medi_id = '" + lblmed.Text + "'");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);
                                            query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "','" + today + "',1,'" + txtnum.Text + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();

                                            sda.Fill(dt);

                                            clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                            m3.Show();
                                            clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                            clnlog.Close();
                                            Visible = false;

                                            MessageBox.Show("จ่ายยาเรียบร้อยแล้ว");
                                        }
                                        else
                                        {

                                            MessageBox.Show("ยาเกินกำหนด");

                                        }


                                    }
                                    else if (cut_stock < 0)
                                    {
                                        /*   query = ("Update medical set medi_qty = 0 where medi_id = '" + lblmed.Text + "'");
                                           cmd = new SqlCommand(query, conn);
                                           sda = new SqlDataAdapter(cmd);
                                           dt = new DataTable();
                                           sda.Fill(dt);*/

                                        clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                        m3.Show();
                                        clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                        clnlog.Close();
                                        Visible = false;

                                        MessageBox.Show("ยาหมดคลังแล้ว");
                                    }
                                    else if (cut_stock >= min)
                                    {
                                        if (nummed < num_pp)
                                        {
                                            MessageBox.Show("ยาเกินกำหนด");
                                        }
                                        else
                                        {
                                            if (cut_stock <= min)
                                            {
                                                query = ("Update medical set medi_qty = '" + cut_stock + "',medi_status_stock = 0 where medi_id = '" + lblmed.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);
                                                query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "','" + today + "',1,'" + txtnum.Text + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
                                                sda.Fill(dt);

                                                clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                                m3.Show();
                                                clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                                clnlog.Close();
                                                Visible = false;
                                                MessageBox.Show("จ่ายยาเรียบร้อยแล้ว");
                                            }
                                            else
                                            {
                                                query = ("Update medical set medi_qty = '" + cut_stock + "' where medi_id = '" + lblmed.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);


                                                query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "','" + today + "',1,'" + txtnum.Text + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
                                                sda.Fill(dt);



                                                clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                                m3.Show();
                                                clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                                clnlog.Close();
                                                Visible = false;

                                                MessageBox.Show("จ่ายยาเรียบร้อย");

                                            }
                                        }

                                    }
                                }
                            }
                            else if (unit_medi == "ชิ้น")
                            {
                                if (cut_stock == 0 && nummed >= min)
                                {
                                    /*    int A = Convert.ToInt32(txtnum.Text);
                                        int R = A - 2;

                                        query = ("Update medical set medi_qty = 2,medi_status_stock = 0 where medi_id = '" + lblmed.Text + "'");
                                        cmd = new SqlCommand(query, conn);
                                        sda = new SqlDataAdapter(cmd);
                                        dt = new DataTable();
                                        sda.Fill(dt);
                                        query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "',SYSDATETIME(),1,'" + R + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                        cmd = new SqlCommand(query, conn);
                                        sda = new SqlDataAdapter(cmd);
                                        dt = new DataTable();
                                        //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
                                        sda.Fill(dt);
                                        clinic_doctor_service m3 = new clinic_doctor_service();
                                        m3.Show();
                                        clinic_doctor_service clnlog = new clinic_doctor_service();
                                        clnlog.Close();
                                        Visible = false;
                                        */
                                    MessageBox.Show("การจ่ายยาเกินกำหนด");
                                }
                                else
                                {
                                    if (cut_stock <= min)
                                    {

                                        if (cut_stock >= min)
                                        {

                                            query = ("Update medical set medi_qty = '" + cut_stock + "',medi_status_stock = 0 where medi_id = '" + lblmed.Text + "'");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);
                                            query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "','" + today + "',1,'" + txtnum.Text + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();

                                            sda.Fill(dt);

                                            clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                            m3.Show();
                                            clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                            clnlog.Close();
                                            Visible = false;
                                            MessageBox.Show("จ่ายยาเรียบร้อยแล้ว");
                                        }
                                        else
                                        {

                                            MessageBox.Show("ยาเกินกำหนด");

                                        }

                                    }
                                    else if (cut_stock < 0)
                                    {
                                        /*   query = ("Update medical set medi_qty = 0 where medi_id = '" + lblmed.Text + "'");
                                           cmd = new SqlCommand(query, conn);
                                           sda = new SqlDataAdapter(cmd);
                                           dt = new DataTable();
                                           sda.Fill(dt);*/


                                        clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                        m3.Show();
                                        clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                        clnlog.Close();
                                        Visible = false;

                                        MessageBox.Show("ยาหมดคลังแล้ว");
                                    }
                                    else if (cut_stock >= min)
                                    {
                                        if (nummed < num_pp)
                                        {
                                            MessageBox.Show("ยาเกินกำหนด");
                                        }
                                        else
                                        {
                                            if (cut_stock <= min)
                                            {
                                                query = ("Update medical set medi_qty = '" + cut_stock + "',medi_status_stock = 0 where medi_id = '" + lblmed.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);
                                                query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "','" + today + "',1,'" + txtnum.Text + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
                                                sda.Fill(dt);

                                                clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                                m3.Show();
                                                clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                                clnlog.Close();
                                                Visible = false;
                                                MessageBox.Show("จ่ายยาเรียบร้อยแล้ว");
                                            }
                                            else
                                            {
                                                query = ("Update medical set medi_qty = '" + cut_stock + "' where medi_id = '" + lblmed.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);


                                                query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "','" + today + "',1,'" + txtnum.Text + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
                                                sda.Fill(dt);



                                                clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                                m3.Show();
                                                clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                                clnlog.Close();
                                                Visible = false;

                                                MessageBox.Show("จ่ายยาเรียบร้อย");

                                            }
                                        }

                                    }

                                }

                            }
                            else if (unit_medi == "กล่อง")
                            {
                                if (cut_stock == 0 && nummed >= min)
                                {
                                    /*   int A = Convert.ToInt32(txtnum.Text);
                                       int R = A - 5;
                                       query = ("Update medical set medi_qty = 5,medi_status_stock = 0 where medi_id = '" + lblmed.Text + "'");
                                       cmd = new SqlCommand(query, conn);
                                       sda = new SqlDataAdapter(cmd);
                                       dt = new DataTable();
                                       sda.Fill(dt);
                                       query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "',SYSDATETIME(),1,'" + R + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                       cmd = new SqlCommand(query, conn);
                                       sda = new SqlDataAdapter(cmd);
                                       dt = new DataTable();
                                       //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
                                       sda.Fill(dt);
                                       clinic_doctor_service m3 = new clinic_doctor_service();
                                       m3.Show();
                                       clinic_doctor_service clnlog = new clinic_doctor_service();
                                       clnlog.Close();
                                       Visible = false;
                                       */
                                    MessageBox.Show("การจ่ายยาเกินกำหนด");
                                }
                                else
                                {

                                    if (cut_stock <= min)
                                    {

                                        if (cut_stock >= min)
                                        {

                                            query = ("Update medical set medi_qty = '" + cut_stock + "',medi_status_stock = 0 where medi_id = '" + lblmed.Text + "'");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);
                                            query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "','" + today + "',1,'" + txtnum.Text + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();

                                            sda.Fill(dt);

                                            clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                            m3.Show();
                                            clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                            clnlog.Close();
                                            Visible = false;

                                            MessageBox.Show("จ่ายยาเรียบร้อยแล้ว");
                                        }
                                        else
                                        {

                                            MessageBox.Show("ยาเกินกำหนด");

                                        }
                                    }
                                    else if (cut_stock < 0)
                                    {
                                        /*   query = ("Update medical set medi_qty = 0 where medi_id = '" + lblmed.Text + "'");
                                           cmd = new SqlCommand(query, conn);
                                           sda = new SqlDataAdapter(cmd);
                                           dt = new DataTable();
                                           sda.Fill(dt);*/


                                        clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                        m3.Show();
                                        clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                        clnlog.Close();
                                        Visible = false;

                                        MessageBox.Show("ยาหมดคลังแล้ว");
                                    }
                                    else if (cut_stock >= min)
                                    {
                                        if (nummed < num_pp)
                                        {
                                            MessageBox.Show("ยาเกินกำหนด");
                                        }
                                        else
                                        {
                                            if (cut_stock <= min)
                                            {
                                                query = ("Update medical set medi_qty = '" + cut_stock + "',medi_status_stock = 0 where medi_id = '" + lblmed.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);
                                                query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "','" + today + "',1,'" + txtnum.Text + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
                                                sda.Fill(dt);

                                                clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                                m3.Show();
                                                clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                                clnlog.Close();
                                                Visible = false;
                                                MessageBox.Show("จ่ายยาเรียบร้อยแล้ว");
                                            }
                                            else
                                            {
                                                query = ("Update medical set medi_qty = '" + cut_stock + "' where medi_id = '" + lblmed.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);


                                                query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "','" + today + "',1,'" + txtnum.Text + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
                                                sda.Fill(dt);



                                                clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                                m3.Show();
                                                clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                                clnlog.Close();
                                                Visible = false;

                                                MessageBox.Show("จ่ายยาเรียบร้อย");

                                            }
                                        }

                                    }
                                }
                            }
                            else if (unit_medi == "ซอง")
                            {
                                if (cut_stock == 0 && nummed >= min)
                                {
                                    /*  int A = Convert.ToInt32(txtnum.Text);
                                      int R = A - 4;
                                      query = ("Update medical set medi_qty = 4,medi_status_stock = 0 where medi_id = '" + lblmed.Text + "'");
                                      cmd = new SqlCommand(query, conn);
                                      sda = new SqlDataAdapter(cmd);
                                      dt = new DataTable();
                                      sda.Fill(dt);
                                      query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "',SYSDATETIME(),1,'" + R + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                      cmd = new SqlCommand(query, conn);
                                      sda = new SqlDataAdapter(cmd);
                                      dt = new DataTable();
                                      //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
                                      sda.Fill(dt);
                                      clinic_doctor_service m3 = new clinic_doctor_service();
                                      m3.Show();
                                      clinic_doctor_service clnlog = new clinic_doctor_service();
                                      clnlog.Close();
                                      Visible = false;
                                      */
                                    MessageBox.Show("การจ่ายยาเกินกำหนด");
                                }
                                else
                                {

                                    if (cut_stock <= min)
                                    {

                                        if (cut_stock >= min)
                                        {

                                            query = ("Update medical set medi_qty = '" + cut_stock + "',medi_status_stock = 0 where medi_id = '" + lblmed.Text + "'");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);
                                            query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "','" + today + "',1,'" + txtnum.Text + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();

                                            sda.Fill(dt);

                                            clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                            m3.Show();
                                            clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                            clnlog.Close();
                                            Visible = false;

                                            MessageBox.Show("จ่ายยาเรียบร้อยแล้ว");
                                        }
                                        else
                                        {

                                            MessageBox.Show("ยาเกินกำหนด");

                                        }

                                    }
                                    else if (cut_stock < 0)
                                    {
                                        /*   query = ("Update medical set medi_qty = 0 where medi_id = '" + lblmed.Text + "'");
                                           cmd = new SqlCommand(query, conn);
                                           sda = new SqlDataAdapter(cmd);
                                           dt = new DataTable();
                                           sda.Fill(dt);*/

                                        clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                        m3.Show();
                                        clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                        clnlog.Close();
                                        Visible = false;

                                        MessageBox.Show("ยาหมดคลังแล้ว");
                                    }
                                    else if (cut_stock >= min)
                                    {
                                        if (nummed < num_pp)
                                        {
                                            MessageBox.Show("ยาเกินกำหนด");
                                        }
                                        else
                                        {
                                            if (cut_stock <= min)
                                            {
                                                query = ("Update medical set medi_qty = '" + cut_stock + "',medi_status_stock = 0 where medi_id = '" + lblmed.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);
                                                query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "','" + today + "',1,'" + txtnum.Text + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
                                                sda.Fill(dt);

                                                clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                                m3.Show();
                                                clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                                clnlog.Close();
                                                Visible = false;
                                                MessageBox.Show("จ่ายยาเรียบร้อยแล้ว");
                                            }
                                            else
                                            {
                                                query = ("Update medical set medi_qty = '" + cut_stock + "' where medi_id = '" + lblmed.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);


                                                query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "','" + today + "',1,'" + txtnum.Text + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
                                                sda.Fill(dt);



                                                clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                                m3.Show();
                                                clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                                clnlog.Close();
                                                Visible = false;
                                                MessageBox.Show("จ่ายยาเรียบร้อย");

                                            }
                                        }

                                    }


                                }










                            }


                            else if (unit_medi == "แผง")
                            {
                                if (cut_stock == 0 && nummed >= min)
                                {
                                    /*      int A = Convert.ToInt32(txtnum.Text);
                                          int R = A - 2;
                                          query = ("Update medical set medi_qty = 2,medi_status_stock = 0 where medi_id = '" + lblmed.Text + "'");
                                          cmd = new SqlCommand(query, conn);
                                          sda = new SqlDataAdapter(cmd);
                                          dt = new DataTable();
                                          sda.Fill(dt);
                                          query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "',SYSDATETIME(),1,'" + R + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                          cmd = new SqlCommand(query, conn);
                                          sda = new SqlDataAdapter(cmd);
                                          dt = new DataTable();
                                          //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
                                          sda.Fill(dt);
                                          clinic_doctor_service m3 = new clinic_doctor_service();
                                          m3.Show();
                                          clinic_doctor_service clnlog = new clinic_doctor_service();
                                          clnlog.Close();
                                          Visible = false;
                                          */
                                    MessageBox.Show("การจ่ายยาเกินกำหนด");
                                }
                                else
                                {
                                    if (cut_stock <= min)
                                    {

                                        if (cut_stock >= min)
                                        {

                                            query = ("Update medical set medi_qty = '" + cut_stock + "',medi_status_stock = 0 where medi_id = '" + lblmed.Text + "'");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();
                                            sda.Fill(dt);
                                            query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "','" + today + "',1,'" + txtnum.Text + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                            cmd = new SqlCommand(query, conn);
                                            sda = new SqlDataAdapter(cmd);
                                            dt = new DataTable();

                                            sda.Fill(dt);

                                            clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                            m3.Show();
                                            clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                            clnlog.Close();
                                            Visible = false;

                                            MessageBox.Show("จ่ายยาเรียบร้อยแล้ว");
                                        }
                                        else
                                        {

                                            MessageBox.Show("ยาเกินกำหนด");

                                        }

                                    }
                                    else if (cut_stock <= 0)
                                    {
                                        /*   query = ("Update medical set medi_qty = 0 where medi_id = '" + lblmed.Text + "'");
                                           cmd = new SqlCommand(query, conn);
                                           sda = new SqlDataAdapter(cmd);
                                           dt = new DataTable();
                                           sda.Fill(dt);*/


                                        clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                        m3.Show();
                                        clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                        clnlog.Close();
                                        Visible = false;
                                        MessageBox.Show("ยาหมดคลังแล้ว");
                                    }
                                    else if (nummed >= min)
                                    {
                                        if (nummed < num_pp)
                                        {
                                            MessageBox.Show("ยาเกินกำหนด");
                                        }
                                        else
                                        {
                                            if (cut_stock <= min)
                                            {
                                                query = ("Update medical set medi_qty = '" + cut_stock + "',medi_status_stock = 0 where medi_id = '" + lblmed.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);
                                                query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "','" + today + "',1,'" + txtnum.Text + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
                                                sda.Fill(dt);

                                                clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                                m3.Show();
                                                clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                                clnlog.Close();
                                                Visible = false;

                                                MessageBox.Show("จ่ายยาเรียบร้อย");
                                            }
                                            else
                                            {
                                                query = ("Update medical set medi_qty = '" + cut_stock + "' where medi_id = '" + lblmed.Text + "'");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                sda.Fill(dt);


                                                query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "','" + today + "',1,'" + txtnum.Text + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                                                cmd = new SqlCommand(query, conn);
                                                sda = new SqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
                                                sda.Fill(dt);



                                                clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                                m3.Show();
                                                clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                                clnlog.Close();
                                                Visible = false;

                                                MessageBox.Show("จ่ายยาเรียบร้อย");

                                            }
                                        }

                                    }


                                }

                            }


                        }
                    }

                }
                else
                {

                    MessageBox.Show("มีข้อมูลการจ่ายยาแล้ว");
                }


                conn.Close();


            }
            catch (Exception)
            {
                MessageBox.Show("มีข้อผิดพลาด กรุณากรอกตัวเลข");
            }



        }
        private void button24_Click(object sender, EventArgs e)
        {
            conn.Open();

            DialogResult dialogResult = MessageBox.Show("ต้องการจ่ายยาและเวชภัณฑ์หรือไม่", "status ", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {

                string query = ("select count(*) from medicine_use where treatr_id = '" + lblidt.Text + "' ");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                int med_count = (int)cmd.ExecuteScalar();


           /*     query = ("select count(*) from appointment inner join opd on opd.opd_id = appointment.opd_id where opd.opd_name = '"+lblopd.Text+"'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                int add_count = (int)cmd.ExecuteScalar();
           */
                if (med_count < 1)
                {
                    MessageBox.Show("ยังไม่มีข้อมูลการจ่ายยา");


                }
                else
                {

                //    if(add_count < 1)
                  //  {
                        query = ("UPDATE medicine_use SET medi_use_status = 2 where treatr_id = '" + lblidt.Text + "'");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);

                        query = ("Update queue_diag_room SET status_queue = 0 where opd_id = '" + lblopdid.Text + "'");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);


                        /*   query = ("Update treatment_record SET treatr_status = 0 where treatr_id = '" + lblidt.Text + "'");
                           cmd = new SqlCommand(query, conn);
                           sda = new SqlDataAdapter(cmd);
                           dt = new DataTable();
                           sda.Fill(dt);*/

                        query = ("Update treatment_record set treatr_status = 2 where treatr_id = " + lblidt.Text + "");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
                        sda.Fill(dt);

                /*        Queue<int> collection = new Queue<int>();
                        query = ("select count(*) from treatment_record where treatr_status = 2");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);

                        int queue = (int)cmd.ExecuteScalar();
                        collection.Enqueue(queue);

                        foreach (int value in collection)
                        {*/
                   /*         query = ("Update treatment_record set treatr_medi_queue = '" + value + "' where treatr_id = '" + lblidt.Text + "'");
                            //  
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);*/

                            query = ("Update queue_diag_room SET status_queue = 0 where opd_id = '" + lblopdid.Text + "'");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);

                            query = ("Update visit_record set vr_status = 2 where opd_id = '" + lblopdid.Text + "'");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);



                            clinic_doctor_service2 m3 = new clinic_doctor_service2();
                            m3.Show();
                            clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                            clnlog.Close();
                            Visible = false;


                               MessageBox.Show("สั่งยาเรียบร้อย");


                    //     }


                    /*       }
                           else
                           {
                               query = ("UPDATE medicine_use SET medi_use_status = 5 where treatr_id = '" + lblidt.Text + "'");
                               cmd = new SqlCommand(query, conn);
                               sda = new SqlDataAdapter(cmd);
                               dt = new DataTable();
                               sda.Fill(dt);


                               query = ("Update queue_diag_room SET status_queue = 0 where opd_id = '" + lblopdid.Text + "'");
                               cmd = new SqlCommand(query, conn);
                               sda = new SqlDataAdapter(cmd);
                               dt = new DataTable();
                               sda.Fill(dt);

                           */
                    /*   query = ("Update treatment_record SET treatr_status = 0 where treatr_id = '" + lblidt.Text + "'");
                       cmd = new SqlCommand(query, conn);
                       sda = new SqlDataAdapter(cmd);
                       dt = new DataTable();
                       sda.Fill(dt);*/

                    /*             query = ("Update treatment_record set treatr_status = 2 where treatr_id = " + lblidt.Text + "");
                                 cmd = new SqlCommand(query, conn);
                                 sda = new SqlDataAdapter(cmd);
                                 dt = new DataTable();
                                 //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
                                 sda.Fill(dt);

                                 clinic_doctor_service2 m3 = new clinic_doctor_service2();
                                 m3.Show();
                                 clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                                 clnlog.Close();
                                 Visible = false;


                                 MessageBox.Show("จ่ายยาเรียบร้อยกรุณารอการนัดหมาย");

                             }*/


                }

            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string position = lblposition.Text;
            conn.Open();

            string query = ("select count(*) from treatment_record where emp_doc_id ='" + txtdocid.Text + "' AND opd_id = '" + lblopdid.Text + "'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            int count_tre = (int)cmd.ExecuteScalar();
            if (count_tre < 1)
            {

                MessageBox.Show("ยังไม่ได้บันทึกข้อมูลการรักษา");
            }
            else
            {
                if (position == "เจ้าหน้าที่")
                {
                    DialogResult dialogResult = MessageBox.Show("ส่งข้อมูลการนัดหมายหรือไม่", "นัดหมายหรือไม่ ? ", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        query = ("select count(*) from appointment where opd_id = '" + lblopdid.Text + "' and status_approve = 1");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);

                        int opd_count_app = (int)cmd.ExecuteScalar();

                        if (opd_count_app < 1)
                        {
                            Queue<int> collection = new Queue<int>();
                            query = ("select count(*) from appointment where status_approve = 1");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);
                            int queue = (int)cmd.ExecuteScalar();
                            collection.Enqueue(queue);
                            foreach (int value in collection)
                            {

                                int plus = value + 1;

                                query = ("Insert into appointment (status_approve,emp_doc_id,opd_id, app_queue) values (1,'" + txtdocid.Text + "','" + lblopdid.Text + "','" + plus + "');");
                                cmd = new SqlCommand(query, conn);
                                sda = new SqlDataAdapter(cmd);
                                dt = new DataTable();

                                sda.Fill(dt);


                                MessageBox.Show("ส่งข้อมูลการนัดหมายเรียบร้อย");



                            }

                        }
                        else
                        {
                            MessageBox.Show("มีข้อมูลการนัดหมายแล้ว");

                        }


                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }

                    //     button1.Visible = true;
                }
                else if (position == "เวชระเบียน")
                {
                    DialogResult dialogResult = MessageBox.Show("ส่งข้อมูลการนัดหมายหรือไม่", "นัดหมายหรือไม่ ? ", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        query = ("select count(*) from appointment where opd_id = '" + lblopdid.Text + "' and status_approve = 1");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);

                        int opd_count_app = (int)cmd.ExecuteScalar();

                        if (opd_count_app < 1)
                        {
                            Queue<int> collection = new Queue<int>();
                            query = ("select count(*) from appointment where status_approve = 1");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);
                            int queue = (int)cmd.ExecuteScalar();
                            collection.Enqueue(queue);
                            foreach (int value in collection)
                            {

                                int plus = value + 1;

                                query = ("Insert into appointment (status_approve,emp_doc_id,opd_id, app_queue) values (1,'" + txtdocid.Text + "','" + lblopdid.Text + "','" + plus + "');");
                                cmd = new SqlCommand(query, conn);
                                sda = new SqlDataAdapter(cmd);
                                dt = new DataTable();

                                sda.Fill(dt);


                                MessageBox.Show("ส่งข้อมูลการนัดหมายเรียบร้อย");



                            }

                        }
                        else
                        {
                            MessageBox.Show("มีข้อมูลการนัดหมายแล้ว");

                        }

                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }
                    //      button1.Visible = true;
                }
                else if (position == "พยาบาล")
                {
                    DialogResult dialogResult = MessageBox.Show("ส่งข้อมูลการนัดหมายหรือไม่", "นัดหมายหรือไม่ ? ", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        query = ("select count(*) from appointment where opd_id = '" + lblopdid.Text + "' and status_approve = 1");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);

                        int opd_count_app = (int)cmd.ExecuteScalar();

                        if (opd_count_app < 1)
                        {
                            Queue<int> collection = new Queue<int>();
                            query = ("select count(*) from appointment where status_approve = 1");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);
                            int queue = (int)cmd.ExecuteScalar();
                            collection.Enqueue(queue);
                            foreach (int value in collection)
                            {

                                int plus = value + 1;

                                query = ("Insert into appointment (status_approve,emp_doc_id,opd_id, app_queue) values (1,'" + txtdocid.Text + "','" + lblopdid.Text + "','" + plus + "');");
                                cmd = new SqlCommand(query, conn);
                                sda = new SqlDataAdapter(cmd);
                                dt = new DataTable();

                                sda.Fill(dt);


                                MessageBox.Show("ส่งข้อมูลการนัดหมายเรียบร้อย");



                            }

                        }
                        else
                        {
                            MessageBox.Show("มีข้อมูลการนัดหมายแล้ว");

                        }

                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }
                }
                else if (position == "เภสัชกรณ์")
                {
                    DialogResult dialogResult = MessageBox.Show("ส่งข้อมูลการนัดหมายหรือไม่", "นัดหมายหรือไม่ ? ", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        query = ("select count(*) from appointment where opd_id = '" + lblopdid.Text + "' and status_approve = 1");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);

                        int opd_count_app = (int)cmd.ExecuteScalar();

                        if (opd_count_app < 1)
                        {
                            Queue<int> collection = new Queue<int>();
                            query = ("select count(*) from appointment where status_approve = 1");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);
                            int queue = (int)cmd.ExecuteScalar();
                            collection.Enqueue(queue);
                            foreach (int value in collection)
                            {

                                int plus = value + 1;

                                query = ("Insert into appointment (status_approve,emp_doc_id,opd_id, app_queue) values (1,'" + txtdocid.Text + "','" + lblopdid.Text + "','" + plus + "');");
                                cmd = new SqlCommand(query, conn);
                                sda = new SqlDataAdapter(cmd);
                                dt = new DataTable();

                                sda.Fill(dt);


                                MessageBox.Show("ส่งข้อมูลการนัดหมายเรียบร้อย");



                            }

                        }
                        else
                        {
                            MessageBox.Show("มีข้อมูลการนัดหมายแล้ว");

                        }

                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }
                }
                else if (position == "หัวหน้า")
                {
                    DialogResult dialogResult = MessageBox.Show("ส่งข้อมูลการนัดหมายหรือไม่", "นัดหมายหรือไม่ ? ", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        query = ("select count(*) from appointment where opd_id = '" + lblopdid.Text + "' and status_approve = 1");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);

                        int opd_count_app = (int)cmd.ExecuteScalar();

                        if (opd_count_app < 1)
                        {
                            Queue<int> collection = new Queue<int>();
                            query = ("select count(*) from appointment where status_approve = 1");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);
                            int queue = (int)cmd.ExecuteScalar();
                            collection.Enqueue(queue);
                            foreach (int value in collection)
                            {

                                int plus = value + 1;

                                query = ("Insert into appointment (status_approve,emp_doc_id,opd_id, app_queue) values (1,'" + txtdocid.Text + "','" + lblopdid.Text + "','" + plus + "');");
                                cmd = new SqlCommand(query, conn);
                                sda = new SqlDataAdapter(cmd);
                                dt = new DataTable();

                                sda.Fill(dt);


                                MessageBox.Show("ส่งข้อมูลการนัดหมายเรียบร้อย");



                            }

                        }
                        else
                        {
                            MessageBox.Show("มีข้อมูลการนัดหมายแล้ว");

                        }

                    }
                    else if (dialogResult == DialogResult.No)
                    {

                        MessageBox.Show("ไม่มีการนัดหมาย");

                    }
                }
                else
                {
                    //   conn.Close();
                    //        button1.Visible = false;
                }



            }

            conn.Close();
        }
/*
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            string query = ("select * from disease where disease = '" + comboBox1.SelectedItem.ToString() + "'");
            cmd = new SqlCommand(query, conn);

            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {

                txtiddis.Text = (sdr["disease_id"].ToString());
                txtdis.Text = (sdr["disease"].ToString());







            }

            conn.Close();
        }
        */
        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();

            string query = ("select count(*) from medicine_use where treatr_id = '" + lblidt.Text + "' ");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            int med_count = (int)cmd.ExecuteScalar();
            if (med_count < 1)
            {
                query = ("select count(*) from treatment_record where treatr_id = '" + lblidt.Text + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                int count_t = (int)cmd.ExecuteScalar();

                string today = DateTime.Now.ToString("yyyy-MM-dd", new CultureInfo("th-TH"));
                if (count_t < 1)
                {
                    MessageBox.Show("ไม่มีข้อมูลการรักษา");
                }
                else
                {


                    query = ("Update treatment_record SET treatr_status = 0 where treatr_id = '" + lblidt.Text + "'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);

                    query = ("Update queue_diag_room SET status_queue = 0 where opd_id = '" + lblopdid.Text + "'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);

                    query = ("Update visit_record set vr_status = 2 where opd_id = '" + lblopdid.Text + "'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);


                    query = ("Update queue_visit_record set qvr_status = 6 where opd_id = '" + lblopdid.Text + "' AND qvr_date = '" + today + "'");

                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);



                    clinic_doctor_service2 m3 = new clinic_doctor_service2();
                    m3.Show();
                    clinic_doctor_service2 clnlog = new clinic_doctor_service2();
                    clnlog.Close();
                    Visible = false;


                    MessageBox.Show("เก็บประวัติการรักษาเรียบร้อย");
                }

            }
            else
            {


                MessageBox.Show("มีข้อมูลการจ่ายยา");
            }

            conn.Close();
        }

        private void clinic_doctor_service2_Load(object sender, EventArgs e)
        {
            conn.Open();
            t.Interval = 1000;
            t.Tick += new EventHandler(this.timer1_Tick);
            t.Start();
            string today = DateTime.Now.ToString("yyyy-MM-dd", new CultureInfo("th-TH"));
            string query = ("select queue_diag_room.qdr_record,opd.opd_id,opd.opd_name,position.pos_name,employee_doctor.emp_doc_id   from queue_diag_room inner join opd on opd.opd_id = queue_diag_room.opd_id inner join schedule_work_doctor on schedule_work_doctor.swd_id = queue_diag_room.swd_id inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id inner join position on position.pos_id = opd.pos_id where queue_diag_room.status_queue = 1 AND room_id = 2 AND queue_diag_room.qdr_date = '" + today + "' ");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                int queue = Convert.ToInt32(sdr["qdr_record"].ToString());

                lblqueue.Text = "" + queue;
                int id = Convert.ToInt32(sdr["opd_id"].ToString());
                string name = sdr["opd_name"].ToString();
                string position = sdr["pos_name"].ToString();
                int doc_id = Convert.ToInt32(sdr["emp_doc_id"].ToString());
                lblopdid.Text = "" + id;
                lblsername.Text = name;
                // lblopd.Text = row.Cells[7].Value.ToString();
                txtdocid.Text = "" + doc_id;
                //    string position = sdr["pos_name"].ToString();
                lblposition.Text = position;
            }

            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();

            query = ("select disease from disease where disease LIKE '%" + txtdis.Text + "%'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                string test = sdr.GetString(0);

                MyCollection.Add(test);
            }

            txtdis.AutoCompleteCustomSource = MyCollection;

            query = ("select symtoms_dis  from symtoms  inner join disease on disease.disease_id = symtoms.disease_id where symtoms_dis LIKE '%" + textBox1.Text + "%'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                string test = sdr.GetString(0);

                MyCollection.Add(test);
            }

            textBox1.AutoCompleteCustomSource = MyCollection;


            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = ("select symtoms_dis,disease.disease,disease.disease_id,disease_group.disease_group  from symtoms  inner join disease on disease.disease_id = symtoms.disease_id   inner join disease_group on disease_group.disease_group_id = disease.disease_group_id where symtoms_dis = '" + textBox1.Text + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {


                    txtdis.Text = sdr["disease"].ToString();
                    txtiddis.Text = sdr["disease_id"].ToString();
                    textBox2.Text = sdr["disease_group"].ToString();

                }
                else
                {
                    txtdis.Text = "";
                    txtiddis.Text = "";
                    textBox2.Text = "";
                }
                conn.Close();

            }
            catch (Exception)
            {

            }

        }

        private void txtdocid_TextChanged(object sender, EventArgs e)
        {

            string query = ("select treatr_id,treatr_symptom,treatr_diagnose ,opd.opd_name,treatment_record.emp_doc_id  from treatment_record inner join opd on opd.opd_id = treatment_record.opd_id where treatr_status = 1 AND treatment_record.emp_doc_id  = '" + txtdocid.Text + "' AND opd.opd_id = '" + lblopdid.Text + "'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView4.Rows.Add();



                dataGridView4.Rows[n].Cells[0].Value = item["treatr_id"].ToString();
                dataGridView4.Rows[n].Cells[1].Value = item["treatr_symptom"].ToString();
                dataGridView4.Rows[n].Cells[2].Value = item["treatr_diagnose"].ToString();
                dataGridView4.Rows[n].Cells[3].Value = item["opd_name"].ToString();
                dataGridView4.Rows[n].Cells[4].Value = item["emp_doc_id"].ToString();

                lblidt.Text = item["treatr_id"].ToString();
                lblopd.Text = item["opd_name"].ToString();
                lbldoctor.Text = item["emp_doc_id"].ToString();


            }


        }

        private void timer1_Tick(object sender, EventArgs e)
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
            label20.Text = time;
        }

        private void label20_TextChanged(object sender, EventArgs e)
        {
            double time = Convert.ToDouble(label20.Text);
            if (time >= 08.00 && time <= 12.00)
            {
                lbltimezone.Text = "เช้า";
            }
            else if (time >= 12.01 && time <= 16.30)
            {
                lbltimezone.Text = "บ่าย";
            }
            else
            {
                lbltimezone.Text = "";
            }
        }

        private void lbltimezone_TextChanged(object sender, EventArgs e)
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd", new CultureInfo("th-TH"));
            if (lbltimezone.Text == "เช้า")
            {
                string query = ("select medicine_use.medi_use_id , medical.medi_name,medicine_use.medi_num,treatment_record.treatr_id, opd.opd_name,employee_doctor.emp_doc_name from opd inner join treatment_record on treatment_record.opd_id = opd.opd_id inner join employee_doctor on employee_doctor.emp_doc_id = treatment_record.emp_doc_id inner join schedule_work_doctor on schedule_work_doctor.emp_doc_id = employee_doctor.emp_doc_id inner join medicine_use on medicine_use.treatr_id = treatment_record.treatr_id inner join medical on medical.medi_id = medicine_use.medi_id where medicine_use.medi_use_status = 1 AND opd.opd_name = '" + lblopd.Text + "' AND schedule_work_doctor.swd_date_work = '" + today + "'AND schedule_work_doctor.swd_timezone = 'เช้า'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView3.Rows.Add();



                    dataGridView3.Rows[n].Cells[0].Value = item["medi_use_id"].ToString();
                    dataGridView3.Rows[n].Cells[1].Value = item["medi_name"].ToString();
                    dataGridView3.Rows[n].Cells[2].Value = item["medi_num"].ToString();
                    dataGridView3.Rows[n].Cells[3].Value = item["treatr_id"].ToString();
                    dataGridView3.Rows[n].Cells[4].Value = item["opd_name"].ToString();
                }


            }
            else if (lbltimezone.Text == "บ่าย")
            {
                string query = ("select medicine_use.medi_use_id , medical.medi_name,medicine_use.medi_num,treatment_record.treatr_id, opd.opd_name,employee_doctor.emp_doc_name from opd inner join treatment_record on treatment_record.opd_id = opd.opd_id inner join employee_doctor on employee_doctor.emp_doc_id = treatment_record.emp_doc_id inner join schedule_work_doctor on schedule_work_doctor.emp_doc_id = employee_doctor.emp_doc_id inner join medicine_use on medicine_use.treatr_id = treatment_record.treatr_id inner join medical on medical.medi_id = medicine_use.medi_id where medicine_use.medi_use_status = 1 AND opd.opd_name = '" + lblopd.Text + "' AND schedule_work_doctor.swd_date_work = '" + today + "'AND schedule_work_doctor.swd_timezone = 'บ่าย'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView3.Rows.Add();



                    dataGridView3.Rows[n].Cells[0].Value = item["medi_use_id"].ToString();
                    dataGridView3.Rows[n].Cells[1].Value = item["medi_name"].ToString();
                    dataGridView3.Rows[n].Cells[2].Value = item["medi_num"].ToString();
                    dataGridView3.Rows[n].Cells[3].Value = item["treatr_id"].ToString();
                    dataGridView3.Rows[n].Cells[4].Value = item["opd_name"].ToString();
                }



            }
            else
            {
                //  MessageBox.Show("ddddddddd");
            }
        }

        private void txtdis_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = ("select disease.disease_id,disease_group.disease_group from disease inner join disease_group on disease_group.disease_group_id = disease.disease_group_id where disease = '" + txtdis.Text + "'");
                cmd = new SqlCommand(query, conn);

                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {

                    int id = Convert.ToInt32(sdr["disease_id"].ToString());
                    //      MessageBox.Show("    "+id);
                    txtiddis.Text = Convert.ToString(id);
                    textBox2.Text = sdr["disease_group"].ToString();
                    //   txtdis.Text = (sdr["disease"].ToString());







                }
                else
                {
                    txtiddis.Text = "";
                    textBox2.Text = "";
                }





                conn.Close();




            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OKCancel);
            }
        }
    }
}
