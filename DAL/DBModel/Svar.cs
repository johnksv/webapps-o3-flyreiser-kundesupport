using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.DBModel
{
    public class SvarC
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public string Svar { get; set; }
        public DateTime Besvart { get; set; }
        public string BesvartAv { get; set;}
}
}
