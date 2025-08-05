namespace BookStoreApi.Models
{
    /// <summary>
    /// Модель для передачи информации о книге через API.
    /// </summary>
    public class BookDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
    }
}
