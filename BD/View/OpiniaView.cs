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
    public partial class OpiniaView : Form
    {
        private OpiniaController controller;
        private string _uzytkownik;

        /// <summary>
        /// Główny bezparametrowy konstruktor okna
        /// </summary>
        public OpiniaView()
        {
            InitializeComponent();
            cb_ocena.SelectedIndex = 0;
            controller = new OpiniaController(this);
        }

        /// <summary>
        /// Dodaje rezygnację dla zdefiniowanego wcześniej użytkownika
        /// </summary>
        /// <param name="uzytkownik">Aktualny użytkownik</param>
        public OpiniaView(string uzytownik)
        {
            InitializeComponent();
            cb_ocena.SelectedIndex = 0;
            _uzytkownik = uzytownik;
            controller = new OpiniaController(this);
        }

        /// <summary>
        /// Zdarzenie obsługujące wyłączenie okna poprzez wciśnięcie "X", program wraca do głównego panelu danego użytkownika.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void Opinia_FormClosing(object sender, FormClosingEventArgs e)
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

        private void b_zapisz_Click(object sender, EventArgs e)
        {
            int zapisz = controller.DodajOpinie(tb_numerRezerwacji.Text, cb_ocena.SelectedIndex + 1, tb_opinia.Text,_uzytkownik);

            switch (zapisz)
            {
                case 1:
                    MessageBox.Show("Opinia została dodana prawidłowo.", "Dodano opinię", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                    break;
                case -1:
                    MessageBox.Show("Wystąpił problem podczas dodawania opinii. Problem związany z obsługa bazy danych.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 0:
                    MessageBox.Show("Wystąpił problem podczas dodawania opinii. Problem zwiazany z konwersją.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            } 
        }
        
        private void tb_numerRezerwacji_Leave(object sender, EventArgs e)
        {

            int pobierz = controller.PobierzNazweWycieczki(tb_numerRezerwacji.Text, _uzytkownik);

            switch (pobierz)
            {
                case 1:
                    this.b_zapisz.Enabled = true;
                    break;
                case -1:
                    MessageBox.Show("Podaj poprawny numer rezerwacji. Taka rezerwacja nie isntnieje.", "Błeny numer rezerwacji.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.b_zapisz.Enabled = false;
                    break;
                case 0:
                    MessageBox.Show("Podaj poprawny numer rezerwacji. Błędny format.", "Błeny numer rezerwacji.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }    
        }
    }
}
