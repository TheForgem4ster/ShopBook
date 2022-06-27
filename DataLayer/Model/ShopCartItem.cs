namespace DataLayer.Models
{
    /// <summary>
    /// Класс элемента корзины магазина, который содержит индификационный код, свойства класса книги, 
    /// цену и индификационный код товара внутри корзины
    /// </summary>
    public class ShopCartItem
    {
        /// <summary>
        /// Индификационный код элемента корзины магазина 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Свойство класса книги 
        /// </summary>
        public Book book { get; set; }

        /// <summary>
        /// Цена элемента корзины магазина 
        /// </summary>
        public int price { get; set; }

        /// <summary>
        /// Индификационный код товара внутри корзины
        /// </summary>
        public string ShopCartId { get; set; }
    }
}
