﻿using SklepZWarzywami.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Razor.Parser.SyntaxTree;

namespace SklepZWarzywami.Models
{
    public class Warzywo
    {
        [DisplayName("ID Warzywa")]
        public int WarzywoId { get; set; }
        public string Nazwa { get; set; }

        private double cenaZaKg;

        [DisplayName("Cena za kg")]
        public string CenaZaKg
        {
            get => cenaZaKg.ToString();
            set
            {
                bool notdate = double.TryParse(value, out cenaZaKg);
                if (!notdate)
                    cenaZaKg = 1.00;
            }
        }

        private double iloscNaStanie;
        [DisplayName("Ilość na stanie")]
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


        public Warzywo() { }
        public Warzywo(int warzywoId, string nazwa, string cenaZaKg, string iloscNaStanie)
        {
            WarzywoId = warzywoId;
            Nazwa = nazwa;
            CenaZaKg = cenaZaKg;
            IloscNaStanie = iloscNaStanie;
        }


        public virtual ICollection<ZakupJednostkowy> ZakupyJednostkowe { get; set; }
    }
}