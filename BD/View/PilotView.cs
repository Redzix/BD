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
        private PilotController controller;
        private string _uzytkownik;

        /// <summary>
        /// Główny bezparametrowy konstruktor okna,, tworzący okno oraz połączenie z bazą danych.
        /// </summary>
        public PilotView()
        {
            InitializeComponent();

            l_uzytkownik.Text = "Niezidentyfikowany użytkownik";
            l_polaczenie.Text = "Połączony";
            l_polaczenie.ForeColor = System.Drawing.Color.Green;

            controller = new PilotController(this);
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
            l_polaczenie.Text = "Połączony";
            _uzytkownik = uzytkownik;
            l_polaczenie.ForeColor = System.Drawing.Color.Green;

            controller = new PilotController(this);

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
            if (!controller.PobierzWycieczki(_uzytkownik))
            { 
                MessageBox.Show("Wystąpił problem podczas pobierania danych z bazy.", "Błąd podczas pobierania.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
