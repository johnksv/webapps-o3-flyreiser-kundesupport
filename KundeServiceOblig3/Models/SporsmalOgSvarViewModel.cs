using DAL.DBModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KundeServiceOblig3.Models
{
    public class SporsmalOgSvarViewModel
    {
        public int Id { get; set; }
        public SporsmalC Sporsmal { get; set; }
        public SvarC Svar { get; set; }
        public bool Publisert { get; set; }
        public Kategori Kategori { get; set; }
        public Kunde Kunde { get; set; }
    }
}