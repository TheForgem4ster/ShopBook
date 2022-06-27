using DataLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    /// <summary>
    /// Интерфейс который отвечает за получение всех категорий
    /// </summary>
    public interface IBooksCategory
    {
        /// <summary>
        /// Функция которая возвращает все модели из категории
        /// </summary>
        IEnumerable<Category> AllCategories { get; }
    }
}
