using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace BD
{
    class Aktualizacja
    {
        private string lastupdate;

        public string ostatniaAktualizacja
        {
            get
            {
                return this.lastupdate;
            }
            set
            {
                this.lastupdate = value;
            }
        }

        public string dataOstatniejAktualizacji()
        {
            Polacz_z_baza _polacz = new Polacz_z_baza();
            SqlConnection _polaczenie = _polacz.PolaczZBaza();
            SqlCommand _zapytanie = _polacz.UtworzZapytanie("select last_user_update from sys.dm_db_index_usage_stats where database_id = DB_ID('baza') order by last_user_update desc");
            SqlDataReader reader = _zapytanie.ExecuteReader();
            reader.Read();
            var tmpupdate = reader["last_user_update"].ToString();
            reader.Close();
            return tmpupdate;
        }

        public bool czyBylaAktualizacja()
        {
            if (this.lastupdate.Equals(dataOstatniejAktualizacji()))
                return false;
            else
            {
                this.lastupdate = dataOstatniejAktualizacji();
                return true;
            }
        }
    }
}
