namespace SklepZWarzywami.Migrations
{
    using SklepZWarzywami.Models;
    using SklepZWarzywami.Models.DbModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SklepZWarzywami.Models.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SklepZWarzywami.Models.DatabaseContext context)
        {
            context.Sprzedawcy.AddOrUpdate(x => x.SprzedawcaId,
                    new Sprzedawca() { SprzedawcaId = 1, Imie = "Monika" , Nazwisko = "Łysiak" },
                    new Sprzedawca() { SprzedawcaId = 2, Imie = "Zofia", Nazwisko = "Jaworska" }
                    );

            context.Zakupy.AddOrUpdate(x => x.ZakupId,
                new Zakup()
                {
                    ZakupId = 1,
                    SprzedawcaId = 1,
                    Data = DateTime.Now.ToString(),
                },
                new Zakup()
                {
                    ZakupId = 2,
                    SprzedawcaId = 2,
                    Data = DateTime.Now.ToString(),
                }
                );

            context.Warzywa.AddOrUpdate(x => x.WarzywoId,
                new Warzywo()
                {
                    WarzywoId = 1,
                    Nazwa = "Marchew",
                    CenaZaKg = "3",
                    IloscNaStanie = "100"
                },
                new Warzywo()
                {
                    WarzywoId = 2,
                    Nazwa = "Pomidor",
                    CenaZaKg = "4",
                    IloscNaStanie = "100"
                }
                );

            context.ZakupyJednostkowe.AddOrUpdate(x => x.WarzywoId,
                new ZakupJednostkowy()
                {
                    ZakupJednostkowyId = 1,
                    ZakupId = 1,
                    WarzywoId = 1,
                    Waga = "5",
                    Cena = 15.00,
                },
                new ZakupJednostkowy()
                {
                    ZakupJednostkowyId = 2,
                    ZakupId = 2,
                    WarzywoId = 1,
                    Waga = "5",
                    Cena = 18.00,
                },
                new ZakupJednostkowy()
                {
                    ZakupJednostkowyId = 3,
                    ZakupId = 1,
                    WarzywoId = 2,
                    Waga = "2",
                    Cena = 8.00,
                },
                new ZakupJednostkowy()
                {
                    ZakupJednostkowyId = 4,
                    ZakupId = 2,
                    WarzywoId = 2,
                    Waga = "1",
                    Cena = 4.00,
                }
                );
        }
    }
}
