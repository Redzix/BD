﻿using System;
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
    /// <summary>
    /// Klasa odpowiedzialna za obsługę zdarzeń wiodku udostępnianego kierowcy.
    /// </summary>
    public partial class KierowcaView : Form
    {
        /// <summary>
        /// Obiekt przechowujący kontroler.
        /// </summary>
        private KierowcaController controller;

        /// <summary>
        /// Obiekt przechowujący klasę odpowiedzialną za sprawdzanie zmian w bazie.
        /// </summary>
        AktualizacjaController aktPojazdu;

        /// <summary>
        /// Zmienna przechowuje numer aktualnie wybranego pojazdu
        /// </summary>
        private string numerRejestracyjny;
        /// <summary>
        /// Konstruktor okna z parametrem, pozwalający na przekazanie nazwy użytkownika zalogowanego do systemu.
        /// </summary>
        /// <param name="uzytkownik">Nazwa użytkownika</param>
        public KierowcaView(Kierowca uzytkownik)
        {
            InitializeComponent();

            l_uzytkownik.Text = uzytkownik.DaneOsobowe();
            l_polaczenie.Text = "Połączony";
            l_polaczenie.ForeColor = System.Drawing.Color.Green;

            controller = new KierowcaController(this);

            aktPojazdu = new AktualizacjaController("pojazd");

            this.helpProvider.HelpNamespace = "Helper\\Kierowca.chm";

            timer1.Start();

        }

        /// <summary>
        /// Zdarzenie obsługujące wylogowanie z systemu po wciśnięciu przycisku "Wyjdź", po kliknięciu program przechodzi do panelu logowania.
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
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
        /// Metoda obsługujące zdarzenie wyłączenia aplikacji poprzez wciśnięcie "X", program całkowicie kończy swoją pracę
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
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

        /// <summary>
        /// Metoda obsługująca zdarzenie ładowania widoku, wywołuje funkcję pobierającą
        /// informacje o pojazdach i obsługuje komunikaty tej funkcji.
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
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

        /// <summary>
        /// Metoda obsługujące zdarzenie kliknięcia przycisku b_kierowca_zapisz, odpowiada za uruchomienie funkcji
        /// zapisującej zmiany i obsługe jej komunikatów.
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_kierowca_zapisz_Click(object sender, EventArgs e)
        {
            int zapisz = controller.ZapiszZmiany(numerRejestracyjny);

            switch(zapisz)
            {
                case 1:
                    MessageBox.Show("W pojezdzie o numerze rejestracyjnym " + numerRejestracyjny +
                        " ustawiono stan na awarię", "Dodano awarię", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.rb_awaria.Enabled = false;
                    this.rb_sprawny.Enabled = false;
                    this.b_kierowca_zapisz.Enabled = false;
                    controller.PobierzPojazdy();
                    break;
                case -1:
                    MessageBox.Show("Brak pojazdu o podanym numerze rejestracyjnym.", "Błędny numer rejestracyjny", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 2:
                    MessageBox.Show("W pojezdzie o numerze rejestracyjnym " + numerRejestracyjny +
                         " ustawiono stan na sprawność", "Dodano sprawność", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.rb_awaria.Enabled = false;
                    this.rb_sprawny.Enabled = false;
                    this.b_kierowca_zapisz.Enabled = false;
                    controller.PobierzPojazdy();
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
        private void lv_pojazdy_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            sortListViewByColumn(sender,e);
        }

        /// <summary>
        /// Metoda obsługująca kolejne ticki timera, co 5s uruchamia metode sprawdzającą, czy nastąpiła aktualizacja w bazie danych
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (aktPojazdu.czyBylaAktualizacja())
            {
                controller.PobierzPojazdy();
            }
            else
            {
                return;
            }       
        }

        /// <summary>
        /// Metoda odpowiadająca za udostepnianie edycji kontrolek po zmianie wyboru pojazdu
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void lv_pojazdy_ItemActivate(object sender, EventArgs e)
        {
            this.rb_awaria.Enabled = true;
            this.rb_sprawny.Enabled = true;
            this.b_kierowca_zapisz.Enabled = true;
            numerRejestracyjny = lv_pojazdy.SelectedItems[0].Tag.ToString();
        }
    }
}
