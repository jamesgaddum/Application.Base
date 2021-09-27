using Application.Base.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Base.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserDto>
    {
        public void Configure(EntityTypeBuilder<UserDto> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .HasColumnType("NVARCHAR(100)");

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasColumnType("NVARCHAR(50)");

            builder.Property(u => u.LastName)
                .HasColumnType("NVARCHAR(50)");

            builder.Property(u => u.DateOfBirth)
                .IsRequired()
                .HasColumnType("DATETIME2(7)");
        }
    }
}
