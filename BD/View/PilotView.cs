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
using System.Threading;
using BD.Controller;

namespace BD.View
{
    public partial class PilotView : Form
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

        /// <summary>
        /// Główny bezparametrowy konstruktor okna,, tworzący okno oraz połączenie z bazą danych.
        /// </summary>
        public PilotView()
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
        public PilotView(string uzytkownik)
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
        /// Zdarzenie obsługujące wyłączenie aplikacji poprzez wciśnięcie "X", program całkowicie kończy swoją pracę
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void Pilot_FormClosing(object sender, FormClosingEventArgs e)
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

        /// <summary>
        /// Zdarzenie, które po załadowaniu aplikacji ładuje dane z bazy danych do dataGridView
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void Pilot_Load(object sender, EventArgs e)
        {

            PilotController controller = new PilotController(this);

            if (!controller.PobierzPilotow())
            { 
                MessageBox.Show("Wystąpił problem podczas pobierania danych z bazy.", "Błąd podczas pobierania.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            /*
             // Bindowanie odpowiednich kolumn bazy danych z kolumnami tabeli dgv_tabelaPilot
             dgv_tabelaPilot.Columns["id_wycieczki"].DataPropertyName = "wycieczkaId";
             dgv_tabelaPilot.Columns["Nazwa_wycieczki"].DataPropertyName = "wycieczka";
             dgv_tabelaPilot.Columns["Data_wyjazdu"].DataPropertyName = "dataOdjazdu";
             dgv_tabelaPilot.Columns["Data_powrotu"].DataPropertyName = "dataPowrotu";
             dgv_tabelaPilot.Columns["Pojazd"].DataPropertyName = "pojazd";
             dgv_tabelaPilot.Columns["Kierowca"].DataPropertyName = "kierowca";

             bazaEntities db = new bazaEntities();

             var query = from wycieczka in db.Wycieczka
                         join kierowca in db.Kierowca on wycieczka.Kierowca_pesel equals kierowca.pesel
                         select new
                         {
                             wycieczkaId = wycieczka.id_wycieczki,
                             wycieczka = wycieczka.nazwa,
                             dataOdjazdu = wycieczka.data_wyjazdu,
                             dataPowrotu = wycieczka.data_powrotu,
                             pojazd = wycieczka.Pojazd_numer_rejestracyjny,
                             kierowca = wycieczka.Kierowca.imie + " " + wycieczka.Kierowca.nazwisko
                         };

             if (query == null)
             {
                 MessageBox.Show("Wystąpił problem podczas pobierania danych z bazy.", "Błąd podczas pobierania.", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             else
             {
                 dgv_tabelaPilot.DataSource = query.ToList();
             } */
        }
    }
}
