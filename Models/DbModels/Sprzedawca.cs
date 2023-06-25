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

        [MinLength(2, ErrorMessage = "Zle")]
        public string Imie { get; set; }

        [MinLength(2, ErrorMessage = "Zle")]
        public string Nazwisko { get; set; }


        public Sprzedawca() { }
        public Sprzedawca(int sprzedawcaId, string imie, string nazwisko)
        {
            SprzedawcaId = sprzedawcaId;
            Imie = imie;
            Nazwisko = nazwisko;
        }


        public virtual ICollection<Zakup> Zakupy { get; set; }
    }
}