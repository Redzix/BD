using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.View;

namespace BD.Controller
{
    class KlientController
    {
        private KlientView _view;
        private bazaEntities db;

        public KlientController(KlientView view)
        {
            _view = view;
            db = new bazaEntities();
        }

        public bool PobierzWycieczki()
        {
            _view.dgv_katalog.AutoGenerateColumns = false;

            // Bindowanie odpowiednich kolumn bazy danych z kolumnami tabeli dgv_tabelaPilot
            _view.dgv_katalog.Columns["id_wycieczki"].DataPropertyName = "wycieczkaId";
            _view.dgv_katalog.Columns["Nazwa_wycieczki"].DataPropertyName = "wycieczka";
            _view.dgv_katalog.Columns["Okres"].DataPropertyName = "okresTrwaniaWycieczki";
            _view.dgv_katalog.Columns["Data_wyjazdu"].DataPropertyName = "dataOdjazdu";
            _view.dgv_katalog.Columns["Promocja"].DataPropertyName = "wartoscPromocji";
            _view.dgv_katalog.Columns["Koszt"].DataPropertyName = "cenaCalkowita";

            var query = from katalog in db.Katalog
                        select new
                        {
                            wycieczkaId = katalog.id_wycieczki,
                            wycieczka = katalog.Wycieczka.nazwa,
                            okresTrwaniaWycieczki = katalog.okres_trwania_wycieczki,
                            dataOdjazdu = katalog.Wycieczka.data_wyjazdu,
                            wartoscPromocji = (katalog.Wycieczka.Promocja.cena != null) ? katalog.Wycieczka.Promocja.cena : 0,
                            cenaCalkowita = katalog.Cennik.cena - ((katalog.Wycieczka.Promocja.cena != null) ? katalog.Wycieczka.Promocja.cena : 0)

                        };
            if (query == null)
            {
                return false;
            }
            else
            {
                _view.dgv_katalog.DataSource = query.ToList();
                return true;
            }
        }

        public int PobierzDaneWycieczki(string _idWycieczki)
        {
            try
            {
                //Pobranie z tabeli oraz z bazy danych odpowiednich wartości do wyświetlenia.
                int idWycieczki = int.Parse(_idWycieczki);

                var pobierz = (from katalog in db.Katalog
                             where katalog.id_wycieczki == idWycieczki
                             select new
                             {
                                 wycieczka = katalog.Wycieczka.nazwa,
                                 dataOdjazdu = katalog.Wycieczka.data_wyjazdu,
                                 dataPowrotu = katalog.Wycieczka.data_wyjazdu,
                                 opisWycieczki = katalog.Wycieczka.opis,
                                 miejsceDoceloweAdres = katalog.Miejsce.adres,
                                 miejsceDoceloweMiejscowosc = katalog.Miejsce.miejscowosc
                             }).FirstOrDefault();

                if (pobierz == null)
                {
                    return -1;
                }
                else
                {
                    // Dodanie wartości parametrów do opisu znajdującego się w texboxie
                    _view.rtb_wycieczka.Text =
                        "Nazwa: " + pobierz.wycieczka +
                        "\nData wyjazdu: " + pobierz.dataOdjazdu +
                        "\nData powrotu: " + pobierz.dataPowrotu +
                        "\nOpis: " + pobierz.opisWycieczki +
                        "\n\nAdres miejsca: " + pobierz.miejsceDoceloweAdres +
                        "\nMiejscowość: " + pobierz.miejsceDoceloweMiejscowosc;
                }

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
    }
}
