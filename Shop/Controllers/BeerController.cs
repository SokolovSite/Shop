using Microsoft.AspNetCore.Mvc;
using Shop.Interfaces;
using Shop.Models;
using Shop.ViewModel;

namespace Shop.Controllers
{
   public class BeerController : Controller
    {
        private readonly IAllBeer _allBeer;
        private readonly IBeerCategory _beerCategories;

        public BeerController(IAllBeer iAllBeer, IBeerCategory iBeerCategory)
        {
            _allBeer = iAllBeer;
            _beerCategories = iBeerCategory;
        }

        //пути в случае которых попадем в условие фильтрации пути
        [HttpGet("Beer/List")]
        public ViewResult List(string category)
        {
            
            //путь категории в URL и его проверка
            IEnumerable<Beer> beer = null;
            beer = _allBeer.Beer.OrderBy(i => i.Id);
   
            //создание самого объекта
            var beerObj = new BeerViewModel
            {
                AllBeer = beer,
            };

            ViewBag.Title = "Пивко";
         
            return View(beerObj);
        }
    }
}
