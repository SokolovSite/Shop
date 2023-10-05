using Microsoft.EntityFrameworkCore;
using Shop.Interfaces;
using Shop.Models;


namespace Shop.Repository
{
    public class BeerRepository : IAllBeer
    {

        //переменная для работы с файлом AppDB для работы с БД
        private readonly AppDBContext AppDBContext;


        //ссылка на файл AppDB для работы с ним
        public BeerRepository(AppDBContext AppDBContext)
        {
            this.AppDBContext = AppDBContext;
        }


        //получение всех данных, которые релевантны одной из категорий пивка
        public IEnumerable<Beer> Beer => AppDBContext.Beer.Include(b => b.Category);


        //получение всех объектов у которых isFavourite = true, с помощью условия Where
        public IEnumerable<Beer> GetFavouriteBeer => AppDBContext.Beer.Where(p => p.IsFavourite).Include(c => c.Category);


        //получение одно объекта по его id 
        public Beer getObjectBeer(int id) => AppDBContext.Beer.FirstOrDefault(g => g.Id == id);
        
    }
}
