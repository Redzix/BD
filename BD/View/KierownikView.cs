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
using System.Data.Entity;

namespace BD.View
{
    public partial class KierownikView : Form
    {
        private int _idReklamacji = 0;
        private string _uzytkownik;
        KierownikController controller;

        /// <summary>
        /// Główny bezparametrowy konstruktor okna, tworzący okno oraz połączenie z bazą danych.
        /// </summary>
        public KierownikView()
        {
            InitializeComponent();
            controller = new KierownikController(this);
            l_uzytkownik.Text = "Niezidentyfikowany użytkownik";
            l_polaczenie.Text = "Połączono";
            l_polaczenie.ForeColor = System.Drawing.Color.Green;
        }

        /// <summary>
        /// Konstruktor okna z parametrem, pozwalający na przekazanie nazwy użytkownika zalogowanego do systemu 
        /// oraz tworzący połączenie z bazą danych.
        /// </summary>
        /// <param name="uzytkownik">Nazwa użytkownika</param>
        public KierownikView(string uzytkownik)
        {
            InitializeComponent();
            controller = new KierownikController(this);
            controller.LadujKatalog();
            _uzytkownik = uzytkownik;
            l_uzytkownik.Text = uzytkownik;
            l_polaczenie.Text = "Połączono";
            l_polaczenie.ForeColor = System.Drawing.Color.Green;
        }

        /// <summary>
        /// Zdarzenie otwiera okno dialogowe pozwalające wprowadzić do bazy nowy pojazd.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_dodaj_pojazd_Click(object sender, EventArgs e)
        {
            PojazdView pojazd = new PojazdView();
            pojazd.ShowDialog();
            ZaladujPojazdy();
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
        /// Zdarzenie otwiera okno dialogowe pozwalające wprowadzić do bazy nową wycieczkę.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_dodaj_wycieczke_Click(object sender, EventArgs e)
        {
            WycieczkaView wycieczka = new WycieczkaView(1, 0);
            wycieczka.ShowDialog();
            controller.LadujKatalog();
        }

        private void tc_kierownik_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tc_kierownik.SelectedIndex)
            {
                case 0:
                    controller.LadujKatalog();
                    break;
                case 1:
                    this.ZaladujReklamacje();
                    break;
                case 2:
                    this.ZaladujPojazdy();
                    break;
            } 
        }

        public void ZaladujPojazdy()
        {
            bazaEntities db = new bazaEntities();
            lv_pojazdy.Items.Clear();
            var query = from p in db.Pojazd select p;

            foreach (Pojazd poj in query)
            {
                ListViewItem pojazd = new ListViewItem(poj.numer_rejestracyjny);
                pojazd.SubItems.Add((bool)poj.dostepny ? "Dostępny" : "Niedostępny");
                pojazd.SubItems.Add(poj.marka);
                pojazd.SubItems.Add(poj.pojemnosc.ToString());
                pojazd.SubItems.Add((bool)poj.stan ? "Sprawny" : "Awaria");
                lv_pojazdy.Items.Add(pojazd);
            }
        }

        private void ZaladujReklamacje()
        {
            bazaEntities db = new bazaEntities();
            var query = from r in db.Reklamacja select r;
            lv_reklamacje.Items.Clear();
            foreach (Reklamacja rek in query)
            {
                ListViewItem reklamacjaItem = new ListViewItem(rek.numer_reklamacji.ToString());
                reklamacjaItem.Tag = rek.numer_reklamacji;
                reklamacjaItem.SubItems.Add(rek.opis.Substring(0, 30));
                reklamacjaItem.SubItems.Add((bool)rek.stan ? "Rozpatrzona" : "Nierozpatrzona");
                lv_reklamacje.Items.Add(reklamacjaItem);
            }
        }

