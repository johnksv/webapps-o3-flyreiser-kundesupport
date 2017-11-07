using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KundeServiceOblig3.Models
{
    public class SkjemaSporsmalView
    {
        public int ID { get; set; }
        [Required]
        public string Fornavn { get; set; }
        [Required]
        public string Etternavn { get; set; }
        [Required]
        public string Epost { get; set; }
        [Required]
        public string Telefon { get; set; }
        [Required]
        public string Sporsmal { get; set; }
    }
}
