using SklepZWarzywami.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Razor.Parser.SyntaxTree;

namespace SklepZWarzywami.Models
{
    public class Warzywo
    {
        public int WarzywoId { get; set; }
        public string Nazwa { get; set; }
        public double CenaZaKg { get; set; }
        public double IloscNaStanie { get; set; }

        public Warzywo() { }
        public Warzywo(int warzywoId, string nazwa, double cenaZaKg, double iloscNaStanie)
        {
            WarzywoId = warzywoId;
            Nazwa = nazwa;
            CenaZaKg = cenaZaKg;
            IloscNaStanie = iloscNaStanie;
        }
        public virtual ICollection<ZakupJednostkowy> ZakupyJednostkowe { get; set; }
    }
}