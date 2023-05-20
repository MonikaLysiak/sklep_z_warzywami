using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepZWarzywami.Models.DbModels
{
    public class Zakup
    {
        public int ZakupId { get; set; }
        public int SprzedawcaId { get; set; }
        public DateTime Data { get; set; }

        public Zakup() {  }

        public Zakup(int zakupId, Sprzedawca sprzedawca, DateTime data)
        {
            ZakupId = zakupId;
            Sprzedawca = sprzedawca;
            Data = data;
        }
        public virtual ICollection<ZakupJednostkowy> ZakupyJednostkowe { get; set; }
        public Sprzedawca Sprzedawca { get; set; }
    }
}