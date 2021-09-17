using Flatties.Matching.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flatties.Matching.Persistence
{
    public class FlatConfiguration : IEntityTypeConfiguration<Flat>
    {
        public void Configure(EntityTypeBuilder<Flat> builder)
        {
            builder.ToTable("Flats");
            builder.HasMany(f => f.Flatmates);
        }
    }
}
