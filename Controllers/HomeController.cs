using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalProject.Controllers
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
		public IActionResult about()
		{
			return View();
		}
		public IActionResult blog()
		{
			return View();
		}
        public IActionResult blog_details()
        {
            return View();
        }
		public IActionResult connect()
		{
			return View();
		}
		public IActionResult instructor()
		{
			return View();
		}
        public IActionResult Privacy()
		{
			return View();
		}
        public IActionResult main()
        {
            return View();
        }
		public IActionResult courses()
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
