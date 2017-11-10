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
        public IActionResult GetKategori()
        {
            var kategoriListe = db.Kategorier.ToList();
            return Ok(kategoriListe);
        }

        // GET: api/Kategori/5
        [HttpGet("{id}")]
        public  IActionResult GetKategori([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kategori = db.Kategorier.SingleOrDefaultAsync(m => m.Navn == id);

            if (kategori == null)
            {
                return NotFound();
            }

            return Ok(kategori);
        }

    }
}