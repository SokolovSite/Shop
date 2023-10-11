using Microsoft.AspNetCore.Mvc;
using Shop.Interfaces;
using Shop.ViewModel;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {

        private readonly IAllBeer _beerRepository;
       


        public HomeController(IAllBeer beerRepository)
        {
            _beerRepository = beerRepository;
        }

        public ViewResult Index()
        {

            var homeBeer = new HomeViewModel
            {
                FavBeer = _beerRepository.GetFavouriteBeer
            };

            return View(homeBeer);
        }

    }
}
