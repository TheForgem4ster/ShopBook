using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataLayer.Models
{
    public class ShopCart
    {
        private readonly AppDBContent _appDBContent;
        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }
       
        public ShopCart(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }

        public static ShopCart GetCart(IServiceProvider services)
        {
            // создали объект для сесии
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            // проверяем если не существует с таким ключем CartId создаем новый
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            // установка новый сесии
            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Book book)
        {
            _appDBContent.ShopCartItems.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                book = book,
                price = book.price,
            });
            // Сохранение всех данных
            _appDBContent.SaveChanges();
        }
        public List<ShopCartItem> GetShopItems()
        {
            return _appDBContent.ShopCartItems.Where(b => b.ShopCartId == ShopCartId)
                .Include(s => s.book).ToList();
        }
    }
}
