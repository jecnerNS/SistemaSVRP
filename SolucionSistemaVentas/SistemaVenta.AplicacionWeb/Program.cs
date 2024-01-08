using SistemaVenta.AplicacionWeb.Utilidades.Automapper;

using SistemaVenta.IOC;

//exportamos este paquete
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

//Soporte para glovalizacion y localizacion
builder.Services.AddLocalization(option =>
{
    option.ResourcesPath = "Recursos";
});

builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();

//Mas soporte para cookies del lenguaje
builder.Services.Configure<RequestLocalizationOptions>(
    option =>
    {
        var lenguajesSoportados = new List<CultureInfo>
        {
            new CultureInfo("es"),
            new CultureInfo("en"),
            new CultureInfo("pt"),
            new CultureInfo("ru")

        };
        option.DefaultRequestCulture = new RequestCulture("es");
        option.SupportedCultures = lenguajesSoportados;
        option.SupportedUICultures = lenguajesSoportados;
    }
    );


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.InyectarDependencia(builder.Configuration);

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

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

//agreamos localization
app.UseRequestLocalization();

//creamos una variables
//var lenguajesSoportados = new[] { "es", "en", "ru", "pt" };
//var opcionesLocalizacion = new RequestLocalizationOptions().SetDefaultCulture(lenguajesSoportados[0])
  //  .AddSupportedCultures(lenguajesSoportados)
    //.AddSupportedUICultures(lenguajesSoportados);

//app.UseRequestLocalization(opcionesLocalizacion);
   

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
