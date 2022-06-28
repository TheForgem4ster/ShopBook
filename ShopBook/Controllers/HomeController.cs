using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Класс контролеер для отображения основной странички
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Создание переменной
        /// </summary>
        private readonly IAllBooks _bookRep;

        /// <summary>
        /// Конструктр с параметрам
        /// </summary>
        /// <param name="bookRep"></param>
        public HomeController(IAllBooks bookRep)
        {
            _bookRep = bookRep;

        }
        /// <summary>
        /// Метод для вывода книг
        /// </summary>
        /// <returns>возращает html страничку</returns>
        public ViewResult Index()
        {
            var homeBook = new HomeViewModel
            {
                favBook = _bookRep.GetFarBooks
            };
            return View(homeBook);
        }
    }
}
