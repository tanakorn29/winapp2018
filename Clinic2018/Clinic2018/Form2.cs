using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic2018
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Document doc = new Document(new iTextSharp.text.Rectangle(24, 12), 5, 5, 1, 1);

            try
            {

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(
                  Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/codes5555555.pdf", FileMode.Create));
                doc.Open();

                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Price");
                for (int i = 0; i < 20; i++)
                {
                    DataRow row = dt.NewRow();
                    row["ID"] = "ZS00000000000000" + i.ToString();
                    row["Price"] = "100," + i.ToString();
                    dt.Rows.Add(row);
                }
         //       System.Drawing.Image img1 = null;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i != 0)
                        doc.NewPage();
                    PdfContentByte cb1 = writer.DirectContent;
                    BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_BOLDITALIC, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                    cb1.SetFontAndSize(bf, 2.0f);
                    cb1.BeginText();
                    cb1.SetTextMatrix(1.2f, 9.5f);
                    cb1.ShowText("Safi Garments");
                    cb1.EndText();

                    PdfContentByte cb2 = writer.DirectContent;
                    BaseFont bf1 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    cb2.SetFontAndSize(bf1, 1.3f);
                    cb2.BeginText();
                    cb2.SetTextMatrix(17.5f, 1.0f);
                    cb2.ShowText(dt.Rows[i]["Price"].ToString());
                    cb2.EndText();

                    iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
                    iTextSharp.text.pdf.Barcode128 bc = new Barcode128();
                    bc.TextAlignment = Element.ALIGN_LEFT;
                    bc.Code = dt.Rows[i]["ID"].ToString();
                    bc.StartStopText = false;
                    bc.CodeType = iTextSharp.text.pdf.Barcode128.EAN13;
                    bc.Extended = true;

                    //System.Drawing.Image bimg = 
                    //  bc.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White);
                    //img1 = bimg;

                    iTextSharp.text.Image img = bc.CreateImageWithBarcode(cb,
                      iTextSharp.text.BaseColor.BLACK, iTextSharp.text.BaseColor.BLACK);

                    cb.SetTextMatrix(1.5f, 3.0f);
                    img.ScaleToFit(60, 5);
                    img.SetAbsolutePosition(1.5f, 1);
                    cb.AddImage(img);
                }

                ////////////////////***********************************//////////////////////

                doc.Close();
                System.Diagnostics.Process.Start(Environment.GetFolderPath(
                           Environment.SpecialFolder.Desktop) + "/codes.pdf");
                //MessageBox.Show("Bar codes generated on desktop fileName=codes.pdf");
            }
            catch
            {
            }
            finally
            {
                doc.Close();
            }
        }
    }
}
