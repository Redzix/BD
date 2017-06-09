using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.View;
using System.Windows.Forms;

namespace BD.Controller
{
    class KierowcaController
    {
        private KierowcaView _view;
        private bazaEntities db;

        public KierowcaController(KierowcaView view)
        {
            _view = view;
            db = new bazaEntities();
        }

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
             
            }catch(Exception exception)
            {
                return 0;
            }
        }  

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
                        _view.lv_pojazdy.Items[_view.lv_pojazdy.SelectedItems[0].Index].SubItems[4].Text = "Awaria";
                        return 1;
                    }
                    catch (Exception exception)
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
                        _view.lv_pojazdy.Items[_view.lv_pojazdy.SelectedItems[0].Index].SubItems[4].Text = "Sprawny";
                        return 2;
                    }
                    catch (Exception exception)
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