        private void b_usun_pojazd_Click(object sender, EventArgs e)
        {
            //Pobranie wybranego numeru rejestracyjnego z listview
            string numerRejestracyjny = lv_pojazdy.SelectedItems[0].SubItems[0].Text;

            if((new Kierownik_model()).UsunPojazd(numerRejestracyjny))
            {
                MessageBox.Show("Pojazd usunięto poprawnie.", "Usunięcie pojazdu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lv_pojazdy.SelectedItems[0].Remove();
            }
            else
            {
                MessageBox.Show("Napotkano problem podczas usuwania pojazdu", "Usunięcie pojazdu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void b_edytuj_pojazd_Click(object sender, EventArgs e)
        {
            //Pobranie wybranego numeru rejestracyjnego z listview
            string numerRejestracyjny = lv_pojazdy.SelectedItems[0].SubItems[0].Text;

            DialogResult dialogResult = MessageBox.Show("Jesli chcesz ustawić dostępność pojazdu na 'Dostepny', kliknij 'Tak', w przeciwnym razie kliknij 'Nie'.", "Zmiana dostępnosci", MessageBoxButtons.YesNoCancel);

            if (dialogResult == DialogResult.Yes)
            {
                if((new Kierownik_model()).EdytujDostepnoscPojazdu(numerRejestracyjny, 1))
                {
                    MessageBox.Show("Poprawnie zmieniono dostępność pojazdu o numerze rejestracyjnym " + numerRejestracyjny, "Zmiana dostępności pojazdu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lv_pojazdy.Items[lv_pojazdy.SelectedItems[0].Index].SubItems[1].Text = "Dostępny";
                }
                else
                {
                    MessageBox.Show("Napotkano błąd podczas zmiany dostępności pojazdu.", "Błąd podczas zmiany.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (dialogResult == DialogResult.No)
            {
                if((new Kierownik_model()).EdytujDostepnoscPojazdu(numerRejestracyjny, 0))
                {
                    MessageBox.Show("Poprawnie zmieniono dostępność pojazdu o numerze rejestracyjnym " + numerRejestracyjny, "Zmiana dostępności pojazdu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lv_pojazdy.Items[lv_pojazdy.SelectedItems[0].Index].SubItems[1].Text = "Niedostępny";
                }
                else
                {
                    MessageBox.Show("Napotkano błąd podczas zmiany dostępności pojazdu.", "Błąd podczas zmiany.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (dialogResult == DialogResult.Cancel)
            {
                MessageBox.Show("Nie zmieniono dostepnośći w pojeździe o numerze rejestracyjnym: " + numerRejestracyjny,"Brak zmian", MessageBoxButtons.OK);
                return;
            }


            dialogResult = MessageBox.Show("Jesli chcesz ustawić stan pojazdu na 'Sprawny', kliknij 'Tak', w przeciwnym razie kliknij 'Nie'.", "Zmiana stanu", MessageBoxButtons.YesNoCancel);

            if (dialogResult == DialogResult.Yes)
            {
                if((new Kierownik_model()).EdytujStanPojazdu(numerRejestracyjny, 1))
                {
                    MessageBox.Show("Poprawnie zmieniono stan pojazdu o numerze rejestracyjnym " + numerRejestracyjny, "Zmiana dostępności pojazdu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lv_pojazdy.Items[lv_pojazdy.SelectedItems[0].Index].SubItems[4].Text = "Sprawny";
                }
                else
                {
                    MessageBox.Show("Napotkano błąd podczas zmiany dostępności pojazdu.", "Błąd podczas zmiany.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (dialogResult == DialogResult.No)
            {
                if((new Kierownik_model()).EdytujStanPojazdu(numerRejestracyjny, 0))
                {
                    MessageBox.Show("Poprawnie zmieniono stan pojazdu o numerze rejestracyjnym " + numerRejestracyjny, "Zmiana dostępności pojazdu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lv_pojazdy.Items[lv_pojazdy.SelectedItems[0].Index].SubItems[4].Text = "Awaria";
                }
                else
                {
                    MessageBox.Show("Napotkano błąd podczas zmiany dostępności pojazdu.", "Błąd podczas zmiany.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (dialogResult == DialogResult.Cancel)
            {
                MessageBox.Show("Nie zmieniono stanu w pojeździe o numerze rejestracyjnym: " + numerRejestracyjny,"Brak zmian",MessageBoxButtons.OK);
                return;
            }

            lv_pojazdy.Refresh();
        }

        private void lv_reklamacje_ItemActivate(object sender, EventArgs e)
        {
            bazaEntities db = new bazaEntities();
            int numer;
            int.TryParse(((ListView)sender).SelectedItems[0].SubItems[0].Text, out numer);
            var reklamacja = (from r in db.Reklamacja
                         where r.numer_reklamacji == numer
                         select r).FirstOrDefault();

            rtb_opisReklamacji.Text = reklamacja.opis;
            tb_nazwa_wycieczki.Text = reklamacja.Uczestnictwo.Rezerwacja.Wycieczka.nazwa;
            TimeSpan roznica = (TimeSpan)(reklamacja.Uczestnictwo.Rezerwacja.Wycieczka.data_powrotu - reklamacja.Uczestnictwo.Rezerwacja.Wycieczka.data_wyjazdu);
            tb_okresTrwaniaWycieczki.Text = String.Format("{0} dni",roznica.Days);
        }

        private void b_rozpatrz_pozytywnie_Click(object sender, EventArgs e)
        {
            if((new Kierownik_model()).RozpatrzReklamacje(_idReklamacji, 1,_uzytkownik))
            {
                MessageBox.Show("Reklamacja została rozpatrzona pozytywnie.","Rozpatrzenie reklamacji", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bład podczas rozpatrywania reklamacji.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void b_rozpatrz_negatywnie_Click(object sender, EventArgs e)
        {
            if((new Kierownik_model()).RozpatrzReklamacje(_idReklamacji, 0, _uzytkownik))
            {
                    MessageBox.Show("Reklamacja została rozpatrzona negatywnie.", "Rozpatrzenie reklamacji", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                    MessageBox.Show("Bład podczas rozpatrywania reklamacji.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }       
        }

        private void b_edytuj_Click(object sender, EventArgs e)
        {
            try
            {
                var id = lv_wycieczki.SelectedItems[0].Tag;
                WycieczkaView wycieczka = new WycieczkaView(0, (int)id);
                wycieczka.ShowDialog();
                controller.LadujKatalog();
            } catch
            {
                MessageBox.Show("Musisz najpierw wybrać wycieczkę do edycji");
            }
        }

        private void b_usun_wycieczke_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz usunąc wycieczke o indeksie: " + (lv_wycieczki.SelectedItems[0].Index + 1).ToString() + " ?","Usunięcie wycieczki.",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(dialogResult == DialogResult.Yes)
            {
                bazaEntities db = new bazaEntities();
                var idKatalog = lv_wycieczki.SelectedItems[0].Tag;
                if(controller.UsunKatalog((int)idKatalog))
                {
                    MessageBox.Show("Usunięto wybraną wycieczkę.", "Usuwanie wycieczki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    controller.LadujKatalog();
                } else
                {
                    MessageBox.Show("Wystąpił błąd podczas usuwania wycieczki.", "Błąd usuwania wycieczki.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("Nie usunięto żadnej wycieczki.", "Usuwanie wycieczki",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PdfCreator pdf = new PdfCreator();
            pdf.createPDF(lv_pojazdy);
        }


        /*
         * Używana do sortowania po kolumnach dla obiektów typu ListView.
         */
        private void sortListViewByColumn(object sender, ColumnClickEventArgs e)
        {
            if (((ListView)sender).Sorting == System.Windows.Forms.SortOrder.Ascending)
                ((ListView)sender).Sorting = System.Windows.Forms.SortOrder.Descending;
            else
                ((ListView)sender).Sorting = System.Windows.Forms.SortOrder.Ascending;
            ((ListView)sender).Sort();
            ((ListView)sender).ListViewItemSorter = new ListViewItemComparer(e.Column, ((ListView)sender).Sorting);
        }
        
        private void lv_pojazdy_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            sortListViewByColumn(sender, e);
        }

        private void b_promocja_Click(object sender, EventArgs e)
        {
            var id = lv_wycieczki.SelectedItems[0].Tag;
            PromocjaView promo = new PromocjaView((int)id);
            promo.ShowDialog();
            controller.LadujKatalog();
        }

        private void lv_wycieczki_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            sortListViewByColumn(sender, e);
        }
    }
}
