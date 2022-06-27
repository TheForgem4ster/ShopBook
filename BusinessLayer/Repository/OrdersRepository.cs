using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Models;
using System;

namespace BusinessLayer.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent _appDBContent;
        private readonly ShopCart _shopCart;
        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            _appDBContent = appDBContent;
            _shopCart = shopCart;
        }
         

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
