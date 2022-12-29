using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using usingAppInsight.Models;

namespace usingAppInsight.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TelemetryClient _telemetryClient;

        public HomeController(ILogger<HomeController> logger, TelemetryClient telemetryClient)
        {
            _logger = logger;
            _telemetryClient = telemetryClient;
        }

        public IActionResult Index()
        {

            _telemetryClient.TrackPageView("Index");
            _telemetryClient.TrackTrace("Http request, Home/Index adresine erişti...");
            try
            {
                int x = 5;
                int y = 0;
                int z = x / y;
            }
            catch (DivideByZeroException ex)
            {
                _telemetryClient.TrackException(ex);
                ViewBag.Exception = ex.Message;
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()
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