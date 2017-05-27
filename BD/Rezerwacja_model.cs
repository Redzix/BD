using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BD
{
    public class Rezerwacja_model
    {
        private int _numer;
        private int _liczbaOsob;
        private bool _stan;
        private decimal _zaliczka;
        private int _idWycieczki;
        private string _klientPesel;
       

        public Rezerwacja_model(){}

        ~Rezerwacja_model(){}

        public int Numer
        {
            get
            {
                return this._numer;
            }
            set
            {
                this._numer = value;
            }
        }

        public int LiczbaOsob
        {
            get
            {
                return this._liczbaOsob;
            }
            set
            {
                this._liczbaOsob = value;
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

        public decimal Zaliczka
        {
            get
            {
                return this._zaliczka;
            }
            set
            {
                this._zaliczka = value;
            }
        }

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

        public string KlientPesel
        {
            get
            {
                return this._klientPesel;
            }
            set
            {
                this._klientPesel = value;
            }
        }

        public List<Rezerwacja_model> PobierzRezerwacje()
        {
            List<Rezerwacja_model> _listaRezerwacji = new List<Rezerwacja_model>();
            Polacz_z_baza _polacz = new Polacz_z_baza();
            SqlConnection _polaczenie = _polacz.PolaczZBaza();
            SqlCommand _zapytanie = _polacz.UtworzZapytanie("SELECT * FROM Rezerwacja");

            SqlDataReader reader = _zapytanie.ExecuteReader();
            while (reader.Read())
            {
                Rezerwacja_model rezerwacja = new Rezerwacja_model();

                rezerwacja.Numer = Convert.ToInt32(reader["numer_rezerwacji"]);
                rezerwacja.LiczbaOsob = Convert.ToInt32(reader["liczba_osob"]);
                rezerwacja.Stan = Convert.ToBoolean(reader["stan"]);
                rezerwacja.Zaliczka = Convert.ToInt32(reader["zaliczka"]);
                rezerwacja.IdWycieczki = Convert.ToInt32(reader["id_wycieczki"]);
                rezerwacja.KlientPesel = reader["Klient_pesel"].ToString();

                _listaRezerwacji.Add(rezerwacja);
            }
            _polacz.ZakonczPolaczenie();
            return _listaRezerwacji;
        }

    }
}
