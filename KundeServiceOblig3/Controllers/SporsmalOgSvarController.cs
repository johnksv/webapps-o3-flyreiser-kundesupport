using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.DBModel;
using KundeServiceOblig3.Models;
using System;

namespace KundeServiceOblig3.Controllers
{
    [Produces("application/json")]
    public class SporsmalOgSvarController : Controller
    {
        private readonly DB db;

        public SporsmalOgSvarController(DB dbContext)
        {
            db = dbContext;
        }


        [Route("api/kategoriermedsvar")]
        [HttpGet]
        public IActionResult GetKategorierMedSvar()
        {
            var kategoriListe = db.Kategorier
                .Include(kat => kat.SporsmalOgSvar).ThenInclude(s => s.Sporsmal)
                .Include(kat => kat.SporsmalOgSvar).ThenInclude(s => s.Svar)
                .Include(kat => kat.SporsmalOgSvar).ThenInclude(s => s.Svar.BesvartAvKundebehandler)
                .Include(kat => kat.SporsmalOgSvar).ThenInclude(s => s.Kunde).ToList();
            foreach (var kategori in kategoriListe)
            {
                //Må sette navigasjons-propertyene til null for at JSON formateres korrekt
                foreach (var sporsmalSvar in kategori.SporsmalOgSvar)
                {
                    sporsmalSvar.Kategori = null;
                    if (sporsmalSvar.Svar != null)
                    {
                        sporsmalSvar.Svar.BesvartAv = sporsmalSvar.Svar.BesvartAvKundebehandler.Brukernavn;
                        sporsmalSvar.Svar.BesvartAvKundebehandler = null;
                    }
                    if (sporsmalSvar.Kunde != null)
                    {
                        sporsmalSvar.Kunde.Sporsmal = null;
                    }
                }
            }

            return Ok(kategoriListe);
        }

        [Route("api/sporsmalogsvar")]
        [HttpPost]
        public IActionResult PostSporsmal([FromBody] SkjemaSporsmalView innSkjemaSporsmal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kunde = new Kunde
            {
                Fornavn = innSkjemaSporsmal.Fornavn,
                Etternavn = innSkjemaSporsmal.Etternavn,
                Epost = innSkjemaSporsmal.Epost,
                Telefon = innSkjemaSporsmal.Telefon,
            };
            var skjemasporsmal = new SporsmalOgSvar
            {
                Sporsmal = new SporsmalC
                {
                    Sporsmal = innSkjemaSporsmal.Sporsmal,
                    Stilt = DateTime.Now
                },
                Kunde = kunde
            };

            db.SporsmalOgSvar.Add(skjemasporsmal);
            db.SaveChanges();

            return CreatedAtAction("GetSkjemaSporsmal", new { id = skjemasporsmal.ID }, skjemasporsmal);
        }

        private bool SporsmalCExists(int id)
        {
            return db.Sporsmal.Any(e => e.ID == id);
        }
    }
}