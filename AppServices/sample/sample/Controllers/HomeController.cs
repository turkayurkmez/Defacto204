using Microsoft.AspNetCore.Mvc;
using sample.Data;
using sample.Models;
using System.Diagnostics;

namespace sample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SampleDbContext sampleDbContext;

        public HomeController(ILogger<HomeController> logger, SampleDbContext sampleDbContext)
        {
            _logger = logger;
            this.sampleDbContext = sampleDbContext;
        }

        public IActionResult Index()
        {
            var products = sampleDbContext.Products.ToList();
            return View(products);
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
    }
}