using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.View;
using System.Windows.Forms;

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
            _view = view;
            db = new bazaEntities();
        }

        /// <summary>
        /// Metoda pobierająca wycieczki z bazy danych i dodająca je do aktualnego widoku.
        /// </summary>
        /// <returns>Zwraca odpowiednie informacje o powodzeniu operacji.</returns>
        public bool PobierzWycieczki()
        {
            _view.lv_klient.Items.Clear();

            var query = from katalog in db.Katalog
                        select new
                        {
                            wycieczkaId = katalog.id_wycieczki,
                            wycieczka = katalog.Wycieczka.nazwa,
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
        /// Metoda pobiera szczegółowe informacje o wybranej wycieczce i dodaje je do richtextboxa
        /// </summary>
        /// <param name="_idWycieczki">Id aktualnie wybranej w listview wycieczki.</param>
        /// <returns>Zwraca odpowiednie informacje o powodzeniu operacji.</returns>
        public int PobierzDaneWycieczki(string _idWycieczki)
        {
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
            catch (FormatException exception)
            {
                return 0;
            }
            catch (Exception exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// Metoda pobiera wyszukująca wycieczki według nazwy i miejscowosci
        /// </summary>
        /// <param name="_idWycieczki">Id aktualnie wybranej w listview wycieczki.</param>
        /// <returns>Zwraca odpowiednie informacje o powodzeniu operacji.</returns>
        public bool SzukajWycieczki(string szukanaFraza)
        {
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
        public bool PobierzRezerwacje(string pesel)
        {
            _view.lv_klient.Items.Clear();

            var query = from rezerwacja in db.Rezerwacja
                        where rezerwacja.Klient_pesel.Equals(pesel)
                        select new
                        {
                            numer_rezerwacji = rezerwacja.numer_rezerwacji,
                            nazwa = rezerwacja.Wycieczka.nazwa,
                            dataWyjazdu = rezerwacja.Wycieczka.data_wyjazdu,
                            dataPowrotu = rezerwacja.Wycieczka.data_powrotu,
                            zaliczka = rezerwacja.zaliczka
                        };

            if (query == null)
            {
                _view.lv_klient.Items.Add("Rezerwacji");
                return false;
            }
            else
            {
                foreach (var rez in query)
                {
                    ListViewItem rezerwacja = new ListViewItem(rez.numer_rezerwacji.ToString());
                    rezerwacja.SubItems.Add(rez.nazwa);
                    rezerwacja.SubItems.Add(rez.dataWyjazdu.ToString());
                    rezerwacja.SubItems.Add(rez.dataPowrotu.ToString());
                    rezerwacja.SubItems.Add(rez.zaliczka.ToString());
                    _view.lv_klient.Items.Add(rezerwacja);
                }
                return true;
            }
        }
    }
}
