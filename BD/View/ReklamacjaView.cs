using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BD.Controller;

namespace BD.View
{
    public partial class ReklamacjaView : Form
    {
        private ReklamacjaController controller;
        private string _uzytkownik;

        /// <summary>
        /// Główny bezparametrowy konstruktor okna
        /// </summary>
        public ReklamacjaView()
        {
            InitializeComponent();
            controller = new ReklamacjaController(this);
        }

        public ReklamacjaView(string uzytkownik)
        {
            InitializeComponent();
            _uzytkownik = uzytkownik;
            controller = new ReklamacjaController(this);
        }

        /// <summary>
        /// Zdarzenie obsługujące wyłączenie okna po wciśnięciu przycisku "Anuluj".
        /// Usuwa utworzone dotąd w ramach swojego działania niezapisane obiekty.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_anuluj_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Zdarzenie obsługujące wyłączenie okna poprzez wciśnięcie "X", program wraca do głównego panelu danego użytkownika.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void Reklamacja_FormClosing(object sender, FormClosingEventArgs e)
        {
            //najpierw sprawdza, czy user kliknał "X" czy po prostu kliknał sobie jakis przycisk wyłączający okno typu "anuluj"
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult czyZakonczyc = MessageBox.Show("Czy na pewno chcesz zamknąć to okno?", "Zamknięcie okna", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (czyZakonczyc == DialogResult.Yes)
                {
                    this.Dispose();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void b_zapisz_Click(object sender, EventArgs e)
        {
            int zapisz = controller.DodajReklamacje(tb_numerRezerwacji.Text,_uzytkownik);

            switch (zapisz)
            {
                case 1:
                    MessageBox.Show("Prawidłowo dodano reklamację.", "Dodano reklamację.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                    break;
                case 0:
                    MessageBox.Show("Wprowadzono nieprawidłowy numer rezerwacji. Błedny format.", "Błąd podczas dodawania reklamacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -1:
                    MessageBox.Show("Wystąpił problem podczas dodawania reklamacji. Błąd z zapisem do bazy danych." , "Błąd podczas dodawania reklamacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -2:
                    MessageBox.Show("Wprowadzono inny numer rezerwacji. Sprawdź poprawność tego numeru.", "Błąd podczas dodawania reklamacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }             
        }

        private void tc_reklamacje_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tc_reklamacje.SelectedIndex == 1)
            {
                if (controller.PobierzReklamacje(_uzytkownik))
                {
                    return;
                }
                else
                {
                    MessageBox.Show("Wystąpił bład podczas pobierania danych.", "Błąd pobierania danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lv_reklamacje_ItemActivate(object sender, EventArgs e)
        {
            int pobierz = controller.PobierzInformacjeOReklamacji(((ListView)sender).SelectedItems[0].Tag.ToString(), _uzytkownik);

            switch (pobierz)
            {
                case 1:
                    break;
                case 0:
                    MessageBox.Show("Nieprawidłowy format numeru reklamacji. Błędny format.", "Błąd podczas pobierania danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -1:
                    MessageBox.Show("Wystapił problem podczas pobierania danych.", "Błąd podczas pobierania danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }
        }

        private void b_sprawdzPoprawnosc_Click(object sender, EventArgs e)
        {
            int pobierz = controller.PobierzNazweWycieczki(tb_numerRezerwacji.Text, _uzytkownik);

            switch (pobierz)
            {
                case 1:
                    b_zapisz.Enabled = true;
                    break;
                case -1:
                    MessageBox.Show("Wprowadź prawidłowy numer rezerwacji. Taka rezerwacja nie istnieje.", "Błąd podczas pobierania danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_nazwaWycieczki.Text = "Błędna rezerwacja";
                    b_zapisz.Enabled = false;
                    break;
                case 0:
                    MessageBox.Show("Wprowadź prawidłowy numer rezerwacji. Błędny format.", "Błąd podczas pobierania danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    b_zapisz.Enabled = false;
                    break;
                case -2:
                    MessageBox.Show("Wystapił problem podczas pobierania danych.", "Błąd podczas pobierania danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    b_zapisz.Enabled = false;
                    break;
                default:
                    break;
            }          
        }

        private void sortListViewByColumn(object sender, ColumnClickEventArgs e)
        {
            if (((ListView)sender).Sorting == System.Windows.Forms.SortOrder.Ascending)
                ((ListView)sender).Sorting = System.Windows.Forms.SortOrder.Descending;
            else
                ((ListView)sender).Sorting = System.Windows.Forms.SortOrder.Ascending;
            ((ListView)sender).Sort();
            ((ListView)sender).ListViewItemSorter = new ListViewItemComparer(e.Column, ((ListView)sender).Sorting);
        }

        private void lv_reklamacje_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            sortListViewByColumn(sender, e);
        }
    }
}
