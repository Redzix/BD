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
        /// <summary>
        /// Widok obsługiwan w danej instancji przez kontroler
        /// </summary>
        object view;
        /// <summary>
        /// Konstruktor kontrolera
        /// </summary>
        /// <param name="view">Widok obsługiwany przez kontroler</param>
        public KierownikController(object view)
        {
            this.view = view;
        }

        /// <summary>
        /// Ładuje wszystkie wpisy katalogu do odpowiedniego listview. Ładuje tylko aktualne wyceiczki gdy checkbox nie jest aktywny na formatce.
        /// </summary>
        /// <returns>True, jeśli wszystko dobrze</returns>
        public bool LadujKatalog()
        {
            KierownikView kView = (KierownikView)view;
            kView.lv_wycieczki.Items.Clear();
            using (var db = new bazaEntities())
            {
                var czyWszystkie = kView.cBox_wycieczki.Checked;
                var query = from katalog in db.Katalog
                            select new
                            {
                                katalog,
                                wycieczka = katalog.Wycieczka,
                                miejsce_z = katalog.Miejsce,
                                miejsce_do = katalog.Miejsce1
                            };
                if (!czyWszystkie)
                    query = query.Where(x => !(x.wycieczka.data_powrotu < DateTime.Now)).Select(x=>x);
                foreach (var wyc in query)
                {
                    ListViewItem wycieczka = new ListViewItem(wyc.wycieczka.nazwa); //Miejsce

                    wycieczka.Tag = wyc.katalog.id_katalogu; //Ukryte ID
                    if (wyc.wycieczka.WycieczkaOdbyta(DateTime.Now))
                        wycieczka.BackColor = Color.LightCoral;
                    else if (wyc.wycieczka.WycieczkaWTrakcie(DateTime.Now))
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
        /// <summary>
        /// Dodaje katalog do bazy danych
        /// </summary>
        /// <returns>True jeśli się powiodło, false jeśli nie</returns>
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
                var nowyKatalog = new Katalog
                {
                    id_miejsca_odjazdu = miejsceOdjazdu,
                    id_miejsca_przyjazdu = miejscePrzyjazdu,
                    okres_trwania_wycieczki = (wView.tb_data_powrotu.Value - wView.tb_data_wyjazdu.Value).Days,
                    cena = decimal.Parse(wView.tb_cena.Text)
                };
                nowyKatalog.Wycieczka = nowaWycieczka;
                using (var db = new bazaEntities())
                {
                    db.Katalog.Add(nowyKatalog);
                    db.Wycieczka.Add(nowaWycieczka);
                    db.SaveChanges();
                }
            } catch
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Metoda do wypełnienia wsyzstkich comboboxów
        /// </summary>
        /// <returns>True jeśli się powiodło</returns>
        public bool WypelnijKatalogBoxy()
        {
            WycieczkaView wView = (WycieczkaView)view;

            using (var db = new bazaEntities())
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
        /// <summary>
        /// Wypełnienie pól katalogu w celu jego edycji
        /// </summary>
        /// <param name="idKatalog">ID katalog edytowanego</param>
        /// <returns>True jesli wypełnienie się uda</returns>
        public bool WypelnijKatalogDoEdycji(int idKatalog)
        {
            WycieczkaView wView = (WycieczkaView)view;

            using (var db = new bazaEntities())
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
        /// <summary>
        /// Metoda do edycji katalogu.
        /// </summary>
        /// <param name="idKatalog">ID katalogu edytowanego</param>
        /// <returns>True jeśli modyfikacja się udała</returns>
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
                using (var db = new bazaEntities())
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
        /// <summary>
        /// Metoda do usuwania katalogu razem z "braćmi"
        /// </summary>
        /// <param name="idKatalog">ID katalogu do usunięcia</param>
        /// <returns>True jeśli się powiodło usunięcie</returns>
        public bool UsunKatalog(int idKatalog) {
            try
            {
                using (var db = new bazaEntities())
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
        /// Ładowanie reklamacji do listview w zależności od checkboxa na formie.
        /// </summary>
        /// <returns>True jeśli się powiodło</returns>
        public bool LadujReklamacje()
        {
            KierownikView kView = (KierownikView)view;
            using (var db = new bazaEntities()) {
                var czyWszystkie = kView.cBox_reklamacja.Checked;
                IQueryable query = null;
                if (czyWszystkie)
                    query = from r in db.Reklamacja select r;
                else
                    query = from r in db.Reklamacja where r.Kierownik_pesel == null select r;

                kView.lv_reklamacje.Items.Clear();
                foreach (Reklamacja rek in query)
                {
                    ListViewItem reklamacjaItem = new ListViewItem(rek.numer_reklamacji.ToString());
                    reklamacjaItem.Tag = rek.numer_reklamacji;
                    reklamacjaItem.SubItems.Add((rek.opis.Length <= 30) ? rek.opis : rek.opis.Substring(0, 30));
                    //reklamacjaItem.SubItems.Add((bool)rek.stan ? "Pozytywnie" : "Negatywnie");
                    reklamacjaItem.SubItems.Add(rek.Kierownik == null ? "Nierozpatrzona" : "Rozpatrzona");
                    kView.lv_reklamacje.Items.Add(reklamacjaItem);
                }
            }
            return true;
        }
        /// <summary>
        /// Metoda ladująca odpowiednie pola służące do rozpatrzenia rekalamcji
        /// </summary>
        /// <param name="idReklamacji">ID reklamacji do rozpatrzenia</param>
        /// <returns>True jeśli się powiodła zmiana</returns>
        public bool WypelnijReklamacjeDoRozpatrzenia(int idReklamacji)
        {
            KierownikView kView = (KierownikView)view;
            try
            {
                using (var db = new bazaEntities())
                {
                    var reklamacjaDoPrzegladu = (from reklamacja in db.Reklamacja
                                                 where reklamacja.numer_reklamacji == idReklamacji
                                                 select new
                                                 {
                                                     reklamacja,
                                                     reklamacja.Uczestnictwo.Rezerwacja.Wycieczka,
                                                     reklamacja.Kierownik,
                                                     reklamacja.Uczestnictwo.Rezerwacja.Klient
                                                 }).FirstOrDefault();

                    kView.rtb_opisReklamacji.Text = reklamacjaDoPrzegladu.reklamacja.opis;
                    kView.tb_nazwa_wycieczki.Text = reklamacjaDoPrzegladu.Wycieczka.nazwa;
                    kView.tb_Reklamujacy.Text = reklamacjaDoPrzegladu.Klient.DaneOsobowe();
                    kView.tb_Rozstrzygajacy.Text = (reklamacjaDoPrzegladu.Kierownik == null) ? "Jeszcze nierozpatrzone" : reklamacjaDoPrzegladu.Kierownik.DaneOsobowe();
                    TimeSpan roznica = (TimeSpan)(reklamacjaDoPrzegladu.Wycieczka.data_powrotu - reklamacjaDoPrzegladu.Wycieczka.data_wyjazdu);
                    kView.tb_okresTrwaniaWycieczki.Text = String.Format("{0} dni", roznica.Days);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Metoda służaca do aktualizacji stanu reklamacji
        /// </summary>
        /// <param name="idReklamacji">ID reklamacji do rozpatrzenia</param>
        /// <param name="stan">True jeśi pozytywnie</param>
        /// <param name="peselKierownika">Pesel kierownika dokonującego rozpatrzenia</param>
        /// <returns></returns>
        public bool RozpatrzReklamacje(int idReklamacji, bool stan, string peselKierownika)
        {
            try
            {
                using (var db = new bazaEntities())
                {
                    var reklamacja = (from rek in db.Reklamacja
                                      where rek.numer_reklamacji == idReklamacji
                                      select rek).FirstOrDefault();
                    reklamacja.stan = stan;
                    reklamacja.Kierownik_pesel = peselKierownika;
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
        /// Metoda służaca do ładowania wszystkich pojazdów do odpowiedniego listview
        /// </summary>
        /// <returns>True jeśli się powiodło</returns>
        public bool LadujPojazdy()
        {
            try
            {
                using (var db = new bazaEntities())
                {
                    KierownikView kView = (KierownikView)view;
                    kView.lv_pojazdy.Items.Clear();

                    var query = from p in db.Pojazd select p;

                    foreach (Pojazd poj in query)
                    {
                        ListViewItem pojazd = new ListViewItem(poj.numer_rejestracyjny);
                        pojazd.Tag = poj.numer_rejestracyjny;
                        pojazd.SubItems.Add((bool)poj.dostepny ? "Dostępny" : "Niedostępny");
                        pojazd.SubItems.Add(poj.marka);
                        pojazd.SubItems.Add(poj.pojemnosc.ToString());
                        pojazd.SubItems.Add((bool)poj.stan ? "Sprawny" : "Awaria");
                        kView.lv_pojazdy.Items.Add(pojazd);
                    }
                }
            } catch
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Metoda odpowiedzialna za dodawanie nowego pojazdu do bazy danych wraz z wszystimi informacjami o nim.
        /// </summary>
        /// <returns>Zwraca odpowiednie informacje o powodzeniu operacji.</returns>
        public int DodajPojazd()
        {
            try
            {
                PojazdView _view = (PojazdView)view;
                using (var db = new bazaEntities())
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
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
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
        /// <summary>
        /// Metoda do zmiany stanu pojazdu
        /// </summary>
        /// <param name="pojazdRejestracja">Numer rejestracyjny pojazdu</param>
        /// <param name="stan">True jeśli sprawny, false jesli niesprawny</param>
        /// <returns>True jeśli się powiodła zmiana stanu</returns>
        public bool EdytujStanPojazdu(string pojazdRejestracja, bool stan)
        {
            try
            {
                using (var db = new bazaEntities())
                {
                    var ePojazd = (from pojazd in db.Pojazd
                                   where pojazd.numer_rejestracyjny == pojazdRejestracja
                                   select pojazd).FirstOrDefault();
                    ePojazd.stan = stan;
                    db.SaveChanges();
                }
            } catch
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Metoda zmieniająca wartość dostepności danego pojazdu
        /// </summary>
        /// <param name="pojazdRejestracja">Numer rejestracyjny pojazdu edytowanego</param>
        /// <param name="dostepny">Dostępność pojazdu</param>
        /// <returns>True jeśli się powiodła zmiana</returns>
        public bool EdytujDostepnoscPojazdu(string pojazdRejestracja, bool dostepny)
        {
            try
            {
                using (var db = new bazaEntities())
                {
                    var ePojazd = (from pojazd in db.Pojazd
                                   where pojazd.numer_rejestracyjny == pojazdRejestracja
                                   select pojazd).FirstOrDefault();
                    ePojazd.dostepny = dostepny;
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
        /// Metoda do usuwania pojazdu
        /// </summary>
        /// <param name="pojazdRejestracja">NUmer rejestracyjny pojazdu usuwanego</param>
        /// <returns>Zwraca true jeśli się powiodło</returns>
        public bool UsunPojazd(string pojazdRejestracja)
        {
            try
            {
                using (var db = new bazaEntities())
                {
                    var pojazdDoUsuniecia = new Pojazd { numer_rejestracyjny = pojazdRejestracja };
                    db.Entry(pojazdDoUsuniecia).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            } catch
            {
                return false;
            }
            return true;
        }
        
        /// <summary>
        /// Metoda służąca do dodania promocji
        /// </summary>
        /// <param name="idKatalog">ID katalogu do którego jest wycieczka na promocji</param>
        /// <returns>True jeśli się uda</returns>
        public bool DodajPromocje(int idKatalog)
        {
            using (var db = new bazaEntities())
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
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
        /// <summary>
        /// Ładowanie ceny do textboxa z kwotą
        /// </summary>
        /// <param name="idKatalogu">Wiadomo</param>
        /// <returns>True, jeśli załadowało. False jeśli promocja nie istnieje</returns>
        public bool LadujPromocje(int idKatalogu)
        {
            using (var db = new bazaEntities())
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
                    using (var db = new bazaEntities())
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
            using (var db = new bazaEntities())
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
