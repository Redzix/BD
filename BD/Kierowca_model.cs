using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BD
{
    public class Kierowca_model : Pracownik_model
    {
        public List<Kierowca_model> pobierzKierowcow()
        {
            List<Kierowca_model> _listaKierowcow = new List<Kierowca_model>();
            Polacz_z_baza _polacz = new Polacz_z_baza();
            SqlConnection _polaczenie = _polacz.PolaczZBaza();
            SqlCommand _zapytanie = _polacz.UtworzZapytanie("SELECT * FROM Kierowca");

            SqlDataReader reader = _zapytanie.ExecuteReader();
            while (reader.Read())
            {
                Kierowca_model kierowca = new Kierowca_model();

                kierowca.NumerPesel = reader["pesel"].ToString();
                kierowca.Imie = reader["imie"].ToString();
                kierowca.Nazwisko = reader["nazwisko"].ToString();
                kierowca.Adres = reader["ulica"].ToString();
                kierowca.Miejscowosc = reader["miejscowosc"].ToString();

                _listaKierowcow.Add(kierowca);
            }
            _polacz.ZakonczPolaczenie();
            return _listaKierowcow;
        }

        public bool DodajZmianeStanu(int stan, string numerRejestracyjny)
        {
            Polacz_z_baza _polacz = new Polacz_z_baza();
            SqlConnection _polaczenie = _polacz.PolaczZBaza();

            if (stan == 1)
            {
                SqlCommand _zapytanie = _polacz.UtworzZapytanie("UPDATE Pojazd SET stan = 1 WHERE numer_rejestracyjny = '" + numerRejestracyjny + "'");
                _zapytanie.ExecuteNonQuery();
                return true;
            }
            else if (stan == 0)
            {
                SqlCommand _zapytanie = _polacz.UtworzZapytanie("UPDATE Pojazd SET stan = 0 WHERE numer_rejestracyjny = '" + numerRejestracyjny +  "'");
                _zapytanie.ExecuteNonQuery();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
