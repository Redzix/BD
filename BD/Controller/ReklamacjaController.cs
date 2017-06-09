using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.View;
using System.Windows.Forms;

namespace BD.Controller
{
    class ReklamacjaController
    {
        private ReklamacjaView _view;
        private bazaEntities db;
        private int sprawdzCzyTaSama;

        public ReklamacjaController(ReklamacjaView view)
        {
            _view = view;
            db = new bazaEntities();
        }

        public bool PobierzReklamacje(string uzytkownik)
        {

            var pobierz = from reklamacja in db.Reklamacja
                          where reklamacja.Uczestnictwo.Rezerwacja.Klient.pesel.Equals(uzytkownik)
                          orderby reklamacja.numer_reklamacji
                          select reklamacja.numer_reklamacji;

            if (pobierz == null)
            {
                _view.lv_reklamacje.Items.Add("Brak reklamacji");
                return false;
            }
            else
            {
                foreach (var rek in pobierz)
                {
                    ListViewItem reklamacja = new ListViewItem(rek.ToString());
                    reklamacja.Tag = rek.ToString();
                    _view.lv_reklamacje.Items.Add(reklamacja);
                }
                return true;
            }
        }

        public int PobierzNazweWycieczki(string numerRezerwacji,string uzytkownik)
        {
            try
            {
                int numer = int.Parse(numerRezerwacji);

                var query = (from uczestnictwo in db.Uczestnictwo
                             where uczestnictwo.numer_rezerwacji == numer && uczestnictwo.Rezerwacja.Klient_pesel.Equals(uzytkownik)
                             select uczestnictwo.Rezerwacja.Wycieczka.nazwa).FirstOrDefault();

                if (query == null)
                {
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
            catch (Exception exception)
            {
                return -2;
            }
        }

        public int PobierzInformacjeOReklamacji(string numerReklamacji,string uzytkownik)
        {
            try
            {
                int numer = int.Parse(numerReklamacji);

                var query = (from reklamacja in db.Reklamacja
                             where reklamacja.numer_reklamacji == numer && reklamacja.Uczestnictwo.Rezerwacja.Klient_pesel.Equals(uzytkownik)
                             select new
                             {
                                 numer = reklamacja.numer_reklamacji,
                                 nazwa = reklamacja.Uczestnictwo.Rezerwacja.Wycieczka.nazwa,
                                 stan = reklamacja.stan,
                                 dataOdjazdu = reklamacja.Uczestnictwo.Rezerwacja.Wycieczka.data_wyjazdu,
                                 dataPowrotu = reklamacja.Uczestnictwo.Rezerwacja.Wycieczka.data_powrotu,
                                 opis = reklamacja.opis
                             }).FirstOrDefault();

                // Dodanie wartości parametrów do opisu znajdującego się w texboxie
                _view.rtb_reklamacja.Text =
                    "Numer reklamacji: " + query.numer +
                    "\nStan: " + ((bool.Parse(query.stan.ToString())) ? "Rozpatrzona" : "Nierpozatrzona") +
                    "\nNazwa wycieczki: " + query.nazwa +
                    "\nData wycieczki: " + query.dataOdjazdu + "--" + query.dataPowrotu +
                    "\nOpis: " + query.opis;

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

        public int DodajReklamacje(string numerRezerwacji,string uzytkownik)
        {
            try
            {
                int numer = int.Parse(numerRezerwacji);

                if (sprawdzCzyTaSama == numer)
                {

                    var uczestnictwo = (from uc in db.Uczestnictwo
                                        where uc.numer_rezerwacji == numer && uc.Rezerwacja.Klient_pesel.Equals(uzytkownik)
                                        select uc).FirstOrDefault();

                    var reklamacja = new Reklamacja
                    {
                        opis = _view.tb_opis_reklamacji.Text,
                        stan = false,
                        Kierownik_pesel = "brak",
                        id_uczestnictwo = uczestnictwo.id_uczestnictwo
                    };
                    db.Reklamacja.Add(reklamacja);

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
