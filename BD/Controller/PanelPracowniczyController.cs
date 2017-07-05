using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.View;

namespace BD.Controller
{
    /// <summary>
    /// Kontroler logowania
    /// </summary>
    class PanelPracowniczyController
    {
        /// <summary>
        /// Obiekt widoku. 
        /// </summary>
        private PanelPracowniczyView _view;

        /// <summary>
        /// Model danych.
        /// </summary>
        private bazaEntities db;

        /// <summary>
        /// Konstruktor tworzący obiekt pobranego widoku oraz nowy model danych.
        /// </summary>
        /// <param name="view">Referencja do widoku, który controller ma obsługiwac</param>
        public PanelPracowniczyController(PanelPracowniczyView view)
        {
            _view = (PanelPracowniczyView)view;
        }

        /// <summary>
        /// Metoda sprwdzająca poprawność wprowadzonych danych logowania, sprawdza uprawnienia i
        /// tworzy odpowiednie widoki.
        /// </summary>
        /// <param name="login">Nazwa użytkownika pobrana z widoku</param>
        /// <param name="haslo">Hasło użytkownika pobrane z widoku.</param>
        /// <returns>Zwraca odpowiednie informacje o powodzeniu operacji.</returns>
        public int SprawdzDaneLogowania(string login, string haslo)
        {
            db = new bazaEntities();
            try
            {
                var pobierz = (from panel in db.Panel_pracowniczy
                               where panel.login.Equals(login) && panel.haslo.Equals(haslo)
                               select panel).FirstOrDefault();

                if (pobierz == null)
                {
                    return 0;
                }
                else
                {
                        if (pobierz.stopien.Equals("kierownik"))
                        {
                            _view.Hide();
                            KierownikView kierownik = new KierownikView(pobierz.Kierownik);
                            kierownik.Closed += (s, args) => _view.Close();
                            kierownik.ShowDialog();

                        }
                        else if (pobierz.stopien.Equals("klient"))
                        {
                            _view.Hide();
                            KlientView klient = new KlientView(pobierz.Klient);
                            klient.Closed += (s, args) => _view.Close();
                            klient.ShowDialog();

                        }
                        else if (pobierz.stopien.Equals("kierowca"))
                        {
                            _view.Hide();
                            KierowcaView kierowca = new KierowcaView(pobierz.Kierowca);
                            kierowca.Closed += (s, args) => _view.Close();
                            kierowca.ShowDialog();

                        }
                        else if (pobierz.stopien.Equals("pilot"))
                        {
                            _view.Hide();
                            PilotView pilot = new PilotView(pobierz.Pilot);
                            pilot.Closed += (s, args) => _view.Close();
                            pilot.ShowDialog();
                        }
                        else
                        {
                            return -1;
                        }
                        return 1;            
                }
            }catch(Exception)
            {
                return -2;
            }
        }
    }
}
