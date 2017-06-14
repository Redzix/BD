using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BD.Controller;

namespace BD.View
{
    public partial class KlientView : Form
    {
        /// <summary>
        /// Zmienna przechowująca id aktualnie wybranej wycieczki
        /// </summary>
        private int _idWycieczki;

        /// <summary>
        /// Obiekt przechowujący kontroler.
        /// </summary>
        private KlientController controller;

        /// <summary>
        /// Zmienna przechowująca pesel aktualnie zalogowanego użytkownika
        /// </summary>
        private string _uzytkownik;

        /// <summary>
        /// Obiekt przechowujący klasę odpowiedzialną za sprawdzanie zmian w bazie.
        /// </summary>
        AktualizacjaController aktKlienta;

        /// <summary>
        /// Zmienna przechowująca aktualnie numer wybranego listview
        /// </summary>
        private int indeksListview= 0;
     

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

            aktKlienta = new AktualizacjaController("wycieczka");

            this.lv_klient.Columns.Remove(this.cenaDoZaplaty);

            timer1.Start();
        }

        /// <summary>
        /// Konstruktor okna z parametrem, pozwalający na przekazanie nazwy użytkownika zalogowanego do systemu 
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

            aktKlienta = new AktualizacjaController("wycieczka promocja katalog");

            this.lv_klient.Columns.Remove(this.cenaDoZaplaty);

