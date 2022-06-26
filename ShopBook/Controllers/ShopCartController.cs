using BusinessLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllBooks _bookRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllBooks bookRep, ShopCart shopCart)
        {
            _bookRep = bookRep;
            _shopCart = shopCart;
        }
        // Вызывает определенный html фаблон и отобразить нашу корзину
        public ViewResult Index()
        {
            var item = _shopCart.GetShopItems();
            _shopCart.ListShopItems = item;

            var obj = new ShopCartViewModel { shopCart = _shopCart };

            return View(obj);
        }
        // переадресовывания на другую страничку
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
