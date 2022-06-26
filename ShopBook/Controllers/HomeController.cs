using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllBooks _bookRep;


        public HomeController(IAllBooks bookRep)
        {
            _bookRep = bookRep;

        }
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
