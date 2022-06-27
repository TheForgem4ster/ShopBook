using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Repository
{
    /// <summary>
    /// Класс хранилище книжек - для получения данных из базы данных
    /// </summary>
    public class BookRepository : IAllBooks
    {
        /// <summary>
        /// Переменная _appDBContent нужна для того чтобы мы вытаскивали данные из базы даных
        /// </summary>
        private readonly AppDBContent _appDBContent;

        /// <summary>
        /// Конструктор с параметром устанавливаем значение которое мы передаем на то что получаем
        /// </summary>
        /// <param name="appDBContent"></param>
        public BookRepository(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }
        /// <summary>
        /// Функция которая получает данные и записываем данные категории
        /// </summary>
        public IEnumerable<Book> Books => _appDBContent.Books.Include(b => b.Category);
        /// <summary>
        /// Функция которая выбирает все записи которые будут со значеним true
        /// </summary>
        public IEnumerable<Book> GetFarBooks => _appDBContent.Books.Where(b => b.isFavourite)
            .Include(f => f.Category);
        /// <summary>
        /// Функция которая выбирает одину книгу по индификатору
        /// </summary>
        /// <param name="bookid"></param>
        /// <returns></returns>
        public Book GetBookById(int bookid) => _appDBContent.Books.FirstOrDefault(b => b.Id == bookid);
    }
}
