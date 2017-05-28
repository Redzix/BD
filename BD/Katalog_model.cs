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
        private int _idCennika;
        private string _miejsceWyjazdu;
        private string _miejsceDocelowe;
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

        public string MiejsceWyjazdu
        {
            get
            {
                return this._miejsceWyjazdu;
            }
            set
            {
                this._miejsceWyjazdu = value;
            }
        }

        public string MiejsceDocelowe
        {
            get
            {
                return this._miejsceDocelowe;
            }
            set
            {
                this._miejsceDocelowe = value;
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

        public List<Katalog_model> PobierzKatalog()
        {
            List<Katalog_model> _listaKatalogu = new List<Katalog_model>();
            Polacz_z_baza _polacz = new Polacz_z_baza();
            SqlConnection _polaczenie = _polacz.PolaczZBaza();
            SqlCommand _zapytanie = _polacz.UtworzZapytanie("SELECT katalog.id_wycieczki as id,id_katalogu,okres_trwania_wycieczki,id_cennika, " +
                "o.adres + ' ' + o.miejscowosc as odjazd, p.adres + ' ' + p.miejscowosc as przyjazd " +
                "FROM katalog " +
                "inner join miejsce as o on katalog.id_miejsca_odjazdu = o.id_miejsca " +
                "inner join miejsce as p on katalog.id_miejsca_przyjazdu = p.id_miejsca");

            SqlDataReader reader = _zapytanie.ExecuteReader();
            while (reader.Read())
            {
                Katalog_model katalog = new Katalog_model();

                katalog.IdKatalogu = Convert.ToInt32(reader["id_katalogu"]);
                katalog.Okres = Convert.ToInt32(reader["okres_trwania_wycieczki"]);
                katalog.IdCennika = Convert.ToInt32(reader["id_cennika"]);
                katalog.MiejsceWyjazdu = reader["odjazd"].ToString();
                katalog.MiejsceDocelowe = reader["przyjazd"].ToString();
                katalog.IdWycieczki = Convert.ToInt32(reader["id"]);

                _listaKatalogu.Add(katalog);
            }
            _polacz.ZakonczPolaczenie();
            return _listaKatalogu;
        }

    }
}
