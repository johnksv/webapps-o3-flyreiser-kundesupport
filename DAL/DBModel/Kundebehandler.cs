using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.DBModel
{
    public class Kundebehandler
    {
        [Key]
        public string Brukernavn { get; set; }
        public byte[] Passord { get; set; }
        public string Salt { get; set; }

        public virtual List<SvarC> Svar { get; set; }

        public static byte[] HashPassord(string password, string salt)
        {
            var algorithm = System.Security.Cryptography.SHA256.Create();
            byte[] str = Encoding.ASCII.GetBytes(String.Concat(password, salt));
            return algorithm.ComputeHash(str);
        }

        /* 
            Denne metoden genererer et dummy-salt. Random-klassen vil kun være pseudo-random, 
            men for å illustrere effekten av å legge til en tilfeldig string på passordet er dette godt nok.
        */
        public static string LagSalt()
        {
            Random r = new Random();
            var saltLength = r.Next(15, 25);
            StringBuilder str = new StringBuilder();
            for (var i = 0; i < saltLength; i++)
            {
                str.Append((char)r.Next(20, 122));
            }
            return str.ToString();
        }

    }
}
