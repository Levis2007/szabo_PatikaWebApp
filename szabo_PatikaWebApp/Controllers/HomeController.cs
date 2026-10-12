using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using szabo_PatikaWebApp.Models;
using szabo_PatikaWebApp.Services;

namespace szabo_PatikaWebApp.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Gyogyszerek()
        {
            List<Gyogyszer> gyogyszerek = new GyogyszerService().GetAllGyogyszer();
            return View(gyogyszerek);
        }

        public IActionResult GyogyszerId(int id)
        {
            Gyogyszer gyogyszer = new GyogyszerService().GetById(id);
            return View(gyogyszer);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
