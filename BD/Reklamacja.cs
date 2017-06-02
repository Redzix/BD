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
    public partial class Reklamacja : Form
    {
        List<Wycieczka_model>  _listaWycieczek= new List<Wycieczka_model>();
        List<Reklamacja_model> _listaReklamacji = new List<Reklamacja_model>();
        Polacz_z_baza _polacz = new Polacz_z_baza();
        SqlConnection _polaczenie = new SqlConnection();

        /// <summary>
        /// Główny bezparametrowy konstruktor okna
        /// </summary>
        public Reklamacja()
        {
            InitializeComponent();
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
            Polacz_z_baza polacz = new Polacz_z_baza();
            SqlConnection polaczenie = polacz.PolaczZBaza();

            Reklamacja_model reklamacja = new Reklamacja_model();

            reklamacja.Numer = polacz.PobierzDaneInt(polacz.UtworzZapytanie("SELECT MAX(numer_reklamacji) FROM Reklamacja")) + 1;
            reklamacja.Opis = tb_opis_reklamacji.Text;
            reklamacja.Stan = 0;
            reklamacja.KierownikPesel = "00043446798";
            reklamacja.IdUczestnictwo = polacz.PobierzDaneInt(polacz.UtworzZapytanie("SELECT Uczestnictwo.id_uczestnictwo " +
                "FROM Uczestnictwo " +
                "WHERE Uczestnictwo.numer_rezerwacji = " + Convert.ToInt32(tb_numerRezerwacji.Text)));

            if (reklamacja.DodajReklamacje(reklamacja))
            {
                MessageBox.Show("Reklamacje dodano poprawnie.", "Potwierdzenie dodania reklamacji", MessageBoxButtons.OK);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Reklamacja już istnieje", "Błąd reklamacji", MessageBoxButtons.OK);
            }
        }

        private void Reklamacja_Load(object sender, EventArgs e)
        {
            _listaWycieczek = (new Wycieczka_model()).PobierzWycieczki();

            for (int i = 0; i < _listaWycieczek.Count; i++)
            {
                cb_nazwa_wycieczki.Items.Add(_listaWycieczek[i].Nazwa.ToString());
            }
            cb_nazwa_wycieczki.SelectedIndex = 0;
        }

        private void tc_reklamacje_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tc_reklamacje.SelectedIndex == 0)
            {
                _listaWycieczek = (new Wycieczka_model()).PobierzWycieczki();

                for (int i = 0; i < _listaWycieczek.Count; i++)
                {
                    cb_nazwa_wycieczki.Items.Add(_listaWycieczek[i].Nazwa.ToString());
                }
                cb_nazwa_wycieczki.SelectedIndex = 0;
            }
            else if(tc_reklamacje.SelectedIndex == 1)
            {
                _listaReklamacji = (new Reklamacja_model()).PobierzReklamacje();

                for (int i = 0; i < _listaReklamacji.Count; i++)
                {
                    ListViewItem reklamacja = new ListViewItem(_listaReklamacji[i].Numer.ToString());
                    lv_reklamacje.Items.Add(reklamacja);
                }
            }
        }

        private void lv_reklamacje_ItemActivate(object sender, EventArgs e)
        {
            int numerReklamacji;
            string nazwaWycieczki;
            DateTime dataWycieczki;
            string opis;

            _polaczenie = _polacz.PolaczZBaza();

            //Pobranie aktualnie wybranego numeru reklamacji
            numerReklamacji =Convert.ToInt32(lv_reklamacje.SelectedItems[0].SubItems[0].Text);

            //Pobranie nazwy wycieczki przypisanej do danej reklamacji
            nazwaWycieczki = _polacz.PobierzDaneString(_polacz.UtworzZapytanie("SELECT Wycieczka.nazwa " +
                "FROM Wycieczka " +
                "INNER JOIN Rezerwacja ON Rezerwacja.id_wycieczki = Wycieczka.id_wycieczki " +
                "INNER JOIN Uczestnictwo ON Rezerwacja.numer_rezerwacji = Uczestnictwo.numer_rezerwacji " +
                "INNER JOIN Reklamacja ON Uczestnictwo.id_uczestnictwo = Reklamacja.id_uczestnictwo " +
                "WHERE Reklamacja.numer_reklamacji = " + numerReklamacji));

            //Pobranie daty wyjazdu na wycieczke
            dataWycieczki = _polacz.PobierzDaneDate(_polacz.UtworzZapytanie("SELECT Wycieczka.data_wyjazdu " +
                "FROM Wycieczka " +
                "INNER JOIN Rezerwacja ON Rezerwacja.id_wycieczki = Wycieczka.id_wycieczki " +
                "INNER JOIN Uczestnictwo ON Rezerwacja.numer_rezerwacji = Uczestnictwo.numer_rezerwacji " +
                "INNER JOIN Reklamacja ON Uczestnictwo.id_uczestnictwo = Reklamacja.id_uczestnictwo " +
                "WHERE Reklamacja.numer_reklamacji = " + numerReklamacji));

            //Pobranie opisu reklamacji
            opis = _listaReklamacji[numerReklamacji - 1].Opis;

            //Dodanie wartości parametrów do opisu znajdującego się w texboxie

            // Dodanie wartości parametrów do opisu znajdującego się w texboxie
            rtb_reklamacja.Text =
                "Numer reklamacji: " + numerReklamacji +
                "\nNazwa wycieczki: " + nazwaWycieczki +
                "\nData wycieczki: " + dataWycieczki +
                "\nOpis: " + opis;

        }
    }
}
