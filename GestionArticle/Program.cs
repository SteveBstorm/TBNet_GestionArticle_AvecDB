using ModelGlobal_DataAccessLayer.Repositories;
using ModelGlobal_DataAccessLayer.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IArticleRepository, ArticleService>();
//builder.Services.AddSingleton<IArticleRepository, ArticleService>();
//builder.Services.AddTransient<IArticleRepository, ArticleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

#region Configuration pour le décimal dans les formulaires
CultureInfo culture = new CultureInfo("fr-FR");
culture.NumberFormat.NumberDecimalSeparator = ".";

CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

app.UseRequestLocalization();

#endregion

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
