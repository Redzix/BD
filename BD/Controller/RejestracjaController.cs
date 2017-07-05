using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.View;

namespace BD.Controller
{
    /// <summary>
    /// Kontroler rejestracji użytkownika
    /// </summary>
    class RejestracjaController
    {
        /// <summary>
        /// Obiekt widoku. 
        /// </summary>
        private RejestracjaView _view;

        /// <summary>
        /// Model danych.
        /// </summary>
        private bazaEntities db;

        /// <summary>
        /// Konstruktor tworzący obiekt pobranego widoku oraz nowy model danych.
        /// </summary>
        /// <param name="view">Referencja do widoku, który controller ma obsługiwac</param>
        public RejestracjaController(RejestracjaView view)
        {
            _view = (RejestracjaView)view;
            db = new bazaEntities();
        }

        /// <summary>
        /// Metoda sprwdzająca czy klient o danym peselu juz istnieje w systemie.
        /// </summary>
        /// <param name="pesel">Pesel wprowadzony przy rejestracji</param>
        /// <returns>Zwraca odpowiednie informacje o powodzeniu operacji.</returns>
        public bool SprawdzCzyPeselIstnieje(string pesel)
        {
            var szukaj = (from klient in db.Klient
                          where klient.pesel.Equals(pesel)
                          select klient).FirstOrDefault();

            if (szukaj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Metoda sprwdzająca czy dany login juz istnieje w systemie.
        /// </summary>
        /// <param name="login">Nazwa użytkownika pobrana z widoku</param>
        /// <returns>Zwraca odpowiednie informacje o powodzeniu operacji.</returns>
        public bool SprawdzCzyLoginIstnieje(string login)
        {
            var szukaj = (from panel in db.Panel_pracowniczy
                          where panel.login.Equals(login)
                          select panel).FirstOrDefault();

            if(szukaj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Metoda tworząca nowego użytkownika w systemie
        /// </summary>
        /// <returns>Zwraca odpowiednie informacje o powodzeniu operacji.</returns>
        public bool UtworzNowegoUzytkownika()
        {
            var klient = new Klient
            {
                pesel = _view.tb_pesel.Text,
                imie = _view.tb_imie.Text,
                nazwisko = _view.tb_nazwisko.Text,
                ulica = _view.tb_adres.Text,
                miejscowosc = _view.tb_miejscowosc.Text
            };

            var daneLogowania = new Panel_pracowniczy
            {
                login = _view.tb_login.Text,
                haslo = _view.tb_haslo.Text,
                stopien = "klient"
            };

            daneLogowania.Klient = klient;
            db.Klient.Add(klient);
            db.Panel_pracowniczy.Add(daneLogowania);

            try
            {
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }

        }
    }
}
