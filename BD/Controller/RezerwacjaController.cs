using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.View;
using System.Windows.Forms;

namespace BD.Controller
{
    class RezerwacjaController
    {
        /// <summary>
        /// Obiekt widoku.
        /// </summary>
        private RezerwacjaView _view;

        /// <summary>
        /// Model danych.
        /// </summary>
        private bazaEntities db;

        /// <summary>
        /// Konstruktor tworzący obiekt pobranego widoku oraz nowy model danych.
        /// </summary>
        /// <param name="view">Referencja do widoku, który controller ma obsługiwac</param
        public RezerwacjaController(RezerwacjaView view)
        {
            _view = (RezerwacjaView)view;
            db = new bazaEntities();
        }

        /// <summary>
        /// Metoda pobierająca informacje o aktualnie wybranej rezerwacji, 
        /// obliczająca kwotę do zapłąty po wprowadzonych zmianach i doajace te informacje do widoku
        /// </summary>
        /// <param name="numerRezerwacji">Numer rezerwacji, dla której pobierane sa informacje.</param>
        /// <param name="uzytkownik">Aktualnie zalogowany użytkownik</param>
        /// <returns>Zwraca odpowiednie informacje o powodzeniu operacji.</returns>
        public int PobierzCeneWycieczki(int numerRezerwacji, string uzytkownik)
        {       
            
                try
                {

                    var rez = (from rezerwacja in db.Rezerwacja
                               where rezerwacja.numer_rezerwacji == numerRezerwacji && rezerwacja.Klient_pesel.Equals(uzytkownik)
                               select rezerwacja).FirstOrDefault();

                if (!bool.Parse(rez.stan.ToString()))
                {
                    var uczest = (from uczestnictwo in db.Uczestnictwo
                                  where uczestnictwo.numer_rezerwacji == numerRezerwacji
                                  select uczestnictwo).FirstOrDefault();

                    if (rez == null)
                    {
                        return -1;
                    }
                    else
                    {
                        _view.tb_kwotaCalkowita.Text = (uczest.cena_rezerwacji).ToString();
                        _view.tb_kwotaDoZaplaty.Text = (uczest.cena_rezerwacji - rez.zaliczka).ToString();

                        return 1;
                    }
                }
                else
                {
                    return -2;
                }
            }
                catch (FormatException exception)
                {
                    return 0;
                }          
        }

        /// <summary>
        /// Metoda dodająca zmiany w rezerwacji do bazy danych.
        /// </summary>
        /// <param name="numerRezerwacji">Numer rezerwacji, dla której pobierane sa informacje.</param>
        /// <param name="uzytkownik">Aktualnie zalogowany użytkownik</param>
        /// <returns>Zwraca odpowiednie informacje o powodzeniu operacji.</returns>
        public int ZaplacRezerwacje(int numerRezerwacji, string uzytkownik)
        {
            try
            {
                    var rez = (from rezerwacja in db.Rezerwacja
                               where rezerwacja.numer_rezerwacji == numerRezerwacji
                               && rezerwacja.Klient_pesel.Equals(uzytkownik)
                               select rezerwacja).FirstOrDefault();

                    var uczest = (from uczestnictwo in db.Uczestnictwo
                                  where uczestnictwo.numer_rezerwacji == numerRezerwacji
                                  && uczestnictwo.Rezerwacja.Klient_pesel.Equals(uzytkownik)
                                  select uczestnictwo).FirstOrDefault();
                    try
                    {
                        decimal kwota = decimal.Parse(_view.tb_kwotaZaplacona.Text);

                        if ((kwota + rez.zaliczka) == uczest.cena_rezerwacji)
                        {
                            rez.zaliczka += kwota;
                            rez.stan = true;
                            db.SaveChanges();
                            db.Dispose();
                            db = new bazaEntities();
                            return 1;
                        }
                        else if ((kwota + rez.zaliczka) > uczest.cena_rezerwacji)
                        {
                            return 0;
                        }
                        else if ((kwota + rez.zaliczka) < uczest.cena_rezerwacji)
                        {
                            rez.zaliczka += kwota;
                            rez.stan = false;
                            db.SaveChanges();
                            db.Dispose();
                            db = new bazaEntities();
                            return -1;
                        }
                        return 2;
                    }
                    catch (FormatException exception)
                    {
                        return -3;
                    }
            }
            catch (FormatException exception)
            {
                return -4;
            }
        }

