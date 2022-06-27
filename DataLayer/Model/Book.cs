namespace DataLayer.Models
{
    /// <summary>
    /// Класс книги, который содержит индификационный код, имя, краткое описание, оценка товара
    /// фотографию, цена, популярность, доступность, индификационный код Категории, класс категории  
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Индификационный код книги
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название книги
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Краткое описание книги
        /// </summary>
        public string shortDesc { get; set; }
        /// <summary>
        /// Оценка книги
        /// </summary>
        public string grade { get; set; }
        /// <summary>
        /// Фотография книги
        /// </summary>
        public string img { get; set; }
        /// <summary>
        /// Цена книги
        /// </summary>
        public ushort price { get; set; }
        /// <summary>
        /// Лучшие книги
        /// </summary>
        public bool isFavourite { get; set; }
        /// <summary>
        /// Доступность книги
        /// </summary>
        public bool available { get; set; }
        /// <summary>
        /// Индификационный код категории
        /// </summary>
        public int categoryId { get; set; }
        /// <summary>
        /// свойство класса категории
        /// </summary>
        public Category Category { get; set; }

    }
}
