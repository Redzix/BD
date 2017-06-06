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

namespace BD.View
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
                PanelPracowniczyView panel_pracowniczy = new PanelPracowniczyView();
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

            RezerwacjaView rezerwacja = new RezerwacjaView(_idWycieczki);
            rezerwacja.ShowDialog();
        }

        /// <summary>
        /// Zdarzenie otwiera okno dialogowe pozwalające wystawić opinię.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void wystawOpinięToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpiniaView opinia = new OpiniaView();
            opinia.ShowDialog();
        }

        /// <summary>
        /// Zdarzenie otwiera okno dialogowe pozwalające na złożenie reklamacji.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void reklamujWycieczkęToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReklamacjaView reklamancja = new ReklamacjaView();
            reklamancja.ShowDialog();
        }

        /// <summary>
        /// Zdarzenie otwiera okno dialogowe pozwalające wprowadzić do bazy nową wycieczkę.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void rezygnacjaZWycieczkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RezygnacjaView rezygnacja = new RezygnacjaView();
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
            dgv_katalog.AutoGenerateColumns = false;
            // Bindowanie odpowiednich kolumn bazy danych z kolumnami tabeli dgv_tabelaPilot
            dgv_katalog.Columns["id_wycieczki"].DataPropertyName = "wycieczkaId";
            dgv_katalog.Columns["Nazwa_wycieczki"].DataPropertyName = "wycieczka";
            dgv_katalog.Columns["Okres"].DataPropertyName = "okresTrwaniaWycieczki";
            dgv_katalog.Columns["Data_wyjazdu"].DataPropertyName = "dataOdjazdu";
            dgv_katalog.Columns["Promocja"].DataPropertyName = "wartoscPromocji";
            dgv_katalog.Columns["Koszt"].DataPropertyName = "cenaCalkowita";

            bazaEntities db = new bazaEntities();

            var query = from katalog in db.Katalog
                        select new {
                            wycieczkaId = katalog.id_wycieczki,
                            wycieczka = katalog.Wycieczka.nazwa,
                            okresTrwaniaWycieczki = katalog.okres_trwania_wycieczki,
                            dataOdjazdu = katalog.Wycieczka.data_wyjazdu,
                            wartoscPromocji = (katalog.Wycieczka.Promocja.cena != null) ? katalog.Wycieczka.Promocja.cena : 0,
                            cenaCalkowita = katalog.Cennik.cena - ((katalog.Wycieczka.Promocja.cena != null) ? katalog.Wycieczka.Promocja.cena : 0)
                        };
            dgv_katalog.DataSource = query.ToList();

        }

        private void dgv_katalog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Podświetlenie wybranego wiersza
            ((DataGridView)sender).Rows[e.RowIndex].Selected = true;

            //Pobranie z tabeli oraz z bazy danych odpowiednich wartości do wyświetlenia.
            int.TryParse(((DataGridView)sender)[0, e.RowIndex].FormattedValue.ToString(), out _idWycieczki);

            bazaEntities db = new bazaEntities();

            var query = (from katalog in db.Katalog
                         where katalog.id_wycieczki == _idWycieczki 
                         select new {
                            wycieczka = katalog.Wycieczka.nazwa,
                            dataOdjazdu = katalog.Wycieczka.data_wyjazdu,
                            dataPowrotu = katalog.Wycieczka.data_wyjazdu,
                            opisWycieczki = katalog.Wycieczka.opis,
                            miejsceDoceloweAdres = katalog.Miejsce.adres,
                            miejsceDoceloweMiejscowosc = katalog.Miejsce.miejscowosc
                         }).FirstOrDefault();

            // Dodanie wartości parametrów do opisu znajdującego się w texboxie

            rtb_wycieczka.Text =
                "Nazwa: " + query.wycieczka +
                "\nData wyjazdu: " + query.dataOdjazdu +
                "\nData powrotu: " + query.dataPowrotu +
                "\nOpis: " + query.opisWycieczki +
                "\n\nAdres miejsca: " + query.miejsceDoceloweAdres +
                "\nMiejscowość: " + query.miejsceDoceloweMiejscowosc;
        }
             
    }
}
