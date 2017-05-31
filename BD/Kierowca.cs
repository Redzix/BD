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
    public partial class Kierowca : Form
    {
        SqlConnection _polaczenie = null;
        SqlCommand _zapytanie = null;
        Polacz_z_baza _polacz = null;
        List<Pojazd_model> _listaPojazdow = new List<Pojazd_model>();

        /// <summary>
        /// Główny bezparametrowy konstruktor okna
        /// </summary>
        public Kierowca()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Konstruktor okna z parametrem, pozwalający na przekazanie nazwy użytkownika zalogowanego do systemu.
        /// </summary>
        /// <param name="uzytkownik">Nazwa użytkownika</param>
        public Kierowca(string uzytkownik)
        {
            InitializeComponent();
            l_uzytkownik.Text = uzytkownik;
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
            Pojazd_model _pojazdy = new Pojazd_model();
            _listaPojazdow = _pojazdy.PobierzPojazdy();

            for (int i = 0; i < _listaPojazdow.Count; i++)
            {
                ListViewItem pojazd = new ListViewItem(_listaPojazdow[i].NumerRejestracyjny.ToString());

                if (_listaPojazdow[i].Dostepnosc)
                {
                    pojazd.SubItems.Add("Dostępny");
                }
                else
                {
                    pojazd.SubItems.Add("Niedostępny");
                };

                pojazd.SubItems.Add(_listaPojazdow[i].Marka.ToString());
                pojazd.SubItems.Add(_listaPojazdow[i].Pojemnosc.ToString());

                if (_listaPojazdow[i].Stan)
                {
                    pojazd.SubItems.Add("Sprawny");
                }
                else
                {
                    pojazd.SubItems.Add("Awaria");
                }

                lv_pojazdy.Items.Add(pojazd);
            }
        }

        private void b_kierowca_zapisz_Click(object sender, EventArgs e)
        {
            string numerRejestracyjny = lv_pojazdy.SelectedItems[0].SubItems[0].Text;

            if (rb_awaria.Checked)
            {
                if((new Kierowca_model()).DodajZmianeStanu(0, numerRejestracyjny))
                {
                    MessageBox.Show("W pojezdzie o numerze rejestracyjnym " + numerRejestracyjny + 
                        " ustawiono stan na awarię","Dodano awarię", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lv_pojazdy.Items[lv_pojazdy.SelectedItems[0].Index].SubItems[4].Text = "Awaria";
                }
                else
                {
                    MessageBox.Show("Błąd podczas wprowadzania zmian","Błąd",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                
            }
            else if (rb_sprawny.Checked)
            {
                if ((new Kierowca_model()).DodajZmianeStanu(1, numerRejestracyjny))
                {
                    MessageBox.Show("W pojezdzie o numerze rejestracyjnym " + numerRejestracyjny +
                        " ustawiono stan na sprawny", "Dodano sprawność", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lv_pojazdy.Items[lv_pojazdy.SelectedItems[0].Index].SubItems[4].Text = "Sprawny";
                }
                else
                {
                    MessageBox.Show("Błąd podczas wprowadzania zmian", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nie podano żadnej zmiany stanu pojazdu.", "Brak zmian", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            lv_pojazdy.Refresh();
        }
     }
}
