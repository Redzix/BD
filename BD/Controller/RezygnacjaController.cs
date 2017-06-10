using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.View;

namespace BD.Controller
{
    class RezygnacjaController
    {
        /// <summary>
        /// Obiekt widoku.
        /// </summary>
        private RezygnacjaView _view;

        /// <summary>
        /// Model danych.
        /// </summary>
        private bazaEntities db;

        /// <summary>
        /// Konstruktor tworzący obiekt pobranego widoku oraz nowy model danych.
        /// </summary>
        /// <param name="view">Referencja do widoku, który controller ma obsługiwac</
        public RezygnacjaController(RezygnacjaView view)
        {
            _view = view;
            db = new bazaEntities();
        }

        /// <summary>
        /// Metoda obliczająca nową kwotę rezerwacji po wprowadzonych zmianach i sprwdzająca poprawność danych
        /// </summary>
        /// <param name="numerRezerwacji">Numer rezerwacji, której dotyczy opinia.</param>
        /// <param name="uzytkownik">Pesel użytkownika, który zamawiał wycieczkę</param>
        /// <returns>Zwraca odpowiednie informacje o powodzeniu operacji.</returns>
        public int Oblicz(string numerRezerwacji,string uzytkownik)
        {
            try
            {
                int numer = int.Parse(_view.tb_numerRezerwacji.Text);

                var query = (from uczestnictwo in db.Uczestnictwo
                             where uczestnictwo.numer_rezerwacji == numer && uczestnictwo.Rezerwacja.Klient_pesel.Equals(uzytkownik)
                             select new
                             {
                                 nazwa = uczestnictwo.Rezerwacja.Wycieczka.nazwa,
                                 cenaRezerwacji = uczestnictwo.cena_rezerwacji,
                                 liczbaOsob = uczestnictwo.liczba_osob
                             }).FirstOrDefault();

                _view.tb_nazwaWycieczki.Text = query.nazwa;
                _view.tb_liczbaOsob.Text = query.liczbaOsob.ToString();

                if (query.liczbaOsob < int.Parse(_view.tb_liczbaRezygnujacychOsob.Text))
                {
                    return 0;                   
                }
                else if (query.liczbaOsob == int.Parse(_view.tb_liczbaRezygnujacychOsob.Text))
                {
                    return -1;
                }
                else
                {
                    var cenaPoRezygnacji = query.cenaRezerwacji - (int.Parse(_view.tb_liczbaRezygnujacychOsob.Text) * (query.cenaRezerwacji / query.liczbaOsob));
                    _view.tb_cenaPoRezygnacji.Text = cenaPoRezygnacji.ToString();
                    return 1;
                }
            }
            catch (FormatException exception)
            {
                return -2;
            }
            catch (Exception exc)
            {
                return -3;
            }
        }

        /// <summary>
        /// Metoda zapisująca zmiany do bazy danych.
        /// </summary>
        /// <param name="numerRezerwacji">Numer rezerwacji, której dotyczy opinia.</param>
        /// <param name="uzytkownik">Pesel użytkownika, który zamawiał wycieczkę</param>
        /// <returns>Zwraca odpowiednie informacje o powodzeniu operacji.</returns>
        public int Zapisz(string numerRezerwacji,string uzytkownik)
        {
            try
            {
                int numer = int.Parse(numerRezerwacji);
                            
                var uczestnictwo = (from uc in db.Uczestnictwo
                                    where uc.numer_rezerwacji == numer && uc.Rezerwacja.Klient_pesel.Equals(uzytkownik)
                                    select uc).FirstOrDefault();

                if ((int.Parse(_view.tb_liczbaOsob.Text) - int.Parse(_view.tb_liczbaRezygnujacychOsob.Text)) == 0)
                {
                    var usun = (from rezerw in db.Rezerwacja
                                      where rezerw.numer_rezerwacji == numer && rezerw.Klient_pesel.Equals(uzytkownik)
                                select rezerw).FirstOrDefault();

                    db.Rezerwacja.Remove(usun);
                }
                else
                {
                    uczestnictwo.cena_rezerwacji = decimal.Parse(_view.tb_cenaPoRezygnacji.Text);
                    uczestnictwo.liczba_osob = int.Parse(_view.tb_liczbaOsob.Text) - int.Parse(_view.tb_liczbaRezygnujacychOsob.Text);
                }

                try
                {
                    db.SaveChanges();
                    db.Dispose();
                    db = new bazaEntities();
                    return 1;
                }
                catch (Exception exception)
                {
                    return -1;
                }
            }
            catch (FormatException exception)
            {
                return 0;
            }
        }
    }
}
