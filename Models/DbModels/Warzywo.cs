using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Razor.Parser.SyntaxTree;

namespace SklepZWarzywami.Models
{
    public class Warzywo
    {
        public int WarzywoId { get; set; } //komentarz komentarz2
        public string Nazwa { get; set; }
        public double CenaZaKg { get; set; }


        public Warzywo() { }
        public Warzywo(int warzywoId, string nazwa, double cenaZaKg)
        {
            WarzywoId = warzywoId;
            Nazwa = nazwa;
            CenaZaKg = cenaZaKg;
        }
    }
}