using Flatties.Matching.Application;
using Flatties.Matching.Domain;
using Microsoft.EntityFrameworkCore;

namespace Flatties.Matching.Persistence
{
    public class FlattiesDbContext : DbContext, IFlattiesDbContext
    {
        public FlattiesDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Flat> Flats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FlattiesDbContext).Assembly);
        }
    }
}
