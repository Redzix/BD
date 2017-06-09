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
        private PojazdView _view;
        private bazaEntities db;

        public PojazdController(PojazdView view)
        {
            _view = view;
            db = new bazaEntities();
        }

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
