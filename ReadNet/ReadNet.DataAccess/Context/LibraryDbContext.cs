using Microsoft.EntityFrameworkCore;
using ReadNet.Domain.Entities;

namespace ReadNet.DataAccess.Context;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }

    public DbSet<Author> Authors { get; set; }

    public DbSet<Book> Books { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Member> Members { get; set; }

    public DbSet<Loan> Loans { get; set; }

    public DbSet<LoanDetail> LoanDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoanDetail>()
            .HasKey(ld => new { ld.LoanId, ld.BookId });

        base.OnModelCreating(modelBuilder);
    }
}