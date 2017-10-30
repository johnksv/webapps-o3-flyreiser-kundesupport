using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DB : DbContext
    {

        public DB(DbContextOptions<DB> options) : base(options)
        {
        }

        public virtual DbSet<Sporsmal> Sporsmal { get; set; }

    }
}
