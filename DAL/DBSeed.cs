﻿using DAL.DBModel;
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
            var svarA = new SvarC
            {
                Svar = "Du kan avbestille reisen din frem til det har gått 48 timer samt gitt at din flygning ikke har hatt avgang.",
                Besvart = DateTime.Now.AddDays(-7),
                BesvartAvKundebehandler = kundebehandler
            };
            var svarB = new SvarC
            {
                Svar = "Bagasje er gratis hos oss",
                Besvart = DateTime.Now.AddDays(-10),
                BesvartAvKundebehandler = kundebehandler
            };

            var svarC = new SvarC
            {
                Svar = "Bagasje er gratis hos oss",
                Besvart = DateTime.Now.AddDays(-10),
                BesvartAvKundebehandler = kundebehandler
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

            var sporsmalSvarA = new SporsmalOgSvar
            {
                Sporsmal = sporsmalA,
                Svar = svarA
            };
            var sporsmalSvarB = new SporsmalOgSvar
            {
                Sporsmal = sporsmalB,
                Svar = svarB
            };
            var sporsmalSvarC = new SporsmalOgSvar
            {
                Sporsmal = sporsmalC,
                Svar = svarC
            };
            var sporsmalSvarD = new SporsmalOgSvar
            {
                Sporsmal = sporsmalD
            };


            var skjemaSporsmal = new SkjemaSporsmal
            {
                Epost = "test@email.com",
                Fornavn = "Ola",
                Etternavn = "Nordmann",
                Telefon = "12345678",
                SporsmalOgSvar = sporsmalSvarD
            };

            dbContext.Kundebehandlere.Add(kundebehandler);
            /* dbContext.Svar.Add(svarA);
            dbContext.Svar.Add(svarB);
            dbContext.Svar.Add(svarC);
            dbContext.Sporsmal.Add(sporsmalA);
            dbContext.Sporsmal.Add(sporsmalB);
            dbContext.Sporsmal.Add(sporsmalC);
            dbContext.Sporsmal.Add(sporsmalD); */
            dbContext.SporsmalOgSvar.Add(sporsmalSvarA);
            dbContext.SporsmalOgSvar.Add(sporsmalSvarC);
            dbContext.SporsmalOgSvar.Add(sporsmalSvarB);
            dbContext.SporsmalOgSvar.Add(sporsmalSvarD);

            dbContext.SkjemaSporsmal.Add(skjemaSporsmal);

            dbContext.SaveChanges();
        }

    }
}
