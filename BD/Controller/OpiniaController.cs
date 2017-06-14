using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.View;

namespace BD.Controller
{
    class OpiniaController
    {
        /// <summary>
        /// Obiekt widoku.
        /// </summary>
        private OpiniaView _view;

        /// <summary>
        /// Model danych.
        /// </summary>
        private bazaEntities db;


        /// <summary>
        /// Konstruktor tworzący obiekt pobranego widoku oraz nowy model danych.
        /// </summary>
        /// <param name="view">Referencja do widoku, który controller ma obsługiwac</param>
        public OpiniaController(OpiniaView view)
        {
            _view = (OpiniaView)view;
            db = new bazaEntities();
        }

        /// <summary>
        /// Metoda odpowiedzialna za dodawanie opiniii do bazy dacych.
        /// </summary>
        /// <param name="numerRezerwacji">Numer rezerwacji, której dotyczy opinia.</param>
        /// <param name="ocena">Ocena wycieczki</param>
        /// <param name="opis">Opis wycieczki</param>
        /// <param name="uzytkownik">Pesel użytkownika, który zamawiał wycieczkę</param>
        /// <returns>Zwraca odpowiednie informacje o powodzeniu operacji.</returns>
        public int DodajOpinie(string numerRezerwacji,int ocena, string opis,string uzytkownik)
        {
             try
            {
                int numer = int.Parse(numerRezerwacji);

                var query = (from uczestnictwo in db.Uczestnictwo
                             where uczestnictwo.numer_rezerwacji == numer && uczestnictwo.Rezerwacja.Klient_pesel.Equals(uzytkownik)
                             select uczestnictwo).FirstOrDefault();

                var opinia = new Opinia
                {
                    opis = opis,
                    ocena = ocena,
                };

                opinia.Uczestnictwo = query;
                db.Opinia.Add(opinia);
                db.SaveChanges();
                db.Dispose();
                db = new bazaEntities();
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
        /// Metoda odpowiedzialna pobieranie nazwy wycieczki w celu uzupełnienia formularza.
        /// </summary>
        /// <param name="numerRezerwacji">Numer rezerwacji, której dotyczy opinia.</param>
        /// <param name="uzytkownik">Pesel użytkownika, który zamawiał wycieczkę</param>
        /// <returns>Zwraca odpowiednie informacje o powodzeniu operacji.</returns>
        public int PobierzNazweWycieczki(string numerRezerwacji, string uzytkownik)
        {
            try
            {
                int numer = int.Parse(numerRezerwacji);

                var query = (from uczestnictwo in db.Uczestnictwo
                             where uczestnictwo.numer_rezerwacji == numer && uczestnictwo.Rezerwacja.Klient_pesel.Equals(uzytkownik)
                             select uczestnictwo.Rezerwacja.Wycieczka.nazwa).FirstOrDefault();

                if (query == null)
                {
                    _view.tb_nazwaWycieczki.Text = "Brak rezerwacji";
                    return -1;
                }
                else
                {
                    _view.tb_nazwaWycieczki.Text = query;
                    return 1;
                }
            }
            catch (FormatException exception)
            {
                return 0;
            }
        }
    }
}
