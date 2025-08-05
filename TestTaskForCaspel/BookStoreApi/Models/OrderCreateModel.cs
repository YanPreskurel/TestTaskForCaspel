namespace BookStoreApi.Models
{
    /// <summary>
    /// Модель для создания нового заказа.
    /// </summary>
    public class OrderCreateModel
    {
        public List<OrderItemCreateModel> Items { get; set; } = new();
    }

    /// <summary>
    /// Модель для добавления книг в заказ.
    /// </summary>
    public class OrderItemCreateModel
    {
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}
