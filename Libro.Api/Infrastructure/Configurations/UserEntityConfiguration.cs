using Libro.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libro.Api.Infrastructure.Configurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");

        builder.Property(x => x.Email).HasMaxLength(250).IsRequired();
        builder.Property(x => x.Username).HasMaxLength(250).IsRequired();
        builder.Property(x => x.Password).HasMaxLength(500).IsRequired();

        builder.HasMany(x => x.Loans).WithOne().HasForeignKey(x => x.UserId);
        builder.Navigation(x => x.Loans).AutoInclude();
    }
}