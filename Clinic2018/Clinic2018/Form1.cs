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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Document document = new Document();
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("test1088.pdf", FileMode.Create));
                document.Open();
                string fontpath = Environment.GetEnvironmentVariable("SystemRoot") + "../fonts/THSarabun.ttf";
                BaseFont basefont = BaseFont.CreateFont(fontpath, BaseFont.IDENTITY_H, true);
                iTextSharp.text.Font arabicFont = new iTextSharp.text.Font(basefont, 24, iTextSharp.text.Font.NORMAL);


                var el = new Chunk();
                iTextSharp.text.Font f2 = new iTextSharp.text.Font(basefont, el.Font.Size,
                                                el.Font.Style, el.Font.Color);
                el.Font = f2;
                PdfPTable table = new PdfPTable(1);

                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                var str = "ทดสอบบบบบบบบบบบบบบบบ";
          //      PdfPCell cell = new PdfPCell(new Phrase(10, str, el.Font));
                //    table.AddCell(cell);
                Paragraph pa = new Paragraph();
                pa.Add(new Phrase(10, str, el.Font));
                document.Add(pa);
                document.Close();

            }
            catch (DocumentException de)
            {
                //              this.Message = de.Message;
            }
            catch (IOException ioe)
            {
                //                this.Message = ioe.Message;
            }

            // step 5: we close the document
            document.Close();
        }
    }
}
