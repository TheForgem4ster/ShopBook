using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Models;
using System;

namespace BusinessLayer.Repository
{
    /// <summary>
    /// Класс хранилище заказов - для получения данных из базы данных
    /// </summary>
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent _appDBContent;
        private readonly ShopCart _shopCart;
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="appDBContent"></param>
        /// <param name="shopCart"></param>
        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            _appDBContent = appDBContent;
            _shopCart = shopCart;
        }
         
        /// <summary>
        /// Метод который создает заказ
        /// </summary>
        /// <param name="order"></param>
        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            _appDBContent.Order.Add(order);
            _appDBContent.SaveChanges();
            //переменная для хранения всех товаров которые приобретает пользователь
            var item = _shopCart.ListShopItems;

            foreach(var elem in item)
            {
                var orderDetail = new OrderDetail()
                {
                    BookId = elem.book.Id,
                    OrderId = order.Id,
                    Price = elem.book.price,
                    
                };
                _appDBContent.OrderDetail.Add(orderDetail);
            }
            //_appDBContent.SaveChanges();
           
        }
    }
}
