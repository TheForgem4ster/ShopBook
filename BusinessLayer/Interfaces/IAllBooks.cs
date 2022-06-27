using DataLayer.Models;
using System.Collections;
using System.Collections.Generic;


namespace BusinessLayer.Interfaces
{
    /// <summary>
    /// Интерфейс служит для работы с книгами
    /// </summary>
    public interface IAllBooks
    {
        /// <summary>
        /// Функция которая возвращение всех товаров
        /// </summary>
        IEnumerable<Book> Books { get;  }
        /// <summary>
        /// Возвращение избранных товаров
        /// </summary>
        IEnumerable<Book> GetFarBooks { get; }

        /// <summary>
        /// Возвращение конкретного товара по индификационному номеру
        /// </summary>
        /// <param name="bookid"></param>
        Book GetBookById(int bookid);
    }
}
