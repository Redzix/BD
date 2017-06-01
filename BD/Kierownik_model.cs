using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BD
{
    public class Kierownik_model : Pracownik_model
    {

        //Dodaj wycieczke
        //edytuj wycieczke
        //usun wycieczke
        //rozpatrz pozytywnie
        //rozpatrz negatywnie

        public bool UsunPojazd(string numerRejestracyjny)
        {
            Polacz_z_baza polacz = new Polacz_z_baza();
            SqlConnection polaczenie = polacz.PolaczZBaza();

            SqlCommand zapytanie = polacz.UtworzZapytanie("DELETE FROM Pojazd WHERE numer_rejestracyjny = '" + numerRejestracyjny + "'");
            zapytanie.ExecuteNonQuery();
            return true;
        }

        public bool EdytujStanPojazdu(string numerRejestracyjny, int stan)
        {
            Polacz_z_baza polacz = new Polacz_z_baza();
            SqlConnection polaczenie = polacz.PolaczZBaza();
            SqlCommand zapytanie = polacz.UtworzZapytanie("UPDATE Pojazd " +
                    "SET " +
                    "stan = " + stan + " " +
                    "WHERE Pojazd.numer_rejestracyjny = '" + numerRejestracyjny + "'");

            try
            {
                zapytanie.ExecuteNonQuery();
                return true;
            }
            catch (SqlException e)
            {
                return false;
            }          
        }

        public bool EdytujDostepnoscPojazdu(string numerRejestracyjny, int dostepnosc)
        {
            Polacz_z_baza polacz = new Polacz_z_baza();
            SqlConnection polaczenie = polacz.PolaczZBaza();
            SqlCommand zapytanie = polacz.UtworzZapytanie("UPDATE Pojazd " +
                    "SET " +
                    "dostepny = " + dostepnosc + " " +
                    "WHERE Pojazd.numer_rejestracyjny = '" + numerRejestracyjny + "'");

            try
            {
                zapytanie.ExecuteNonQuery();
                return true;
            }
            catch (SqlException e)
            {
                return false;
            }
        }
    }
}
