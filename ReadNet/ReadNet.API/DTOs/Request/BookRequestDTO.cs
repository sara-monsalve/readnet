namespace ReadNet.API.DTOs.Request;

public class BookRequestDTO
{
    public string Title { get; set; } = string.Empty;

    public string ISBN { get; set; } = string.Empty;

    public int PublishYear { get; set; }

    public int AuthorId { get; set; }

    public int CategoryId { get; set; }
}