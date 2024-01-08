using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using SistemaVenta.AplicacionWeb.Models;
using System.Diagnostics;


namespace SistemaVenta.AplicacionWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //agreamos un metodo para seleccionar el idioma
        [HttpPost]
        public IActionResult ManejadorLenguaje(string lenguaje, string urlRetorno)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(lenguaje)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(5)}
                );
            // return RedirectToAction(nameof(Index));
            return LocalRedirect(urlRetorno);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Perfil()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}