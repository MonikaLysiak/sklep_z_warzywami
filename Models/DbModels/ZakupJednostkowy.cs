using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SklepZWarzywami.Models.DbModels
{
    public class ZakupJednostkowy
    {
        public int ZakupJednostkowyId { get; set; }

        //[Compare("Warzywo.IloscNaStanie")]
        //[MinLength(5, ErrorMessage = "Zle")]
        public Warzywo Warzywo { get; set; }

        //[Compare("ZakupId")]
        public double Waga { get ; set; }
        public int ZakupId { get; set; }
        public int WarzywoId { get; set; }
        public double Cena { get; set; }

        public ZakupJednostkowy() { }

        // apparently we do not use this
        public ZakupJednostkowy(double waga, Warzywo warzywo, Zakup zakup)
        {
            if (waga > warzywo.IloscNaStanie)
                throw new ArgumentException("Brak na stanie");
            Waga = waga;
            warzywo.IloscNaStanie -= waga;
            Warzywo = warzywo;
            Cena = warzywo.CenaZaKg * Waga;
            Zakup = zakup;
        }
        public Zakup Zakup { get; set; }
    }
}