using BD.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.Mapping;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD.View
{
    /// <summary>
    /// Widok okna służacego do generowania raportów dla danych argumentów
    /// </summary>
    public partial class RaporterView : Form
    {
        /// <summary>
        /// Kontroler odpowiedzialny za generowanie PDF
        /// </summary>
        RaporterController controller;
        /// <summary>
        /// Rodzaj raportu (pojazdy, wycieczki, reklamacje)
        /// </summary>
        int rodzaj;
        /// <summary>
        /// Konstruktor tworzący widok bazując na rodzaju
        /// </summary>
        /// <param name="rodzaj">Typ raportu do wygenerowania</param>
        public RaporterView(int rodzaj)
        {
            InitializeComponent();
            this.rodzaj = rodzaj;
            controller = new RaporterController(this);
            controller.ZaladujKolumny(rodzaj);
        }
        /// <summary>
        /// Przycisk odpowiadający za generowanie raportu
        /// </summary>
        /// <param name="sender">Obiekt wysyłający event</param>
        /// <param name="e">Argumenty eventu</param>
        private void b_GenerujRaport_Click(object sender, EventArgs e)
        {
            PdfCreator pdf = new PdfCreator(textBox1.Text);
            try
            {
                pdf.createPDF(lv_Sortowanie);
                MessageBox.Show("Raport został wygenerowany dla odpowiednich kolumn.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch
            {
                MessageBox.Show("Najpierw musisz wypełnić pola dla raportu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Przycisk odpowiadający za dodanie kolumn, które znajdą się w raporcie
        /// </summary>
        /// <param name="sender">Obiekt wysyłający event</param>
        /// <param name="e">Argumenty eventu</param>
        private void b_DodajKolumny_Click(object sender, EventArgs e)
        {
            switch (rodzaj)
            {
                case 0:
                    controller.WypelnijDlaWycieczek(false);
                    break;
                case 1:
                    controller.WypelnijDlaReklamacji(false);
                    break;
                case 2:
                    controller.WypelnijDlaPojazdow(false);
                    break;
            }
        }
        /// <summary>
        /// Metoda odpowiadająca za sortowanie kolumn 
        /// </summary>
        /// <param name="sender">Obiekt wysyłający event</param>
        /// <param name="e">Argumenty eventu</param>
        private void sortListViewByColumn(object sender, ColumnClickEventArgs e)
        {
            if (((ListView)sender).Sorting == System.Windows.Forms.SortOrder.Ascending)
                ((ListView)sender).Sorting = System.Windows.Forms.SortOrder.Descending;
            else
                ((ListView)sender).Sorting = System.Windows.Forms.SortOrder.Ascending;
            ((ListView)sender).Sort();
            ((ListView)sender).ListViewItemSorter = new ListViewItemComparer(e.Column, ((ListView)sender).Sorting);
        }
        /// <summary>
        /// Akcja dla klikniętej nazwy kolumny w celu sortowania jej
        /// </summary>
        /// <param name="sender">Obiekt wysyłający event</param>
        /// <param name="e">Argumenty eventu</param>
        private void lv_Sortowanie_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            sortListViewByColumn(sender, e);
        }
    }
}
