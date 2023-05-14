using SklepZWarzywami.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SklepZWarzywami.Models
{
	public class DatabaseContext : DbContext
	{
        public DatabaseContext() : base("SklepZWarzywamiConnectionString") { }

        public DbSet<Sprzedawca> Sprzedawcy { get; set; }
        public DbSet<Warzywo> Warzywa { get; set; }
        public DbSet<ZakupJednostkowy> ZakupyJednostkowe { get; set; }
        public DbSet<Zakup> Zakupy { get; set; }

    }
}