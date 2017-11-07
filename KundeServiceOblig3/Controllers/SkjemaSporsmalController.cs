using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.DBModel;

namespace KundeServiceOblig3.Controllers
{
    [Produces("application/json")]
    [Route("api/SkjemaSporsmal")]
    public class SkjemaSporsmalController : Controller
    {
        private readonly DB db;

        public SkjemaSporsmalController(DB context)
        {
            db = context;
        }

        // GET: api/SkjemaSporsmal
        [HttpGet]
        public IEnumerable<SkjemaSporsmal> GetSkjemaSporsmal()
        {
            return db.SkjemaSporsmal;
        }

        // GET: api/SkjemaSporsmal/5
        [HttpGet("{id}")]
        public  IActionResult GetSkjemaSporsmal([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var skjemaSporsmal =  db.SkjemaSporsmal.SingleOrDefault(m => m.ID == id);

            if (skjemaSporsmal == null)
            {
                return NotFound();
            }

            return Ok(skjemaSporsmal);
        }

        // PUT: api/SkjemaSporsmal/5
        [HttpPut("{id}")]
        public  IActionResult PutSkjemaSporsmal([FromRoute] int id, [FromBody] SkjemaSporsmal skjemaSporsmal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != skjemaSporsmal.ID)
            {
                return BadRequest();
            }

            db.Entry(skjemaSporsmal).State = EntityState.Modified;

            try
            {
                 db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EksistererSkjemaSporsmal(id))
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

        // POST: api/SkjemaSporsmal
        [HttpPost]
        public  IActionResult PostSkjemaSporsmal([FromBody] SkjemaSporsmal skjemaSporsmal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return StatusCode(201);
            db.SkjemaSporsmal.Add(skjemaSporsmal);
             db.SaveChanges();

            return CreatedAtAction("GetSkjemaSporsmal", new { id = skjemaSporsmal.ID }, skjemaSporsmal);
        }

        // DELETE: api/SkjemaSporsmal/5
        [HttpDelete("{id}")]
        public  IActionResult DeleteSkjemaSporsmal([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var skjemaSporsmal =  db.SkjemaSporsmal.SingleOrDefault(m => m.ID == id);
            if (skjemaSporsmal == null)
            {
                return NotFound();
            }

            db.SkjemaSporsmal.Remove(skjemaSporsmal);
             db.SaveChanges();

            return Ok(skjemaSporsmal);
        }

        private bool EksistererSkjemaSporsmal(int id)
        {
            return db.SkjemaSporsmal.Any(sporsmal => sporsmal.ID == id);
        }
    }
}