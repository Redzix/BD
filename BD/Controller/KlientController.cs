using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.View;
using System.Windows.Forms;
using System.Drawing;

namespace BD.Controller
{
    class KlientController
    {
        /// <summary>
        /// Obiekt widoku.
        /// </summary>
        private KlientView _view;

        /// <summary>
        /// Model danych.
        /// </summary>
        private bazaEntities db;

        /// <summary>
        /// Konstruktor tworzący obiekt pobranego widoku oraz nowy model danych.
        /// </summary>
        /// <param name="view">Referencja do widoku, który controller ma obsługiwac</param>
        public KlientController(KlientView view)
        {
            _view = (KlientView)view;
        }

        /// <summary>
        /// Metoda pobierająca wycieczki z bazy danych i dodająca je do aktualnego widoku.
        /// </summary>
        /// <returns>Zwraca odpowiednie informacje o powodzeniu operacji.</returns>
        public bool PobierzWycieczki()
        {
            db = new bazaEntities();

            _view.lv_klient.Items.Clear();

            var query = from katalog in db.Katalog
                        where DateTime.Now < katalog.Wycieczka.data_wyjazdu
                        select new
                        {
                            wycieczkaId = katalog.id_wycieczki,
                            wycieczka = katalog.Wycieczka,
                            okresTrwaniaWycieczki = katalog.okres_trwania_wycieczki,
                            dataOdjazdu = katalog.Wycieczka.data_wyjazdu,
                            wartoscPromocji = (katalog.Wycieczka.Promocja.cena != null) ? katalog.Wycieczka.Promocja.cena : 0,
                            cenaCalkowita = katalog.cena - ((katalog.Wycieczka.Promocja.cena != null) ? katalog.Wycieczka.Promocja.cena : 0)
                        };

            if (query == null)
            {
                _view.lv_klient.Items.Add("Brak wycieczek");
                return false;
            }
            else
            {
                foreach (var kli in query)
                {
                    ListViewItem klient = new ListViewItem(kli.wycieczka.nazwa);
                    klient.Tag = kli.wycieczkaId;
                    klient.SubItems.Add(kli.okresTrwaniaWycieczki.ToString());
                    klient.SubItems.Add(kli.dataOdjazdu.ToString());
                    klient.SubItems.Add(kli.wartoscPromocji.ToString());
                    klient.SubItems.Add(kli.cenaCalkowita.ToString());
                    _view.lv_klient.Items.Add(klient);
                }
                return true;
            }
        }

