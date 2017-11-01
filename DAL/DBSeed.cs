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
            dbContext.Database.EnsureCreated();

            if (dbContext.Sporsmal.Any())
            {
                return;
            }
            var kundebehandler = new Kundebehandler
            {
                Brukernavn = "Ola",
                Passord = new byte[] { 157, 139, 122, 179, 32, 60, 242, 212, 90, 206, 9, 36, 228, 133, 132, 142, 26, 193, 225, 49, 252, 98, 154, 102, 87, 73, 148, 252, 232, 222, 104, 39 }, //Test1
                Salt = "SALT"
            };

            var sporsmalA = new SporsmalC
            {
                Sporsmal = "Hvordan kan jeg avbestille min reise?",
                Stilt = DateTime.Now.AddDays(-17)
            };

            var sporsmalB = new SporsmalC
            {
                Sporsmal = "Hvor mye koster ekstra bagasje?",
                Stilt = DateTime.Now.AddDays(-12)
            };
            var sporsmalC = new SporsmalC
            {
                Sporsmal = "Selger dere gavekort?",
                Stilt = DateTime.Now.AddDays(-4)
            };
            var sporsmalD = new SporsmalC
            {
                Sporsmal = "Dere flyr ikke dit jeg vil. Når vil det komme reiser til Asia?",
                Stilt = DateTime.Now
            };
            var svarA = new SvarC
            {
                Svar = "Du kan avbestille reisen din frem til det har gått 48 timer samt gitt at din flygning ikke har hatt avgang.",
                Besvart = DateTime.Now.AddDays(-7),
                BesvartAv = kundebehandler
            };
            var svarB = new SvarC
            {
                Svar = "Bagasje er gratis hos oss",
                Besvart = DateTime.Now.AddDays(-10),
                BesvartAv = kundebehandler
            };

            var svarC = new SvarC
            {
                Svar = "Bagasje er gratis hos oss",
                Besvart = DateTime.Now.AddDays(-10),
                BesvartAv = kundebehandler
            };
            /* svarA.Sporsmal = sporsmalA;
            svarB.Sporsmal = sporsmalB;
            svarC.Sporsmal = sporsmalC; */
            

            var skjemaSporsmal = new SkjemaSporsmal
            {
                Epost = "test@email.com",
                Fornavn = "Ola",
                Etternavn = "Nordmann",
                Telefon = "12345678",
                Sporsmal = sporsmalD
            };

            dbContext.Kundebehandlere.Add(kundebehandler);
            dbContext.Sporsmal.Add(sporsmalA);
            dbContext.Sporsmal.Add(sporsmalB);
            dbContext.Sporsmal.Add(sporsmalC);
            dbContext.Sporsmal.Add(sporsmalD);
            dbContext.Svar.Add(svarA);
            dbContext.Svar.Add(svarB);
            dbContext.Svar.Add(svarC);

            dbContext.SkjemaSporsmal.Add(skjemaSporsmal);
            try
            {

                dbContext.SaveChanges();
            }
            catch (Exception e)
            {

            }

        }

    }
}
