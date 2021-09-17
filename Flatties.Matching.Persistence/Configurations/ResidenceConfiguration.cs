using Flatties.Matching.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flatties.Matching.Persistence
{
    public class ResidenceConfiguration : IEntityTypeConfiguration<Residence>
    {
        public void Configure(EntityTypeBuilder<Residence> builder)
        {
            builder.ToTable("Residences");
            builder.HasMany(r => r.Rooms);
            builder.OwnsOne(r => r.StreetAddress);
        }
    }
}
