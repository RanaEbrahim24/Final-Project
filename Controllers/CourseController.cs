using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _db;

        public CourseController(AppDbContext db)
        {
            _db = db; // Dependency Injection
        }

        // Display course list
        public async Task<IActionResult> Index()
        {
            var courses = await _db.Courses.ToListAsync();
            return View(courses);
        }

        // GET: Course/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Courses course)
        {
            if (ModelState.IsValid)
            {
                _db.Courses.Add(course);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Course/Edit/{id}
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var course = _db.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Course/Edit/{id}
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id, Courses course)
        {
            if (id != course.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(course);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // POST: Course/Delete/{id}
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var course = _db.Courses.Find(id);
            if (course != null)
            {
                _db.Courses.Remove(course);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        // In CourseController.cs
        public async Task<IActionResult> Search(string Search)
        {
            if (string.IsNullOrWhiteSpace(Search))
            {
                return RedirectToAction(nameof(Index)); // Redirect to the index if no search term is provided
            }

            var courses = await _db.Courses
                .Where(c => c.Title.Contains(Search) || c.Category.Contains(Search))
                .ToListAsync();

            return View("Index", courses); // Return the Index view with the filtered courses
        }

    }
}








