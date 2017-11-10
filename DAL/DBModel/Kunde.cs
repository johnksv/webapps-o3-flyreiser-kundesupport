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
        [RegularExpression("^[A-Za-zæøåÆØÅ\\- ]+$")]
        public string Fornavn { get; set; }
        [RegularExpression("^[A-Za-zæøåÆØÅ\\- ]+$")]
        public string Etternavn { get; set; }
        [RegularExpression("^[A-Za-zæøåÆØÅ0-9_\\-,\\.+ ]+@[a-zA-Z0-9]+\\.[a-zA-Z]+$")]
        public string Epost { get; set; }
        [RegularExpression("^[1-9][0-9]{7}$")]
        public string Telefon { get; set; }

        public virtual List<SporsmalOgSvar> Sporsmal { get; set; }
    }
}
