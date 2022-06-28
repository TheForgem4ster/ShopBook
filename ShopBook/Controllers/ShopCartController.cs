using BusinessLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Класс контроллер для создания корзины
    /// </summary>
    public class ShopCartController : Controller
    {
        private readonly IAllBooks _bookRep;
        private readonly ShopCart _shopCart;

        /// <summary>
        /// Констуктор с параметрами
        /// </summary>
        /// <param name="bookRep"></param>
        /// <param name="shopCart"></param>
        public ShopCartController(IAllBooks bookRep, ShopCart shopCart)
        {
            _bookRep = bookRep;
            _shopCart = shopCart;
        }

        /// <summary>
        /// Метод для отображения в корзине заказов
        /// </summary>
        /// <returns>Возращает определенный html фаблон и отображает заказы</returns>
        public ViewResult Index()
        {
            var item = _shopCart.GetShopItems();
            _shopCart.ListShopItems = item;

            var obj = new ShopCartViewModel { shopCart = _shopCart };

            return View(obj);
        }
        /// <summary>
        /// Метод добавляет товары в корзину
        /// </summary>
        /// <param name="id"></param>
        /// <returns>переадресуем пользователя на страничку с корзиной</returns>
        public RedirectToActionResult addToCart(int id)
        {
            // выбирает нужный товар из списка базы данных
            var item = _bookRep.Books.FirstOrDefault(i => i.Id == id);

            if(item != null)
            {
                _shopCart.AddToCart(item);
            }
            // когда мы нажмем на добавление товара то мы переадресуем пользователя на страничку с корзиной
            return RedirectToAction("Index");
        }
    }
}
