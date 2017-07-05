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
    /// <summary>
    /// Widok dostępny dla pilota
    /// </summary>
    public partial class PilotView : Form
    {
        /// <summary>
        /// Obiekt przechowujący kontroler.
        /// </summary>
        private PilotController controller;

        /// <summary>
        /// Obiekt przechowujący klasę odpowiedzialną za sprawdzanie zmian w bazie.
        /// </summary>
        AktualizacjaController aktWycieczki;

        /// <summary>
        /// Zmienna przechowująca pesel aktualnie wybranej wycieczki
        /// </summary>
        private Pilot _uzytkownik;

        /// <summary>
        /// Konstruktor okna z parametrem, pozwalający na przekazanie nazwy użytkownika zalogowanego do systemu
        /// oraz tworzący połączenie z bazą danych.
        /// </summary>
        /// <param name="uzytkownik">Nazwa użytkownika</param>
        public PilotView(Pilot uzytkownik)
        {
            InitializeComponent();

            l_uzytkownik.Text = uzytkownik.DaneOsobowe();
            l_polaczenie.Text = "Połączony";
            _uzytkownik = uzytkownik;
            l_polaczenie.ForeColor = System.Drawing.Color.Green;         

            controller = new PilotController(this);

            aktWycieczki = new AktualizacjaController("wycieczka");

            this.helpProvider.HelpNamespace = "Helper\\Pilot.chm";

            timer1.Start();
        }

        /// <summary>
        /// Metoda obsługująca zdarzenie wylogowania z systemu po wciśnięciu przycisku "Wyjdź", po kliknięciu program przechodzi do panelu logowania.
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
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
        /// Metoda obsługująca zdarzenie wyłączenia aplikacji poprzez wciśnięcie "X", program całkowicie kończy swoją pracę
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
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
        /// Metoda obsługująca zdarzenie ładowania widoku odpowiedzialne za wywołanie funkcji ładującej informacje
        /// o wycieczkach do widoku i obsługujące jej komunikaty.
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void Pilot_Load(object sender, EventArgs e)
        {
            if (!controller.PobierzWycieczki(_uzytkownik.pesel))
            { 
                MessageBox.Show("Wystąpił problem podczas pobierania danych z bazy.", "Błąd podczas pobierania.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Metoda implementująca wywołanie funkcji sortującej wiersze w kolumnach
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
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
        /// Metoda obsługująca zdarzenie kliknięcia na nagłówek kolumny, sortuje zawartość listview według danej kolumny
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void lv_pilot_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            sortListViewByColumn(sender, e);
        }

        /// <summary>
        /// Metoda obsługująca kolejne ticki timera, co 5s uruchamia metode sprawdzającą, czy nastąpiła aktualizacja w bazie danych
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (aktWycieczki.czyBylaAktualizacja())
            {
                controller.PobierzWycieczki(_uzytkownik.pesel);
            }
            else
            {
                return;
            }
        }
    }
}
