using AutoMapper;
using BookStoreApi.Mappings;
using BookStoreApi.Entities;
using BookStoreApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.MapGet("/books", async (IBookRepository repo, string? title, DateTime? releaseDate) =>
//{
//    var books = await repo.GetBooksAsync(title, releaseDate);
//    return Results.Ok(books);
//});

//app.MapGet("/books/{id}", async (IBookRepository repo, int id) =>
//{
//    var book = await repo.GetBookByIdAsync(id);
//    return book is not null ? Results.Ok(book) : Results.NotFound();
//});

//app.MapGet("/orders", async (IOrderRepository repo, string? orderNumber, DateTime? orderDate) =>
//{
//    var orders = await repo.GetOrdersAsync(orderNumber, orderDate);
//    return Results.Ok(orders);
//});

//app.MapPost("/orders", async (IOrderRepository repo, OrderCreateModel model) =>
//{
//    var orderId = await repo.CreateOrderAsync(model);
//    return Results.Created($"/orders/{orderId}", null);
//});

app.Run();
