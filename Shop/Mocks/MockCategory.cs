using Shop.Interfaces;
using Shop.Models;

//Мокс для хранения базы локально внутри проекта без сторонней БД

namespace Shop.Mocks
{
    public class MockCategory : IBeerCategory
    {
        public IEnumerable<Category> AllCategories { 
        
        get
            {
                return new List<Category>
                {
                    new Category {CategoryName = "Безалкогольное пивко", CategoryDescription = "Если любишь пивко, но не хочешь нахрюкаться"},
                    new Category {CategoryName = "Алкогольное", CategoryDescription = "Всё с тобой ясно..."}
                };
            }
        }
    }
}
