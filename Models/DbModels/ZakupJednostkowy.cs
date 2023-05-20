using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepZWarzywami.Models.DbModels
{
    public class ZakupJednostkowy
    {
        public int ZakupJednostkowyId { get; set; }
        public double Waga { get; set; }
        public int ZakupId { get; set; }
        public int WarzywoId { get; set; }
        public double Cena { get; set; }

        public ZakupJednostkowy() { }
        public ZakupJednostkowy(double waga, Warzywo warzywo, Zakup zakup)
        {
            Waga = waga;
            Warzywo = warzywo;
            Cena = warzywo.CenaZaKg * Waga;
            Zakup = zakup;
        }
        public Zakup Zakup { get; set; }
        public Warzywo Warzywo { get; set; }
    }
}