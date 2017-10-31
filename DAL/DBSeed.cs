using DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DBSeed
    {

        public static void Seed(DB dbContext)
        {
            if (!dbContext.Sporsmal.Any())
            {
                dbContext.AddRange(kundebehandlere);

                dbContext.AddRange(sporsmal);

                dbContext.AddRange(skjemaSporsmal);
                dbContext.SaveChanges();
            }
        }

        private static List<Kundebehandler> kundebehandlere = new List<Kundebehandler>
        {
            new Kundebehandler
            {
                Brukernavn ="Ola",
                Passord = new byte[]{ 157, 139, 122, 179, 32, 60, 242, 212, 90, 206, 9, 36, 228, 133, 132, 142, 26, 193, 225, 49, 252, 98, 154, 102, 87, 73, 148, 252, 232, 222, 104, 39 }, //Test1
                Salt = "SALT"
            }

        };

        private static List<SporsmalC> sporsmal = new List<SporsmalC>
        {
            new SporsmalC
            {
                Sporsmal ="Hvordan kan jeg avbestille min reise?",
                Stilt = DateTime.Now.AddDays(-17),
                Svar = new SvarC
                {
                    Svar ="Du kan avbestille reisen din frem til det har gått 48 timer samt gitt at din flygning ikke har hatt avgang."
                }
            },
            new SporsmalC
            {
                Sporsmal ="Hvor mye koster ekstra bagasje?",
                Stilt = DateTime.Now.AddDays(-12),
                Svar = new SvarC
                {
                    Svar ="Bagasje er gratis hos oss",
                    Besvart = DateTime.Now.AddDays(-10),
                    BesvartAv = kundebehandlere.First(),
                }
            },
            new SporsmalC
            {
                Sporsmal ="Selger dere gavekort?",
                Stilt = DateTime.Now.AddDays(-4),
                Svar = new SvarC
                {
                    Svar ="Bagasje er gratis hos oss",
                    Besvart = DateTime.Now.AddDays(-10),
                    BesvartAv = kundebehandlere.First(),
                }
            }
        };

        private static List<SkjemaSporsmal> skjemaSporsmal = new List<SkjemaSporsmal>
        {
            new SkjemaSporsmal
            {
                Epost ="test@email.com",
                Fornavn = "Ola",
                Etternavn ="Nordmann",
                Telefon = "12345678",
                Sporsmal = new SporsmalC
                {
                    Sporsmal ="Dere flyr ikke dit jeg vil. Når vil det komme reiser til Asia?",
                    Stilt = DateTime.Now,
                }
            }
        };
    }
}
