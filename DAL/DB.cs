using DAL.DBModel;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DB : DbContext
    {

        public DB(DbContextOptions<DB> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<SporsmalC>()
            .HasOne(sporsmal => sporsmal.Svar);
        }

        public virtual DbSet<SporsmalC> Sporsmal { get; set; }
        public virtual DbSet<SvarC> Svar { get; set; }
        public virtual DbSet<Kundebehandler> Kundebehandlere { get; set; }
        public virtual DbSet<SkjemaSporsmal> SkjemaSporsmal { get; set; }

    }
}
