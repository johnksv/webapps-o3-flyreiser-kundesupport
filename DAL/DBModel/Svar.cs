using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.DBModel
{
    public class SvarC
    {

        [Key]
        public int ID { get; set; }
        public string Svar { get; set; }
        public Kundebehandler BesvartAv { get; set; }
        public DateTime Besvart { get; set; }

        public SporsmalC sporsmal { get; set; }
    }
}
