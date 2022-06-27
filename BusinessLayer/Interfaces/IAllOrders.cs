using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    /// <summary>
    /// Интерфейс служит для работы с заказами
    /// </summary>
    public interface IAllOrders
    {
       /// <summary>
       /// Функция которая создает заказ 
       /// </summary>
       /// <param name="order"></param>
        void CreateOrder(Order order);
    }
}
