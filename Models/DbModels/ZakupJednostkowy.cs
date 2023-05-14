using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepZWarzywami.Models.DbModels
{
    public class ZakupJednostkowy
    {
        public int ZakupJednostkowyId { get; set; }
        public double Ilosc { get; set; }
        //public Warzywo W { get; set; }
        public double Cena { get; set; }

        public ZakupJednostkowy(double ilosc, Warzywo warzywo)
        {
            Ilosc = ilosc;
            Warzywo = warzywo;
            Cena = warzywo.CenaZaKg * Ilosc;

        }

        // nie jestem pewna czy to tak ma być, poprzednie zakomentowane powyżej
        public int? WarzywoId { get; set; }
        public virtual Warzywo Warzywo { get; set; }

        // powyżej nowa część, możliwe że do modyfikacji

    }
}