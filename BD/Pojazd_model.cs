using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BD
{
    public class Pojazd_model
    {
        private string _numerRejestracyjny;
        private bool _dostepnosc;
        private string _marka;
        private bool _stan;
        private int _pojemnosc;

        public Pojazd_model(){}

        ~Pojazd_model(){}

        public string NumerRejestracyjny            
        {
            get
            {
                return this._numerRejestracyjny;
            }
            set
            {
                this._numerRejestracyjny = value;
            }
        }

        public bool Dostepnosc        
        {
            get
            {
                return this._dostepnosc;
            }
            set
            {
                this._dostepnosc = value;
            }
        }

        public string Marka
        {
            get
            {
                return this._marka;
            }
            set
            {
                this._marka = value;
            }
        }

        public bool Stan
        {
            get
            {
                return this._stan;
            }
            set
            {
                this._stan = value;
            }
        }
        public int Pojemnosc
        {
            get
            {
                return this._pojemnosc;
            }
            set
            {
                this._pojemnosc = value;
            }
        }

        public List<Pojazd_model> PobierzPojazdy()
        {
            List<Pojazd_model> _listaPojazdow = new List<Pojazd_model>();          
            Polacz_z_baza _polacz= new Polacz_z_baza();
            SqlConnection _polaczenie = _polacz.PolaczZBaza();
            SqlCommand _zapytanie = _polacz.UtworzZapytanie("SELECT * FROM Pojazd");

            SqlDataReader reader = _zapytanie.ExecuteReader();
            while (reader.Read())
            {
                Pojazd_model pojazd = new Pojazd_model();

                pojazd.NumerRejestracyjny = reader["numer_rejestracyjny"].ToString();
                pojazd.Dostepnosc = Convert.ToBoolean(reader["dostepny"]);
                pojazd.Pojemnosc = Convert.ToInt32(reader["pojemnosc"]);
                pojazd.Marka = reader["marka"].ToString();
                pojazd.Stan = Convert.ToBoolean(reader["stan"]);
                
                _listaPojazdow.Add(pojazd);             
            }
            _polacz.ZakonczPolaczenie();
            return _listaPojazdow;
        }

        }
}
