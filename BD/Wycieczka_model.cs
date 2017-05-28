using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BD
{
    public class Wycieczka_model
    {
        private int _idWycieczki;
        private string _nazwa;
        private DateTime _dataWyjazdu;
        private DateTime _dataPowrotu;
        private string _opis;

        //nie tak ma byc, ale jest najprosciej
        private string _kierowca;
        private string _pilot;


        public Wycieczka_model(){}

        ~Wycieczka_model(){}

        public int IdWycieczki
        {
            get
            {
                return this._idWycieczki;
            }
            set
            {
                this._idWycieczki = value;
            }
        }

        public string Nazwa
        {
            get
            {
                return this._nazwa;
            }
            set
            {
                this._nazwa = value;
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

        public DateTime DataPowrotu
        {
            get
            {
                return this._dataPowrotu;
            }
            set
            {
                this._dataPowrotu = value;
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

        public List<Wycieczka_model> PobierzWycieczki()
        {
            List<Wycieczka_model> _listaWycieczek = new List<Wycieczka_model>();
            Polacz_z_baza _polacz = new Polacz_z_baza();
            SqlConnection _polaczenie = _polacz.PolaczZBaza();
            SqlCommand _zapytanie = _polacz.UtworzZapytanie("SELECT id_wycieczki,nazwa,data_wyjazdu," +
                "data_powrotu,opis,p.imie + ' '+ p.nazwisko as pil,k.imie + ' '+ k.nazwisko as kiero " +
                "from wycieczka inner join pilot as p on wycieczka.pilot_pesel = p.pesel " +
                "inner join kierowca as k on wycieczka.kierowca_pesel = k.pesel ");

            SqlDataReader reader = _zapytanie.ExecuteReader();
            while (reader.Read())
            {
                Wycieczka_model wycieczka = new Wycieczka_model();

                wycieczka.IdWycieczki = Convert.ToInt32(reader["id_wycieczki"]);
                wycieczka.Nazwa = reader["nazwa"].ToString();
                wycieczka.DataPowrotu = Convert.ToDateTime(reader["data_powrotu"]);
                wycieczka.DataWyjazdu = Convert.ToDateTime(reader["data_wyjazdu"]);
                wycieczka.Opis = reader["opis"].ToString();
                wycieczka.Kierowca = reader["kiero"].ToString();
                wycieczka.Pilot = reader["pil"].ToString();

                _listaWycieczek.Add(wycieczka);
            }
            _polacz.ZakonczPolaczenie();
            return _listaWycieczek;
        }

    }
}
