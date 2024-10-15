using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

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
        public ActionResult Index(string category = null)
        {
            var courses = _db.Courses.AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                courses = courses.Where(c => c.Category == category);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userCourses = _db.userCourses.Where(uc => uc.UserId == userId).ToList(); // جلب بيانات المستخدم

            var viewModel = courses.AsEnumerable().Select(course => new
            {
                Course = course,
                IsLiked = userCourses.Any(uc => uc.CourseId == course.CourseId && uc.Likes > 0),
                IsDisliked = userCourses.Any(uc => uc.CourseId == course.CourseId && uc.Dislikes > 0),
                IsSaved = userCourses.Any(uc => uc.CourseId == course.CourseId)
            }).ToList();



            return View(viewModel);
        }

        // Like a course
        [HttpPost]
        [Authorize]
        public IActionResult LikeCourse(int courseId)
        {
            // Get the UserId of the currently logged-in user
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Check if userId is null
            if (string.IsNullOrEmpty(userId))
            {
                return Json(new { success = false, message = "User is not authenticated." });
            }

            var userCourse = _db.userCourses.FirstOrDefault(uc => uc.CourseId == courseId && uc.UserId == userId);

            if (userCourse == null)
            {
                userCourse = new UserCourses
                {
                    CourseId = courseId,
                    UserId = userId,
                    Likes = 1 // Initialize likes
                };
                _db.userCourses.Add(userCourse);
            }
            else
            {
                userCourse.Likes += 1; // Increment like count
            }

            _db.SaveChanges();

            // Return the current number of likes
            return Json(new { success = true, likesCount = userCourse.Likes });
        }


        // Dislike a course
        [HttpPost]
        [Authorize]
        public IActionResult DislikeCourse(int courseId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userCourse = _db.userCourses.FirstOrDefault(uc => uc.CourseId == courseId && uc.UserId == userId);

            if (userCourse == null)
            {
                userCourse = new UserCourses
                {
                    CourseId = courseId,
                    UserId = userId,
                    Dislikes = 1 // Initialize dislikes
                };
                _db.userCourses.Add(userCourse);
            }
            else
            {
                userCourse.Dislikes += 1; // Increment dislike count
            }

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Save a course
        [HttpPost]
        [Authorize]
        public IActionResult SaveCourse(int courseId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userCourse = _db.userCourses.FirstOrDefault(uc => uc.CourseId == courseId && uc.UserId == userId);

            if (userCourse == null)
            {
                userCourse = new UserCourses
                {
                    UserId = userId,
                    CourseId = courseId,
                };

                _db.userCourses.Add(userCourse);
            }

            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}





