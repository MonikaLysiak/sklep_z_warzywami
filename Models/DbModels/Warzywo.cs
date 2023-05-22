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


        private double iloscNaStanie;
        public string IloscNaStanie
        {
            get => iloscNaStanie.ToString();
            set
            {
                bool notdate = double.TryParse(value, out iloscNaStanie);
                if (!notdate)
                    iloscNaStanie = 0.00;
            }
        }

        //public double IloscNaStanie { get; set; }

        public Warzywo() { }
        public Warzywo(int warzywoId, string nazwa, double cenaZaKg, string iloscNaStanie)
        {
            WarzywoId = warzywoId;
            Nazwa = nazwa;
            CenaZaKg = cenaZaKg;
            IloscNaStanie = iloscNaStanie;
        }
        public virtual ICollection<ZakupJednostkowy> ZakupyJednostkowe { get; set; }
    }
}