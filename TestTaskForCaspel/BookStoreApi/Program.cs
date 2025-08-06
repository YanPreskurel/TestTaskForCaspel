using AutoMapper;
using BookStoreApi.Entities;
using BookStoreApi.Mappings;
using BookStoreApi.Middleware;
using BookStoreApi.Repositories;
using BookStoreApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateSlimBuilder(args);

//builder.Services.ConfigureHttpJsonOptions(options =>
//{
//    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
//});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<OrderService>();

builder.Services.AddControllers();


builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

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
app.MapControllers();
app.Run();
