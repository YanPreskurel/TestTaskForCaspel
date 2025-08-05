using AutoMapper;
using BookStoreApi.Entities;
using BookStoreApi.Models;

namespace BookStoreApi.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Книга -> DTO
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();

            // Заказ -> DTO
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            // OrderCreateModel -> Order (для создания заказа)
            CreateMap<OrderCreateModel, Order>();

            // Позиция заказа
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<OrderItemDto, OrderItem>();
        }
    }
}
