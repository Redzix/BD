using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.View;

namespace BD.Controller
{
    class RezygnacjaController
    {
        private RezygnacjaView _view;
        private bazaEntities db;

        public RezygnacjaController(RezygnacjaView view)
        {
            _view = view;
            db = new bazaEntities();
        }                  

        public int Oblicz(string numerRezerwacji,string uzytkownik)
        {
            try
            {
                int numer = int.Parse(_view.tb_numerRezerwacji.Text);

                var query = (from uczestnictwo in db.Uczestnictwo
                             where uczestnictwo.numer_rezerwacji == numer && uczestnictwo.Rezerwacja.Klient_pesel.Equals(uzytkownik)
                             select new
                             {
                                 nazwa = uczestnictwo.Rezerwacja.Wycieczka.nazwa,
                                 cenaRezerwacji = uczestnictwo.cena_rezerwacji,
                                 liczbaOsob = uczestnictwo.liczba_osob
                             }).FirstOrDefault();

                _view.tb_nazwaWycieczki.Text = query.nazwa;
                _view.tb_liczbaOsob.Text = query.liczbaOsob.ToString();

                if (query.liczbaOsob < int.Parse(_view.tb_liczbaRezygnujacychOsob.Text))
                {
                    return 0;                   
                }
                else if (query.liczbaOsob == int.Parse(_view.tb_liczbaRezygnujacychOsob.Text))
                {
                    return -1;
                }
                else
                {
                    var cenaPoRezygnacji = query.cenaRezerwacji - (int.Parse(_view.tb_liczbaRezygnujacychOsob.Text) * (query.cenaRezerwacji / query.liczbaOsob));
                    _view.tb_cenaPoRezygnacji.Text = cenaPoRezygnacji.ToString();
                    return 1;
                }
            }
            catch (FormatException exception)
            {
                return -2;
            }
            catch (Exception exc)
            {
                return -3;
            }
        }

        public int Zapisz(string numerRezerwacji,string uzytkownik)
        {
            try
            {
                int numer = int.Parse(numerRezerwacji);
                            
                var uczestnictwo = (from uc in db.Uczestnictwo
                                    where uc.numer_rezerwacji == numer && uc.Rezerwacja.Klient_pesel.Equals(uzytkownik)
                                    select uc).FirstOrDefault();

                if ((int.Parse(_view.tb_liczbaOsob.Text) - int.Parse(_view.tb_liczbaRezygnujacychOsob.Text)) == 0)
                {
                    var usun = (from rezerw in db.Rezerwacja
                                      where rezerw.numer_rezerwacji == numer && rezerw.Klient_pesel.Equals(uzytkownik)
                                select rezerw).FirstOrDefault();

                    db.Rezerwacja.Remove(usun);
                }
                else
                {
                    uczestnictwo.cena_rezerwacji = decimal.Parse(_view.tb_cenaPoRezygnacji.Text);
                    uczestnictwo.liczba_osob = int.Parse(_view.tb_liczbaOsob.Text) - int.Parse(_view.tb_liczbaRezygnujacychOsob.Text);
                }

                try
                {
                    db.SaveChanges();
                    return 1;
                }
                catch (Exception exception)
                {
                    return -1;
                }
            }
            catch (FormatException exception)
            {
                return 0;
            }
        }
    }
}
