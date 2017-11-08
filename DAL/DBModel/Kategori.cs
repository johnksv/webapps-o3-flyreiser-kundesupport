using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DBModel
{
    public class Kategori
    {
        [Key]
        public string Navn { get; set; } = "Annet";
        public virtual List<SporsmalOgSvar> SporsmalOgSvar { get; set; }
    }
}