        /// <summary>
        /// Metoda dodająca nową rezerwację dla aktualnie wy ranej przez użytkownika wycieczki.
        /// </summary>
        /// <param name="idWycieczki">Aktualny numer wycieczki wybranej przez użytkownika.</param>
        /// <returns>Zwraca odpowiednie informacje o powodzeniu operacji.</returns>
        public int DodajRezerwacje(int idWycieczki, Klient uzytkownik)
        {
            bool czyZmianaDanych = false;

            var cenaRezerwacji = (from katalog in db.Katalog
                                  where katalog.id_wycieczki == idWycieczki
                                  select katalog.cena).FirstOrDefault();

            try
            {
                if ((uzytkownik.imie.Equals(_view.tb_imie.Text)) && (uzytkownik.nazwisko.Equals(_view.tb_nazwisko.Text)) 
                    && (uzytkownik.ulica.Equals(_view.tb_adres.Text)) && (uzytkownik.miejscowosc.Equals(_view.tb_miejscowosc.Text)))
                {
                    czyZmianaDanych = false;
                }
                else
                {
                    czyZmianaDanych = true;
                }

                var nowaRezerwacja = new Rezerwacja
                {
                    liczba_osob = int.Parse(_view.tb_liczba_osob.Text),
                    stan = false,
                    zaliczka = decimal.Parse(_view.tb_zaliczka.Text),
                    id_wycieczki = idWycieczki,
                };

                var noweUczestnictwo = new Uczestnictwo
                {
                    liczba_osob = nowaRezerwacja.liczba_osob,
                    cena_rezerwacji = cenaRezerwacji * nowaRezerwacja.liczba_osob
                };

                if (czyZmianaDanych)
                {
                    uzytkownik.imie = _view.tb_imie.Text;
                    uzytkownik.nazwisko = _view.tb_nazwisko.Text;
                    uzytkownik.ulica = _view.tb_adres.Text;
                    uzytkownik.miejscowosc = _view.tb_miejscowosc.Text;
                }

                nowaRezerwacja.Klient = uzytkownik;
                noweUczestnictwo.Rezerwacja = nowaRezerwacja;
                db.Rezerwacja.Add(nowaRezerwacja);
                db.Uczestnictwo.Add(noweUczestnictwo);
                db.SaveChanges();
                db.Dispose();
                db = new bazaEntities();
                  
                return nowaRezerwacja.numer_rezerwacji;
            }
            catch (FormatException exception)
            {
                return -1;
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Metoda pobierająca z bazy dane uzytkownika i ładująca je do textboxow
        /// </summary>
        /// <param name="idWycieczki">Aktualny numer wycieczki wybranej przez użytkownika.</param>
        /// <returns>Zwraca odpowiednie informacje o powodzeniu operacji.</returns>
        public Klient PobierzDaneKlienta(string uzytkownik)
        {
            var klient = (from kli in db.Klient
                          where kli.pesel.Equals(uzytkownik)
                          select kli).FirstOrDefault();

            _view.tb_pesel.Text = klient.pesel;
            _view.tb_imie.Text = klient.imie;
            _view.tb_nazwisko.Text = klient.nazwisko;
            _view.tb_adres.Text = klient.ulica;
            _view.tb_miejscowosc.Text = klient.miejscowosc;

            return klient;
        }

        /// <summary>
        /// Metoda wypełniająca nazwę wycieczki dla dokonanych rezerwacji
        /// </summary>
        /// <returns>True jeśli się uda</returns>
        public bool WypelnijRezerwacje(string pesel)
        {
            try
            {
                using (var db = new bazaEntities())
                {
                    Dictionary<int, string> values = new Dictionary<int, string>();
                    var query = from rezerwacja in db.Rezerwacja
                                where rezerwacja.Klient_pesel.Equals(pesel) && rezerwacja.stan == false
                                select new
                                {
                                    rezerwacja,
                                    rezerwacja.Wycieczka.nazwa
                                };

                    foreach (var row in query)
                    {
                        values.Add(row.rezerwacja.numer_rezerwacji, row.nazwa);
                    }
                    this._view.cb_nazwaWycieczki.DataSource = new BindingSource(values, null);
                    this._view.cb_nazwaWycieczki.DisplayMember = "Value";
                    this._view.cb_nazwaWycieczki.ValueMember = "Key";
                }
            }
            catch
            {
                return false;
            }
            return true;
        }


    }
}