using OnlineShop.Web.Service;
using OnlineShop.Web.Service.IService;
using OnlineShop.Web.Utility;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IDiscountService, DiscountService>();
SD.DiscountAPIBase = builder.Configuration["ServiceUrls:DiscountAPI"];

builder.Services.AddScoped<IBaseService,BaseService>();
builder.Services.AddScoped<IDiscountService, DiscountService>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