            timer1.Start();

        }

        /// <summary>
        /// Zdarzenie obsługujące wylogowanie z systemu po wciśnięciu przycisku "Wyjdź", po kliknięciu program przechodzi do panelu logowania.
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego/param>
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
        /// <param name="sender">Rozpoznanie obiektu wywołującego/param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_katalog_rezerwuj_Click(object sender, EventArgs e)
        {
            if (controller.SprawdzCzyOdbyta(_idWycieczki))
            {
                MessageBox.Show("Wybrana wycieczka została już odbyta", "Wycieczka odbyta.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                RezerwacjaView rezerwacja = new RezerwacjaView(_idWycieczki, _uzytkownik);
                rezerwacja.ShowDialog();
            }
        }

        /// <summary>
        /// Zdarzenie otwiera okno dialogowe pozwalające wystawić opinię.
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego/param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void wystawOpinięToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpiniaView opinia = new OpiniaView(_uzytkownik);
            opinia.ShowDialog();
        }

        /// <summary>
        /// Zdarzenie otwiera okno dialogowe pozwalające na złożenie reklamacji.
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego/param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void reklamujWycieczkęToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReklamacjaView reklamancja = new ReklamacjaView(_uzytkownik);
            reklamancja.ShowDialog();
        }

        /// <summary>
        /// Zdarzenie otwiera okno dialogowe pozwalające wprowadzić do bazy nową wycieczkę.
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego/param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void rezygnacjaZWycieczkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RezygnacjaView rezygnacja = new RezygnacjaView(_uzytkownik);
            rezygnacja.ShowDialog();
        }

        /// <summary>
        /// Zdarzenie obsługujące wyłączenie aplikacji poprzez wciśnięcie "X", program całkowicie kończy swoją pracę
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego/param>
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

        /// <summary>
        /// Metoda obsługująca zdarzenie ładowania widoku, odpowiada za wywołanie funkcji ładującej
        /// informacje o wycieczkach do widoku i obsługuje jej komunikaty.
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego/param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void Klient_Load(object sender, EventArgs e)
        {
            if(!controller.PobierzWycieczki())
            {
                MessageBox.Show("Wystąpił problem podczas pobierania danych z bazy.", "Błąd podczas pobierania.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.b_katalog_rezerwuj.Enabled = false;
            }
        }

        /// <summary>
        /// Metoda obsługująca zdarzenie kliknięcia przycisku b_zaplac, odpowiada za wywołanie widoku 
        /// płacenia za wycieczkę
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego/param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_zaplac_Click(object sender, EventArgs e)
        {
            RezerwacjaView rezerwacja = new RezerwacjaView(_uzytkownik);
            rezerwacja.ShowDialog();
        }

        /// <summary>
        /// Metoda implementująca wywołanie funkcji sortującej wiersze w kolumnach
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego/param>
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
        /// <param name="sender">Rozpoznanie obiektu wywołującego/param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void lv_klient_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            sortListViewByColumn(sender, e);
        }

        /// <summary>
        /// Metoda obsługująca zdarzenie ładowania kliknięcie komórki listview, odpowiada za wywołanie funkcji ładującej
        /// informacje o wybranej wycieczce do richtextboxa.
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego/param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void lv_klient_ItemActivate(object sender, EventArgs e)
        {
            if (indeksListview == 0)
            {
                int pobierz = controller.PobierzDaneWycieczki(((ListView)sender).SelectedItems[0].Tag.ToString());

                switch (pobierz)
                {
                    case 1:
                        int.TryParse(((ListView)sender).SelectedItems[0].Tag.ToString(), out _idWycieczki);
                        this.b_katalog_rezerwuj.Enabled = true;
                        break;
                    case 0:
                        MessageBox.Show("Wystąpił problem podczas konwersji id wycieczki", "Błąd konwersji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.b_katalog_rezerwuj.Enabled = false;
                        break;
                    case -1:
                        MessageBox.Show("Wystąpił problem podczas pobierania danych.", "Błąd pobierania danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.b_katalog_rezerwuj.Enabled = false;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                int pobierz = controller.PobierzDaneRezerwacji(((ListView)sender).SelectedItems[0].Tag.ToString());

                switch (pobierz)
                {
                    case 1:
                        int.TryParse(((ListView)sender).SelectedItems[0].Tag.ToString(), out _idWycieczki);
                        this.b_katalog_rezerwuj.Enabled = true;
                        break;
                    case 0:
                        MessageBox.Show("Wystąpił problem podczas konwersji id wycieczki", "Błąd konwersji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.b_katalog_rezerwuj.Enabled = false;
                        break;
                    case -1:
                        MessageBox.Show("Wystąpił problem podczas pobierania danych.", "Błąd pobierania danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.b_katalog_rezerwuj.Enabled = false;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Metoda obsługująca zdarzenie kliknięcia pprzycisku b_szukaj, wywołuje funkcje odpowiedzialną za wyszukiwanie w bazie danych i 
        /// obsługuje jej komunikaty
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego/param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void b_szukaj_Click(object sender, EventArgs e)
        {
            if (controller.SzukajWycieczki(tb_szukaj.Text))
            {
                b_szukaj.Enabled = false;               
            }
            else
            {
                MessageBox.Show("Brak wyszukiwanych wycieczek.","Brak rezultatów",MessageBoxButtons.OK,MessageBoxIcon.Information);
                controller.PobierzWycieczki();
                b_szukaj.Enabled = false;
            }

        }

        /// <summary>
        /// Metoda obsługująca zdarzenie wprowadzenia tekstu do tb_szukaj, zmienia stan przycisku b_szukaj na enable, co pozwala
        /// uruchomic wyszukiwanie
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego/param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void tb_szukaj_TextChanged(object sender, EventArgs e)
        {
            b_szukaj.Enabled = true;
        }

        /// <summary>
        /// Metoda obsługująca kolejne ticki timera, co 5s uruchamia metode sprawdzającą, czy nastąpiła aktualizacja w bazie danych
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (aktKlienta.czyBylaAktualizacja() && (indeksListview == 0))
            {
                controller.PobierzWycieczki();
            }
            else
            {
                return;
            }
        }
        
        /// <summary>
        /// Metoda odpowiadająca za pobranie i wyświetlenie wszystkich wycieczek oraz dodanie ich do listview
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void wyświetlWszystkieWycieczkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.nazwaWycieczki.Text = "Nazwa wycieczki";
            this.nazwaWycieczki.Width = 110;
            this.okresTrwania.Text = "Długość wycieczki";
            this.dataWyjazdu.Text = "Data wyjazdu";
            this.promocja.Text = "Promocja";
            this.cenaCalkowita.Text = "Cena całkowita";
            this.cenaCalkowita.Width = 110;
            this.lv_klient.Columns.Remove(this.cenaDoZaplaty);
            this.tb_szukaj.Enabled = true;
            this.rtb_wycieczka.Text = "Nazwa\nData wyjazdu\nData powrotu\nOpis\n\nAdres miejsca\nMiejscowość";
            this.b_zaplac.Enabled = false;
            indeksListview = 0;

            controller.PobierzWycieczki();
        }

        /// <summary>
        /// Metoda odpowiadająca za pobranie i wyświetlenie wszystkich rezerwacji oraz dodanie ich do listview
        /// </summary>
        /// <param name="sender">Rozpoznanie obiektu wywołującego</param>
        /// <param name="e">Zdarzenia systemowe</param>
        private void wyświetlMojeRezerwacjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.nazwaWycieczki.Text = "Numer";
            this.nazwaWycieczki.Width = 60;
            this.okresTrwania.Text = "Nazwa wycieczki";
            this.dataWyjazdu.Text = "Data wyjazdu";
            this.promocja.Text = "Data powrotu";
            this.cenaCalkowita.Text = "Zaliczka";
            this.cenaCalkowita.Width = 70;
            this.lv_klient.Columns.Remove(this.cenaDoZaplaty);
            this.lv_klient.Columns.Insert(5,this.cenaDoZaplaty);
            this.cenaDoZaplaty.Width = 110;
            this.tb_szukaj.Enabled = false;
            this.b_szukaj.Enabled = false;
            this.rtb_wycieczka.Text = "Numer rezerwacji\nLiczba osób\nNazwa Wycieczki\nCena całkowita\nData wyjazdu\nData powrotu\nOpis wycieczki";
            indeksListview = 1;

            int pobierz = controller.PobierzRezerwacje(_uzytkownik);

            switch (pobierz)
            {
                case -2:
                    this.b_zaplac.Enabled = false;
                    break;
                case -0:
                    MessageBox.Show("Wszystkie rezerwacje zostały zapłacone.", "Niezapłacone rezerwacje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.b_zaplac.Enabled = false;
                    break;
                default:
                    MessageBox.Show("Do zapłaty pozostało: " + pobierz.ToString() + " rezerwacji.","Niezapłacone rezerwacje",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.b_zaplac.Enabled = true;
                    break;
            }
        }
    }
}
