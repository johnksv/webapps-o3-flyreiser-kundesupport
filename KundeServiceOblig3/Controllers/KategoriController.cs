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
    [Route("api/kategoriermedsvar")]
    public class KategoriController : Controller
    {
        private readonly DB db;

        public KategoriController(DB context)
        {
            db = context;
        }

        // GET: api/Kategori
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

        // GET: api/Kategori/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKategori([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kategori = await db.Kategorier.SingleOrDefaultAsync(m => m.Navn == id);

            if (kategori == null)
            {
                return NotFound();
            }

            return Ok(kategori);
        }

    }
}