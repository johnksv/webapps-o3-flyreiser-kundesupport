using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DBModel
{
    public class Kategori
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public string Navn { get; set; } = "Annet";
        public virtual List<SporsmalOgSvar> SporsmalOgSvar { get; set; }
    }
}
