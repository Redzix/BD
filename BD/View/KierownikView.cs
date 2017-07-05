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
using System.Data.Entity;

namespace BD.View
{
    public partial class KierownikView : Form
    {

        /// <summary>
        /// Zmienna przechowująca pesel aktualnie zalogowanego użytkownika
        /// </summary>
        private Kierownik _uzytkownik;

        /// <summary>
        /// Obiekt przechowujący kontroler.
        /// </summary>
        KierownikController controller;

        /// <summary>
        /// Obiekt przechowujący klasę odpowiedzialną za sprawdzanie zmian w bazie.
        /// </summary>
        AktualizacjaController aktKatalog;

        /// <summary>
        /// Obiekt przechowujący klasę odpowiedzialną za sprawdzanie zmian w bazie.
        /// </summary>
        AktualizacjaController aktReklamacja;

        /// <summary>
        /// Obiekt przechowujący klasę odpowiedzialną za sprawdzanie zmian w bazie.
        /// </summary>
        AktualizacjaController aktPojazd;

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

            aktKatalog= new AktualizacjaController("wycieczka katalog");
            aktReklamacja = new AktualizacjaController("reklamacja");
            aktPojazd = new AktualizacjaController("pojazd");

            timer1.Start();
        }

        /// <summary>
        /// Konstruktor okna z parametrem, pozwalający na przekazanie nazwy użytkownika zalogowanego do systemu 
        /// oraz tworzący połączenie z bazą danych.
        /// </summary>
        /// <param name="uzytkownik">Nazwa użytkownika</param>
        public KierownikView(Kierownik uzytkownik)
        {
            InitializeComponent();
            controller = new KierownikController(this);
            controller.LadujKatalog();
            _uzytkownik = uzytkownik;
            l_uzytkownik.Text = _uzytkownik.DaneOsobowe();
            l_polaczenie.Text = "Połączono";
            l_polaczenie.ForeColor = System.Drawing.Color.Green;

            aktKatalog = new AktualizacjaController("wycieczka katalog");
            aktReklamacja = new AktualizacjaController("reklamacja");
            aktPojazd = new AktualizacjaController("pojazd");
            this.helpProvider1.HelpNamespace = "Helper\\Kierownik.chm";
            timer1.Start();
        }

        /// <summary>
        /// Zdarzenie otwiera okno dialogowe pozwalające wprowadzić do bazy nowy pojazd.
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_dodaj_pojazd_Click(object sender, EventArgs e)
        {
            PojazdView pojazd = new PojazdView();
            pojazd.ShowDialog();
            controller.LadujPojazdy();
        }

