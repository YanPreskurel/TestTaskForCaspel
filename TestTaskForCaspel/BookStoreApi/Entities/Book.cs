namespace BookStoreApi.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
