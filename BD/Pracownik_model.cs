using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BD
{
    public class Pracownik_model
    {
        private string _numerPesel;
        private string _imie;
        private string _nazwisko;
        private string _adres;
        private string _miejscowosc;

        public string NumerPesel
        {
            get
            {
                return this._numerPesel;
            }
            set
            {
                this._numerPesel = value;
            }
        }

        public string Imie
        {
            get
            {
                return this._imie;
            }
            set
            {
                this._imie = value;
            }
        }

        public string Nazwisko
        {
            get
            {
                return this._nazwisko;
            }
            set
            {
                this._nazwisko = value;

            }
        }
        public string Adres
        {
            get
            {
                return this._miejscowosc;
            }
            set
            {
                this._miejscowosc = value;
            }
        }

        public string Miejscowosc
        {
            get
            {
                return this._numerPesel;
            }
            set
            {
                this._numerPesel = value;
            }
        }


        //to na razie lac, nie wiem po co w sumie :D
   /*     public List<Pracownik_model> pobierzPracownikow()
        {
                List<Pracownik_model> _listaPracownikow = new List<Pracownik_model>();
                Polacz_z_baza _polacz = new Polacz_z_baza();
                SqlConnection _polaczenie = _polacz.PolaczZBaza();
                SqlCommand _zapytanie = _polacz.UtworzZapytanie("SELECT * FROM PojazdView");

                SqlDataReader reader = _zapytanie.ExecuteReader();
                while (reader.Read())
                {
                    Pracownik_model pracownik = new Pracownik_model();

                    pracownik.NumerPesel = reader["numer_rejestracyjny"].ToString();
                    pracownik.Imie = reader["numer_rejestracyjny"].ToString();
                    pracownik.Nazwisko = reader["numer_rejestracyjny"].ToString();
                    pracownik.Adres = reader["numer_rejestracyjny"].ToString();
                    pracownik.Miejscowosc = reader["numer_rejestracyjny"].ToString();

                _listaPracownikow.Add(pracownik);
                }
                _polacz.ZakonczPolaczenie();
                return _listaPracownikow;           
        }*/
    }
}
