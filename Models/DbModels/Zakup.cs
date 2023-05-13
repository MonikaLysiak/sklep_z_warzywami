using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepZWarzywami.Models.DbModels
{
    public class Zakup
    {
        public int NumerZakupu { get; set; }
        public List<ZakupJednostkowy> Zakupy = new List<ZakupJednostkowy>();
        public int SprzedawcaId { get; set; }
        public double KwotaCalkowita { get; set; }
        public Zakup(int numerZakupu, List<ZakupJednostkowy> zakupy, int sprzedawcaId)
        {
            NumerZakupu = numerZakupu;
            Zakupy = zakupy;
            SprzedawcaId = sprzedawcaId;

            KwotaCalkowita = zakupy.Sum(z => z.Cena);
        }

    }
}