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
    public partial class KierowcaView : Form
    {

        /// <summary>
        /// Główny bezparametrowy konstruktor okna
        /// </summary>
        public KierowcaView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Konstruktor okna z parametrem, pozwalający na przekazanie nazwy użytkownika zalogowanego do systemu.
        /// </summary>
        /// <param name="uzytkownik">Nazwa użytkownika</param>
        public KierowcaView(string uzytkownik)
        {
            InitializeComponent();

            l_uzytkownik.Text = uzytkownik;

            Polacz_z_baza _polacz = new Polacz_z_baza();
            SqlConnection _polaczenie = _polacz.PolaczZBaza();

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
            ZaladujPojazdy();
        }

        private void b_kierowca_zapisz_Click(object sender, EventArgs e)
        {
            string numerRejestracyjny = ((ListView)sender).SelectedItems[0].Tag.ToString();

            bazaEntities db = new bazaEntities();
            lv_pojazdy.Items.Clear();
            
            if (rb_awaria.Checked)
            {              
                    var query = (from pojazd in db.Pojazd
                                where pojazd.numer_rejestracyjny == numerRejestracyjny
                                select pojazd).FirstOrDefault();

                    query.stan = false;

                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("W pojezdzie o numerze rejestracyjnym " + numerRejestracyjny +
                        " ustawiono stan na awarię", "Dodano awarię", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Błąd podczas wprowadzania zmian", "Błąd \n" + exception.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    lv_pojazdy.Items[lv_pojazdy.SelectedItems[0].Index].SubItems[4].Text = "Awaria";               
            }
            else if (rb_sprawny.Checked)
            {
                var query = (from pojazd in db.Pojazd
                             where pojazd.numer_rejestracyjny == numerRejestracyjny
                             select pojazd).FirstOrDefault();

                query.stan = true;

                try
                {
                    db.SaveChanges();
                    MessageBox.Show("W pojezdzie o numerze rejestracyjnym " + numerRejestracyjny +
                    " ustawiono stan na sprawność", "Dodano sprawność", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Błąd podczas wprowadzania zmian", "Błąd \n" + exception.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                lv_pojazdy.Items[lv_pojazdy.SelectedItems[0].Index].SubItems[4].Text = "Sprawny";           
            }
            else
            {
                MessageBox.Show("Nie podano żadnej zmiany stanu pojazdu.", "Brak zmian", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            lv_pojazdy.Refresh();
        }
        
        private void ZaladujPojazdy()
        {
            bazaEntities db = new bazaEntities();
            lv_pojazdy.Items.Clear();

            var query = from pojazd in db.Pojazd
                        select pojazd;

            foreach (Pojazd poj in query)
            {
                ListViewItem pojazd = new ListViewItem(poj.numer_rejestracyjny);
                pojazd.Tag = poj.numer_rejestracyjny;
                pojazd.SubItems.Add((bool)poj.dostepny ? ("Dostępny") : ("Niedostępny"));
                pojazd.SubItems.Add(poj.marka);
                pojazd.SubItems.Add(poj.pojemnosc.ToString());
                pojazd.SubItems.Add((bool)poj.stan ? ("Sprawny") : ("Awaria"));
                lv_pojazdy.Items.Add(pojazd);
            }
        }

     }
   }
