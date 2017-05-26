using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BD
{
    public class Katalog_model
    {
        private int _idKatalogu;
        private int _okres;
        private int _idMiejscaOdjazdu;
        private int _idMiejscaPrzyjazdu;
        private int _idWycieczki;

        public int IdKatalogu
        {
            get
            {
                return this._idKatalogu;
            }
            set
            {
                this._idKatalogu = value;
            }
        }

        public int Okres
        {
            get
            {
                return this._okres;
            }
            set
            {
                this._okres = value;
            }
        }

        public int IdMiejscaOdjazdu
        {
            get
            {
                return this._idMiejscaOdjazdu;
            }
            set
            {
                this._idMiejscaOdjazdu = value;
            }
        }

        public int IdMiejscaPrzyjazdu
        {
            get
            {
                return this._idMiejscaPrzyjazdu;
            }
            set
            {
                this._idMiejscaPrzyjazdu = value;
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

        public List<Katalog_model> PobierzPojazdy()
        {
            List<Katalog_model> _listaPojazdow = new List<Katalog_model>();
            Polacz_z_baza _polacz = new Polacz_z_baza();
            SqlConnection _polaczenie = _polacz.PolaczZBaza();
            SqlCommand _zapytanie = _polacz.UtworzZapytanie("SELECT * FROM Katalog");

            SqlDataReader reader = _zapytanie.ExecuteReader();
            while (reader.Read())
            {
                Katalog_model katalog = new Katalog_model();

                katalog.IdKatalogu = Convert.ToInt32(reader["id_katalogu"]);
                katalog.Okres = Convert.ToInt32(reader["okres_trwania_wycieczki"]);
                katalog.IdMiejscaOdjazdu = Convert.ToInt32(reader["id_miejsca_odjazdu"]);
                katalog.IdMiejscaPrzyjazdu = Convert.ToInt32(reader["id_miejsca_przyjazdu"]);
                katalog.IdWycieczki = Convert.ToInt32(reader["id_wycieczki"]);

                _listaPojazdow.Add(katalog);
            }
            _polacz.ZakonczPolaczenie();
            return _listaPojazdow;
        }

    }
}
