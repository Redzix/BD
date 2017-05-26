using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BD
{
    public class Promocja_model
    {
        private int _idPromocji;
        private decimal _cena;
        private int _idWycieczki;

        public int IdPromocji
        {
            get
            {
                return this._idPromocji;
            }
            set
            {
                this._idPromocji = value;
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

        public List<Promocja_model> PobierzPojazdy()
        {
            List<Promocja_model> _listaPojazdow = new List<Promocja_model>();
            Polacz_z_baza _polacz = new Polacz_z_baza();
            SqlConnection _polaczenie = _polacz.PolaczZBaza();
            SqlCommand _zapytanie = _polacz.UtworzZapytanie("SELECT * FROM Promocja");

            SqlDataReader reader = _zapytanie.ExecuteReader();
            while (reader.Read())
            {
                Promocja_model promocja = new Promocja_model();

                promocja.IdPromocji = Convert.ToInt32(reader["id_promocji"]);
                promocja.Cena = Convert.ToDecimal(reader["cena"]);
                promocja.IdWycieczki = Convert.ToInt32(reader["id_wycieczki"]);


                _listaPojazdow.Add(promocja);
            }
            _polacz.ZakonczPolaczenie();
            return _listaPojazdow;
        }
    }
}
