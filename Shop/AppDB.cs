using Microsoft.EntityFrameworkCore;
using Shop.Interfaces;
using Shop.Models;

namespace Shop
{
    //создание класса с наследованием от фреймворка

    public class AppDBContext : DbContext
    {

        //получение базы с помощью фреймворка
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { 
        
        }
        
        //получение данных из моделей 
        public DbSet<Beer> Beer { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<ShopCartItem> ShopCartItems { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public AppDBContext()
        {
            Database.EnsureCreated();
        }


        //создание базы на основе Postgres
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=Sokolov510;");
        }
    }

}
