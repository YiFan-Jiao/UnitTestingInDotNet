using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UnitTestingInDotNet.Data;
using UnitTestingInDotNet.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UnitTestingInDotNetContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UnitTestingInDotNetContext") ?? throw new InvalidOperationException("Connection string 'UnitTestingInDotNetContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IRepository<Vehicle>), typeof(VehicleRepo));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Vehicles}/{action=Create}/{id?}");

app.Run();
