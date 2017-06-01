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
        private int _dostepnosc;
        private string _marka;
        private int _stan;
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

        public int Dostepnosc        
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

        public int Stan
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
                pojazd.Dostepnosc = Convert.ToInt32(reader["dostepny"]);
                pojazd.Pojemnosc = Convert.ToInt32(reader["pojemnosc"]);
                pojazd.Marka = reader["marka"].ToString();
                pojazd.Stan = Convert.ToInt32(reader["stan"]);
                
                _listaPojazdow.Add(pojazd);             
            }
            _polacz.ZakonczPolaczenie();
            return _listaPojazdow;
        }

        public bool DodajPojazd(Pojazd_model pojazd)
        {
            Polacz_z_baza polacz = new Polacz_z_baza();
            SqlConnection polaczenie = polacz.PolaczZBaza();
            string numerRejestracyjny = "";

            numerRejestracyjny = polacz.PobierzDaneString(polacz.UtworzZapytanie("SELECT numer_rejestracyjny " +
                "FROM Pojazd " +
                "WHERE numer_rejestracyjny = '" + pojazd.NumerRejestracyjny + "'"));

            if (pojazd.NumerRejestracyjny.Equals(numerRejestracyjny))
            {                
                return false;
            }
            else
            {
                SqlCommand zapytanie = polacz.UtworzZapytanie("INSERT INTO Pojazd " +
                             "VALUES('" + pojazd.NumerRejestracyjny + "'," + pojazd.Dostepnosc + ",'" + pojazd.Marka +
                             "'," + pojazd.Pojemnosc + "," + pojazd.Stan + ")");
                zapytanie.ExecuteNonQuery();
                return true;
            }
        }
    }
}
