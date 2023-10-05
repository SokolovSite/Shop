using Shop.Interfaces;
using Shop.Models;

namespace Shop.Repository
{
    public class CategoryRepository : IBeerCategory
    {

        //переменная для работы с файлом AppDB для работы с БД
        private readonly AppDBContext AppDBContext;


        //ссылка на файл AppDB для работы с ним
        public CategoryRepository(AppDBContext AppDBContext)
        {
            this.AppDBContext = AppDBContext;
        }


        //получение всех категорий пивка
        public IEnumerable<Category> AllCategories => AppDBContext.Category;
    }
}
