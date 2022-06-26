using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Repository
{
    public class BookRepository : IAllBooks
    {
        private readonly AppDBContent _appDBContent;
        public BookRepository(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }

        public IEnumerable<Book> Books => _appDBContent.Books.Include(b => b.Category);

        public IEnumerable<Book> GetFarBooks => _appDBContent.Books.Where(b => b.isFavourite)
            .Include(f => f.Category);

        public Book GetBookById(int bookid) => _appDBContent.Books.FirstOrDefault(b => b.Id == bookid);
    }
}
