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

namespace BD
{
    public partial class Rezerwacja : Form
    {
        private int _idWycieczki;

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
        public Rezerwacja(int idWycieczki)
        {
            _idWycieczki = idWycieczki;
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
            Uczestnictwo_model uczestnictwo = new Uczestnictwo_model();
            Polacz_z_baza polacz = new Polacz_z_baza();
            SqlConnection polaczenie = polacz.PolaczZBaza();

            klient.Pesel = tb_pesel.Text;
            klient.Imie = tb_imie.Text;
            klient.Nazwisko = tb_nazwisko.Text;
            klient.Adres = tb_adres.Text;
            klient.Miejscowosc = tb_miejscowosc.Text;

            rezerwacja.Numer = polacz.PobierzDaneInt(polacz.UtworzZapytanie("select MAX(numer_rezerwacji) FROM rezerwacja")) +1;
            rezerwacja.LiczbaOsob = Int32.Parse(tb_liczba_osob.Text);
            rezerwacja.Stan = 0;
            rezerwacja.Zaliczka = Convert.ToDecimal(tb_zaliczka.Text);
            rezerwacja.IdWycieczki = _idWycieczki;
            rezerwacja.KlientPesel = klient.Pesel;

            uczestnictwo.IdUczestnictwa = polacz.PobierzDaneInt(polacz.UtworzZapytanie("select MAX(id_uczestnictwo) FROM Uczestnictwo")) + 1;
            uczestnictwo.LiczbaOsob = rezerwacja.LiczbaOsob;
            uczestnictwo.NumerRezerwacji = rezerwacja.Numer;
            

            klient.DodajKlienta(klient);
            if(rezerwacja.DodajRezerwacje(rezerwacja))
            {
                if (uczestnictwo.DodajUczestnictwo(uczestnictwo))
                {
                    MessageBox.Show("Rezerwację dodano poprawnie.", "Potwierdzenie rezerwacji.", MessageBoxButtons.OK);
                    this.Dispose();
                }
            }
            else
            {
                MessageBox.Show("Wystąpił problem z dodanie rezerwacji. Prawdopodobnie złożona rezerwacja o danym numerze już istnieje.", "Bład rezerwacji",MessageBoxButtons.OK);
            }
        }
      
    }
}
