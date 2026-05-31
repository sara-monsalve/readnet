using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadNet.Domain.Entities;

namespace ReadNet.DataAccess.Configurations;

public class LoanDetailConfiguration : IEntityTypeConfiguration<LoanDetail>
{
    public void Configure(EntityTypeBuilder<LoanDetail> builder)
    {
        builder.HasKey(ld => new { ld.LoanId, ld.BookId });

        builder.HasOne(ld => ld.Loan)
            .WithMany(l => l.LoanDetails)
            .HasForeignKey(ld => ld.LoanId);

        builder.HasOne(ld => ld.Book)
            .WithMany(b => b.LoanDetails)
            .HasForeignKey(ld => ld.BookId);
    }
}