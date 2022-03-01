using Estudos.Hotelaria.Infrastructure.MongoDb;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.UseMongoDb(builder.Configuration);

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

app.Use(async (context, next) =>
{
    var currentThreadCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
    currentThreadCulture.NumberFormat = NumberFormatInfo.InvariantInfo;

    Thread.CurrentThread.CurrentCulture = currentThreadCulture;
    Thread.CurrentThread.CurrentUICulture = currentThreadCulture;

    await next();
});

app.Run();
