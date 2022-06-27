using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataLayer.Models
{
    /// <summary>
    /// Класс корзина, в котором есть  список элементы корзины магазина, конструктор с параметром
    /// методы получения, добавления и получения товара из магазина
    /// </summary>
    public class ShopCart
    {
        /// <summary>
        /// Создания поля для чтения AppDBContent для реализации конcтруктора
        /// </summary>
        private readonly AppDBContent _appDBContent;

        /// <summary>
        /// Индификатор корзины покупок
        /// </summary>
        public string ShopCartId { get; set; }

        /// <summary>
        /// Список товаров в корзине
        /// </summary>
        public List<ShopCartItem> ListShopItems { get; set; }
       
        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="appDBContent"></param>
        public ShopCart(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }
       /// <summary>
       /// Статический метод который получает 
       /// </summary>
       /// <param name="services"></param>
       /// <returns>Возвращает обьект класса корзина</returns>
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
        /// <summary>
        /// Метод который добавляет в корзину книгу
        /// </summary>
        /// <param name="book"></param>
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

        /// <summary>
        /// Список товаров из корзины
        /// </summary>
        /// <returns>Возвращает список товаров по ShopCartId</returns>
        public List<ShopCartItem> GetShopItems()
        {
            return _appDBContent.ShopCartItems.Where(b => b.ShopCartId == ShopCartId)
                .Include(s => s.book).ToList();
        }
    }
}
