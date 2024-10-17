// Controllers/QuizController.cs
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Controllers
{
    public class QuizController : Controller
    {
        private readonly AppDbContext _context;

        public QuizController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var quizzes = _context.Quizzes.ToList();
            return View(quizzes);
        }

        public IActionResult TakeQuiz(int id)
        {
            var quiz = _context.Quizzes
                .Include(q => q.Questions)
                .ThenInclude(q => q.Answers)
                .FirstOrDefault(q => q.QuizId == id);

            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }

        [HttpPost]
        public IActionResult SubmitQuiz(int quizId, Dictionary<int, int> studentAnswers)
        {
            var quiz = _context.Quizzes
                .Include(q => q.Questions)
                .ThenInclude(q => q.Answers)
                .FirstOrDefault(q => q.QuizId == quizId);

            if (quiz == null)
            {
                return NotFound();
            }

            int score = 0;

            foreach (var question in quiz.Questions)
            {
                if (studentAnswers.ContainsKey(question.QuestionId) &&
                    studentAnswers[question.QuestionId] == question.CorrectAnswerId)
                {
                    score++;
                }
            }

            var quizResult = new QuizResult
            {
                StudentId = 1, // Replace with dynamic student ID later
                Score = score,
                TotalQuestions = quiz.Questions.Count
            };

            // Return the same view with the quiz and result
            ViewBag.QuizResult = quizResult; // Pass the result to the view
            return View("TakeQuiz", quiz); // Return the TakeQuiz view
        }

    }
}


