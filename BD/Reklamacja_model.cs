using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BD
{
    public class Reklamacja_model
    {
        private int _numer;
        private bool _stan;
        private string _opis;

        public Reklamacja_model(){}
        ~Reklamacja_model(){}

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

        public List<Reklamacja_model> PobierzReklamacje()
        {
            List<Reklamacja_model> _listaReklamacji = new List<Reklamacja_model>();
            Polacz_z_baza _polacz = new Polacz_z_baza();
            SqlConnection _polaczenie = _polacz.PolaczZBaza();
            SqlCommand _zapytanie = _polacz.UtworzZapytanie("SELECT * FROM Reklamacja");

            SqlDataReader reader = _zapytanie.ExecuteReader();
            while (reader.Read())
            {
                Reklamacja_model reklamacja = new Reklamacja_model();
                reklamacja.Numer = Convert.ToInt32(reader["numer_reklamacji"]);
                reklamacja.Opis = reader["opis"].ToString();
                reklamacja.Stan = Convert.ToBoolean(reader["stan"]);

                _listaReklamacji.Add(reklamacja);
            }
            _polacz.ZakonczPolaczenie();
            return _listaReklamacji;
        }
    }
}
