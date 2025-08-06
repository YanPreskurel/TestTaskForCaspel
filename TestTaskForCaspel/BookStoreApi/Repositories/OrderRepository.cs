using BookStoreApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync(string? orderNumberFilter, DateTime? orderDateFilter)
        {
            var query = _context.Orders.AsQueryable();

            if (!string.IsNullOrWhiteSpace(orderNumberFilter))
                query = query.Where(o => o.OrderNumber.Contains(orderNumberFilter));

            if (orderDateFilter.HasValue)
                query = query.Where(o => o.OrderDate.Date == orderDateFilter.Value.Date);

            return await query.Include(o => o.OrderItems).ThenInclude(oi => oi.Book).ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Book)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<int> CreateOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order); 
            await _context.SaveChangesAsync();    
            return order.Id;                    
        }

    }
}
