using System.Collections.Generic;

namespace DataLayer.Models
{
    /// <summary>
    /// Класс категории книг, который содержит индификационный код, имя, описание
    /// Лист книг 
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Индификационный код категории
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название категории
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// Описание категории
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// Лист книг
        /// </summary>
        public List<Book> Books { get; set; }
    }
}
