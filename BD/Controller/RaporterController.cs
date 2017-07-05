using BD.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD.Controller
{
    /// <summary>
    /// Kontroler dla tworzenia raportów
    /// </summary>
    class RaporterController
    {
        /// <summary>
        /// Widok formatki raportu
        /// </summary>
        RaporterView view;
        /// <summary>
        /// Konstruktor dla pre-generatora raportów
        /// </summary>
        /// <param name="view">Widok raportu</param>
        public RaporterController(RaporterView view)
        {
            this.view = view;
        }
        /// <summary>
        /// Ładowanie kolumn do wyboru pól w listBox
        /// </summary>
        /// <param name="rodzaj">Jaki typ raportu należy wygenerować</param>
        public void ZaladujKolumny(int rodzaj)
        {
            switch (rodzaj)
            {
                case 0:
                    WypelnijDlaWycieczek(true);
                    break;
                case 1:
                    WypelnijDlaReklamacji(true);
                    break;
                case 2:
                    WypelnijDlaPojazdow(true);
                    break;
            }
        }
        /// <summary>
        /// Wypełnienie pól dla wycieczki
        /// </summary>
        /// <param name="kolumny">True jeśli mają zostać wypełnione pola do wyboru kolumn</param>
        public void WypelnijDlaWycieczek(bool kolumny)
        {
            using (var dc = new bazaEntities())
            {
                var q = from c in dc.Katalog
                        select new
                        {
                            c.Wycieczka.nazwa,
                            c.Wycieczka.opis,
                            kierowca = c.Wycieczka.Kierowca.imie + " " + c.Wycieczka.Kierowca.nazwisko,
                            pilot = c.Wycieczka.Pilot.imie + " " + c.Wycieczka.Pilot.nazwisko,
                            odjazd = c.Miejsce.miejscowosc + ", " + c.Miejsce.adres,
                            przyjazd = c.Miejsce1.miejscowosc + ", " + c.Miejsce1.adres,
                            c.cena,
                            cena_promocyjna = (c.Wycieczka.Promocja == null) ? "Brak promocji" : c.Wycieczka.Promocja.cena.ToString(),
                        };

                if (kolumny)
                {
                    var columns = q.First();
                    var properties = from property in columns.GetType().GetProperties()
                                     select property.Name;
                    foreach (var column in properties)
                    {
                        view.lb_kolumny.Items.Add(column);
                    }
                }
                else
                {
                    view.lv_Sortowanie.Clear();
                    foreach (var item in view.lb_kolumny.SelectedItems)
                    {
                        view.lv_Sortowanie.Columns.Add(item.ToString());
                    }

                    foreach (var bub in q)
                    {
                        List<string> dane = new List<string>();
                        foreach (var item in view.lb_kolumny.SelectedItems)
                        {
                            dane.Add(bub.GetType().GetProperty(item.ToString()).GetValue(bub, null).ToString());
                        }
                        ListViewItem listView = new ListViewItem(dane.ToArray());
                        view.lv_Sortowanie.Items.Add(listView);
                    }
                }
            }
        }
        /// <summary>
        /// Wypełnienie pól dla reklamacji
        /// </summary>
        /// <param name="kolumny">True jeśli mają zostać wypełnione pola do wyboru kolumn</param>
        public void WypelnijDlaReklamacji(bool kolumny)
        {
            using (var dc = new bazaEntities())
            {
                var q = from c in dc.Reklamacja
                        select new
                        {
                            nazwa_wycieczki = c.Uczestnictwo.Rezerwacja.Wycieczka.nazwa,
                            kierowca = c.Uczestnictwo.Rezerwacja.Wycieczka.Kierowca.imie + " " + c.Uczestnictwo.Rezerwacja.Wycieczka.Kierowca.nazwisko,
                            pilot = c.Uczestnictwo.Rezerwacja.Wycieczka.Pilot.imie + " " + c.Uczestnictwo.Rezerwacja.Wycieczka.Pilot.nazwisko,
                            klient = c.Uczestnictwo.Rezerwacja.Klient.imie + " " + c.Uczestnictwo.Rezerwacja.Klient.nazwisko,
                            kierownik = (c.Kierownik == null) ? "Nierozstrzygnięte" : c.Kierownik.imie + " " + c.Kierownik.nazwisko,
                            opis_reklamacji = c.opis,
                            stan = ((bool)c.stan) ? "Pozytywnie" : (c.Kierownik == null) ? "Brak rozpatrzenia" : "Negatywnie",
                        };

                if (kolumny)
                {
                    var columns = q.First();
                    var properties = from property in columns.GetType().GetProperties()
                                     select property.Name;
                    foreach (var column in properties)
                    {
                        view.lb_kolumny.Items.Add(column);
                    }
                }
                else
                {
                    view.lv_Sortowanie.Clear();
                    foreach (var item in view.lb_kolumny.SelectedItems)
                    {
                        view.lv_Sortowanie.Columns.Add(item.ToString());
                    }

                    foreach (var bub in q)
                    {
                        List<string> dane = new List<string>();
                        foreach (var item in view.lb_kolumny.SelectedItems)
                        {
                            dane.Add(bub.GetType().GetProperty(item.ToString()).GetValue(bub, null).ToString());
                        }
                        ListViewItem listView = new ListViewItem(dane.ToArray());
                        view.lv_Sortowanie.Items.Add(listView);
                    }
                }
            }
        }
        /// <summary>
        /// Wypełnienie pól dla pojazdów
        /// </summary>
        /// <param name="kolumny">True jeśli mają zostać wypełnione pola do wyboru kolumn</param>
        public void WypelnijDlaPojazdow(bool kolumny)
        {
            using (var dc = new bazaEntities())
            {
                var q = from c in dc.Pojazd
                        select new
                        {
                            c.numer_rejestracyjny,
                            c.marka,
                            c.pojemnosc,
                            stan = ((bool)c.stan) ? "Sprawny" : "Niesprawny",
                            dostępność = ((bool)c.dostepny) ? "Dostępny" : "Niedostępny"
                        };

                if (kolumny)
                {
                    var columns = q.First();
                    var properties = from property in columns.GetType().GetProperties()
                                     select property.Name;
                    foreach (var column in properties)
                    {
                        view.lb_kolumny.Items.Add(column);
                    }
                }
                else
                {
                    view.lv_Sortowanie.Clear();
                    foreach (var item in view.lb_kolumny.SelectedItems)
                    {
                        view.lv_Sortowanie.Columns.Add(item.ToString());
                    }

                    foreach (var bub in q)
                    {
                        List<string> dane = new List<string>();
                        foreach (var item in view.lb_kolumny.SelectedItems)
                        {
                            dane.Add(bub.GetType().GetProperty(item.ToString()).GetValue(bub, null).ToString());
                        }
                        ListViewItem listView = new ListViewItem(dane.ToArray());
                        view.lv_Sortowanie.Items.Add(listView);
                    }
                }
            }
        }
    }
}
