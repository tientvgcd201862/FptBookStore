using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FptBookStore.Data;
using FptBookStore.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FptBookStoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FptBookStoreContext") ?? throw new InvalidOperationException("Connection string 'FptBookStoreContext' not found.")));

builder.Services.AddDefaultIdentity<DefaultUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<FptBookStoreContext>();

builder.Services.AddRazorPages();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<Cart>(sp => Cart.GetCart(sp));

builder.Services.AddHostedService<SeedData>();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    //options.IdleTimeout = TimeSpan.FromSeconds(10);
});

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Store}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});
app.Run();
