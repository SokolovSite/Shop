using Shop.Interfaces;
using Shop.Models;

//Мокс для хранения базы локально внутри проекта без сторонней БД

namespace Shop.Mocks
{
    public class MockBeer : IAllBeer
    {
     
        private readonly IBeerCategory _categoryBeer = new MockCategory();
        
        public IEnumerable<Beer> Beer
        {
            get {
                return new List<Beer>()
                {
                    new Beer {
                        Name = "Жигулёвское",
                        ShortDesc = "Золотая классика",
                        LongDesc = "", 
                        Img = "/img/1.png",
                        Price = 50, 
                        IsFavourite = true, 
                        Availablbe = true,
                        Category = _categoryBeer.AllCategories.Last()
                    },
                    new Beer {
                        Name = "Green Beer",
                        ShortDesc = "Молодёжное пивко раньше было",
                        LongDesc = "",
                        Img = "/img/2.jpg",
                        Price = 70,
                        IsFavourite = true,
                        Availablbe = true,
                        Category = _categoryBeer.AllCategories.Last()
                    },
                    new Beer {
                        Name = "Gold mine beer",
                        ShortDesc = "Ну, про это сам всё понимаешь",
                        LongDesc = "",
                        Img = "/img/3.jpg",
                        Price = 80,
                        IsFavourite = true,
                        Availablbe = true,
                        Category = _categoryBeer.AllCategories.Last()
                    },
                    new Beer {
                        Name = "Bud 0.0",
                        ShortDesc = "Если хочешь освежиться",
                        LongDesc = "",
                        Img = "/img/4.png",
                        Price = 45,
                        IsFavourite = true,
                        Availablbe = true,
                        Category = _categoryBeer.AllCategories.First()
                    }
                };
            }
        }
        public IEnumerable<Beer> GetFavouriteBeer { get; set; }

        public Beer getObjectBeer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
