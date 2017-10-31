using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DB : DbContext
    {

        public DB(DbContextOptions<DB> options) : base(options)
        {
        }

        public virtual DbSet<SporsmalC> Sporsmal { get; set; }
        public virtual DbSet<SvarC> Svar { get; set; }
        public virtual DbSet<Kundebehandler> Kundebehandlere { get; set; }
        public virtual DbSet<SkjemaSporsmal> SkjemaSporsmal { get; set; }

    }
}
