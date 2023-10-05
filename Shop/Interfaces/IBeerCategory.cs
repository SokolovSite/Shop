using Shop.Models;

namespace Shop.Interfaces
{
    public interface IBeerCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
