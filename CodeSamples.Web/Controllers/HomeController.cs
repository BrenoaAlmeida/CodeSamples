using CodeSamples.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CodeSamples.Web.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Todo()
        {
            List<string> todos = null;
            //    = new List<string>();
            //todos.Add("Todo 1");
            //todos.Add("Todo 2");
            //todos.Add("Todo 3");
            return View(todos);
        }
    }
}