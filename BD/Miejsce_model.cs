using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BD
{
    public class Miejsce_model
    {
        private int _idMiejsca;
        private string _adres;
        private string _miejscowosc;


        public int IdMiejsca
        {
            get
            {
                return this._idMiejsca;
            }
            set
            {
                this._idMiejsca = value;
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

        public List<Miejsce_model> PobierzPojazdy()
        {
            List<Miejsce_model> _listaPojazdow = new List<Miejsce_model>();
            Polacz_z_baza _polacz = new Polacz_z_baza();
            SqlConnection _polaczenie = _polacz.PolaczZBaza();
            SqlCommand _zapytanie = _polacz.UtworzZapytanie("SELECT * FROM Miejsce");

            SqlDataReader reader = _zapytanie.ExecuteReader();
            while (reader.Read())
            {
                Miejsce_model miejsce = new Miejsce_model();

                miejsce.IdMiejsca = Convert.ToInt32(reader["id_miejsca"]);
                miejsce.Adres = reader["adres"].ToString();
                miejsce.Miejscowosc = reader["miejscowosc"].ToString();

                _listaPojazdow.Add(miejsce);
            }
            _polacz.ZakonczPolaczenie();
            return _listaPojazdow;
        }

    }
}
