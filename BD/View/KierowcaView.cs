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
    public partial class KierowcaView : Form
    {
        private KierowcaController controller;

        /// <summary>
        /// Główny bezparametrowy konstruktor okna
        /// </summary>
        public KierowcaView()
        {
            InitializeComponent();

            l_uzytkownik.Text = "Niezidentyfikowany użytkownik";
            l_polaczenie.Text = "Połączony";
            l_polaczenie.ForeColor = System.Drawing.Color.Green;

            controller = new KierowcaController(this);

        }

        /// <summary>
        /// Konstruktor okna z parametrem, pozwalający na przekazanie nazwy użytkownika zalogowanego do systemu.
        /// </summary>
        /// <param name="uzytkownik">Nazwa użytkownika</param>
        public KierowcaView(string uzytkownik)
        {
            InitializeComponent();

            l_uzytkownik.Text = uzytkownik;
            l_polaczenie.Text = "Połączony";
            l_polaczenie.ForeColor = System.Drawing.Color.Green;

            controller = new KierowcaController(this);
        }

        /// <summary>
        /// Zdarzenie obsługujące wylogowanie z systemu po wciśnięciu przycisku "Wyjdź", po kliknięciu program przechodzi do panelu logowania.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_kierowca_wyjdz_Click(object sender, EventArgs e)
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
        private void Kierowca_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Kierowca_Load(object sender, EventArgs e)
        {
            int pobierz = controller.PobierzPojazdy();

            if(pobierz == -1)
            {
                MessageBox.Show("Wystąpił problem podczas pobierania danych z bazy. Brak pojazdów.", "Błąd podczas pobierania.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if(pobierz == -1)
            {
                MessageBox.Show("Wystąpił problem podczas pobierania danych z bazy.", "Błąd podczas pobierania.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void b_kierowca_zapisz_Click(object sender, EventArgs e)
        {
            string numerRejestracyjny = ((ListView)sender).SelectedItems[0].Tag.ToString();

            int zapisz = controller.ZapiszZmiany(numerRejestracyjny);

            switch(zapisz)
            {
                case 1:
                    MessageBox.Show("W pojezdzie o numerze rejestracyjnym " + numerRejestracyjny +
                        " ustawiono stan na awarię", "Dodano awarię", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case -1:
                    MessageBox.Show("Brak pojazdu o podanym numerze rejestracyjnym.", "Błędny numer rejestracyjny", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 2:
                    MessageBox.Show("W pojezdzie o numerze rejestracyjnym " + numerRejestracyjny +
                         " ustawiono stan na sprawność", "Dodano sprawność", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case -2:
                    MessageBox.Show("Brak pojazdu o podanym numerze rejestracyjnym.", "Błędny numer rejestracyjny", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 0:
                    MessageBox.Show("Błąd podczas wprowadzania zmian. Błąd w trakcie zapisywania do bazy.", "Błąd ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -3:
                    MessageBox.Show("Nie podano żadnej zmiany stanu pojazdu.", "Brak zmian", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    break;
            }    
        }
        
        private void lv_pojazdy_SelectedIndexChanged(object sender, EventArgs e)
        {
                this.rb_awaria.Enabled = true;
                this.rb_sprawny.Enabled = true;
                this.b_kierowca_zapisz.Enabled = true;
        }
    }
}
