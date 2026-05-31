namespace ReadNet.API.DTOs.Response;

public class BookResponseDTO
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string ISBN { get; set; } = string.Empty;

    public int PublishYear { get; set; }

    public int AuthorId { get; set; }

    public int CategoryId { get; set; }
}