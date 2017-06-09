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
    public partial class KlientView : Form
    {

        private int _idWycieczki;
        private KlientController controller;
        private string _uzytkownik;

        /// <summary>
        /// Główny bezparametrowy konstruktor okna
        /// </summary>
        public KlientView()
        {
            InitializeComponent();

            l_uzytkownik.Text = "Niezidentyfikowany użytkownik";
            l_polaczenie.Text = "Połączony";
            l_polaczenie.ForeColor = System.Drawing.Color.Green;
       
            controller = new KlientController(this);
        }

        /// <summary>
        /// Konstruktor okna z parametrem, pozwalający na przekazanie nazwy użytkownika zalogowanego do systemu 
        /// oraz tworzący połączenie z bazą danych.
        /// </summary>
        /// <param name="uzytkownik">Nazwa użytkownika</param>
        public KlientView(string uzytkownik)
        {
            InitializeComponent();

            l_uzytkownik.Text = uzytkownik;
            l_polaczenie.Text = "Połączony";
            l_polaczenie.ForeColor = System.Drawing.Color.Green;

            _uzytkownik = uzytkownik;
            controller = new KlientController(this);
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
            RezerwacjaView rezerwacja = new RezerwacjaView(_idWycieczki,_uzytkownik);
            rezerwacja.ShowDialog();
        }

        /// <summary>
        /// Zdarzenie otwiera okno dialogowe pozwalające wystawić opinię.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void wystawOpinięToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpiniaView opinia = new OpiniaView(_uzytkownik);
            opinia.ShowDialog();
        }

        /// <summary>
        /// Zdarzenie otwiera okno dialogowe pozwalające na złożenie reklamacji.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void reklamujWycieczkęToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReklamacjaView reklamancja = new ReklamacjaView(_uzytkownik);
            reklamancja.ShowDialog();
        }

        /// <summary>
        /// Zdarzenie otwiera okno dialogowe pozwalające wprowadzić do bazy nową wycieczkę.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void rezygnacjaZWycieczkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RezygnacjaView rezygnacja = new RezygnacjaView(_uzytkownik);
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
            if(controller.PobierzWycieczki())
            {
                this.b_katalog_rezerwuj.Enabled = true;
            }
            else
            {
                MessageBox.Show("Wystąpił problem podczas pobierania danych z bazy.", "Błąd podczas pobierania.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.b_katalog_rezerwuj.Enabled = false;
            }
      }

        private void dgv_katalog_CellClick(object sender, DataGridViewCellEventArgs e)
        {           
            // Podświetlenie wybranego wiersza
            ((DataGridView)sender).Rows[e.RowIndex].Selected = true;

            int pobierz = controller.PobierzDaneWycieczki(((DataGridView)sender)[0, e.RowIndex].FormattedValue.ToString());

            switch (pobierz)
            {
                case 1:
                    int.TryParse(((DataGridView)sender)[0, e.RowIndex].FormattedValue.ToString(), out _idWycieczki);
                    break;
                case 0:
                    MessageBox.Show("Wystąpił problem podczas konwersji id wycieczki", "Błąd konwersji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -1:
                    MessageBox.Show("Wystąpił problem podczas pobierania danych.", "Błąd pobierania danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }           
        }

        private void b_zaplac_Click(object sender, EventArgs e)
        {
            RezerwacjaView rezerwacja = new RezerwacjaView();
            rezerwacja.ShowDialog();
        }
    }
}
