using Libro.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libro.Api.Infrastructure.Configurations;

public class LoanConfiguration : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.ToTable("Loans");

        builder.HasKey(x => x.Id);
        builder.HasOne<UserEntity>().WithMany(x => x.Loans).HasForeignKey(x => x.UserId).IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Book>().WithMany(x => x.Loans).HasForeignKey(x => x.BookId).IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}