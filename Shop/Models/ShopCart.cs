using Microsoft.EntityFrameworkCore;

namespace Shop.Models
{
    public class ShopCart
    {

        private readonly AppDBContext AppDBContext;


        //ссылка на файл AppDB для работы с ним
        public ShopCart(AppDBContext AppDBContext)
        {
            this.AppDBContext = AppDBContext;
        }

        public string ShopCartId { get; set; }

        public List<ShopCartItem> ListShopItems { get; set; }

        //создание корзины и работа сессией 
        public static ShopCart GetCart(IServiceProvider services) 
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContext>();
            string ShopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", ShopCartId);

            return new ShopCart(context) { ShopCartId = ShopCartId };
        }


       public void AddToCart (Beer beer)
        {
            AppDBContext.ShopCartItems.Add(new ShopCartItem {

                ShopCartId = ShopCartId,
                Beer = beer,
                Price = beer.Price,
            });

            AppDBContext.SaveChanges();
        }

        public List<ShopCartItem> GetShopItems()
        {
            return AppDBContext.ShopCartItems.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Beer).ToList();
        }
    }
}
