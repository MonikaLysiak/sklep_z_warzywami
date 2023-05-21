using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace SklepZWarzywami.Models.DbModels
{
    public class Zakup
    {
        public int ZakupId { get; set; }
        public int SprzedawcaId { get; set; }

        public DateTime data;
        public DateTime Data { get => data; set => data =value; }

        public Zakup() {  }
        public Zakup(int zakupId, Sprzedawca sprzedawca, string data)
        {
            ZakupId = zakupId;
            Sprzedawca = sprzedawca;

            if (!DateTime.TryParseExact(data, new[] { "dd.MM.yyyy HH:mm", "dd/MM/yyyy HH:mm", "dd-MM-yyyy HH:mm", "yyyy.MM.dd HH:mm", "yyyy.MM.dd" + "at" + "HH:mm" }, null, DateTimeStyles.None, out this.data))
                Data = DateTime.Now;
        }
        public virtual ICollection<ZakupJednostkowy> ZakupyJednostkowe { get; set; }
        public Sprzedawca Sprzedawca { get; set; }
    }
}