using BusinessLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class BooksController : Controller
    {
        private readonly IAllBooks _allBooks;
        private readonly IBooksCategory _allCategory;

        
        public BooksController(IAllBooks iAllBooks, IBooksCategory iAllCategory)
        {
            _allBooks = iAllBooks;
            _allCategory = iAllCategory;
        }
        // возвращает результат html странички
        [Route("Books/List")]
        [Route("Books/List/{category}")]
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
    }
}
