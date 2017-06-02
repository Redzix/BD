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
    public partial class Klient : Form
    {
        /// <summary>
        /// Zmienna odpowiada za utworzenie połączenia z bazą danych.
        /// </summary>
        SqlConnection _polaczenie = null;

        /// <summary>
        /// Zmienna przechowuje zapytanie do bazy danych.
        /// </summary>
        SqlCommand _zapytanie = null;

        /// <summary>
        /// Zmienna przechowujeobiekt klasy Polacz_z_baza.
        /// </summary>
        Polacz_z_baza _polacz = null;

        private int _idWycieczki;

        private string _nazwa;

        private DateTime _dataWyjazdu;

        private DateTime _dataPowrotu;

        private string _opis;

        private string _adresMiejscaDocelowego;

        private string _miejscowoscDocelowa;

        /// <summary>
        /// Główny bezparametrowy konstruktor okna
        /// </summary>
        public Klient()
        {
            InitializeComponent();
            _polacz = new Polacz_z_baza();
            _polaczenie = _polacz.PolaczZBaza();
            if (_polaczenie != null)
            {
                l_polaczenie.Text = "Połączony";
                l_polaczenie.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                l_polaczenie.Text = "Rozłączony";
                l_polaczenie.ForeColor = System.Drawing.Color.Red;
            }
        }

        /// <summary>
        /// Zdarzenie obsługujące wylogowanie z systemu po wciśnięciu przycisku "Wyjdź", po kliknięciu program przechodzi do panelu logowania.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_katalog_wyjdz_Click(object sender, EventArgs e)
        {
            //klasyczna obsługa wyjścia z programu po klinięciu "X"/przycisku, messagebox pyta, czy zakończyć, jeśtli tak wyacza okno, jesli nie działa dalej
            DialogResult czyZakonczyc = MessageBox.Show("Czy na pewno chcesz się wylogować?", "Wyloguj", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (czyZakonczyc == DialogResult.Yes)
            {
                this.Hide();
                Panel_pracowniczy panel_pracowniczy = new Panel_pracowniczy();
                panel_pracowniczy.Closed += (s, args) => this.Close();
                panel_pracowniczy.Show();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Zdarzenie otwiera okno dialogowe pozwalające złozyć rezerwację..
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_katalog_rezerwuj_Click(object sender, EventArgs e)
        {

            Rezerwacja rezerwacja = new Rezerwacja(_idWycieczki);
            rezerwacja.ShowDialog();
        }

        /// <summary>
        /// Zdarzenie otwiera okno dialogowe pozwalające wystawić opinię.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void wystawOpinięToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opinia opinia = new Opinia();
            opinia.ShowDialog();
        }

        /// <summary>
        /// Zdarzenie otwiera okno dialogowe pozwalające na złożenie reklamacji.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void reklamujWycieczkęToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reklamacja reklamancja = new Reklamacja();
            reklamancja.ShowDialog();
        }

        /// <summary>
        /// Zdarzenie otwiera okno dialogowe pozwalające wprowadzić do bazy nową wycieczkę.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void rezygnacjaZWycieczkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rezygnacja rezygnacja = new Rezygnacja();
            rezygnacja.ShowDialog();
        }

        /// <summary>
        /// Zdarzenie obsługujące wyłączenie aplikacji poprzez wciśnięcie "X", program całkowicie kończy swoją pracę
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void Klient_FormClosing(object sender, FormClosingEventArgs e)
        {
            //najpierw sprawdza, czy user kliknał "X" czy po prostu kliknał sobie jakis przycisk wyłączający okno typu "anuluj"
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult czyZakonczyc = MessageBox.Show("Czy na pewno chcesz się wyjść?", "Zakończ", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (czyZakonczyc == DialogResult.Yes)
                {
                    Application.Exit();
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

        private void Klient_Load(object sender, EventArgs e)
        {
            List<Promocja_model> listaPromocji = new List<Promocja_model>();

            //Wyłączenie generowania dodatkowych kolumn.
            dgv_katalog.AutoGenerateColumns = false;
            // Bindowanie odpowiednich kolumn bazy danych z kolumnami tabeli dgv_tabelaPilot
            dgv_katalog.Columns["Nazwa_wycieczki"].DataPropertyName = "nazwa";
            dgv_katalog.Columns["Okres"].DataPropertyName = "okres_trwania_wycieczki";
            dgv_katalog.Columns["Data_wyjazdu"].DataPropertyName = "data_wyjazdu";
            dgv_katalog.Columns["Promocja"].DataPropertyName = "wartosc_promocji";
            dgv_katalog.Columns["Koszt"].DataPropertyName = "cena_calkowita";

            // Utworzenie zapytania do bazy danych w celu pobrania potrzebnych informacji o wycieczce.
            _zapytanie = _polacz.UtworzZapytanie("SELECT nazwa," +
                "okres_trwania_wycieczki," +
                "data_wyjazdu," +
                "Promocja.cena as wartosc_promocji," +
                "Cennik.cena - Promocja.cena as cena_calkowita" +
                " FROM Katalog " +
                "inner join Wycieczka on Katalog.id_wycieczki = Wycieczka.id_wycieczki " +
                "inner join Promocja on Wycieczka.id_wycieczki = Promocja.id_wycieczki " +
                "inner join Cennik on Katalog.id_cennika = Cennik.id_cennika");

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(_zapytanie);

            // Utworzenie i wypełnienie tabeli jako DataSource
            DataTable tabela = new DataTable();
            sqlDataAdapter.Fill(tabela);
            dgv_katalog.DataSource = tabela;

        }

        private void dgv_katalog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Podświetlenie wybranego wiersza
            dgv_katalog.Rows[dgv_katalog.CurrentCell.RowIndex].Selected = true;

            //Pobranie z tabeli oraz z bazy danych odpowiednich wartości do wyświetlenia.
            _idWycieczki = dgv_katalog.CurrentCell.RowIndex + 1; 

            _nazwa = dgv_katalog.Rows[dgv_katalog.CurrentCell.RowIndex].Cells["Nazwa_wycieczki"].Value.ToString();

            _dataWyjazdu = _polacz.PobierzDaneDate(_polacz.UtworzZapytanie("SELECT data_wyjazdu FROM Wycieczka WHERE nazwa= "
                + "'" + _nazwa + "'"));

            _dataPowrotu = _polacz.PobierzDaneDate(_polacz.UtworzZapytanie("SELECT data_powrotu FROM Wycieczka WHERE nazwa= "
                + "'" + _nazwa + "'"));

            _opis = _polacz.PobierzDaneString(_polacz.UtworzZapytanie("SELECT opis FROM Wycieczka WHERE nazwa= "
                + "'" + _nazwa + "'")).ToString();

            _adresMiejscaDocelowego = _polacz.PobierzDaneString(_polacz.UtworzZapytanie("SELECT adres " +
                "FROM Miejsce " +
                "INNER JOIN Katalog ON Miejsce.id_miejsca = Katalog.id_miejsca_przyjazdu " +
                "INNER JOIN Wycieczka ON Wycieczka.id_wycieczki = Katalog.id_wycieczki " +
                "WHERE Wycieczka.nazwa = " + "'" + _nazwa + "'"));

            _miejscowoscDocelowa = _polacz.PobierzDaneString(_polacz.UtworzZapytanie("SELECT miejscowosc " +
                "FROM Miejsce " +
                "INNER JOIN Katalog ON Miejsce.id_miejsca = Katalog.id_miejsca_przyjazdu " +
                "INNER JOIN Wycieczka ON Wycieczka.id_wycieczki = Katalog.id_wycieczki " +
                "WHERE Wycieczka.nazwa = " + "'" + _nazwa + "'"));


            // Dodanie wartości parametrów do opisu znajdującego się w texboxie
            rtb_wycieczka.Text =
                "Nazwa: " + _nazwa +
                "\nData wyjazdu: " + _dataWyjazdu +
                "\nData powrotu: " + _dataPowrotu +
                "\nOpis: " + _opis +
                "\n\nAdres miejsca: " + _adresMiejscaDocelowego +
                "\nMiejscowość: " + _miejscowoscDocelowa;
        }
             
    }
}
