using Shop.Interfaces;
using Shop.Models;

namespace Shop.Repository
{
    public class OrdersRepository : IAllOrders
    {
        //переменная для добавления в бд
        private readonly AppDBContext appDBContext;
        
        //переменная для работы с корзиной
        private readonly ShopCart shopCart;

        public OrdersRepository (AppDBContext appDBContext, ShopCart shopCart)
        {
            this.appDBContext = appDBContext;
            this.shopCart = shopCart;
        }

        public void createOrder(Order order)
        {
            //установка времени заказа
            order.OrderTime = DateTime.Now;
            //добавление заказа в таблицу бд
            appDBContext.Order.Add(order);
            //переменная для получения товаров в корзину
            var items = shopCart.ListShopItems;
            //перебор товара 
            foreach (var el in items) 
            {
                //получение объекта корзины
                var orderDetail = new OrderDetail()
                {
                    BeerId = el.Beer.Id,
                    OrderId = order.Id,
                    Price = el.Beer.Price,
                };

                //добавление в бд
                appDBContext.OrderDetails.Add(orderDetail);
            }

            appDBContext.SaveChanges();
        }
    }
}
