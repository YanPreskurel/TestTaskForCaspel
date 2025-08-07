namespace BookStoreApi.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = default!;
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
