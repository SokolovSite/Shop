using Microsoft.AspNetCore.Mvc;
using Shop.Interfaces;
using Shop.Models;
using Shop.ViewModel;

namespace Shop.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IAllBeer _allBeer;
        private readonly IBeerCategory _beerCategories;

        public CategoryController(IAllBeer iAllBeer, IBeerCategory iBeerCategory)
        {
            _allBeer = iAllBeer;
            _beerCategories = iBeerCategory;
        }

        IEnumerable<Beer> beer = null;
        string beerCategory = "";

        [HttpGet("Beer/List/{category}")]
        public ViewResult List(string category)
        {

            if (string.IsNullOrEmpty(category))
            { 
                beer = _allBeer.Beer.OrderBy(i => i.Id);
            }
            else

                if (string.Equals("alcoholbeer", category, StringComparison.OrdinalIgnoreCase))
                {
                    beer = _allBeer.Beer.Where(i => i.Category.CategoryName.Equals("Алкогольное")).OrderBy(i => i.Id);
                    beerCategory = "Если хочешь нахрюкаться";
                }
                else if (string.Equals("alcoholfree", category, StringComparison.OrdinalIgnoreCase))
                {
                    beer = _allBeer.Beer.Where(i => i.Category.CategoryName.Equals("Безалкогольное")).OrderBy(i => i.Id);
                    beerCategory = "Если хочешь освежиться";
                }

                var categoryObj = new BeerViewModel
                {
                    AllBeer = beer,
                    beerCategory = beerCategory,
                };

                return View(categoryObj);
        }
    }
}





