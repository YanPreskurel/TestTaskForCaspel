using BookStoreApi.Entities;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetBooksAsync(string? title, DateTime? releaseDate);
    Task<Book?> GetBookByIdAsync(int id);
}
