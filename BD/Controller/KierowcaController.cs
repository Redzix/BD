using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.View;
using System.Windows.Forms;

namespace BD.Controller
{
    /// <summary>
    /// Kontroler kierowcy
    /// </summary>
    class KierowcaController

    {   /// <summary>
        /// Obiekt widoku.
        /// </summary>
        private KierowcaView _view;

        /// <summary>
        /// Model danych.
        /// </summary>
        private bazaEntities db;

        /// <summary>
        /// Konstruktor tworzący obiekt pobranego widoku oraz nowy model danych.
        /// </summary>
        /// <param name="view">Referencja do widoku, który controller ma obsługiwac</param>
        public KierowcaController(KierowcaView view)
        {
            _view = (KierowcaView)view;
            db = new bazaEntities();
        }

        /// <summary>
        /// Metoda pobierająca pojazdy z bazy danych oraz dodająca je do widoku.
        /// </summary>
        /// <returns>Zwraca odpowiednie informacje o powodzeniu operacji.</returns>
        public int PobierzPojazdy()
        {
            _view.lv_pojazdy.Items.Clear();

            try
            {
                var query = from pojazd in db.Pojazd
                            select pojazd;

                if (query == null)
                {
                    _view.lv_pojazdy.Items.Add("Brak pojazów");
                    return -1;
                }
                else
                {
                    foreach (Pojazd poj in query)
                    {
                        ListViewItem pojazd = new ListViewItem(poj.numer_rejestracyjny);
                        pojazd.Tag = poj.numer_rejestracyjny;
                        pojazd.SubItems.Add((bool)poj.dostepny ? ("Dostępny") : ("Niedostępny"));
                        pojazd.SubItems.Add(poj.marka);
                        pojazd.SubItems.Add(poj.pojemnosc.ToString());
                        pojazd.SubItems.Add((bool)poj.stan ? ("Sprawny") : ("Awaria"));
                        _view.lv_pojazdy.Items.Add(pojazd);
                    }

                    return 1;
                }
             
            }catch(Exception)
            {
                return 0;
            }
        }


        /// <summary>
        /// Metoda zapisuuje do bazy danych zmiany dla wybranego wcześniej pojazdu.
        /// </summary>
        /// <param name="numerRejestracyjny">Numer rejestracyjny edytowanego pojazdu.</param>
        /// <returns>Zwraca odpowiednie informacje o powodzeniu operacji.</returns>
        public int ZapiszZmiany(string numerRejestracyjny)
        {

            _view.lv_pojazdy.Items.Clear();

            if (_view.rb_awaria.Checked)
            {
                var query = (from pojazd in db.Pojazd
                             where pojazd.numer_rejestracyjny.Equals(numerRejestracyjny)
                             select pojazd).FirstOrDefault();

                if (query == null)
                {
                    return -1;
                }
                else
                {
                    query.stan = false;

                    try
                    {
                        db.SaveChanges();
                        db.Dispose();
                        db = new bazaEntities();
                        return 1;
                    }
                    catch (Exception)
                    {
                        return 0;
                    }
                }
            }
            else if (_view.rb_sprawny.Checked)
            {
                var query = (from pojazd in db.Pojazd
                             where pojazd.numer_rejestracyjny.Equals(numerRejestracyjny)
                             select pojazd).FirstOrDefault();

                if (query == null)
                {
                    return -2;
                }
                else
                {
                    query.stan = true;

                    try
                    {
                        db.SaveChanges();
                        return 2;
                    }
                    catch (Exception)
                    {
                        return 0;
                    }                  
                }
            }
            else
            {
                return -3;
            }
        }
    }
}
