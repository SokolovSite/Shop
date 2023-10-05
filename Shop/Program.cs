using Microsoft.EntityFrameworkCore;
using Shop;
using Shop.Interfaces;
using Shop.Models;
//using Shop.Mocks;
using Shop.Repository;

var builder = WebApplication.CreateBuilder(args);


// Добавление сервисов (СonfigurateServices)
builder.Services.AddControllersWithViews();

//использование всех интерфейсов с БД
builder.Services.AddTransient<IBeerCategory, CategoryRepository>(); 
builder.Services.AddTransient<IAllBeer, BeerRepository>();
builder.Services.AddTransient<IAllOrders, OrdersRepository>();

/* использование всех интерфейсов с моксами
builder.Services.AddTransient<IBeerCategory, MockCategory>();
builder.Services.AddTransient<IAllBeer, MockBeer>();
*/


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => ShopCart.GetCart(sp));


builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddMvc();

//подключение базы
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<AppDBContext>(opt =>
        opt.UseNpgsql(builder.Configuration.GetConnectionString("SampleDbConnection")));

var app = builder.Build();

// (Configure) 
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
   
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

//вызов функции при старте программы для получения данных из БД
//подключение к БД
using (var scope = app.Services.CreateScope())
{
    AppDBContext context = scope.ServiceProvider.GetRequiredService<AppDBContext>();
    DBObj.Initial(context);
}


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    //по-умолчанию главная страница
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    //путь к алкогольному пивку
    app.MapControllerRoute(
    name: "category",
    pattern: "Beer/{action}/{category?}",
    defaults: new { controller = "Beer", action = "List" });

app.Run();
