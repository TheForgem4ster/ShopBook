using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer
{
    public class AppDBContent : DbContext
    {
        
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopCartItem> ShopCartItems { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { }
        public AppDBContent()
        {
        }
    }
    public class BloggingContextFactory : IDesignTimeDbContextFactory<AppDBContent>
    {
        public AppDBContent CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDBContent>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BookShop;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DataLayer"));//

            return new AppDBContent(optionsBuilder.Options);
        }
    }
}
