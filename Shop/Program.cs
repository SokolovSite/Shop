using Microsoft.EntityFrameworkCore;
using Shop;
using Shop.Interfaces;
using Shop.Models;
//using Shop.Mocks;
using Shop.Repository;

var builder = WebApplication.CreateBuilder(args);


// ���������� �������� (�onfigurateServices)
builder.Services.AddControllersWithViews();

//������������� ���� ����������� � ��
builder.Services.AddTransient<IBeerCategory, CategoryRepository>(); 
builder.Services.AddTransient<IAllBeer, BeerRepository>();
builder.Services.AddTransient<IAllOrders, OrdersRepository>();

/* ������������� ���� ����������� � �������
builder.Services.AddTransient<IBeerCategory, MockCategory>();
builder.Services.AddTransient<IAllBeer, MockBeer>();
*/


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => ShopCart.GetCart(sp));


builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddMvc();

//����������� ����
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

//����� ������� ��� ������ ��������� ��� ��������� ������ �� ��
//����������� � ��
using (var scope = app.Services.CreateScope())
{
    AppDBContext context = scope.ServiceProvider.GetRequiredService<AppDBContext>();
    DBObj.Initial(context);
}


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    //��-��������� ������� ��������
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    //���� � ������������ �����
    app.MapControllerRoute(
    name: "category",
    pattern: "Beer/{action}/{category?}",
    defaults: new { controller = "Beer", action = "List" });

app.Run();
