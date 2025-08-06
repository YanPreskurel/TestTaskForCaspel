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
            // Маппим модель создания заказа в сущность Order
            var orderEntity = _mapper.Map<Order>(model);

            var orderId = await _orderRepository.CreateOrderAsync(orderEntity);

            return orderId;
        }

        public async Task<OrderDto?> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            return order == null ? null : _mapper.Map<OrderDto>(order);
        }
    }

}
