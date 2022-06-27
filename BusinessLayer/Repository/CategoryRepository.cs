using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace BusinessLayer.Repository
{
    /// <summary>
    /// Класс хранилище категорий - для получения данных из базы данных
    /// </summary>
    public class CategoryRepository : IBooksCategory
    {
        /// <summary>
        /// Переменная _appDBContent нужна для того чтобы мы вытаскивали данные из базы даных
        /// </summary>
        private readonly AppDBContent _appDBContent;
        /// <summary>
        /// Конструктор с параметром устанавливаем значение которое мы передаем на то что получаем
        /// </summary>
        /// <param name="appDBContent"></param>
        public CategoryRepository(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }
        /// <summary>
        /// Функция для получения всех категорий
        /// </summary>
        public IEnumerable<Category> AllCategories => _appDBContent.Category;
    }
}
