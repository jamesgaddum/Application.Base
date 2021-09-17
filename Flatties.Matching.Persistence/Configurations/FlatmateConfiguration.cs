using Flatties.Matching.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flatties.Matching.Persistence.Configurations
{
    public class FlatmateConfiguration : IEntityTypeConfiguration<Flatmate>
    {
        public void Configure(EntityTypeBuilder<Flatmate> builder)
        {
            builder.ToTable("Flatmates");
            builder.HasKey(f => new
            {
                f.FlatId,
                f.UserId
            });
        }
    }
}
