namespace ReadNet.Domain.Entities;

public class LoanDetail
{
    public int LoanId { get; set; }

    public Loan Loan { get; set; } = null!;

    public int BookId { get; set; }

    public Book Book { get; set; } = null!;
}