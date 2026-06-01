using ReadNet.Domain.Entities;
using ReadNet.Domain.Interfaces;

namespace ReadNet.Domain.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(Book book)
    {
        if (string.IsNullOrWhiteSpace(book.Title))
            throw new ArgumentException("El título del libro es obligatorio.");

        if (string.IsNullOrWhiteSpace(book.ISBN))
            throw new ArgumentException("El ISBN es obligatorio.");

        if (book.PublishYear <= 0)
            throw new ArgumentException("El año de publicación debe ser válido.");

        await _repository.AddAsync(book);
    }

    public async Task UpdateAsync(Book book)
    {
        if (string.IsNullOrWhiteSpace(book.Title))
            throw new ArgumentException("El título del libro es obligatorio.");

        if (string.IsNullOrWhiteSpace(book.ISBN))
            throw new ArgumentException("El ISBN es obligatorio.");

        if (book.PublishYear <= 0)
            throw new ArgumentException("El año de publicación debe ser válido.");

        await _repository.UpdateAsync(book);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}