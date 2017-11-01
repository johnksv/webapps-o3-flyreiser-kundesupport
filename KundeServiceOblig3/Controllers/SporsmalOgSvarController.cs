using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.DBModel;
using KundeServiceOblig3.Models;

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
        public List<SporsmalOgSvar> GetSporsmalOgSvar()
        {
            var resultat = new List<SporsmalOgSvar>();

            foreach (var sporsmal in db.Sporsmal)
            {
                var sporsmalSvar = new SporsmalOgSvar
                {
                    Sporsmal = sporsmal,
                    Svar = sporsmal.Svar
                };
                resultat.Add(sporsmalSvar);
            }

            return resultat;
        }

        // api/SporsmalOgSvar/1
        [HttpGet("{id}")]
        public IActionResult GetSporsmalOgSvar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sporsmal = db.Sporsmal.SingleOrDefault(m => m.ID == id);

            if (sporsmal != null)
            {
                var sporsmalSvar = new SporsmalOgSvar
                {
                    Sporsmal = sporsmal,
                    Svar = sporsmal.Svar
                };

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
        public IActionResult PostSporsmalC([FromBody] SporsmalC sporsmalC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sporsmal.Add(sporsmalC);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SporsmalCExists(sporsmalC.ID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSporsmalC", new { id = sporsmalC.ID }, sporsmalC);
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