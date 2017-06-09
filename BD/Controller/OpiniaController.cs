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
        private OpiniaView _view;
        private bazaEntities db;

        public OpiniaController(OpiniaView view)
        {
            _view = view;
            db = new bazaEntities();
        }

        public int DodajOpinie(string numerRezerwacji,int ocena, string opis,string uzytkownik)
        {
             try
            {
                int numer = int.Parse(numerRezerwacji);

                var query = (from uczestnictwo in db.Uczestnictwo
                             where uczestnictwo.numer_rezerwacji == numer && uczestnictwo.Rezerwacja.Klient_pesel.Equals(uzytkownik)
                             select uczestnictwo.id_uczestnictwo).FirstOrDefault();

                var opinia = new Opinia
                {
                    opis = opis,
                    ocena = ocena,
                    id_uczestnictwo = query
                };

                db.Opinia.Add(opinia);
                db.SaveChanges();

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
