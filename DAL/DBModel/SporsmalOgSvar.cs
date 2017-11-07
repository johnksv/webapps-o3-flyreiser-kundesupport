﻿using DAL.DBModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DBModel
{
    public class SporsmalOgSvar
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public virtual SporsmalC Sporsmal { get; set; }
        public virtual SvarC Svar { get; set; }
        public string Kategori { get; set; }
        public bool Publisert { get; set; } = true;

        public virtual Kunde Kunde { get; set; }
    }
}
