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
                Kunde = kunde,
                Kategori = new Kategori()
            };

            db.Kategorier.Attach(skjemasporsmal.Kategori);
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

        private bool SporsmalCExists(int id)
        {
            return db.Sporsmal.Any(e => e.ID == id);
        }
    }
}