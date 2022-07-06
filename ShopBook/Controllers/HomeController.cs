using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Controller class for displaying the main page
    /// </summary>
    public class HomeController : Controller
    {

        /// <summary>
        /// Create a variable
        /// </summary>
        private readonly IAllBooks _bookRep;

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="bookRep"></param>
        public HomeController(IAllBooks bookRep)
        {
            _bookRep = bookRep;

        }
        /// <summary>
        /// Method for outputting books
        /// </summary>
        /// <returns>returns html page</returns>
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
