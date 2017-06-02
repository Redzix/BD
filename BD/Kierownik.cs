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
    public partial class Kierownik : Form
    {
        SqlConnection _polaczenie = null;
        SqlCommand _zapytanie = null;
        Polacz_z_baza _polacz = null;
        List<Pojazd_model> _listaPojazdow = new List<Pojazd_model>();
        List<Reklamacja_model> _listaReklamacji = new List<Reklamacja_model>();
        List<Wycieczka_model> _listaWycieczek = new List<Wycieczka_model>();
        List<Katalog_model> _listaKatalogu = new List<Katalog_model>();
        private int _idReklamacji = 0;

        /// <summary>
        /// Główny bezparametrowy konstruktor okna, tworzący okno oraz połączenie z bazą danych.
        /// </summary>
        public Kierownik()
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
        public Kierownik(string uzytkownik)
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
        /// a co to je?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Kierownik_Load(object sender, EventArgs e)
        {
            this.ZaladujWycieczki();
            // this.reportViewer1.RefreshReport();
        }

        /// <summary>
        /// Zdarzenie otwiera okno dialogowe pozwalające wprowadzić do bazy nowy pojazd.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_dodaj_pojazd_Click(object sender, EventArgs e)
        {
            Pojazd pojazd = new Pojazd();
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
        /// Zdarzenie otwiera okno dialogowe pozwalające wprowadzić do bazy nową wycieczkę.
        /// </summary>
        /// <param name="sender">Rozpoznanie wciśniętego przycisku</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_dodaj_wycieczke_Click(object sender, EventArgs e)
        {
            Wycieczka wycieczka = new Wycieczka(1, 0);
            wycieczka.ShowDialog();
            ZaladujWycieczki();
        }

        private void tc_kierownik_SelectedIndexChanged(object sender, EventArgs e)
        {   
            // Tutaj pobiera liste od nowa, ponieważ ma się przeładować i uaktualnić.
            if(tc_kierownik.SelectedIndex == 0)
            {
                this.ZaladujWycieczki();
            }
            else if (tc_kierownik.SelectedIndex == 1)
            {
                _listaWycieczek = new Wycieczka_model().PobierzWycieczki();

                for(int i = 0; i < _listaWycieczek.Count; i++)
                {
                    cb_nazwa_wycieczki.Items.Add(_listaWycieczek[i].Nazwa);
                }

            }
            else if (tc_kierownik.SelectedIndex == 2)
            {
                ZaladujPojazdy();
            }
        }

        public void ZaladujWycieczki()
        {
            List<Wycieczka_model> _listaWycieczek = new Wycieczka_model().PobierzWycieczki();
            _listaKatalogu = new Katalog_model().PobierzKatalog();          
            List<Promocja_model> _listaPromocji = new Promocja_model().PobierzPromocje();
            List<Cennik_model> _listaCennikow = new Cennik_model().PobierzCennik();

            _listaWycieczek = new Wycieczka_model().PobierzWycieczki();


            for (int i = 0; i < _listaKatalogu.Count; i++)
            {

                ListViewItem wycieczka = new ListViewItem(_listaWycieczek[_listaKatalogu[i].IdWycieczki - 1].Nazwa);
                wycieczka.SubItems.Add(_listaWycieczek[_listaKatalogu[i].IdWycieczki - 1].DataWyjazdu.ToString());
                wycieczka.SubItems.Add(_listaWycieczek[_listaKatalogu[i].IdWycieczki - 1].DataPowrotu.ToString());
                wycieczka.SubItems.Add(_listaWycieczek[_listaKatalogu[i].IdWycieczki - 1].Opis);

                int j = 0;
                while (_listaPromocji[j].IdWycieczki != _listaKatalogu[i].IdWycieczki)
                {
                    j++;
                }
 
                wycieczka.SubItems.Add(_listaPromocji[j].Cena.ToString());
                wycieczka.SubItems.Add(_listaCennikow[_listaKatalogu[i].IdCennika - 1].Cena.ToString());
                wycieczka.SubItems.Add(_listaWycieczek[_listaKatalogu[i].IdWycieczki - 1].Kierowca.ToString());
                wycieczka.SubItems.Add(_listaWycieczek[_listaKatalogu[i].IdWycieczki - 1].Pilot.ToString());
                wycieczka.SubItems.Add(_listaKatalogu[i].MiejsceWyjazdu);
                wycieczka.SubItems.Add(_listaKatalogu[i].MiejsceDocelowe);

                lv_wycieczki.Items.Add(wycieczka);
            }


            /*_listaWycieczek.Clear();
            lv_wycieczki.Items.Clear();
            _listaWycieczek = (new Katalog_kontroler_list()).PobierzListeDlaKierownika();

            for (int i = 0; i < _listaWycieczek.Count; i++)
            {
                ListViewItem wycieczka = new ListViewItem(_listaWycieczek[i].NazwaWycieczki.ToString());
                wycieczka.SubItems.Add(_listaWycieczek[i].DataWyjazdu.ToString());
                wycieczka.SubItems.Add(_listaWycieczek[i].DataPrzyjazdu.ToString());
                wycieczka.SubItems.Add(_listaWycieczek[i].Opis.ToString());
                wycieczka.SubItems.Add(_listaWycieczek[i].Promocja.ToString());
                wycieczka.SubItems.Add(_listaWycieczek[i].Cena.ToString());
                wycieczka.SubItems.Add(_listaWycieczek[i].Kierowca.ToString());
                wycieczka.SubItems.Add(_listaWycieczek[i].Pilot.ToString());
                wycieczka.SubItems.Add(_listaWycieczek[i].MiejsceOdjazdu.ToString());
                wycieczka.SubItems.Add(_listaWycieczek[i].MiejsceDocelowe.ToString());

                lv_wycieczki.Items.Add(wycieczka);*/
       
        }

        public void ZaladujPojazdy()
        {
            _listaPojazdow.Clear();
            lv_pojazdy.Items.Clear();
            _listaPojazdow = (new Pojazd_model()).PobierzPojazdy();

            for (int i = 0; i < _listaPojazdow.Count; i++)
            {
                ListViewItem pojazd = new ListViewItem(_listaPojazdow[i].NumerRejestracyjny.ToString());

                if (_listaPojazdow[i].Dostepnosc == 1)
                {
                    pojazd.SubItems.Add("Dostępny");
                }
                else
                {
                    pojazd.SubItems.Add("Niedostępny");
                }

                pojazd.SubItems.Add(_listaPojazdow[i].Marka.ToString());
                pojazd.SubItems.Add(_listaPojazdow[i].Pojemnosc.ToString());
                if (_listaPojazdow[i].Stan == 1)
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

        private void cb_nazwa_wycieczki_SelectedIndexChanged(object sender, EventArgs e)
        {          
            List<int> listaNumerowReklamacji = new List<int>();

            lv_reklamacje.Items.Clear();

            listaNumerowReklamacji = _polacz.PobierzListInt(_polacz.UtworzZapytanie("SELECT numer_reklamacji " +
                "FROM Reklamacja " +
                "INNER JOIN Uczestnictwo ON Uczestnictwo.id_uczestnictwo = Reklamacja.id_uczestnictwo " +
                "INNER JOIN Rezerwacja ON Rezerwacja.numer_rezerwacji = Uczestnictwo.numer_rezerwacji I" +
                "NNER JOIN Wycieczka ON Wycieczka.id_wycieczki = Rezerwacja.id_wycieczki " +
                "WHERE Wycieczka.nazwa = '" + cb_nazwa_wycieczki.Text + "'"));

            if (listaNumerowReklamacji.Count == 0)
            {
                lv_reklamacje.Items.Add("brak reklamacji");
            }
            else
            {
                for (int i = 0; i < listaNumerowReklamacji.Count; i++)
                {
                    lv_reklamacje.Items.Add(listaNumerowReklamacji[i].ToString());
                }
            }
            lv_reklamacje.Refresh();
        }

        private void lv_reklamacje_ItemActivate(object sender, EventArgs e)
        {
            _listaReklamacji = new Reklamacja_model().PobierzReklamacje();
            string opis = "";
            int okres = 0;

            _idReklamacji = Convert.ToInt32(lv_reklamacje.SelectedItems[0].SubItems[0].Text);
            opis = _listaReklamacji[_idReklamacji + 1].Opis;

            /* opis = _polacz.PobierzDaneString(_polacz.UtworzZapytanie("SELECT opis " +
                 "FROM Reklamacja " +
                 "INNER JOIN Uczestnictwo ON Uczestnictwo.id_uczestnictwo = Reklamacja.id_uczestnictwo " +
                 "INNER JOIN Rezerwacja ON Rezerwacja.numer_rezerwacji = Uczestnictwo.numer_rezerwacji I" +
                 "NNER JOIN Wycieczka ON Wycieczka.id_wycieczki = Rezerwacja.id_wycieczki " +
                 "WHERE Reklamacja.numer_reklamacji = " + Convert.ToInt32(lv_reklamacje.SelectedItems[0].SubItems[0].Text)));
             */

            okres = _polacz.PobierzDaneInt(_polacz.UtworzZapytanie("SELECT DATEDIFF(day,data_wyjazdu,data_powrotu) " +
               "FROM Reklamacja " +
               "INNER JOIN Uczestnictwo ON Uczestnictwo.id_uczestnictwo = Reklamacja.id_uczestnictwo " +
               "INNER JOIN Rezerwacja ON Rezerwacja.numer_rezerwacji = Uczestnictwo.numer_rezerwacji " +
               "INNER JOIN Wycieczka ON Wycieczka.id_wycieczki = Rezerwacja.id_wycieczki " +
               "WHERE Reklamacja.numer_reklamacji = " + _idReklamacji));

            rtb_opisReklamacji.Text = opis;
            tb_okresTrwaniaWycieczki.Text = okres.ToString();
        }

        private void b_rozpatrz_pozytywnie_Click(object sender, EventArgs e)
        {
            if((new Kierownik_model()).RozpatrzReklamacje(_idReklamacji, 1))
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
            if((new Kierownik_model()).RozpatrzReklamacje(_idReklamacji, 0))
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
            Wycieczka wycieczka = new Wycieczka(0,lv_wycieczki.SelectedItems[0].Index + 1);
            wycieczka.ShowDialog();
            ZaladujWycieczki();
        }

        private void b_usun_wycieczke_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz usunąc wycieczke o indeksie: " + (lv_wycieczki.SelectedItems[0].Index + 1).ToString() + " ?","Usunięcie wycieczki.",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(dialogResult == DialogResult.Yes)
            {
                if ((new Kierownik_model()).UsunWycieczke(lv_wycieczki.SelectedItems[0].Index + 1))
                {
                    MessageBox.Show("Usunięto wybraną wycieczkę.", "Usuwanie wycieczki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
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
    }
}
