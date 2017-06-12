using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.View;
using System.Windows.Forms;

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
            _view.lv_pilot.Items.Clear();

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
                _view.lv_pilot.Items.Add("Brak wycieczek.");
                return false;
            }
            else
            {
                foreach(var pil in query)
                {
                    ListViewItem pilot = new ListViewItem(pil.wycieczka);
                    pilot.Tag = pil.wycieczkaId;
                    pilot.SubItems.Add(pil.dataOdjazdu.ToString());
                    pilot.SubItems.Add(pil.dataPowrotu.ToString());
                    pilot.SubItems.Add(pil.pojazd);
                    pilot.SubItems.Add(pil.kierowca);
                    _view.lv_pilot.Items.Add(pilot);
                }
                return true;
            }     
        }
    }
}
