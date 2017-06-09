using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.View;

namespace BD.Controller
{
    class PanelPracowniczyController
    {
        private PanelPracowniczyView _view;
        private bazaEntities db;

        public PanelPracowniczyController(PanelPracowniczyView view)
        {
            _view = view;
            db = new bazaEntities();
        }

        public int SprawdzDaneLogowania(string login, string haslo)
        {
            try
            {
                var pobierz = (from panel in db.Panel_pracowniczy
                               where panel.login.Equals(login) && panel.login.Equals(haslo)
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
                        KierownikView kierownik = new KierownikView(pobierz.Kierownik_pesel);
                        kierownik.Closed += (s, args) => _view.Close();
                        kierownik.ShowDialog();

                    }
                    else if (pobierz.stopien.Equals("klient"))
                    {
                        _view.Hide();
                        KlientView klient = new KlientView(pobierz.Klient_pesel);
                        klient.Closed += (s, args) => _view.Close();
                        klient.ShowDialog();

                    }
                    else if (pobierz.stopien.Equals("kierowca"))
                    {
                        _view.Hide();
                        KierowcaView kierowca = new KierowcaView(pobierz.Kierowca_pesel);
                        kierowca.Closed += (s, args) => _view.Close();
                        kierowca.ShowDialog();

                    }
                    else if (pobierz.stopien.Equals("pilot"))
                    {
                        _view.Hide();
                        PilotView pilot = new PilotView(pobierz.Pilot_pesel);
                        pilot.Closed += (s, args) => _view.Close();
                        pilot.ShowDialog();
                    }
                    else
                    {
                        return -1;
                    }
                    return 1;
                }
            }catch(Exception exception)
            {
                return -2;
            }
        }
    }
}
