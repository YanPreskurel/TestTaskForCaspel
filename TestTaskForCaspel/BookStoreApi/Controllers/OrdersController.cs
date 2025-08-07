using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders(
            [FromQuery] string? orderNumber,
            [FromQuery] DateTime? orderDate)
        {
            var orders = await _orderService.GetOrdersAsync(orderNumber, orderDate);
            return Ok(orders);
        }

        /// <summary>
        /// Получить заказ по ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        /// <summary>
        /// Создать новый заказ
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrder([FromBody] OrderCreateModel model)
        {
            var orderId = await _orderService.CreateOrderAsync(model);
            var order = await _orderService.GetOrderByIdAsync(orderId);

            return CreatedAtAction(nameof(GetOrderById), new { id = orderId }, order);
        }

    }
}
