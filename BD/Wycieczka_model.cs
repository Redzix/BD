using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BD
{
    public class Wycieczka_model
    {
        private int _idWycieczki;
        private string _nazwa;
        private DateTime _dataWyjazdu;
        private DateTime _dataPowrotu;
        private string _opis;

        //nie tak ma byc, ale jest najprosciej
        private string _kierowca;
        private string _pilot;
        private string _pojazd;

        public Wycieczka_model(){}

        ~Wycieczka_model(){}

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

        public string Nazwa
        {
            get
            {
                return this._nazwa;
            }
            set
            {
                this._nazwa = value;
            }
        }

        public DateTime DataWyjazdu
        {
            get
            {
                return this._dataWyjazdu;
            }
            set
            {
                this._dataWyjazdu = value;
            }
        }

        public DateTime DataPowrotu
        {
            get
            {
                return this._dataPowrotu;
            }
            set
            {
                this._dataPowrotu = value;
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

        public string Kierowca
        {
            get
            {
                return this._kierowca;
            }
            set
            {
                this._kierowca = value;
            }
        }

        public string Pilot
        {
            get
            {
                return this._pilot;
            }
            set
            {
                this._pilot = value;
            }
        }

        public string Pojazd
        {
            get
            {
                return this._pojazd;
            }
            set
            {
                this._pojazd = value;
            }
        }

        public List<Wycieczka_model> PobierzWycieczki()
        {
            List<Wycieczka_model> _listaWycieczek = new List<Wycieczka_model>();
            Polacz_z_baza _polacz = new Polacz_z_baza();
            SqlConnection _polaczenie = _polacz.PolaczZBaza();
            SqlCommand _zapytanie = _polacz.UtworzZapytanie("SELECT id_wycieczki,nazwa,data_wyjazdu," +
                "data_powrotu,opis,p.imie + ' '+ p.nazwisko as pil,k.imie + ' '+ k.nazwisko as kiero " +
                "from wycieczka inner join pilot as p on wycieczka.pilot_pesel = p.pesel " +
                "inner join kierowca as k on wycieczka.kierowca_pesel = k.pesel ");

            SqlDataReader reader = _zapytanie.ExecuteReader();
            while (reader.Read())
            {
                Wycieczka_model wycieczka = new Wycieczka_model();

                wycieczka.IdWycieczki = Convert.ToInt32(reader["id_wycieczki"]);
                wycieczka.Nazwa = reader["nazwa"].ToString();
                wycieczka.DataPowrotu = Convert.ToDateTime(reader["data_powrotu"]);
                wycieczka.DataWyjazdu = Convert.ToDateTime(reader["data_wyjazdu"]);
                wycieczka.Opis = reader["opis"].ToString();
                wycieczka.Kierowca = reader["kiero"].ToString();
                wycieczka.Pilot = reader["pil"].ToString();

                _listaWycieczek.Add(wycieczka);
            }
            _polacz.ZakonczPolaczenie();
            return _listaWycieczek;
        }
        //Dodaj wycieczke
        //edytuj wycieczke

        public bool DodajWycieczke(Wycieczka_model wycieczka, string miejsceWyjazdu, string miejsceDocelowe, decimal cena)
        {
            Polacz_z_baza polacz = new Polacz_z_baza();
            SqlConnection polaczenie = polacz.PolaczZBaza();

            SqlCommand zapytanieWycieczka = polacz.UtworzZapytanie("INSERT INTO Wycieczka " +
                "(id_wycieczki,nazwa,data_wyjazdu,data_powrotu,opis,Pilot_pesel,Pojazd_numer_rejestracyjny," +
                "Kierowca_pesel) " +
                "VALUES("+ wycieczka.IdWycieczki + ",'" + wycieczka.Nazwa + "','" + wycieczka.DataWyjazdu + "','" +
                 wycieczka.DataPowrotu + "','" + wycieczka.Opis + "'," +
                "(SELECT Pilot.pesel FROM Pilot WHERE (Pilot.imie + ' ' + Pilot.nazwisko) LIKE '" + wycieczka.Pilot + "')," +
                "'" + wycieczka.Pojazd + "'," +
                "(SELECT Kierowca.pesel FROM Kierowca WHERE (Kierowca.imie + ' ' + Kierowca.nazwisko) LIKE '" + wycieczka.Kierowca + "'))");

            SqlCommand zapytanieCennik = polacz.UtworzZapytanie("INSERT INTO Cennik " +
                "VALUES((SELECT COUNT(*) + 1 FROM Cennik)," + cena + ",'0001-01-01','0001-01-01')");

            SqlCommand zapytanieKatalog = polacz.UtworzZapytanie("INSERT INTO Katalog " +
                "VALUES((SELECT COUNT(*) + 1 FROM Katalog)," +
                "(SELECT datediff(day,data_wyjazdu,data_powrotu) FROM Wycieczka WHERE Wycieczka.id_wycieczki = " + wycieczka.IdWycieczki + ")," +
                "(SELECT MAX(id_cennika) FROM Cennik), " +
                "(SELECT id_miejsca FROM Miejsce WHERE adres + ' ' + miejscowosc = '" + miejsceWyjazdu + "')," +
                "(SELECT id_miejsca FROM Miejsce WHERE adres + ' ' + miejscowosc = '" + miejsceDocelowe + "')," + wycieczka.IdWycieczki + ")");

            try
            {
                zapytanieWycieczka.ExecuteNonQuery();
                zapytanieCennik.ExecuteNonQuery();
                zapytanieKatalog.ExecuteNonQuery();
                return true;
            }catch(SqlException e)
            {
                return false;
            }
             
        }

        public bool EdytujWycieczke(Wycieczka_model wycieczka, string miejsceWyjazdu, decimal cena)
        {
            Polacz_z_baza polacz = new Polacz_z_baza();
            SqlConnection polaczenie = polacz.PolaczZBaza();

            SqlCommand zapytanieWycieczka = polacz.UtworzZapytanie("UPDATE Wycieczka " +
                "SET " +
                "opis = '" + wycieczka.Opis + "', " +
                "Pilot_pesel = (SELECT Pilot.pesel FROM Pilot WHERE (Pilot.imie + ' ' + Pilot.nazwisko) LIKE '" + wycieczka.Pilot + "'), " +
                "Kierowca_pesel = (SELECT Kierowca.pesel FROM Kierowca WHERE (Kierowca.imie + ' ' + Kierowca.nazwisko) LIKE '" + wycieczka.Kierowca + "'), " +
                "Pojazd_numer_rejestracyjny = '" + wycieczka.Pojazd + "' " +
                "FROM Wycieczka " +
                "WHERE id_wycieczki = " + IdWycieczki);

            SqlCommand zapytanieCennik = polacz.UtworzZapytanie("UPDATE Cennik " +
                "SET cena = " + cena + " " +
                "FROM Cennik " +
                "INNER JOIN Katalog ON Katalog.id_cennika = Cennik.id_cennika " +
                "WHERE Katalog.id_wycieczki = " + IdWycieczki);

            SqlCommand zapytanieKatalog = polacz.UtworzZapytanie("UPDATE Katalog " +
                "SET " +
                "id_miejsca_odjazdu = (SELECT id_miejsca FROM Miejsce WHERE adres + ' ' + miejscowosc = '" + miejsceWyjazdu + "'), " +
                "okres_trwania_wycieczki = datediff(day,data_wyjazdu,data_powrotu) " +
                "FROM Katalog " +
                "INNER JOIN Wycieczka ON Wycieczka.id_wycieczki = Katalog.id_wycieczki " +
                "WHERE Katalog.id_wycieczki = " + IdWycieczki);

            try
            {
                zapytanieWycieczka.ExecuteNonQuery();
                zapytanieCennik.ExecuteNonQuery();
                zapytanieKatalog.ExecuteNonQuery();
                return true;
            }
            catch (SqlException e)
            {
                return false;
            }
        }

    }
}
