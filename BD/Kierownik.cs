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
    public partial class Kierownik : Form
    {
        SqlConnection _polaczenie = null;
        SqlCommand _zapytanie = null;
        Polacz_z_baza _polacz = null;
        List<Pojazd_model> _listaPojazdow = new List<Pojazd_model>();
        List<Reklamacja_model> _listaReklamacji = new List<Reklamacja_model>();

        /// <summary>
        /// Główny bezparametrowy konstruktor okna, tworzący okno oraz połączenie z bazą danych.
        /// </summary>
        public Kierownik()
        {
            InitializeComponent();
            l_uzytkownik.Text = "Niezidentyfikowany użytkownik";
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
        /// Konstruktor okna z parametrem, pozwalający na przekazanie nazwy użytkownika zalogowanego do systemu 
        /// oraz tworzący połączenie z bazą danych.
        /// </summary>
        /// <param name="uzytkownik">Nazwa użytkownika</param>
        public Kierownik(string uzytkownik)
        {
            InitializeComponent();
            l_uzytkownik.Text = uzytkownik;
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
        /// a co to je?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Kierownik_Load(object sender, EventArgs e)
        {
           // this.reportViewer1.RefreshReport();
        }

        /// <summary>
        /// Zdarzenie otwiera okno dialogowe pozwalające wprowadzić do bazy nowy pojazd.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_dodaj_pojazd_Click(object sender, EventArgs e)
        {
            Pojazd pojazd = new Pojazd();
            pojazd.ShowDialog();
        }

        /// <summary>
        /// Zdarzenie obsługujące wyłączenie aplikacji poprzez wciśnięcie "X", program całkowicie kończy swoją pracę
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void Kierownik_FormClosing(object sender, FormClosingEventArgs e)
        {
           //najpierw sprawdza, czy user kliknał "X" czy po prostu kliknał sobie jakis przycisk wyłączający okno typu "anuluj"
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult czyZakonczyc = MessageBox.Show("Czy na pewno chcesz wyjść?", "Zakończ", MessageBoxButtons.YesNo,
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

        /// <summary>
        /// Zdarzenie obsługujące wylogowanie z systemu po wciśnięciu przycisku "Wyjdź", po kliknięciu program przechodzi do panelu logowania.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_wyjdz_Click(object sender, EventArgs e)
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
        /// Zdarzenie otwiera okno dialogowe pozwalające wprowadzić do bazy nową wycieczkę.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_dodaj_wycieczke_Click(object sender, EventArgs e)
        {
            Katalog_kontroler_list katalog = new Katalog_kontroler_list();

            List<Katalog_kontroler_list> lista = katalog.PobierzListeDlaKierownika();


            for (int i = 0; i < lista.Count; i++)
            {
                ListViewItem awycieczka = new ListViewItem(lista[i].NazwaWycieczki.ToString());
                awycieczka.SubItems.Add(lista[i].DataWyjazdu.ToString());
                awycieczka.SubItems.Add(lista[i].DataPrzyjazdu.ToString());
                awycieczka.SubItems.Add(lista[i].Opis.ToString());
                awycieczka.SubItems.Add(lista[i].Promocja.ToString());
                awycieczka.SubItems.Add(lista[i].Cena.ToString());
                awycieczka.SubItems.Add(lista[i].Kierowca.ToString());
                awycieczka.SubItems.Add(lista[i].Pilot.ToString());
                awycieczka.SubItems.Add(lista[i].MiejsceOdjazdu.ToString());
                awycieczka.SubItems.Add(lista[i].MiejsceDocelowe.ToString());

                lv_wycieczki.Items.Add(awycieczka);
            }


            Wycieczka wycieczka = new Wycieczka();
            wycieczka.ShowDialog();
        }

        private void tc_kierownik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tc_kierownik.SelectedIndex == 1)
            {
                Reklamacja_model _reklamacja= new Reklamacja_model();
                _listaReklamacji = _reklamacja.PobierzReklamacje();

                for (int i = 0; i < _listaReklamacji.Count; i++)
                {
                    ListViewItem reklamacja = new ListViewItem(_listaReklamacji[i].Numer.ToString());
                    lv_reklamacje.Items.Add(reklamacja);
                }
            }
            else if (tc_kierownik.SelectedIndex == 2)
            {
                Pojazd_model _pojazdy = new Pojazd_model();
                _listaPojazdow = _pojazdy.PobierzPojazdy();

                for (int i = 0; i < _listaPojazdow.Count; i++)
                {
                    ListViewItem pojazd = new ListViewItem(_listaPojazdow[i].NumerRejestracyjny.ToString());
                    pojazd.SubItems.Add(_listaPojazdow[i].Dostepnosc.ToString());
                    pojazd.SubItems.Add(_listaPojazdow[i].Marka.ToString());
                    pojazd.SubItems.Add(_listaPojazdow[i].Pojemnosc.ToString());
                    pojazd.SubItems.Add(_listaPojazdow[i].Stan.ToString());
                    lv_pojazdy.Items.Add(pojazd);
                }
            }
        }

    }
}
