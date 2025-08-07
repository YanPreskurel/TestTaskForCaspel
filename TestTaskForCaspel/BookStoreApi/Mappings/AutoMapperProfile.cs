using AutoMapper;
using BookStoreApi.Entities;
using BookStoreApi.Models;

namespace BookStoreApi.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();

            CreateMap<OrderItemCreateModel, OrderItem>();

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title));


            CreateMap<OrderCreateModel, Order>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.Items));

            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems));
        }
    }

}
