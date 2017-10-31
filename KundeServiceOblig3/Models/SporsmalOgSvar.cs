using DAL.DBModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KundeServiceOblig3.Models
{
    public class SporsmalOgSvar
    {
        [Required]
        public SporsmalC Sporsmal { get; set; }
        [Required]
        public SvarC Svar { get; set; }
    }
}
