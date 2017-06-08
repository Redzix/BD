using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.Controller
{
    class OpiniaController
    {
        public int DodajOpinie(string numerRezerwacji,int ocena, string opis)
        {
            bazaEntities db = new bazaEntities();

            try
            {
                int numer = int.Parse(numerRezerwacji);

                var query = (from uczestnictwo in db.Uczestnictwo
                             where uczestnictwo.numer_rezerwacji == numer
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

        public string PobierzNazweWycieczki(string numerRezerwacji)
        {
            bazaEntities db = new bazaEntities();

            try
            {
                int numer = int.Parse(numerRezerwacji);

                var query = (from uczestnictwo in db.Uczestnictwo
                             where uczestnictwo.numer_rezerwacji == numer
                             select uczestnictwo.Rezerwacja.Wycieczka.nazwa).FirstOrDefault();

                if (query == null)
                {
                    return "-1";
                }
                else
                {
                    return query;
                }
            }
            catch (FormatException exception)
            {
                return "0";
            }
        }
    }
}
