namespace BookStoreApi.Models
{
    /// <summary>
    /// Модель для возврата информации о заказе.
    /// </summary>
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemDto> Items { get; set; } = new();
    }

    /// <summary>
    /// Модель для возврата информации о заказной позиции.
    /// </summary>
    public class OrderItemDto
    {
        public int BookId { get; set; }
        public required string BookTitle { get; set; }
        public int Quantity { get; set; }
    }
}
