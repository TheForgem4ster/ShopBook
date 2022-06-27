using System.Collections.Generic;
using System;

namespace DataLayer.Models
{
    /// <summary>
    /// Класс Деталей Заказов, который содержит индификационный код заказа, индификационный код 
    /// деталей заказа, индификационный код книги, цена детали заказа, свойства класса книжки, 
    /// свойства класса заказы
    /// </summary>
    public class OrderDetail
    {
        /// <summary>
        /// Индификационный код деталей заказа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Индификационный код Заказа
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Индификационный код Книги
        /// </summary>
        public int BookId{ get; set; }

        /// <summary>
        /// Цена детали заказа
        /// </summary>
        public uint Price { get; set; }

        /// <summary>
        /// свойства класса книжки
        /// </summary>
        public Book book { get; set; }

        /// <summary>
        /// свойства класса заказы
        /// </summary>
        public Order order { get; set; }

    }
}
