using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.DBModel
{
    public class SkjemaSporsmal
    {
        [Key]
        public int ID { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Epost { get; set; }
        public string Telefon { get; set; }
        public SporsmalC Sporsmal { get; set; }
    }
}
