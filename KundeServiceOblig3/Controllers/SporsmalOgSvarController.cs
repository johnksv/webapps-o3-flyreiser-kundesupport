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
    [Route("api/SporsmalOgSvar")]
    public class SporsmalOgSvarController : Controller
    {
        private readonly DB db;

        public SporsmalOgSvarController(DB dbContext)
        {
            db = dbContext;
        }

        // api/SporsmalOgSvar
        [HttpGet]
        public IActionResult GetSporsmalOgSvar()
        {
            var resultat = new List<SporsmalOgSvar>();
            var sporsmalSvarListe = db.SporsmalOgSvar
                .Include(s => s.Sporsmal)
                .Include(s => s.Svar)
                .Include(s => s.Svar.BesvartAvKundebehandler)
                .Include(s => s.Kunde).ToList();
            foreach (var sporsmalSvar in sporsmalSvarListe)
            {
                if (sporsmalSvar.Svar != null)
                {
                    sporsmalSvar.Svar.BesvartAv = sporsmalSvar.Svar.BesvartAvKundebehandler.Brukernavn;
                    sporsmalSvar.Svar.BesvartAvKundebehandler = null;
                }
                if(sporsmalSvar.Kunde != null)
                {
                    //Trenger dette, om ikke vil ikke JSON bli formatert korrekt
                    sporsmalSvar.Kunde.Sporsmal = null;
                }
                    

                resultat.Add(sporsmalSvar);
            }

            return Ok(resultat);
        }

        // api/SporsmalOgSvar/1
        [HttpGet("{id}")]
        public IActionResult GetSporsmalOgSvar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sporsmalSvar = db.SporsmalOgSvar.SingleOrDefault(m => m.Sporsmal.ID == id);

            if (sporsmalSvar != null)
            {
                

                return Ok(sporsmalSvar);
            }
            return NotFound();
        }

        // api/SporsmalOgSvar/1
        [HttpPut("{id}")]
        public IActionResult PutSporsmalC([FromRoute] int id, [FromBody] SporsmalC sporsmalC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sporsmalC.ID)
            {
                return BadRequest();
            }

            db.Entry(sporsmalC).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SporsmalCExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // api/SporsmalOgSvar
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

        // api/SporsmalOgSvar/1
        [HttpDelete("{id}")]
        public IActionResult DeleteSporsmalC([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sporsmalC = db.Sporsmal.SingleOrDefault(m => m.ID == id);
            if (sporsmalC == null)
            {
                return NotFound();
            }

            db.Sporsmal.Remove(sporsmalC);
            db.SaveChanges();

            return Ok(sporsmalC);
        }

        private bool SporsmalCExists(int id)
        {
            return db.Sporsmal.Any(e => e.ID == id);
        }
    }
}