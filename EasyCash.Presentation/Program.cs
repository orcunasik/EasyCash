using EasyCash.Business.Abstract;
using EasyCash.Business.Concrete;
using EasyCash.DataAccess.Abstract;
using EasyCash.DataAccess.Concrete;
using EasyCash.DataAccess.Repositories.EntityFrameworkCore;
using EasyCash.Entities.Concrete;
using EasyCash.Presentation.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EasyCashDbContext>();
builder.Services.AddIdentity<AppUser,AppRole>()
    .AddEntityFrameworkStores<EasyCashDbContext>()
    .AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddScoped<ICustomerAccountProcessDal, EfCustomerAccountProcessDal>();
builder.Services.AddScoped<ICustomerAccountProcessService, CustomerAccountProcessService>();

builder.Services.AddScoped<ICustomerAccountDal, EfCustomerAccountDal>();
builder.Services.AddScoped<ICustomerAccountService, CustomerAccountService>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
