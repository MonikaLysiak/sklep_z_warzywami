using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace SklepZWarzywami.Models.DbModels
{
    public class Sprzedawca
    {
        public int SprzedawcaId { get; set; }

        //[MinLength(5, ErrorMessage = "Zle")]
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public List<Zakup> Transakcje { get; set; } = new List<Zakup>();

        public Sprzedawca() { }

        public Sprzedawca(int sprzedawcaId, string imie, string nazwisko, List<Zakup> transakcje)
        {
            SprzedawcaId = sprzedawcaId;
            Imie = imie;
            Nazwisko = nazwisko;
            Transakcje = transakcje;
        }

        public int? ZakupId { get; set; }
        public virtual Zakup Zakup { get; set; }
    }
}