using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    public class Katalog_kontroler_list
    {
        private string _nazwaWycieczki;
        private DateTime _dataWyjazdu;
        private DateTime _dataPrzyjazdu;
        private string _opis;
        private decimal _promocja;
        private decimal _cena;
        private string _kierowca;
        private string _pilot;
        private string _miejsceOdjazdu;
        private string _miejsceDocelowe;

        public string NazwaWycieczki
        {
            get
            {
                return this._nazwaWycieczki;
            }
            set
            {
                this._nazwaWycieczki = value;
            }
        }

        public DateTime DataWyjazdu
        {
            get
            {
                return this._dataWyjazdu;
            }
            set
            {
                this._dataWyjazdu = value;
            }
        }

        public DateTime DataPrzyjazdu
        {
            get
            {
                return this._dataPrzyjazdu;
            }
            set
            {
                this._dataPrzyjazdu = value;
            }
        }

        public string Opis
        {
            get
            {
                return this._opis;
            }
            set
            {
                this._opis = value;
            }
        }

        public decimal Promocja
        {
            get
            {
                return this._promocja;
            }
            set
            {
                this._promocja = value;
            }
        }

        public decimal Cena
        {
            get
            {
                return this._cena;
            }
            set
            {
                this._cena = value;
            }
        }

        public string Kierowca
        {
            get
            {
                return this._kierowca;
            }
            set
            {
                this._kierowca = value;
            }
        }

        public string Pilot
        {
            get
            {
                return this._pilot;
            }
            set
            {
                this._pilot = value;
            }
        }

        public string MiejsceOdjazdu
        {
            get
            {
                return this._miejsceOdjazdu;
            }
            set
            {
                this._miejsceOdjazdu = value;
            }
        }

        public string MiejsceDocelowe
        {
            get
            {
                return this._miejsceDocelowe;
            }
            set
            {
                this._miejsceDocelowe = value;
            }
        }

        public List<Katalog_kontroler_list> PobierzListe()
        {
            List<Katalog_kontroler_list> _lista = new List<Katalog_kontroler_list>();
            List<Katalog_model> _listaKatalogu = new Katalog_model().PobierzKatalog();
            List<Pilot_model> _listaPilotow = new Pilot_model().pobierzPilotow();
            List<Kierowca_model> _listaKierowcow = new Kierowca_model().pobierzKierowcow();
            List<Wycieczka_model> _listaWycieczek = new Wycieczka_model().PobierzWycieczki();
            List<Promocja_model> _listaPromocji = new Promocja_model().PobierzPromocje();
            List<Cennik_model> _listaCennikow = new Cennik_model().PobierzCennik();

            Katalog_kontroler_list katalog = new Katalog_kontroler_list();
            for (int i = 0; i < _listaKatalogu.Count; i++)
            {
                katalog.NazwaWycieczki = _listaWycieczek[_listaKatalogu[i].IdWycieczki - 1].Nazwa;
                katalog.DataWyjazdu = _listaWycieczek[_listaKatalogu[i].IdWycieczki - 1].DataWyjazdu;
                katalog.DataPrzyjazdu = _listaWycieczek[_listaKatalogu[i].IdWycieczki - 1].DataPowrotu;
                katalog.Opis = _listaWycieczek[_listaKatalogu[i].IdWycieczki - 1].Opis;
                //promocja
                int j = 0;
                while (_listaPromocji[j].IdWycieczki != _listaKatalogu[i].IdWycieczki)
                {
                    j++;
                }
                katalog.Promocja = _listaPromocji[j].Cena;
                katalog.Cena = _listaCennikow[_listaKatalogu[i].IdCennika - 1].Cena - _listaPromocji[j].Cena;
            }
            return _lista;
        }


    }
}
