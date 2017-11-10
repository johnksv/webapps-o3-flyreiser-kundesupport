using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DBModel
{
    public class Kategori
    {
        [Key]
        [RegularExpression("^[A-Za-zæøåÆØÅ\\- ]+$")]
        public string Navn { get; set; } = "Brukerspørsmål";
        public virtual List<SporsmalOgSvar> SporsmalOgSvar { get; set; }
    }
}
