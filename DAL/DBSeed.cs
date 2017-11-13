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

            var svarA = new SvarC
            {
                Svar = "Du kan avbestille reisen din frem til det har gått 48 timer samt gitt at din flygning ikke har hatt avgang.",
                Besvart = DateTime.Now.AddDays(-7),
                BesvartAv = "Ola"
            };
            var svarB = new SvarC
            {
                Svar = "Bagasje er gratis hos oss",
                Besvart = DateTime.Now.AddDays(-10),
                BesvartAv = "Ola"
            };

            var svarC = new SvarC
            {
                Svar = "Ja! Gavekort selges i alle butikker i hele Norge, med unntak av de butikkene der det ikke selges.",
                Besvart = DateTime.Now.AddDays(-10),
                BesvartAv = "Ola"
            };
            var svarD = new SvarC
            {
                Svar = "Kostnaden for bagasje bestemmes av destinasjon.",
                Besvart = DateTime.Now,
                BesvartAv = "Ola"
            };
            var svarE = new SvarC
            {
                Svar = "Ekstra bagasje kan bestilles ved å kontakte oss med kontaksskjemaet.",
                Besvart = DateTime.Now,
                BesvartAv = "Ola"
            };
            var svarF = new SvarC
            {
                Svar = "Du kan medbringe musikkinstrument hvis ønskelig. Det fraktes i henhold til spesielle betingelser, vennligst les mer her.",
                Besvart = DateTime.Now,
                BesvartAv = "Ola"
            };
            var svarG = new SvarC
            {
                Svar = "Spedbarn (under 2 år) uten eget flysete kan ha med seg inntil fem kilo innsjekket bagasje uten ekstra kostnad (enten i foreldrenes innsjekkede bagasje eller i en separat bag). Vanlig regler for innsjekket bagasje gjelder for barn/spedbarn med eget sete.",
                Besvart = DateTime.Now,
                BesvartAv = "Ola"
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
                Sporsmal = "Hvor mye koster ekstra bagasje?",
                Stilt = DateTime.Now
            };
            var sporsmalE = new SporsmalC
            {
                Sporsmal = "Hvordan kan jeg bestille ekstra bagasje?",
                Stilt = DateTime.Now
            };
            var sporsmalF = new SporsmalC
            {
                Sporsmal = "Hvordan reiser jeg med musikkinstrument?",
                Stilt = DateTime.Now
            };
            var sporsmalG = new SporsmalC
            {
                Sporsmal = "Hvor mye bagasje kan jeg ta med for et barn?",
                Stilt = DateTime.Now
            };
            //Brukersporsmal
            var sporsmalH = new SporsmalC
            {
                Sporsmal = "Dere flyr ikke dit jeg vil. Når vil det komme reiser til Asia?",
                Stilt = DateTime.Now
            };
            var generelt = new Kategori
            {
                Navn = "Generelt"
            };
            var bagasje = new Kategori
            {
                Navn = "Bagasje"
            };

            var sporsmalSvarA = new SporsmalOgSvar
            {
                Sporsmal = sporsmalA,
                Svar = svarA,
                Kategori = generelt
            };
            var sporsmalSvarB = new SporsmalOgSvar
            {
                Sporsmal = sporsmalB,
                Svar = svarB,
                Kategori = generelt
            };
            var sporsmalSvarC = new SporsmalOgSvar
            {
                Sporsmal = sporsmalC,
                Svar = svarC,
                Kategori = generelt
            };
            var sporsmalSvarD = new SporsmalOgSvar
            {
                Sporsmal = sporsmalD,
                Svar = svarD,
                Kategori = bagasje
            };
            var sporsmalSvarE = new SporsmalOgSvar
            {
                Sporsmal = sporsmalE,
                Svar = svarE,
                Kategori = bagasje
            };
            var sporsmalSvarF = new SporsmalOgSvar
            {
                Sporsmal = sporsmalF,
                Svar = svarF,
                Kategori = bagasje
            };
            var sporsmalSvarG = new SporsmalOgSvar
            {
                Sporsmal = sporsmalG,
                Svar = svarG,
                Kategori = bagasje
            };

            var kunde = new Kunde
            {
                Epost = "test@email.com",
                Fornavn = "Ola",
                Etternavn = "Nordmann",
                Telefon = "12345678",
            };
            var sporsmalSvarH = new SporsmalOgSvar
            {
                Sporsmal = sporsmalH,
                Kunde = kunde,
                Kategori = new Kategori()
            };

            dbContext.SporsmalOgSvar.Add(sporsmalSvarA);
            dbContext.SporsmalOgSvar.Add(sporsmalSvarC);
            dbContext.SporsmalOgSvar.Add(sporsmalSvarB);
            dbContext.SporsmalOgSvar.Add(sporsmalSvarD);
            dbContext.SporsmalOgSvar.Add(sporsmalSvarE);
            dbContext.SporsmalOgSvar.Add(sporsmalSvarF);
            dbContext.SporsmalOgSvar.Add(sporsmalSvarG);
            dbContext.SporsmalOgSvar.Add(sporsmalSvarH);

            dbContext.SaveChanges();
        }

    }
}
