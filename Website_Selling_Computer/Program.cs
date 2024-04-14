using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Website_Selling_Computer.Models;
using Website_Selling_Computer.DataAccess;
using Website_Selling_Computer.Repositories.Interfaces;
using Website_Selling_Computer.Repositories.EntityFrameworks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout= TimeSpan.FromMinutes(15);
    options.Cookie.HttpOnly=true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<WebsiteSellingComputerDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddIdentity<User, IdentityRole>()
 .AddDefaultTokenProviders()
 .AddDefaultUI()
 .AddEntityFrameworkStores<WebsiteSellingComputerDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IProduct, EFProducts>();
builder.Services.AddScoped<IProductCategory, EFProductCategory>();
builder.Services.AddScoped<IManufacturer, EFManufacturer>();
builder.Services.AddScoped<ICart, EFCart>();
builder.Services.AddScoped<I_Inventory, EFInventory>();
builder.Services.AddScoped<IOrder, EFOrder>();
builder.Services.AddScoped<IOrderDetails, EFOrderDetails>();

builder.Services.AddScoped<IProductDetails,EFProductDetails>();
builder.Services.ConfigureApplicationCookie(option =>
{
    option.LoginPath = $"/Identity/Account/Login";
    option.LogoutPath = $"/Identity/Account/Logout";
    option.LogoutPath = $"/Identity/Account/AccessDenied";

});
var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();
app.MapRazorPages();
/*app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "Admin", pattern: "{area:exists}/{controller=Product}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
});*/
/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");*/

app.MapControllerRoute(name: "Admin", pattern: "{area:exists}/{controller=Product}/{action=Index}/{id?}");
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
