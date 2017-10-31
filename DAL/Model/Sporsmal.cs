﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Model
{
    public class SporsmalC
    {
        [Key]
        public int ID { get; set; }
        public string Sporsmal { get; set; }
        public DateTime Stilt { get; set; }
        public bool Publisert { get; set; }
        public SvarC Svar { get; set; }

    }
}
