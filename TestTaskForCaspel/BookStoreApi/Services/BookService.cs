using AutoMapper;
using BookStoreApi.Models;

namespace BookStoreApi.Services
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> GetBooksAsync(string? title, DateTime? releaseDate)
        {
            var books = await _bookRepository.GetBooksAsync(title, releaseDate);
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto?> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            return book == null ? null : _mapper.Map<BookDto>(book);
        }
    }

}
