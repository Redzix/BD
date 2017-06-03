using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD.Controller
{
    class PdfCreator
    {
        public void createPDF(ListView view)
        {
            PdfPTable pdfTable = new PdfPTable(view.Columns.Count);
            pdfTable.DefaultCell.Padding = 5;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            FontFactory.RegisterDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Fonts));
            Font fontHeader = FontFactory.GetFont("microsoft sans serif", BaseFont.IDENTITY_H, true, 12, Font.BOLD);
            Font fontText = FontFactory.GetFont("microsoft sans serif", BaseFont.IDENTITY_H, true, 10);

            //Adding Header row
            foreach (ColumnHeader column in view.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.Text, fontHeader));
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (ListViewItem itemRow in view.Items)
            {
                for (int i = 0; i < itemRow.SubItems.Count; i++)
                {
                    pdfTable.AddCell(new PdfPCell(new Phrase(itemRow.SubItems[i].Text,fontText)));
                }
            }
            try
            {
                using (FileStream stream = new FileStream("ListView.pdf", FileMode.Create))
                {
                    //Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                    Document pdfDoc = new Document(PageSize.A4);
                    PdfWriter.GetInstance(pdfDoc, stream);

                    pdfDoc.Open();
                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();
                    stream.Close();
                }
            } catch(IOException)
            {
                MessageBox.Show("Zamknij najpierw plik pdf.");
            }
        }
    }
}
