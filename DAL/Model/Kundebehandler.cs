using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Model
{
    public class Kundebehandler
    {
        [Key]
        public string Brukernavn { get; set; }
        public byte[] Passord { get; set; }

    }
}