        /// <summary>
        /// Zdarzenie obsługujące wyłączenie aplikacji poprzez wciśnięcie "X", program całkowicie kończy swoją pracę
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
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
        /// Zdarzenie otwiera okno dialogowe pozwalające wprowadzić do bazy nową wycieczkę.
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_dodaj_wycieczke_Click(object sender, EventArgs e)
        {
            WycieczkaView wycieczka = new WycieczkaView(1, 0);
            wycieczka.ShowDialog();
            controller.LadujKatalog();
        }
        /// <summary>
        /// Akcja wywoływana podczas zmieniania tabów w aplikacji
        /// </summary>
        /// <param name="sender">Obiekt który wywołał metodę</param>
        /// <param name="e">Argumenty</param>
        private void tc_kierownik_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tc_kierownik.SelectedIndex)
            {
                case 0:
                    controller.LadujKatalog();
                    break;
                case 1:
                    controller.LadujReklamacje();
                    break;
                case 2:
                    controller.LadujPojazdy();
                    break;
            } 
        }
        /// <summary>
        /// Akcja dla przycisku do usuwania pojazdu
        /// </summary>
        /// <param name="sender">Obiekt który wywołał metodę</param>
        /// <param name="e">Argumenty</param>
        private void b_usun_pojazd_Click(object sender, EventArgs e)
        {
            //Pobranie wybranego numeru rejestracyjnego z listview
            try
            {
                string numerRejestracyjny = (string)lv_pojazdy.SelectedItems[0].Tag;

                if (controller.UsunPojazd(numerRejestracyjny))
                {
                    MessageBox.Show("Pojazd usunięto poprawnie.", "Usunięcie pojazdu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    controller.LadujPojazdy();
                }
                else
                {
                    MessageBox.Show("Napotkano problem podczas usuwania pojazdu", "Usunięcie pojazdu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Należy najpierw wybrać pojazd w celu jego usunięcia", "Usunięcie pojazdu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Akcja dla przycisku do edytowania pojazdów. Wyświetlają się messageboxy na które należy odpowiedzieć w celu edycji
        /// </summary>
        /// <param name="sender">Obiekt który wywołał metodę</param>
        /// <param name="e">Argumenty</param>
        private void b_edytuj_pojazd_Click(object sender, EventArgs e)
        {
            //Pobranie wybranego numeru rejestracyjnego z listview
            try
            {
                string numerRejestracyjny = (string)lv_pojazdy.SelectedItems[0].Tag;

                DialogResult dialog = MessageBox.Show("Jesli chcesz ustawić dostępność pojazdu na 'Dostepny', kliknij 'Tak', w przeciwnym razie kliknij 'Nie'.", "Zmiana dostępnosci", MessageBoxButtons.YesNoCancel);

                switch (dialog)
                {
                    case DialogResult.Yes:
                        if (controller.EdytujDostepnoscPojazdu(numerRejestracyjny, true))
                            MessageBox.Show("Poprawnie zmieniono dostępność pojazdu o numerze rejestracyjnym " + numerRejestracyjny, "Zmiana dostępności pojazdu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Napotkano błąd podczas zmiany dostępności pojazdu.", "Błąd podczas zmiany.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case DialogResult.No:
                        if (controller.EdytujDostepnoscPojazdu(numerRejestracyjny, false))
                            MessageBox.Show("Poprawnie zmieniono dostępność pojazdu o numerze rejestracyjnym " + numerRejestracyjny, "Zmiana dostępności pojazdu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Napotkano błąd podczas zmiany dostępności pojazdu.", "Błąd podczas zmiany.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case DialogResult.Cancel:
                        MessageBox.Show("Nie zmieniono dostepnośći w pojeździe o numerze rejestracyjnym: " + numerRejestracyjny, "Brak zmian", MessageBoxButtons.OK);
                        break;
                }

                dialog = MessageBox.Show("Jesli chcesz ustawić stan pojazdu na 'Sprawny', kliknij 'Tak', w przeciwnym razie kliknij 'Nie'.", "Zmiana stanu", MessageBoxButtons.YesNoCancel);
                switch (dialog)
                {
                    case DialogResult.Yes:
                        if (controller.EdytujStanPojazdu(numerRejestracyjny, true))
                        {
                            MessageBox.Show("Poprawnie zmieniono stan pojazdu o numerze rejestracyjnym " + numerRejestracyjny, "Zmiana dostępności pojazdu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Napotkano błąd podczas zmiany dostępności pojazdu.", "Błąd podczas zmiany.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case DialogResult.No:
                        if (controller.EdytujStanPojazdu(numerRejestracyjny, false))
                        {
                            MessageBox.Show("Poprawnie zmieniono stan pojazdu o numerze rejestracyjnym " + numerRejestracyjny, "Zmiana dostępności pojazdu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Napotkano błąd podczas zmiany dostępności pojazdu.", "Błąd podczas zmiany.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case DialogResult.Cancel:
                        MessageBox.Show("Nie zmieniono stanu w pojeździe o numerze rejestracyjnym: " + numerRejestracyjny, "Brak zmian", MessageBoxButtons.OK);
                        break;
                }
                controller.LadujPojazdy();
            } catch
            {
                MessageBox.Show("Najpierw należy wybrać pojazd do edycji", "Brak zmian", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Akcja na kliknięcie danego wiersza reklamacji. Wypełnia wszystkie pola dla wybranej reklamacji
        /// </summary>
        /// <param name="sender">Obiekt który wywołał metodę</param>
        /// <param name="e">Argumenty</param>
        private void lv_reklamacje_ItemActivate(object sender, EventArgs e)
        {
            try
            {
                var idReklamacji = (int)((ListView)sender).SelectedItems[0].Tag;
                if (!controller.WypelnijReklamacjeDoRozpatrzenia(idReklamacji))
                    MessageBox.Show("Bład podczas ładowania reklamacji do rozpatrzenia.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch
            {

            }
        }
        /// <summary>
        /// Akcja przycisku służaca do pozytywnego rozpatrzenia reklamacji
        /// </summary>
        /// <param name="sender">Obiekt który wywołał metodę</param>
        /// <param name="e">Argumenty</param>
        private void b_rozpatrz_pozytywnie_Click(object sender, EventArgs e)
        {
            try
            {
                var idReklamacji = (int)lv_reklamacje.SelectedItems[0].Tag;
                if (controller.RozpatrzReklamacje(idReklamacji, true, _uzytkownik.pesel))
                {
                    MessageBox.Show("Reklamacja została rozpatrzona pozytywnie.", "Rozpatrzenie reklamacji", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Bład podczas rozpatrywania reklamacji.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch
            {
                MessageBox.Show("Należy najpierw wybrać zgłoszoną reklamację", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            controller.LadujReklamacje();

        }
        /// <summary>
        /// Akcja przycisku służąca do negatywnego rozpatrzenia reklamacji
        /// </summary>
        /// <param name="sender">Obiekt który wywołał metodę</param>
        /// <param name="e">Argumenty</param>
        private void b_rozpatrz_negatywnie_Click(object sender, EventArgs e)
        {
            try
            {
                var idReklamacji = (int)lv_reklamacje.SelectedItems[0].Tag;
                if (controller.RozpatrzReklamacje(idReklamacji, false, _uzytkownik.pesel))
                {
                    MessageBox.Show("Reklamacja została rozpatrzona negatywnie.", "Rozpatrzenie reklamacji", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    controller.LadujReklamacje();
                }
                else
                {
                    MessageBox.Show("Bład podczas rozpatrywania reklamacji.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Należy najpierw wybrać zgłoszoną reklamację", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        /// <summary>
        /// Akcja przycisku do edycji wycieczki
        /// </summary>
        /// <param name="sender">Obiekt który wywołał metodę</param>
        /// <param name="e">Argumenty</param>
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
                MessageBox.Show("Musisz najpierw wybrać wycieczkę do edycji", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Akcja przycisku do usunięcia wycieczki
        /// </summary>
        /// <param name="sender">Obiekt który wywołał metodę</param>
        /// <param name="e">Argumenty</param>
        private void b_usun_wycieczke_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz usunąć wycieczkę?","Usunięcie wycieczki.",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(dialogResult == DialogResult.Yes)
            {
                try
                {
                    var idKatalog = lv_wycieczki.SelectedItems[0].Tag;
                    if (controller.UsunKatalog((int)idKatalog))
                    {
                        MessageBox.Show("Usunięto wybraną wycieczkę.", "Usuwanie wycieczki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        controller.LadujKatalog();
                    }
                    else
                    {
                        MessageBox.Show("Wystąpił błąd podczas usuwania wycieczki.", "Błąd usuwania wycieczki.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                } catch
                {
                    MessageBox.Show("Najpierw to należy wybrać wycieczkę.", "Błąd usuwania wycieczki.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Nie usunięto żadnej wycieczki.", "Usuwanie wycieczki",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
        }
        /// <summary>
        /// Używana do sortowania po kolumnach dla obiektów typu ListView.
        /// </summary>
        /// <param name="sender">Obiekt wyzwalający event</param>
        /// <param name="e">Arguemnty eventu</param>
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
        /// Akcja po kliknięciu nazwy kolumny w pojazdach. Służy do sortowania
        /// </summary>
        /// <param name="sender">Obiekt który wywołał metodę</param>
        /// <param name="e">Argumenty</param>
        private void lv_pojazdy_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            sortListViewByColumn(sender, e);
        }
        /// <summary>
        /// Akcja po kliknięciu przycisku dodania promocji dla danej wycieczki
        /// </summary>
        /// <param name="sender">Obiekt który wywołał metodę</param>
        /// <param name="e">Argumenty</param>
        private void b_promocja_Click(object sender, EventArgs e)
        {
            try
            {
                var id = lv_wycieczki.SelectedItems[0].Tag;
                PromocjaView promo = new PromocjaView((int)id);
                promo.ShowDialog();
                controller.LadujKatalog();
            } catch
            {
                MessageBox.Show("Najpierw należy wybrać wycieczkę", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Akcja po kliknięciu nazwy kolumny w wycieczkach. Służy do sortowania
        /// </summary>
        /// <param name="sender">Obiekt który wywołał metodę</param>
        /// <param name="e">Argumenty</param>
        private void lv_wycieczki_ColumnClick(object sender, ColumnClickEventArgs e)
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
            switch (tc_kierownik.SelectedIndex)
            {
                case 0:
                    if (aktKatalog.czyBylaAktualizacja())
                        controller.LadujKatalog();
                    break;
                case 1:
                    if (aktReklamacja.czyBylaAktualizacja())
                        controller.LadujReklamacje();
                    break;
                case 2:
                    if (aktPojazd.czyBylaAktualizacja())
                        controller.LadujPojazdy();
                    break;
            }           
        }
        /// <summary>
        /// Akcja po kliknięciu nazwy kolumny w reklamacjach. Służy do sortowania
        /// </summary>
        /// <param name="sender">Obiekt który wywołał metodę</param>
        /// <param name="e">Argumenty</param>
        private void lv_reklamacje_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            sortListViewByColumn(sender, e);
        }
        /// <summary>
        /// Akcja dla zmiany wyświetlanych reklamacji w katalogu. Gdy zaznaczone, wyświetla wycieckzi które się odbyły.
        /// </summary>
        /// <param name="sender">Obiekt który wywołał metodę</param>
        /// <param name="e">Argumenty</param>
        private void cBox_reklamacja_CheckedChanged(object sender, EventArgs e)
        {
            controller.LadujReklamacje();
        }
        /// <summary>
        /// Akcja dla zmiany wyświetlanych wycieczek w katalogu. Gdy zaznaczone, wyświetla wycieckzi które się odbyły.
        /// </summary>
        /// <param name="sender">Obiekt który wywołał metodę</param>
        /// <param name="e">Argumenty</param>
        private void cBox_wycieczki_CheckedChanged(object sender, EventArgs e)
        {
            controller.LadujKatalog();
        }
        /// <summary>
        /// Akcja dla przycisku wywołującego możliwość generowania raportu dla pojazdów
        /// </summary>
        /// <param name="sender">Obiekt który wywołał metodę</param>
        /// <param name="e">Argumenty</param>
        private void b_raport_pojazdy_Click(object sender, EventArgs e)
        {
            RaporterView rView = new RaporterView(2);
            rView.ShowDialog();
        }
        /// <summary>
        /// Akcja dla przycisku wywołującego możliwość generowania raportu dla wycieczek
        /// </summary>
        /// <param name="sender">Obiekt który wywołał metodę</param>
        /// <param name="e">Argumenty</param>
        private void b_raport_wycieczki_Click(object sender, EventArgs e)
        {
            RaporterView rView = new RaporterView(0);
            rView.ShowDialog();
        }
        /// <summary>
        /// Akcja dla przycisku wywołującego możliwość generowania raportu dla reklamacji
        /// </summary>
        /// <param name="sender">Obiekt który wywołał metodę</param>
        /// <param name="e">Argumenty</param>
        private void b_raport_reklamacje_Click(object sender, EventArgs e)
        {
            RaporterView rView = new RaporterView(1);
            rView.ShowDialog();
        }
    }
}
