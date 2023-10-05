using Shop.Models;

namespace Shop.Interfaces
{
    public interface IAllBeer
    {
        IEnumerable<Beer> Beer { get; }
        IEnumerable<Beer> GetFavouriteBeer { get; }
        Beer getObjectBeer(int id);
    }
}
