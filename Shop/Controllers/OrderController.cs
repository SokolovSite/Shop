using Microsoft.AspNetCore.Mvc;
using Shop.Interfaces;
using Shop.Models;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {

        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        //Функция для получения формы
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }


        //ловим срабатываение метода пост с Checkout, когда отпраляют форму
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.ListShopItems = shopCart.GetShopItems();

            if(shopCart.ListShopItems == null) 
            {
                ModelState.AddModelError(""," Нечего затаривать :(");
            }

            if(ModelState.IsValid)
            {
                allOrders.createOrder(order);

                return RedirectToAction("Complete");
            }
            return View(order);
        }

        [HttpGet]
        public IActionResult Complete() 
        {
            ViewBag.Message = "Затарено :)";
            return View();
        }

    }
}
