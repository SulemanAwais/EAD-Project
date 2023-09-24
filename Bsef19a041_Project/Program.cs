using Bsef19a041_Project.Models.Interface;
using Bsef19a041_Project.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program));
//Services for sessions
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddSingleton<IProduct, ProductRepository>();
builder.Services.AddSingleton<IUser,UserRepository>();
builder.Services.AddSingleton<IAdmin, AdminRepository>();
builder.Services.AddSingleton<IOrder, OrderRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

//Middleware Of Sessions 
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
