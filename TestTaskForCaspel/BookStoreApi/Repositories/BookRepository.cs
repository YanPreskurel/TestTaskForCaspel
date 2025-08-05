using BookStoreApi.Entities;
using Microsoft.EntityFrameworkCore;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _context;
    public BookRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetBooksAsync(string? title, DateTime? releaseDate)
    {
        var query = _context.Books.AsQueryable();

        if (!string.IsNullOrEmpty(title))
            query = query.Where(b => b.Title.Contains(title));

        if (releaseDate.HasValue)
            query = query.Where(b => b.ReleaseDate.Date == releaseDate.Value.Date);

        return await query.ToListAsync();
    }

    public async Task<Book?> GetBookByIdAsync(int id)
    {
        return await _context.Books.FindAsync(id);
    }
}
