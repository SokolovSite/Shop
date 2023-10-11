using Shop.Models;

namespace Shop.ViewModel
{
    public class BeerViewModel
    {
        public IEnumerable<Beer> AllBeer { get; set; }
        public string beerCategory { get; set; }
    }
}
