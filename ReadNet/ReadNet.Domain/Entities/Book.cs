namespace ReadNet.Domain.Entities;

public class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string ISBN { get; set; } = string.Empty;

    public int PublishYear { get; set; }

    public int AuthorId { get; set; }

    public Author Author { get; set; } = null!;

    public int CategoryId { get; set; }

    public Category Category { get; set; } = null!;

    public ICollection<LoanDetail> LoanDetails { get; set; }
        = new List<LoanDetail>();
} 