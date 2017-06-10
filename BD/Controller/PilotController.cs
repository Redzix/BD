using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.View;

namespace BD.Controller
{
    class PilotController
    {
        /// <summary>
        /// Obiekt widoku.
        /// </summary>
        private PilotView _view;

        /// <summary>
        /// Model danych.
        /// </summary>
        private bazaEntities db;

        /// <summary>
        /// Konstruktor tworzący obiekt pobranego widoku oraz nowy model danych.
        /// </summary>
        /// <param name="view">Referencja do widoku, który controller ma obsługiwac</param>
        public PilotController(PilotView view)
        {
            _view = view;
            db = new bazaEntities();
        }

        /// <summary>
        /// Metoda pobierająca informacje o wycieczkach, które obsługuje aktualnie wybrany pilot.
        /// </summary>
        /// <param name="uzytkownik">Pesel aktualnie zalogowanego użytkownika.</param>
        /// <returns>Zwraca informacje o poprawnym pobraniu wycieczek.</returns>
        public bool PobierzWycieczki(string uzytkownik)
        {
            _view.dgv_tabelaPilot.AutoGenerateColumns = false;

            // Bindowanie odpowiednich kolumn bazy danych z kolumnami tabeli dgv_tabelaPilot
            _view.dgv_tabelaPilot.Columns["id_wycieczki"].DataPropertyName = "wycieczkaId";
            _view.dgv_tabelaPilot.Columns["Nazwa_wycieczki"].DataPropertyName = "wycieczka";
            _view.dgv_tabelaPilot.Columns["Data_wyjazdu"].DataPropertyName = "dataOdjazdu";
            _view.dgv_tabelaPilot.Columns["Data_powrotu"].DataPropertyName = "dataPowrotu";
            _view.dgv_tabelaPilot.Columns["Pojazd"].DataPropertyName = "pojazd";
            _view.dgv_tabelaPilot.Columns["Kierowca"].DataPropertyName = "kierowca";



            var query = from wycieczka in db.Wycieczka
                        where wycieczka.Pilot_pesel.Equals(uzytkownik)
                        join kierowca in db.Kierowca on wycieczka.Kierowca_pesel equals kierowca.pesel
                        select new
                        {
                            wycieczkaId = wycieczka.id_wycieczki,
                            wycieczka = wycieczka.nazwa,
                            dataOdjazdu = wycieczka.data_wyjazdu,
                            dataPowrotu = wycieczka.data_powrotu,
                            pojazd = wycieczka.Pojazd_numer_rejestracyjny,
                            kierowca = wycieczka.Kierowca.imie + " " + wycieczka.Kierowca.nazwisko
                        };

            if (query == null)
            {
                return false;
            }
            else
            {
                _view.dgv_tabelaPilot.DataSource = query.ToList();
                return true;
            }     
        }
    }
}
