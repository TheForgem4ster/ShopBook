using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer
{
    /// <summary>
    /// Класс AppDBContent служит для создания сущностей в базе данных
    /// </summary>
    public class AppDBContent : DbContext
    {
        /// <summary>
        /// представляет набор сущностей книги, для хранения в базе данных
        /// </summary>
        public DbSet<Book> Books { get; set; }
        /// <summary>
        /// представляет набор сущностей категорий, для хранения в базе данных
        /// </summary>
        public DbSet<Category> Category { get; set; }
        /// <summary>
        /// представляет набор сущностей товаров в корзине, для хранения в базе данных
        /// </summary>
        public DbSet<ShopCartItem> ShopCartItems { get; set; }
        /// <summary>
        /// представляет набор сущностей заказов, для хранения в базе данных
        /// </summary>
        public DbSet<Order> Order { get; set; }
        /// <summary>
        /// представляет набор сущностей детаей заказа, для хранения в базе данных
        /// </summary>
        public DbSet<OrderDetail> OrderDetail { get; set; }
        /// <summary>
        /// Конструктор DbContextявно позволяет сконструироваться для внедрения зависимостей.
        /// </summary>
        /// <param name="options"></param>
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public AppDBContent()
        {
        }
    }
    /// <summary>
    /// BloggingContextFactory служит для создании миграции
    /// </summary>
    public class BloggingContextFactory : IDesignTimeDbContextFactory<AppDBContent>
    {
        /// <summary>
        /// Создаем объект DbContextOptionsBuilder, который позволяет создать параметры подключения
        /// И подключаемся к базе данных BookShop
        /// </summary>
        /// <param name="args"></param>
        /// <returns>Созданный обьект AppDBContent контекта устройства </returns>
        public AppDBContent CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDBContent>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BookShop;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DataLayer"));//

            return new AppDBContent(optionsBuilder.Options);
        }
    }
}
