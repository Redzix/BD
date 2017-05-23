using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD
{
    public partial class Rezerwacja : Form
    {
        /// <summary>
        /// Główny bezparametrowy konstruktor okna
        /// </summary>
        public Rezerwacja()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Konstruktor z parametrem, otrzymuje jako parametr obiekt typu wyieczka, aby potem zapisac go do bazy
        /// </summary>
        /// <param name="wycieczka"></param>
        public Rezerwacja(Wycieczka_model wycieczka)
        {
            InitializeComponent();
        }
        /// <summary>
        /// Zdarzenie obsługujące wyłączenie okna po wciśnięciu przycisku "Anuluj".
        /// Usuwa utworzone dotąd w ramach swojego działania niezapisane obiekty.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_rezerwacja_anuluj_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Zdarzenie obsługujące wyłączenie okna poprzez wciśnięcie "X", program wraca do głównego panelu danego użytkownika.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void Rezerwacja_FormClosing(object sender, FormClosingEventArgs e)
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

        private void b_rezerwacja_zapisz_Click(object sender, EventArgs e)
        {
            Klient_model klient = new Klient_model();
            Rezerwacja_model rezerwacja = new Rezerwacja_model();

            klient.Imie = tb_imie.Text;
            klient.Nazwisko = tb_nazwisko.Text;
            klient.Adres = tb_adres.Text;
            klient.Miejscowosc = l_miejscowosc.Text;

            rezerwacja.LiczbaOsob = Int32.Parse(tb_liczba_osob.Text);
            rezerwacja.Stan = false;
            rezerwacja.Zaliczka = decimal.Parse(tb_zaliczka.Text);

            //teraz wysłac do bazy danych rezerwacja/klienta
            MessageBox.Show("wysyłamy do bazy", "huehue", MessageBoxButtons.OK);
            MessageBox.Show(klient.Imie +" "+ klient.Nazwisko + " " + klient.Adres + " " + klient.Miejscowosc 
                + " " + rezerwacja.LiczbaOsob.ToString() + " " + rezerwacja.Zaliczka.ToString(), "dane dupy", MessageBoxButtons.OK);
        }
    }
}
