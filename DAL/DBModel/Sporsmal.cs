using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.DBModel
{
    public class SporsmalC
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public string Sporsmal { get; set; }
        public DateTime Stilt { get; set; }
        public bool Publisert { get; set; } = false;
        public virtual SvarC Svar { get; set; }

    }
}
