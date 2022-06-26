using DataLayer.Models;
using System.Collections;
using System.Collections.Generic;


namespace BusinessLayer.Interfaces
{
    public interface IAllBooks
    {
        //Возвращение всех товаров
        IEnumerable<Book> Books { get;  }
        //Возвращение избранных товаров
        IEnumerable<Book> GetFarBooks { get; }
        //Возвращение конкретного товара по айди
        Book GetBookById(int bookid);
    }
}
