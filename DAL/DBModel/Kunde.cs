using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.DBModel
{
    public class Kunde
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        [RegularExpression("")]
        public string Fornavn { get; set; }
        [RegularExpression("")]
        public string Etternavn { get; set; }
        [RegularExpression("")]
        public string Epost { get; set; }
        [RegularExpression("")]
        public string Telefon { get; set; }

        public virtual List<SporsmalOgSvar> Sporsmal { get; set; }
    }
}
