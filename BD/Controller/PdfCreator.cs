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
        /// <summary>
        /// Nazwa raportu który zostanie wygenerowany
        /// </summary>
        string nazwaRaportu;
        /// <summary>
        /// Konstruktor klasy
        /// </summary>
        /// <param name="nazwa">Nazwa raportu do wygenerowania</param>
        public PdfCreator(string nazwa)
        {
            if (!nazwa.Equals(""))
                this.nazwaRaportu = nazwa;
            else
                this.nazwaRaportu = "raport";
        }
        /// <summary>
        /// Tworzy plik PDF o podanej nazwie w konstruktorze
        /// </summary>
        /// <param name="view">ListView z którego ma pobrać dane</param>
        public void createPDF(ListView view)
        {
            PdfPTable mainRaport = new PdfPTable(view.Columns.Count);
            mainRaport.DefaultCell.Padding = 5;
            mainRaport.WidthPercentage = 100;
            mainRaport.HorizontalAlignment = Element.ALIGN_LEFT;
            mainRaport.DefaultCell.BorderWidth = 1;
            FontFactory.RegisterDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Fonts));
            Font fontHeader = FontFactory.GetFont("microsoft sans serif", BaseFont.IDENTITY_H, true, 12, Font.BOLD);
            Font fontText = FontFactory.GetFont("microsoft sans serif", BaseFont.IDENTITY_H, true, 10);
            Font header = FontFactory.GetFont("microsoft sans serif", BaseFont.IDENTITY_H, true, 32);

            //Adding Header row
            foreach (ColumnHeader column in view.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(this.FormatujNazweKolumny(column.Text), fontHeader));
                mainRaport.AddCell(cell);
            }

            //Adding DataRow
            foreach (ListViewItem itemRow in view.Items)
            {
                for (int i = 0; i < itemRow.SubItems.Count; i++)
                {
                    mainRaport.AddCell(new PdfPCell(new Phrase(itemRow.SubItems[i].Text, fontText)));
                }
            }

            using (Document pdfDoc = new Document(PageSize.A4))
            {
                //Strona tytułowa
                PdfPTable frontPage = new PdfPTable(1);
                DateTime dateTime = DateTime.Now;// .UtcNow;
                frontPage.WidthPercentage = 100;
                var tempCell = new PdfPCell(new Paragraph(String.Format("Wygenerowano dnia {0:dd/MM/yyyy} o godzinie {0:H:m:s}", dateTime), fontText));
                tempCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                tempCell.Border = PdfPCell.NO_BORDER;
                frontPage.AddCell(tempCell);

                tempCell = new PdfPCell(new Paragraph("Raport wygenerowany dla " + nazwaRaportu, header));
                tempCell.MinimumHeight = (pdfDoc.PageSize.Height - (pdfDoc.BottomMargin + pdfDoc.TopMargin))-30;
                tempCell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                tempCell.Border = PdfPCell.NO_BORDER;
                tempCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                frontPage.AddCell(tempCell);

                try
                {
                    string nazwaPliku = String.Format("{0}_{1:dd_MM_yyyy}.pdf", nazwaRaportu, DateTime.Now);
                    Console.WriteLine(nazwaPliku);
                    using (FileStream stream = new FileStream(nazwaPliku, FileMode.Create))
                    { 
                        PdfWriter.GetInstance(pdfDoc, stream);

                        pdfDoc.Open();
                        pdfDoc.Add(frontPage);
                        pdfDoc.NewPage();
                        pdfDoc.Add(mainRaport);
                        pdfDoc.Close();
                        stream.Close();
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Zamknij najpierw plik pdf.");
                }
            }
        }

        /// <summary>
        /// Funkcja do edycji nazwy kolumny, usuwająca krawężniki oraz zamieniająca pierwszą literę na wielką.
        /// </summary>
        /// <param name="kolumna">Nazwa kolumny do edycji</param>
        /// <returns></returns>
        private string FormatujNazweKolumny(string kolumna)
        {
            kolumna = kolumna.Replace("_", " ");
            kolumna = char.ToUpper(kolumna[0]) + kolumna.Substring(1);
            return kolumna;
        }
    }
}
