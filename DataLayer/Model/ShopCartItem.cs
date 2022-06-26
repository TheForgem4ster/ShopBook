namespace DataLayer.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Book book { get; set; }
        public int price { get; set; }
        //Айди товара внутри корзины
        public string ShopCartId { get; set; }
    }
}
