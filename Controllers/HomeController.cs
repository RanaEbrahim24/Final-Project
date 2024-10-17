using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalProject.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _appDb;



        public HomeController(ILogger<HomeController> logger, AppDbContext appDb)
        {
            _logger = logger;
            _appDb = appDb;
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
        public IActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ContactUs(Contactus contactus)
        {
            if (ModelState.IsValid)
            {
                _appDb.Contactus.Add(contactus);
                _appDb.SaveChanges();
                TempData["SuccessMessage"] = "The message has been sent successfully!";
                return RedirectToAction("ContactUs");
            }
            return View(contactus);
        }
        public IActionResult Success()
        {
            return View();
        }
        public IActionResult Tips()
        {
            return View();
        }

        public IActionResult OurTeam()
        {
            return View();
        }
    }
}
