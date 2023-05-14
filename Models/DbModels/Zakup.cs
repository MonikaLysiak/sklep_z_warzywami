using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepZWarzywami.Models.DbModels
{
    public class Zakup
    {
        public int ZakupId { get; set; }

        public List<ZakupJednostkowy> ZakupyJednostkowe = new List<ZakupJednostkowy>();
        //public int SprzedawcaId { get; set; }
        public double KwotaCalkowita { get; set; }
        public Zakup(int numerZakupu, List<ZakupJednostkowy> zakupy, int sprzedawcaId)
        {
            ZakupId = numerZakupu;
            ZakupyJednostkowe = zakupy;
            SprzedawcaId = sprzedawcaId;

            KwotaCalkowita = zakupy.Sum(z => z.Cena);
        }
        public int? ZakupJednostkowyId { get; set; }
        public virtual ZakupJednostkowy ZakupJednostkowy { get; set; }
        public int? SprzedawcaId { get; set; }
        public virtual Sprzedawca Sprzedawca { get; set; }

    }
}