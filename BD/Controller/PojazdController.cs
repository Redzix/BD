using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.View;

namespace BD.Controller
{
    class PojazdController
    {
        /// <summary>
        /// Obiekt widoku.
        /// </summary>
        private PojazdView _view;

        /// <summary>
        /// Model danych.
        /// </summary>
        private bazaEntities db;
        
        /// <summary>
        /// Konstruktor tworzący obiekt pobranego widoku oraz nowy model danych.
        /// </summary>
        /// <param name="view">Referencja do widoku, który controller ma obsługiwac</param>
        public PojazdController(PojazdView view)
        {
            _view = view;
            db = new bazaEntities();
        }

        /// <summary>
        /// Metoda odpowiedzialna za dodawanie nowego pojazdu do bazy danych wraz z wszystimi informacjami o nim.
        /// </summary>
        /// <returns>Zwraca odpowiednie informacje o powodzeniu operacji.</returns>
        public int DodajPojazd()
        {
            try
            {
                int pojemnosc = int.Parse(_view.tb_pojemnosc.Text);

                var sprawdz = (from poj in db.Pojazd
                               where poj.numer_rejestracyjny.Equals(_view.tb_numer_rejestracyjny.Text)
                               select poj).FirstOrDefault();
                if (sprawdz == null)
                {
                    var pojazd = new Pojazd
                    {
                        numer_rejestracyjny = _view.tb_numer_rejestracyjny.Text,
                        dostepny = true,
                        marka = _view.tb_marka.Text,
                        stan = true,
                        pojemnosc = pojemnosc
                    };

                    db.Pojazd.Add(pojazd);
                    db.SaveChanges();
                    db.Dispose();
                    db = new bazaEntities();
                    return 1;
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
            catch (Exception exception)
            {
                return -1;
            }
        }
    }
}
