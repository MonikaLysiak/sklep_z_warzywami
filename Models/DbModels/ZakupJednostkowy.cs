using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SklepZWarzywami.Models.DbModels
{
    public class ZakupJednostkowy
    {
        [DisplayName("ID zakupu jednostkowego")]
        public int ZakupJednostkowyId { get; set; }

        private double waga;
        public string Waga
        {
            get => waga.ToString();
            set
            {
                bool notdate = double.TryParse(value, out waga);
                if (!notdate)
                    waga = 0.00;
            }
        }

        [DisplayName("ID zakupu")]
        public int ZakupId { get; set; }

        [DisplayName("ID warzywa")]
        public int WarzywoId { get; set; }

        public double Cena { get; set; }


        public ZakupJednostkowy() { }
        public ZakupJednostkowy(double waga, Warzywo warzywo, Zakup zakup)
        {
            if (waga > double.Parse(warzywo.IloscNaStanie))
                throw new ArgumentException("Brak na stanie");
            Waga = waga.ToString();
            warzywo.IloscNaStanie = (double.Parse(warzywo.IloscNaStanie) - waga).ToString();
            Warzywo = warzywo;
            Cena = double.Parse(warzywo.CenaZaKg) * this.waga;
            Zakup = zakup;
        }


        public virtual Zakup Zakup { get; set; }

        public virtual Warzywo Warzywo { get; set; }
    }
}