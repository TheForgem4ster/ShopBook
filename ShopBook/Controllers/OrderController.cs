using BusinessLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication1.Controllers
{
    /// <summary>
    /// Класс контролеер заказа
    /// </summary>
    public class OrderController : Controller
    {
        /// <summary>
        /// Создание переменной
        /// </summary>
        private readonly IAllOrders _allOrders;
        /// <summary>
        /// Создание переменной
        /// </summary>
        private readonly ShopCart _shopCart;
        /// <summary>
        /// Создание конструктора с параметрами
        /// </summary>
        /// <param name="allOrders"></param>
        /// <param name="shopCart"></param>
        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            _allOrders = allOrders;
            _shopCart = shopCart;
        }
        /// <summary>
        /// Функция для вывода заказов
        /// </summary>
        /// <returns>возвращает некий html щаблон</returns>
        public IActionResult Checkout()
        {
            return View();
        }
        /// <summary>
        /// Метод срабатывает когда мы отправляем форму и лужит для заполнения товара 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]

        public IActionResult Checkout(Order order)
        {
            _shopCart.ListShopItems = _shopCart.GetShopItems();
            
            if (_shopCart.ListShopItems.Count == 0)
            {
                ModelState.AddModelError("", "You must have goods!");
            }

            if (ModelState.IsValid)
            {
                _allOrders.CreateOrder(order);
                //Возвращаем функции Complete
                return RedirectToAction("Complete");
            }
            return View(order);
        }
        /// <summary>
        /// Класс служит для отображения сообщения когда мы сделали заказ
        /// </summary>
        /// <returns>возвращает страничку</returns>
        public IActionResult Complete()
        {
            ViewBag.Message = "Order successfully processed";
            return View();
        }
    }
}
