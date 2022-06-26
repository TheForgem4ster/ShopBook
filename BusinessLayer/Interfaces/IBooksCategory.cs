using DataLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    // Получение всех категорий из модели
    public interface IBooksCategory
    {
        //возвращает все модели
        IEnumerable<Category> AllCategories { get; }
    }
}
