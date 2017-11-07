using DAL.DBModel;
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
        public virtual DbSet<SporsmalOgSvar> SporsmalOgSvar { get; set; }
        public virtual DbSet<Kundebehandler> Kundebehandlere { get; set; }
        public virtual DbSet<Kunde> Kunder { get; set; }

    }
}
