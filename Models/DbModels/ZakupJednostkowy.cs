using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepZWarzywami.Models.DbModels
{
    public class ZakupJednostkowy
    {
        public double Ilosc { get; set; }
        public Warzywo W { get; set; }
        public double Cena { get; set; }

        public ZakupJednostkowy(double ilosc, Warzywo w)
        {
            Ilosc = ilosc;
            W = w;
            Cena = w.CenaZaKg * Ilosc;

        }
    }
}