using Microsoft.AspNetCore.Mvc;
using Shop.Interfaces;
using Shop.Models;
using Shop.ViewModel;

namespace Shop.Controllers
{
    public class ShopCartController : Controller
    {
        
        private readonly IAllBeer _beerRepository;
        private readonly ShopCart _shopCart;


        public ShopCartController(IAllBeer beerRepository, ShopCart shopCart)
        {
            _beerRepository = beerRepository;
            _shopCart = shopCart;
        }

        [HttpGet]
        public ViewResult Index()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;


            var obj = new ShopCartViewModel
            {
                ShopCart = _shopCart,
            };

            return View(obj);
        }

        [HttpGet]
        public RedirectToActionResult AddToCart(int id)
        {
            var item = _beerRepository.Beer.FirstOrDefault(x => x.Id == id);

            if(item != null)
            {
                _shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }

    }
}
