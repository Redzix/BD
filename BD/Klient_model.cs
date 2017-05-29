using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BD
{
    public class Klient_model
    {
        private string _pesel;
        private string _imie;
        private string _nazwisko;
        private string _adres;
        private string _miejscowosc;


        public string Pesel
        {
            get
            {
                return this._pesel;
            }
            set
            {
                this._pesel = value;
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
                return this._adres;
            }
            set
            {
                this._adres = value;
            }
        }

        public string Miejscowosc
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

        public List<Klient_model> PobierzKlientow()
        {
            List<Klient_model> _listaKlientow = new List<Klient_model>();
            Polacz_z_baza _polacz = new Polacz_z_baza();
            SqlConnection _polaczenie = _polacz.PolaczZBaza();
            SqlCommand _zapytanie = _polacz.UtworzZapytanie("SELECT * FROM Klient");

            SqlDataReader reader = _zapytanie.ExecuteReader();
            while (reader.Read())
            {
                Klient_model klient = new Klient_model();
                klient.Pesel = reader["pesel"].ToString();
                klient.Imie = reader["imie"].ToString();
                klient.Nazwisko = reader["nazwisko"].ToString();
                klient.Adres = reader["ulica"].ToString();
                klient.Miejscowosc = reader["miejscowosc"].ToString();

                _listaKlientow.Add(klient);
            }
            _polacz.ZakonczPolaczenie();
            return _listaKlientow;
        }

        public void DodajKlienta(Klient_model klient)
        {
            Polacz_z_baza _polacz = new Polacz_z_baza();
            SqlConnection _polaczenie = _polacz.PolaczZBaza();

            SqlCommand _zapytanie = _polacz.UtworzZapytanie("INSERT INTO Klient " +
                "VALUES('"+ klient.Pesel + "','" + klient.Imie + "','" + klient.Nazwisko + "','" +
                klient.Adres + "','" + klient.Miejscowosc + "')");
            _zapytanie.ExecuteNonQuery();
            
        }
    }
}
