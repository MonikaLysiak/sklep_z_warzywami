using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.EnterpriseServices;
using System.Globalization;
using System.Linq;
using System.Web;

namespace SklepZWarzywami.Models.DbModels
{
    public class Zakup
    {
        [DisplayName("ID Zakupu")]
        public int ZakupId { get; set; }

        [DisplayName("ID Sprzedawcy")]
        public int SprzedawcaId { get; set; }

        private DateTime data;
        public string Data { get => data.ToString();
            set
            {
                bool notdate = DateTime.TryParse(value, out data);
                if (!notdate)
                    data = DateTime.Now;
            }
        }


        public Zakup() {  }
        public Zakup(int zakupId, Sprzedawca sprzedawca, string data)
        {
            ZakupId = zakupId;
            Sprzedawca = sprzedawca;
            Data = data;
        }


        public virtual List<ZakupJednostkowy> ZakupyJednostkowe { get; set; }
        public virtual Sprzedawca Sprzedawca { get; set; }


        public double ObliczSumę()
        {
            return ZakupyJednostkowe.Sum(z => z.Cena);
        }
    }
}