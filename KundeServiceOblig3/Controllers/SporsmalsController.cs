using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Model;

namespace KundeServiceOblig3.Controllers
{
    [Produces("application/json")]
    [Route("api/Sporsmals")]
    public class SporsmalsController : Controller
    {
        private readonly DB db;

        public SporsmalsController(DB context)
        {
            db = context;
        }

        // GET: api/Sporsmals
        [HttpGet]
        public IEnumerable<Sporsmal> GetSporsmal()
        {
            db.Add(new Sporsmal
            {

            });
            db.SaveChanges();

            return db.Sporsmal;
        }

        // GET: api/Sporsmals/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSporsmal([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sporsmal = await db.Sporsmal.SingleOrDefaultAsync(m => m.ID == id);

            if (sporsmal == null)
            {
                return NotFound();
            }

            return Ok(sporsmal);
        }

        // PUT: api/Sporsmals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSporsmal([FromRoute] int id, [FromBody] Sporsmal sporsmal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sporsmal.ID)
            {
                return BadRequest();
            }

            db.Entry(sporsmal).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SporsmalExists(id))
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

        // POST: api/Sporsmals
        [HttpPost]
        public async Task<IActionResult> PostSporsmal([FromBody] Sporsmal sporsmal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sporsmal.Add(sporsmal);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetSporsmal", new { id = sporsmal.ID }, sporsmal);
        }

        // DELETE: api/Sporsmals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSporsmal([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sporsmal = await db.Sporsmal.SingleOrDefaultAsync(m => m.ID == id);
            if (sporsmal == null)
            {
                return NotFound();
            }

            db.Sporsmal.Remove(sporsmal);
            await db.SaveChangesAsync();

            return Ok(sporsmal);
        }

        private bool SporsmalExists(int id)
        {
            return db.Sporsmal.Any(e => e.ID == id);
        }
    }
}