        /// <summary>
        /// Metoda pobiera szczegółowe informacje o wybranej wycieczce i dodaje je do richtextboxa
        /// </summary>
        /// <param name="_idWycieczki">Id aktualnie wybranej w listview wycieczki.</param>
        /// <returns>Zwraca odpowiednie informacje o powodzeniu operacji.</returns>
        public int PobierzDaneWycieczki(string _idWycieczki)
        {
            db = new bazaEntities();

            try
            {
                //Pobranie z tabeli oraz z bazy danych odpowiednich wartości do wyświetlenia.
                int idWycieczki = int.Parse(_idWycieczki);

                var pobierz = (from katalog in db.Katalog
                             where katalog.id_wycieczki == idWycieczki
                             select new
                             {
                                 wycieczka = katalog.Wycieczka.nazwa,
                                 dataOdjazdu = katalog.Wycieczka.data_wyjazdu,
                                 dataPowrotu = katalog.Wycieczka.data_wyjazdu,
                                 opisWycieczki = katalog.Wycieczka.opis,
                                 miejsceDoceloweAdres = katalog.Miejsce1.adres,
                                 miejsceDoceloweMiejscowosc = katalog.Miejsce1.miejscowosc,
                                 cena = katalog.cena
                             }).FirstOrDefault();
            
                if (pobierz == null)
                {
                    return -1;
                }
                else
                {
                    // Dodanie wartości parametrów do opisu znajdującego się w texboxie
                    _view.rtb_wycieczka.Text =
                        "Nazwa: " + pobierz.wycieczka +
                        "\nCena: " + pobierz.cena +
                        "\nData wyjazdu: " + pobierz.dataOdjazdu +
                        "\nData powrotu: " + pobierz.dataPowrotu +
                        "\nOpis: " + pobierz.opisWycieczki +
                        "\n\nAdres miejsca: " + pobierz.miejsceDoceloweAdres +
                        "\nMiejscowość: " + pobierz.miejsceDoceloweMiejscowosc;
                }

                return 1;

            }
            catch (FormatException)
            {
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// Metoda  wyszukująca wycieczki według nazwy i miejscowosci
        /// </summary>
        /// <param name="szukanaFraza">Szukany ciąg znaków</param>
        /// <returns>Zwraca odpowiednie informacje o powodzeniu operacji.</returns>
        public bool SzukajWycieczki(string szukanaFraza)
        {
            db = new bazaEntities();

            var szukaj = from katalog in db.Katalog
                         where (katalog.Wycieczka.nazwa + " " + katalog.Miejsce1.miejscowosc).Contains(szukanaFraza)
                         select new
                         {
                             wycieczkaId = katalog.id_wycieczki,
                             wycieczka = katalog.Wycieczka.nazwa,
                             okresTrwaniaWycieczki = katalog.okres_trwania_wycieczki,
                             dataOdjazdu = katalog.Wycieczka.data_wyjazdu,
                             wartoscPromocji = (katalog.Wycieczka.Promocja.cena != null) ? katalog.Wycieczka.Promocja.cena : 0,
                             cenaCalkowita = katalog.cena - ((katalog.Wycieczka.Promocja.cena != null) ? katalog.Wycieczka.Promocja.cena : 0)
                         };

            if (szukaj.Count() == 0)
            {
                _view.lv_klient.Items.Add("Brak wycieczek");
                return false;
            }
            else
            {
                _view.lv_klient.Items.Clear();
                foreach (var kli in szukaj)
                {
                    ListViewItem klient = new ListViewItem(kli.wycieczka);
                    klient.Tag = kli.wycieczkaId;
                    klient.SubItems.Add(kli.okresTrwaniaWycieczki.ToString());
                    klient.SubItems.Add(kli.dataOdjazdu.ToString());
                    klient.SubItems.Add(kli.wartoscPromocji.ToString());
                    klient.SubItems.Add(kli.cenaCalkowita.ToString());
                    _view.lv_klient.Items.Add(klient);
                }
                return true;
            }
        }

        /// <summary>
        /// Metoda pobierająca rezerwacje aktualnego użytkownika dodająca je do aktualnego widoku.
        /// </summary>
        /// <returns>Zwraca odpowiednie informacje o powodzeniu operacji.</returns>
        public int PobierzRezerwacje(string pesel)
        {
            db = new bazaEntities();
            int doZaplaty = 0;

            _view.lv_klient.Items.Clear();

            var query = from uczestnictwo in db.Uczestnictwo
                        where uczestnictwo.Rezerwacja.Klient_pesel.Equals(pesel)
                        select new
                        {
                            rezerwacja = uczestnictwo.Rezerwacja,
                            wycieczka = uczestnictwo.Rezerwacja.Wycieczka,
                            cenaCalkowita = uczestnictwo.cena_rezerwacji
                        };

            if (query == null)
            {
                _view.lv_klient.Items.Add("Brak ezerwacji");
                return -1;
            }
            else
            {
                foreach (var ucz in query)
                {
                    ListViewItem rezerwacja = new ListViewItem(ucz.rezerwacja.numer_rezerwacji.ToString());
                    rezerwacja.Tag = ucz.rezerwacja.numer_rezerwacji.ToString();
                    rezerwacja.SubItems.Add(ucz.wycieczka.nazwa);
                    rezerwacja.SubItems.Add(ucz.wycieczka.data_wyjazdu.ToString());
                    rezerwacja.SubItems.Add(ucz.wycieczka.data_powrotu.ToString());
               
                    if ((ucz.wycieczka.WycieczkaZaplanowana(DateTime.Now)) && (!bool.Parse(ucz.rezerwacja.stan.ToString())))
                    {
                        rezerwacja.BackColor = Color.Yellow;
                        doZaplaty++;
                    }
                    else if (ucz.wycieczka.WycieczkaOdbyta(DateTime.Now))
                        rezerwacja.BackColor = Color.LightCoral;
                    else if ((ucz.wycieczka.WycieczkaZaplanowana(DateTime.Now)) && (bool.Parse(ucz.rezerwacja.stan.ToString())))
                        rezerwacja.BackColor = Color.LightGreen;

                    rezerwacja.SubItems.Add(ucz.rezerwacja.zaliczka.ToString());
                    rezerwacja.SubItems.Add((ucz.cenaCalkowita - ucz.rezerwacja.zaliczka).ToString());
                    _view.lv_klient.Items.Add(rezerwacja);
                }
                return doZaplaty;
            }
        }

        /// <summary>
        /// Metoda pobiera szczegółowe informacje o wybranej rezerwacji i dodaje je do richtextboxa
        /// </summary>
        /// <param name="numerRezerwacji">Numeraktualnie wybranej w listview rezerwacji.</param>
        /// <returns>Zwraca odpowiednie informacje o powodzeniu operacji.</returns>
        public int PobierzDaneRezerwacji(string numerRezerwacji)
        {
            db = new bazaEntities();

            try
            {
                //Pobranie z tabeli oraz z bazy danych odpowiednich wartości do wyświetlenia.
                int numer = int.Parse(numerRezerwacji);

                var pobierz = (from uczestnictwo in db.Uczestnictwo
                               where uczestnictwo.numer_rezerwacji == numer
                               select new
                               {
                                   rezerwacja = uczestnictwo.Rezerwacja,
                                   wycieczka = uczestnictwo.Rezerwacja.Wycieczka,
                                   uczest = uczestnictwo
                               }).FirstOrDefault();

                if (pobierz == null)
                {
                    return -1;
                }
                else
                {
                    // Dodanie wartości parametrów do opisu znajdującego się w texboxie
                    _view.rtb_wycieczka.Text = "Numer rezerwacji " + pobierz.rezerwacja.numer_rezerwacji +
                        "\nNazwa Wycieczki " + pobierz.wycieczka.nazwa +
                        "\nLiczba osób " + pobierz.uczest.liczba_osob +
                        "\nCena całkowita " + pobierz.uczest.cena_rezerwacji +
                        "\nData wyjazdu " + pobierz.wycieczka.data_wyjazdu +
                        "\nData powrotu " + pobierz.wycieczka.data_powrotu +
                        "\nOpis wycieczki " + pobierz.wycieczka.opis;
                 }

                return 1;

            }
            catch (FormatException)
            {
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// Metoda sprawdza, czy wycieczka została już odbyta lub jest w trakcie
        /// </summary>
        /// <param name="idWycieczki">Numer aktualnie wybranej w listview wycieczki.</param>
        /// <returns>Zwraca  true jeśli wycieczka została odbyta, false jeśli jest zaplanowana.</returns>
        public bool SprawdzCzyOdbyta(int idWycieczki)
        {
            db = new bazaEntities();

            var sprawdz = (from wycieczka in db.Wycieczka
                           where wycieczka.id_wycieczki == idWycieczki
                           select wycieczka).FirstOrDefault();

            if(sprawdz.WycieczkaOdbyta(DateTime.Now) || sprawdz.WycieczkaWTrakcie(DateTime.Now))
            {
                return true;
            }
            else{
                return false;
            }           
        }
    }
}
