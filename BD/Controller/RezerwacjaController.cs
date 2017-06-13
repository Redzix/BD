using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.View;

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
        /// Zmienna przechowująca informacje o tym, czy użytkownik
        /// chce zapisać zmiany dla pierwotnie wybranej rezerwacji, czy zmienił jej numer
        /// </summary>
        private int sprawdzCzyTaSama;


        /// <summary>
        /// Konstruktor tworzący obiekt pobranego widoku oraz nowy model danych.
        /// </summary>
        /// <param name="view">Referencja do widoku, który controller ma obsługiwac</param
        public RezerwacjaController(RezerwacjaView view)
        {
            _view = view;
            db = new bazaEntities();
        }

        /// <summary>
        /// Metoda pobierająca informacje o aktualnie wybranej rezerwacji, 
        /// obliczająca kwotę do zapłąty po wprowadzonych zmianach i doajace te informacje do widoku
        /// </summary>
        /// <param name="numerRezerwacji">Numer rezerwacji, dla której pobierane sa informacje.</param>
        /// <param name="uzytkownik">Aktualnie zalogowany użytkownik</param>
        /// <returns>Zwraca odpowiednie informacje o powodzeniu operacji.</returns>
        public int PobierzNazweWycieczki(string numerRezerwacji, string uzytkownik)
        {
            try
            {
                int numer = int.Parse(numerRezerwacji);
                sprawdzCzyTaSama = numer;

                var rez = (from rezerwacja in db.Rezerwacja
                           where rezerwacja.numer_rezerwacji == numer && rezerwacja.Klient_pesel.Equals(uzytkownik)
                           select rezerwacja).FirstOrDefault();

                var uczest = (from uczestnictwo in db.Uczestnictwo
                              where uczestnictwo.numer_rezerwacji == numer
                              select uczestnictwo).FirstOrDefault();

                if (rez == null)
                {
                    return -1;
                }
                else
                {

                    _view.tb_nazwaWycieczkiZaplac.Text = rez.Wycieczka.nazwa;
                    _view.tb_kwotaCalkowita.Text = (uczest.cena_rezerwacji).ToString();
                    _view.tb_kwotaDoZaplaty.Text = (uczest.cena_rezerwacji - rez.zaliczka).ToString();

                    return 1;
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
        public int ZaplacRezerwacje(string numerRezerwacji, string uzytkownik)
        {
            try
            {
                int numer = int.Parse(_view.tb_numerRezerwacji.Text);

                if (sprawdzCzyTaSama == numer)
                {
                    var rez = (from rezerwacja in db.Rezerwacja
                               where rezerwacja.numer_rezerwacji == numer
                               && rezerwacja.Klient_pesel.Equals(uzytkownik)
                               select rezerwacja).FirstOrDefault();

                    var uczest = (from uczestnictwo in db.Uczestnictwo
                                  where uczestnictwo.numer_rezerwacji == numer
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
                else
                {
                    return -2;
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
        public int DodajRezerwacje(int idWycieczki, string uzytkownik)
        {

            var cenaRezerwacji = (from katalog in db.Katalog
                                  where katalog.id_wycieczki == idWycieczki
                                  select katalog.Cennik.cena).FirstOrDefault();

            try
            {
                var nowyKlient = new Klient
                {
                        pesel = _view.tb_pesel.Text,
                        imie = _view.tb_imie.Text,
                        nazwisko = _view.tb_nazwisko.Text,
                        ulica = _view.tb_adres.Text,
                        miejscowosc = _view.tb_miejscowosc.Text,
                 };

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

                var czyKlientIstnieje = (from czyIstnieje in db.Klient
                                         where czyIstnieje.pesel.Equals(nowyKlient.pesel)
                                         select czyIstnieje).FirstOrDefault();

                if (czyKlientIstnieje == null)
                {
                    db.Klient.Add(nowyKlient);
                }

                nowaRezerwacja.Klient = nowyKlient;
                noweUczestnictwo.Rezerwacja = nowaRezerwacja;
                db.Rezerwacja.Add(nowaRezerwacja);
                db.Uczestnictwo.Add(noweUczestnictwo);
                db.SaveChanges();
                db.Dispose();
                db = new bazaEntities();

                return 1;
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
    }
}