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
    /// Kontroler opinii
    /// </summary>
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
        public int DodajOpinie(int numerRezerwacji,int ocena, string opis,string uzytkownik)
        {
             try
            {
                var query = (from uczestnictwo in db.Uczestnictwo
                             where uczestnictwo.numer_rezerwacji == numerRezerwacji && uczestnictwo.Rezerwacja.Klient_pesel.Equals(uzytkownik)
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
            catch (FormatException)
            {
                return 0;
            }
            catch (Exception)
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
        public int PobierzNazweWycieczki(int numerRezerwacji, string uzytkownik)
        {
            try
            {
                var query = (from uczestnictwo in db.Uczestnictwo
                             where uczestnictwo.numer_rezerwacji == numerRezerwacji && uczestnictwo.Rezerwacja.Klient_pesel.Equals(uzytkownik)
                             select uczestnictwo.Rezerwacja.Wycieczka.nazwa).FirstOrDefault();

                if (query == null)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            catch (FormatException)
            {
                return 0;
            }
        }
        /// <summary>
        /// Metoda wypełniająca nazwę wycieczki dla dokonanych rezerwacji
        /// </summary>
        /// <returns>True jeśli się uda</returns>
        public bool WypelnijRezerwacje(string pesel)
        {
            try
            {
                using (var db = new bazaEntities())
                {
                    Dictionary<int, string> values = new Dictionary<int, string>();
                    var query = from rezerwacja in db.Rezerwacja
                                where rezerwacja.Klient_pesel.Equals(pesel)
                                select new
                                {
                                    rezerwacja,
                                    rezerwacja.Wycieczka.nazwa
                                };

                    foreach (var row in query)
                    {
                        values.Add(row.rezerwacja.numer_rezerwacji, row.nazwa);
                    }
                    this._view.cb_rezerwacje.DataSource = new BindingSource(values, null);
                    this._view.cb_rezerwacje.DisplayMember = "Value";
                    this._view.cb_rezerwacje.ValueMember = "Key";
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
