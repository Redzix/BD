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
        private RezerwacjaView _view;
        private bazaEntities db;
        private int sprawdzCzyTaSama; 

        public RezerwacjaController(RezerwacjaView view)
        {
            _view = view;
            db = new bazaEntities();
        }

        public int PobierzNazweWycieczki(string numerRezerwacji)
        {
            bazaEntities db = new bazaEntities();

            try
            {
                int numer = int.Parse(numerRezerwacji);
                sprawdzCzyTaSama = numer;

                var rez = (from rezerwacja in db.Rezerwacja
                           where rezerwacja.numer_rezerwacji == numer
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

        public int ZaplacRezerwacje(string numerRezerwacji)
        {
            try
            {
                int numer = int.Parse(_view.tb_numerRezerwacji.Text);

                if(sprawdzCzyTaSama == numer)
                {
                    var rez = (from rezerwacja in db.Rezerwacja
                           where rezerwacja.numer_rezerwacji == numer
                           select rezerwacja).FirstOrDefault();

                    var uczest = (from uczestnictwo in db.Uczestnictwo
                              where uczestnictwo.numer_rezerwacji == numer
                              select uczestnictwo).FirstOrDefault();
                    try
                    {
                        decimal kwota = decimal.Parse(_view.tb_kwotaZaplacona.Text);

                        if ((kwota + rez.zaliczka) == uczest.cena_rezerwacji)
                        {
                            rez.zaliczka += kwota;
                            rez.stan = true;
                            db.SaveChanges();
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

        public int DodajRezerwacje(int idWycieczki)
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
                    Klient_pesel = nowyKlient.pesel
                };

                var noweUczestnictwo = new Uczestnictwo
                {
                    liczba_osob = nowaRezerwacja.liczba_osob,
                    numer_rezerwacji = nowaRezerwacja.numer_rezerwacji,
                    cena_rezerwacji = cenaRezerwacji * nowaRezerwacja.liczba_osob
                };
                nowaRezerwacja.Klient = nowyKlient;
                noweUczestnictwo.Rezerwacja = nowaRezerwacja;

                var czyKlientIstnieje = (from czyIstnieje in db.Klient
                                         where czyIstnieje.pesel.Equals(nowyKlient.pesel)
                                         select czyIstnieje).FirstOrDefault();

                if (czyKlientIstnieje == null)
                {
                    db.Klient.Add(nowyKlient);
                }

                db.Rezerwacja.Add(nowaRezerwacja);
                db.Uczestnictwo.Add(noweUczestnictwo);
                db.SaveChanges();

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
