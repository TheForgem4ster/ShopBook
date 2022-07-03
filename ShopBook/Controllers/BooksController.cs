using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Класс контролеер книги
    /// </summary>
    public class BooksController : Controller
    {
        private readonly AppDBContent _context;
        /// <summary>
        /// Создание переменной
        /// </summary>
        private readonly IAllBooks _allBooks;
        /// <summary>
        /// Создание переменной
        /// </summary>
        private readonly IBooksCategory _allCategory;
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="iAllBooks">Передаем параметр интерфейса IAllBooks и устанавливаем его</param>
        /// <param name="iAllCategory">Передаем параметр интерфейса IBooksCategory и устанавливаем его</param>
        public BooksController(IAllBooks iAllBooks, IBooksCategory iAllCategory)
        {
            _allBooks = iAllBooks;
            _allCategory = iAllCategory;
        }
        /// <summary>
        /// Указываем Юрл адресс при котором будет срабатывать функция
        /// </summary>
        [Route("Books/List")]
        [Route("Books/List/{category}")]
        /// <summary>
        /// Метод который возвращает html страницу с списком всех товаров
        /// </summary>
        /// <param name="category"></param>
        /// <returns>возвращает результат html странички</returns>
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Book> books = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                books = _allBooks.Books.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("horror", category, StringComparison.OrdinalIgnoreCase))
                {
                    books = _allBooks.Books.Where(i => i.Category.CategoryName.Equals("Horror")).OrderBy(i => i.Id);
                    currCategory = "Horror";
                }
                else if (string.Equals("detective", category, StringComparison.OrdinalIgnoreCase))
                {
                    books = _allBooks.Books.Where(i => i.Category.CategoryName.Equals("Detective")).OrderBy(i => i.Id);
                    currCategory = "Detective";
                }
            }
            var bookObj = new BooksListViewModel
            {
                AllBooks = books,
                CurrectCategory = currCategory
            };
            ViewBag.Title = "Page with books";
            
            return View(bookObj);
        }
        //[Route("Books/Find")]
        //[Route("Books/Find/{searchString}")]
        [HttpGet]   
        public ViewResult Find(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Book> books = null;
            if (string.IsNullOrEmpty(_searchString))
            {
                ModelState.AddModelError("", "empty!");
                
            }
            else
            {
                books = _allBooks.Books.Where(s => s.Name.Contains(searchString)).ToList();
            }
            //var allbooks = db.Books.Where(a => a.Author.Contains(name)).ToList();
           
            //string _searchString = searchString;
            //IEnumerable<Book> books = null;
            //if (string.IsNullOrEmpty(searchString))
            //{
            //    ModelState.AddModelError("", "Nothing found!");
            //}
            //else
            //{

            //    books = _allBooks.Books.OrderBy(i => i.Id);
            //    //books = from b in _allBooks.Books select b;
            //    books = books.Where(s => s.Name.Contains(searchString));
            //}

            return View(books);
        }
    }
}
