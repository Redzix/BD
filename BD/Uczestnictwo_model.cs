using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BD
{
    public class Uczestnictwo_model
    {
        private int _idUczestnictwa;
        private int _iczbaOsob;
        private int _numerRezerwacji;

        public int IdUczestnictwa
        {
            get
            {
                return this._idUczestnictwa;
            }
            set
            {
                this._idUczestnictwa = value;
            }
        }

        public int LiczbaOsob
        {
            get
            {
                return this._iczbaOsob;
            }
            set
            {
                this._iczbaOsob = value;
            }
        }
        public int NumerRezerwacji
        {
            get
            {
                return this._numerRezerwacji;
            }
            set
            {
                this._numerRezerwacji = value;
            }
        }

        public List<Uczestnictwo_model> PobierzUczestnictwo()
        {
            List<Uczestnictwo_model> _listaUczestnictw= new List<Uczestnictwo_model>();
            Polacz_z_baza _polacz = new Polacz_z_baza();
            SqlConnection _polaczenie = _polacz.PolaczZBaza();
            SqlCommand _zapytanie = _polacz.UtworzZapytanie("SELECT * FROM Uczestnictwo");

            SqlDataReader reader = _zapytanie.ExecuteReader();
            while (reader.Read())
            {
                Uczestnictwo_model uczestnictwo = new Uczestnictwo_model();

                uczestnictwo.IdUczestnictwa = Convert.ToInt32(reader["id_uczestnictwo"]);
                uczestnictwo.LiczbaOsob = Convert.ToInt32(reader["liczba_osob"]);
                uczestnictwo.NumerRezerwacji = Convert.ToInt32(reader["numer_rezerwacji"]);


                _listaUczestnictw.Add(uczestnictwo);
            }
            _polacz.ZakonczPolaczenie();
            return _listaUczestnictw;
        }
    }
}
