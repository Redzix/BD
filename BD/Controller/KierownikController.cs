using BD.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.Controller
{
    class KierownikController
    {
        object view;
        bazaEntities db;
        public KierownikController(object view)
        {
            this.view = view;
            db = new bazaEntities();
        }

        /**
         */
        public bool dodajPromocje(int idKatalog)
        {
            var wycieczka = (from katalog in db.Katalog
                            where katalog.id_katalogu == idKatalog
                            select katalog.Wycieczka).FirstOrDefault();
            var promocja = new Promocja
            {
                cena = decimal.Parse(((PromocjaView)view).tb_kwota.Text)
            };
            promocja.Wycieczka = wycieczka;
            try
            {
                db.Promocja.Add(promocja);
                db.SaveChanges();
            } catch
            {
                return false;
            }
            return true;
        }
        public bool ladujPromocje(int idKatalogu)
        {
            var idWyc = db.Katalog.Where(x => x.id_katalogu == idKatalogu).Select(x => x.id_wycieczki).FirstOrDefault();
            if (db.Promocja.Any(x=>x.id_wycieczki == idWyc))
            {
                ((PromocjaView)view).tb_kwota.Text = db.Promocja.Where(x => x.id_wycieczki == idWyc).Select(x => x.cena).FirstOrDefault().ToString();
                return true;
            }
            return false;
        }
        
        public bool edytujPromocje(int idKatalogu)
        {
            PromocjaView pView = ((PromocjaView)view);
            if (pView.tb_kwota.Text.Equals(""))
            {
                return this.usunPromocje(idKatalogu);
            }
            else
            {
                try
                {
                    var edit = (from katalog in db.Katalog
                                where katalog.id_katalogu == idKatalogu
                                select katalog.Wycieczka.Promocja).FirstOrDefault();
                    edit.cena = decimal.Parse(pView.tb_kwota.Text);
                    db.SaveChanges();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        public bool usunPromocje(int idKatalogu)
        {
            var idWyc = db.Katalog.Where(x => x.id_katalogu == idKatalogu).Select(x => x.id_wycieczki).FirstOrDefault();
            var promoDoUsuniecia = new Promocja { id_wycieczki = (int)idWyc };
            try
            {
                db.Entry(promoDoUsuniecia).State = EntityState.Deleted;
                db.SaveChanges();
            } catch
            {
                return false;
            }
            return true;
        }
    }
}
