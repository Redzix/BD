using BD.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD.Controller
{
    class KierownikController
    {
        object view;
        bazaEntities db;
        public KierownikController(object view)
        {
            this.view = view;
        }

        public bool LadujKatalog()
        {
            KierownikView kView = (KierownikView)view;
            kView.lv_wycieczki.Items.Clear();
            using (db = new bazaEntities())
            {
                var query = from katalog in db.Katalog
                            select new
                            {
                                katalog,
                                wycieczka = katalog.Wycieczka,
                                miejsce_z = katalog.Miejsce,
                                miejsce_do = katalog.Miejsce1
                            };

                foreach (var wyc in query)
                {
                    ListViewItem wycieczka = new ListViewItem(wyc.wycieczka.nazwa); //Miejsce
                    var roznica = wyc.wycieczka.data_wyjazdu.Value.Date - wyc.wycieczka.data_powrotu.Value.Date;

                    wycieczka.Tag = wyc.katalog.id_katalogu; //Ukryte ID
                    if (DateTime.Now.Date > wyc.wycieczka.data_powrotu.Value.Date)
                        wycieczka.BackColor = Color.LightCoral;
                    else if (DateTime.Now.Date >= wyc.wycieczka.data_wyjazdu.Value.Date && DateTime.Now.Date <=wyc.wycieczka.data_powrotu.Value.Date)
                        wycieczka.BackColor = Color.LightGreen;
           
                    wycieczka.SubItems.Add(String.Format("{0:dd.MM.yyyy}", (DateTime)wyc.wycieczka.data_wyjazdu)); //Data z
                    wycieczka.SubItems.Add(String.Format("{0:dd.MM.yyyy}", (DateTime)wyc.wycieczka.data_powrotu)); //data do
                    wycieczka.SubItems.Add(wyc.miejsce_z.miejscowosc); //miejsce od
                    wycieczka.SubItems.Add(wyc.miejsce_do.miejscowosc); //miejsce do
                    wycieczka.SubItems.Add(wyc.katalog.cena.ToString()); //cena
                    kView.lv_wycieczki.Items.Add(wycieczka);
                }
            }
            return true;
        }

        public bool DodajKatalog()
        {
            WycieczkaView wView = (WycieczkaView)view;
            try
            {
                string pilotPesel = ((KeyValuePair<string, string>)wView.cb_pilot.SelectedItem).Key;
                string kierowcaPesel = ((KeyValuePair<string, string>)wView.cb_kierowca.SelectedItem).Key;
                string pojazdRejestracja = ((KeyValuePair<string, string>)wView.cb_pojazd.SelectedItem).Key;
                int miejsceOdjazdu = int.Parse(((KeyValuePair<string, string>)wView.cb_odjazd.SelectedItem).Key);
                int miejscePrzyjazdu = int.Parse(((KeyValuePair<string, string>)wView.cb_docelowa.SelectedItem).Key);
                var nowaWycieczka = new Wycieczka
                {
                    nazwa = wView.tb_nazwa.Text,
                    data_powrotu = wView.tb_data_powrotu.Value,
                    data_wyjazdu = wView.tb_data_wyjazdu.Value,
                    opis = wView.tb_opis.Text,
                    Pilot_pesel = pilotPesel,
                    Kierowca_pesel = kierowcaPesel,
                    Pojazd_numer_rejestracyjny = pojazdRejestracja,
                };
                var nowyCennik = new Cennik
                {
                    cena = decimal.Parse(wView.tb_cena.Text),
                    okres_od = wView.tb_data_powrotu.Value,
                    okres_do = wView.tb_data_wyjazdu.Value

                };
                var nowyKatalog = new Katalog
                {
                    id_miejsca_odjazdu = miejsceOdjazdu,
                    id_miejsca_przyjazdu = miejscePrzyjazdu,
                    cena = decimal.Parse(wView.tb_cena.Text)
                };
                nowyKatalog.Cennik = nowyCennik;
                nowyKatalog.Wycieczka = nowaWycieczka;
                using (db = new bazaEntities())
                {
                    db.Katalog.Add(nowyKatalog);
                    db.Wycieczka.Add(nowaWycieczka);
                    db.Cennik.Add(nowyCennik);
                    db.SaveChanges();
                }
            } catch
            {
                return false;
            }
            return true;
        }
        public bool WypelnijKatalogBoxy()
        {
            WycieczkaView wView = (WycieczkaView)view;

            using (db = new bazaEntities())
            {
                var miejscowosci = from m in db.Miejsce orderby m.miejscowosc select m;
                var piloci = from m in db.Pilot orderby m.nazwisko select m;
                var kierowcy = from m in db.Kierowca orderby m.nazwisko select m;
                var pojazdy = from m in db.Pojazd orderby m.pojemnosc where m.stan == true select m;
                Dictionary<string, string> values = new Dictionary<string, string>();
                foreach (var row in miejscowosci)
                {
                    values.Add(row.id_miejsca.ToString(), row.miejscowosc + ", " + row.adres);
                }
                wView.cb_docelowa.DataSource = new BindingSource(values, null);
                wView.cb_docelowa.DisplayMember = "Value";
                wView.cb_docelowa.ValueMember = "Key";

                wView.cb_odjazd.DataSource = new BindingSource(values, null);
                wView.cb_odjazd.DisplayMember = "Value";
                wView.cb_odjazd.ValueMember = "Key";

                values.Clear();
                foreach (var row in piloci)
                {
                    values.Add(row.pesel, row.nazwisko + " " + row.imie);
                }

                wView.cb_pilot.DataSource = new BindingSource(values, null);
                wView.cb_pilot.DisplayMember = "Value";
                wView.cb_pilot.ValueMember = "Key";
                values.Clear();

                foreach (var row in kierowcy)
                {
                    values.Add(row.pesel, row.nazwisko + " " + row.imie);
                }

                wView.cb_kierowca.DataSource = new BindingSource(values, null);
                wView.cb_kierowca.DisplayMember = "Value";
                wView.cb_kierowca.ValueMember = "Key";
                values.Clear();

                foreach (var row in pojazdy)
                {
                    values.Add(row.numer_rejestracyjny, row.numer_rejestracyjny + " [poj: " + row.pojemnosc + "]");
                }

                wView.cb_pojazd.DataSource = new BindingSource(values, null);
                wView.cb_pojazd.DisplayMember = "Value";
                wView.cb_pojazd.ValueMember = "Key";
                values.Clear();
            }
            return true;
        }
        public bool WypelnijKatalogDoEdycji(int idKatalog)
        {
            WycieczkaView wView = (WycieczkaView)view;

            using (db = new bazaEntities())
            {
                var query = (from katalog in db.Katalog
                             where katalog.id_katalogu == idKatalog
                             select new
                             {
                                 katalog,
                                 wycieczka = katalog.Wycieczka,
                                 miejsce_z = katalog.Miejsce,
                                 miejsce_do = katalog.Miejsce1
                             }).FirstOrDefault();

                var docelowa = (from x in wView.cb_odjazd.Items.OfType<KeyValuePair<string, string>>()
                                where x.Key.Equals(query.katalog.id_miejsca_odjazdu.ToString())
                                select x).FirstOrDefault();

                var odjazd = (from x in wView.cb_docelowa.Items.OfType<KeyValuePair<string, string>>()
                              where x.Key.Equals(query.katalog.id_miejsca_przyjazdu.ToString())
                              select x).FirstOrDefault();

                var kierowca = (from x in wView.cb_kierowca.Items.OfType<KeyValuePair<string, string>>()
                                where x.Key.Equals(query.wycieczka.Kierowca_pesel)
                                select x).FirstOrDefault();

                var pilot = (from x in wView.cb_pilot.Items.OfType<KeyValuePair<string, string>>()
                             where x.Key.Equals(query.wycieczka.Pilot_pesel)
                             select x).FirstOrDefault();

                var pojazd = (from x in wView.cb_pojazd.Items.OfType<KeyValuePair<string, string>>()
                              where x.Key.Equals(query.wycieczka.Pojazd_numer_rejestracyjny)
                              select x).FirstOrDefault();

                try
                {
                    wView.cb_odjazd.SelectedItem = odjazd;
                    wView.cb_docelowa.SelectedItem = docelowa;
                    wView.cb_kierowca.SelectedItem = kierowca;
                    wView.cb_pilot.SelectedItem = pilot;
                    wView.cb_pojazd.SelectedItem = pojazd;
                    wView.tb_data_powrotu.Value = (DateTime)query.wycieczka.data_powrotu.Value;
                    wView.tb_data_wyjazdu.Value = (DateTime)query.wycieczka.data_wyjazdu.Value;
                    wView.tb_nazwa.Text = query.wycieczka.nazwa;
                    wView.tb_opis.Text = query.wycieczka.opis;
                    wView.tb_cena.Text = query.katalog.cena.Value.ToString();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
        public bool EdytujKatalog(int idKatalog)
        {
            WycieczkaView wView = (WycieczkaView)view;
            try
            {
                string pilotPesel = ((KeyValuePair<string, string>)wView.cb_pilot.SelectedItem).Key;
                string kierowcaPesel = ((KeyValuePair<string, string>)wView.cb_kierowca.SelectedItem).Key;
                string pojazdRejestracja = ((KeyValuePair<string, string>)wView.cb_pojazd.SelectedItem).Key;
                int miejsceOdjazdu = int.Parse(((KeyValuePair<string, string>)wView.cb_odjazd.SelectedItem).Key);
                int miejscePrzyjazdu = int.Parse(((KeyValuePair<string, string>)wView.cb_docelowa.SelectedItem).Key);
                using (db = new bazaEntities())
                {
                    var edit = (from katalog in db.Katalog
                                where katalog.id_katalogu == idKatalog
                                select new
                                {
                                    katalog,
                                    Wycieczka = katalog.Wycieczka,

                                }).FirstOrDefault();

                    edit.Wycieczka.Pilot_pesel = pilotPesel;
                    edit.Wycieczka.Kierowca_pesel = kierowcaPesel;
                    edit.Wycieczka.Pojazd_numer_rejestracyjny = pojazdRejestracja;
                    edit.Wycieczka.data_wyjazdu = wView.tb_data_wyjazdu.Value;
                    edit.Wycieczka.data_powrotu = wView.tb_data_powrotu.Value;

                    edit.katalog.id_miejsca_odjazdu = miejscePrzyjazdu;
                    edit.katalog.id_miejsca_przyjazdu = miejsceOdjazdu;
                    edit.katalog.cena = decimal.Parse(wView.tb_cena.Text);

                    edit.Wycieczka.opis = wView.tb_opis.Text;
                    edit.Wycieczka.nazwa = wView.tb_nazwa.Text;
                    db.SaveChanges();
                }
            } catch
            {
                return false;
            }

            return true;
        }

        public bool UsunKatalog(int idKatalog) {
            try
            {
                using (db = new bazaEntities())
                {
                    var idWyc = (from katalog in db.Katalog
                                where katalog.id_katalogu == idKatalog
                                select katalog.id_wycieczki).FirstOrDefault();
                    var wycieczka = new Wycieczka { id_wycieczki = (int)idWyc };
                    db.Entry(wycieczka).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idKatalog"></param>
        /// <returns></returns>
        public bool DodajPromocje(int idKatalog)
        {
            var wycieczka = (from katalog in db.Katalog
                            where katalog.id_katalogu == idKatalog
                            select katalog.Wycieczka).FirstOrDefault();
            var promocja = new Promocja
            {
                cena = decimal.Parse(((PromocjaView)view).tb_kwota.Text)
            };
            promocja.Wycieczka = wycieczka;
            try
            {
                db.Promocja.Add(promocja);
                db.SaveChanges();
            } catch
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Ładowanie ceny do textboxa z kwotą
        /// </summary>
        /// <param name="idKatalogu">Wiadomo</param>
        /// <returns>True, jeśli załadowało. False jeśli promocja nie istnieje</returns>
        public bool LadujPromocje(int idKatalogu)
        {
            using (db = new bazaEntities())
            {
                var idWyc = db.Katalog.Where(x => x.id_katalogu == idKatalogu).Select(x => x.id_wycieczki).FirstOrDefault();
                if (db.Promocja.Any(x => x.id_wycieczki == idWyc))
                {
                    ((PromocjaView)view).tb_kwota.Text = db.Promocja.Where(x => x.id_wycieczki == idWyc).Select(x => x.cena).FirstOrDefault().ToString();
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Edycja promocji
        /// </summary>
        /// <param name="idKatalogu">ID katalogu, który zawiera promocję w wycieczce do edycji</param>
        /// <returns>True, jeśli się uda. False jeśli nie</returns>
        public bool EdytujPromocje(int idKatalogu)
        {
            PromocjaView pView = ((PromocjaView)view);
            if (pView.tb_kwota.Text.Equals("") || pView.tb_kwota.Text.Equals("0"))
            {
                return this.UsunPromocje(idKatalogu);
            }
            else
            {
                try
                {
                    using (db = new bazaEntities())
                    {
                        var edit = (from katalog in db.Katalog
                                    where katalog.id_katalogu == idKatalogu
                                    select katalog.Wycieczka.Promocja).FirstOrDefault();
                        edit.cena = decimal.Parse(pView.tb_kwota.Text);
                        db.SaveChanges();
                    }
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Metoda służąca do usunięcia promocji, jeśli jej wartość wynosi 0 lub jest pusta
        /// </summary>
        /// <param name="idKatalogu">Id katalogu, w którym jest wycieczka z daną promocją do usunięcia</param>
        /// <returns>True jeśli usunięte, false jeśli nie</returns>
        public bool UsunPromocje(int idKatalogu)
        {
            using (db = new bazaEntities())
            {
                var idWyc = db.Katalog.Where(x => x.id_katalogu == idKatalogu).Select(x => x.id_wycieczki).FirstOrDefault();
                var promoDoUsuniecia = new Promocja { id_wycieczki = (int)idWyc };
                try
                {
                    db.Entry(promoDoUsuniecia).State = EntityState.Deleted;
                    db.SaveChanges();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
    }
}
