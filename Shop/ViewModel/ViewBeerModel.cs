using Shop.Models;

namespace Shop.ViewModel
{
    public class ViewBeerModel
    {
        public IEnumerable<Beer> AllBeer { get; set; }
        public string beerCategory { get; set; }
    }
}
