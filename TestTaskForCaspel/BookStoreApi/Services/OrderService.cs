using AutoMapper;
using BookStoreApi.Entities;
using BookStoreApi.Models;
using BookStoreApi.Repositories;

namespace BookStoreApi.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersAsync(string? orderNumber, DateTime? orderDate)
        {
            var orders = await _orderRepository.GetOrdersAsync(orderNumber, orderDate);
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<int> CreateOrderAsync(OrderCreateModel model)
        {
            var order = new Order
            {
                OrderNumber = $"ORD-{Guid.NewGuid().ToString().Substring(0, 8)}",
                OrderDate = DateTime.UtcNow,
                OrderItems = new List<OrderItem>()
            };

            foreach (var item in model.Items)
            {
                // Загружаем книгу по Id
                var book = await _orderRepository.GetBookByIdAsync(item.BookId);
                if (book == null)
                {
                    throw new Exception($"Book with ID {item.BookId} not found.");
                }

                order.OrderItems.Add(new OrderItem
                {
                    BookId = item.BookId,
                    Book = book,
                    Quantity = item.Quantity,
                    Order = order
                });
            }

            return await _orderRepository.CreateOrderAsync(order);
        }

        public async Task<OrderDto?> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            return order == null ? null : _mapper.Map<OrderDto>(order);
        }
    }

}
