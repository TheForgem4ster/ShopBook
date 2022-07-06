﻿using DataLayer.Model;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer
{
    /// <summary>
    /// The AppDBContent class is used to create entities in the database
    /// </summary>
    public class AppDBContent : DbContext
    {
        /// <summary>
        /// represents the book entity set to be stored in the database
        /// </summary>
        public DbSet<Book> Books { get; set; }
        /// <summary>
        /// represents a set of category entities to be stored in the database
        /// </summary>
        public DbSet<Category> Category { get; set; }
        /// <summary>
        /// represents the entity set of the items in the cart, to be stored in the database
        /// </summary>
        public DbSet<ShopCartItem> ShopCartItems { get; set; }
        /// <summary>
        /// represents a set of order entities to be stored in the database
        /// </summary>
        public DbSet<Order> Order { get; set; }
        /// <summary>
        /// represents a set of order details entities to be stored in the database
        /// </summary>
        public DbSet<OrderDetail> OrderDetail { get; set; }
        /// <summary>
        /// represents a set of user entities to be stored in the database
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// The DbContext constructor explicitly allows you to construct for dependency injection.
        /// </summary>
        /// <param name="options"></param>
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { }
        /// <summary>
        /// Default constructor
        /// </summary>
        public AppDBContent()
        {
        }
    }
    /// <summary>
    /// BloggingContextFactory is used to create a migration
    /// </summary>
    public class BloggingContextFactory : IDesignTimeDbContextFactory<AppDBContent>
    {
        /// <summary>
        /// Create a DbContextOptionsBuilder object that allows you to create connection options
        /// And connect to the BookShop database
        /// </summary>
        /// <param name="args"></param>
        /// <returns>The created AppDBContext object of the device context</returns>
        public AppDBContent CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDBContent>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BookShop;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DataLayer"));//

            return new AppDBContent(optionsBuilder.Options);
        }
    }
}
