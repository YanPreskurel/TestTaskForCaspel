using BookStoreApi.Entities;

namespace BookStoreApi.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersAsync(string? orderNumberFilter, DateTime? orderDateFilter);
        Task<Order?> GetOrderByIdAsync(int id);
        Task AddOrderAsync(Order order);
        Task SaveChangesAsync();
        Task<int> CreateOrderAsync(Order order);
        Task<Book?> GetBookByIdAsync(int bookId);
    }
}
