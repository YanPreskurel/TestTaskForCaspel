using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(b => b.Price)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book { Title = "C# in Depth", ReleaseDate = new DateTime(2023, 1, 1), Price = 45 },
                    new Book { Title = "ASP.NET Core Guide", ReleaseDate = new DateTime(2024, 6, 15), Price = 50 },
                    new Book { Title = "Entity Framework Core", ReleaseDate = new DateTime(2022, 11, 5), Price = 40 }
                );
                context.SaveChanges();
            }
        }
    }

}
