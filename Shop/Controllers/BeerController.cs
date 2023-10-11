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
        [Route("Beer/List")]
        [Route("Beer/List/{category}")]
        public ViewResult List(string category)
        {

            //путь категории в URL и его проверка
            IEnumerable<Beer> beer = null;
            string beerCategory = "";

            //проверка и сортирока категории по id
            if(string.IsNullOrEmpty(category))
            {
                beer = _allBeer.Beer.OrderBy(i => i.Id);
            }
            else
            {
                if(string.Equals("alcoholbeer", category, StringComparison.OrdinalIgnoreCase))
                {
                    beer = _allBeer.Beer.Where(i => i.Category.CategoryName.Equals("Алкогольное")).OrderBy(i => i.Id);
                    beerCategory = "Если хочешь нахрюкаться";
                }
                else if (string.Equals("alcoholfree", category, StringComparison.OrdinalIgnoreCase))
                {
                    beer = _allBeer.Beer.Where(i => i.Category.CategoryName.Equals("Безалкогольное")).OrderBy(i => i.Id);
                    beerCategory = "Если хочешь освежиться";
                }
            }

            //создание самого объекта
            var beerObj = new BeerViewModel
            {
                AllBeer = beer,
                beerCategory = beerCategory,
            };

            ViewBag.Title = "Пивко";
         
            return View(beerObj);
        }
    }
}
