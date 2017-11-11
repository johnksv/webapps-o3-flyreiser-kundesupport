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
    [Route("api/sporsmalogsvar")]
    public class SporsmalOgSvarController : Controller
    {
        private readonly DB db;

        public SporsmalOgSvarController(DB dbContext)
        {
            db = dbContext;
        }

        /// <summary>
        ///   JSON-objektet vil se slik ut:
        ///[  
        ///  {  
        ///     "navn":"Generelt",
        ///     "sporsmalOgSvar":[  
        ///        {  
        ///           "id":2,
        ///           "sporsmal":{  
        ///              "id":1,
        ///              "sporsmal":"Hvordan kan jeg avbestille min reise?",
        ///              "stilt":"2017-10-22T13:15:47.7968554"
        ///           },
        ///           "svar":{  
        ///              "id":1,
        ///              "svar":"Du kan avbestille reisen din frem til det har gått 48 timer samt gitt at din flygning ikke har hatt avgang.",
        ///              "besvartAvKundebehandler":null,
        ///              "besvart":"2017-11-01T13:15:47.791514",
        ///              "besvartAv":"Ola"
        ///           },
        ///           "kategori":null,
        ///           "publisert":true,
        ///           "kunde":null
        ///        }
        ///     ]
        ///  }
        ///]
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetSporsmal()
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

        [HttpGet("{id}")]
        public IActionResult GetSporsmalMedSvar([FromRoute] int id)
        {
            var sporsmalSvar = db.SporsmalOgSvar.SingleOrDefault(m => m.Sporsmal.ID == id);

            if (sporsmalSvar != null)
            {
                return Ok(sporsmalSvar);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult PostSporsmal([FromBody] SkjemaSporsmalView innSkjemaSporsmal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var kunde = db.Kunder.Where(k => k.Epost == innSkjemaSporsmal.Epost).FirstOrDefault();
            if (kunde == null)
            {
                kunde = new Kunde
                {
                    Fornavn = innSkjemaSporsmal.Fornavn,
                    Etternavn = innSkjemaSporsmal.Etternavn,
                    Epost = innSkjemaSporsmal.Epost,
                    Telefon = innSkjemaSporsmal.Telefon,
                };
            }else
            {
                db.Kunder.Attach(kunde);
            }

            //Brukerspørsmål skal egentlig bli laget i DBseed, men legger inn denne som backup i tilfelelt man ikke kjører dbSeed
            var kategori = db.Kategorier.Where(k => k.Navn == "Brukerspørsmål").FirstOrDefault();
            if(kategori == null)
            {
                kategori = new Kategori();
            }
            else
            {
                db.Kategorier.Attach(kategori);
            }

            var skjemasporsmal = new SporsmalOgSvar
            {
                Sporsmal = new SporsmalC
                {
                    Sporsmal = innSkjemaSporsmal.Sporsmal,
                    Stilt = DateTime.Now
                },
                Kunde = kunde,
                Kategori = kategori
            };

            db.SporsmalOgSvar.Add(skjemasporsmal);
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
            return CreatedAtAction("GetSporsmalMedSvar", new { id = skjemasporsmal.ID }, skjemasporsmal);
        }

        [HttpPut]
        public ActionResult OppdaterSporsmal([FromBody] SporsmalOgSvarViewModel sporsmalOgSvar)
        {
            var sos = db.SporsmalOgSvar.FirstOrDefault(s => s.ID == sporsmalOgSvar.Id);

            if (sos == null) return NotFound(sporsmalOgSvar.Id);

            sos.Publisert = sporsmalOgSvar.Publisert;
            sos.Svar = sporsmalOgSvar.Svar;


            db.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult SlettSporsmalOgSvar([FromRoute] int id)
        {
            var sos = db.SporsmalOgSvar.FirstOrDefault(s => s.ID == id);
            if (sos == null) return NotFound(id);

            db.SporsmalOgSvar.Remove(sos);
            db.SaveChanges();
            return Ok();
        }
        
    }
}