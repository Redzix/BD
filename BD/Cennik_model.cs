using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BD
{
    public class Cennik_model
    {
        private int _idCennika;
        private decimal _cena;
        private DateTime _okresOd;
        private DateTime _okredDo;

        public int IdCennika
        {
            get
            {
                return this._idCennika;
            }
            set
            {
                this._idCennika = value;
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

        public DateTime OkresOd
        {
            get
            {
                return this._okresOd;
            }
            set
            {
                this._okresOd = value;
            }
        }

        public DateTime OkresDo
        {
            get
            {
                return this._okredDo;
            }
            set
            {
                this._okredDo = value;
            }
        }

        public List<Cennik_model> PobierzCennik()
        {
            List<Cennik_model> _listaCen = new List<Cennik_model>();
            Polacz_z_baza _polacz = new Polacz_z_baza();
            SqlConnection _polaczenie = _polacz.PolaczZBaza();
            SqlCommand _zapytanie = _polacz.UtworzZapytanie("SELECT * FROM Cennik");

            SqlDataReader reader = _zapytanie.ExecuteReader();
            while (reader.Read())
            { 
                Cennik_model cennik = new Cennik_model();

                cennik.IdCennika = Convert.ToInt32(reader["id_cennika"]);
                cennik.Cena = Convert.ToInt32(reader["cena"]);
                cennik.OkresOd = Convert.ToDateTime(reader["okres_od"]);
                cennik.OkresDo = Convert.ToDateTime(reader["okres_do"]);


                _listaCen.Add(cennik);
            }
            _polacz.ZakonczPolaczenie();
            return _listaCen;
        }
    }
}
