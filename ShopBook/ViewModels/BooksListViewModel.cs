using DataLayer.Models;
using System.Collections;
using System.Collections.Generic;


namespace WebApplication1.ViewModels
{
    public class BooksListViewModel
    {
        // Функция которая будет получать все товары
        public IEnumerable<Book> AllBooks { get; set; }

        public string CurrectCategory { get; set; }
    }
}
