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

        public IActionResult SubmitQuiz(int quizId, Dictionary<int, int> studentAnswers)
        {
          
            var quiz = _context.Quizzes.Include(q => q.Questions)
                                        .ThenInclude(q => q.Answers)
                                        .FirstOrDefault(q => q.QuizId == quizId);

            if (quiz == null)
            {
                return NotFound();
            }

          
            var unansweredQuestions = quiz.Questions
                .Where(q => !studentAnswers.ContainsKey(q.QuestionId))
                .ToList();

            if (unansweredQuestions.Any())
            {
                
                TempData["ErrorMessage"] = "Please answer all questions before submitting.";
                return RedirectToAction("TakeQuiz", new { id = quizId });
            }

            int score = 0;

            foreach (var question in quiz.Questions)
            {
                Console.WriteLine($"QuestionId: {question.QuestionId}, CorrectAnswerId: {question.CorrectAnswerId}");

                if (studentAnswers.TryGetValue(question.QuestionId, out var selectedAnswerId))
                {
                    Console.WriteLine($"Student Selected AnswerId: {selectedAnswerId}");

                    var correctAnswer = question.Answers.FirstOrDefault(a => a.IsCorrect);

                    if (correctAnswer != null && selectedAnswerId == correctAnswer.AnswerId)
                    {
                        score++;
                        Console.WriteLine("Correct answer!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect answer.");
                    }
                }
                else
                {
                    Console.WriteLine("No answer selected for this question.");
                }
            }

            Console.WriteLine($"Final Score: {score} out of {quiz.Questions.Count}");

            ViewData["TotalQuestions"] = quiz.Questions.Count; 
            return View("Result", score); 
        }




    }
}



