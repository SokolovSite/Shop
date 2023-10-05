using Shop.Models;

namespace Shop.Interfaces
{
    public interface IAllOrders
    {
        //функция создания заказа
        void createOrder(Order order);
    }
}
