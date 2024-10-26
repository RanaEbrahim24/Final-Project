using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Quizzes.Any())
            {
                var quiz = new Quiz
                {
                    QuizTitle = "Programming for Kids",
                    Questions = new List<Question>
                    {
                        new Question
                        {
                            Text = "What do you like to do?",
                            Answers = new List<Answer>
                            {
                                new Answer { Text = "Writing stories", IsCorrect = false },
                                new Answer { Text = "Creating programs and games", IsCorrect = true },
                                new Answer { Text = "Drawing pictures", IsCorrect = false }
                            }
                        },
                        new Question
                        {
                            Text = "Which program helps children learn programming?",
                            Answers = new List<Answer>
                            {
                                new Answer { Text = "Photoshop", IsCorrect = false },
                                new Answer { Text = "Scratch", IsCorrect = true },
                                new Answer { Text = "PowerPoint", IsCorrect = false }
                            }
                        },
                        new Question
                        {
                            Text = "What skill does programming help you improve?",
                            Answers = new List<Answer>
                            {
                                new Answer { Text = "Cooking", IsCorrect = false },
                                new Answer { Text = "Critical thinking", IsCorrect = true },
                                new Answer { Text = "Dancing", IsCorrect = false }
                            }
                        },
                        new Question
                        {
                            Text = "Where do we use programming in real life?",
                            Answers = new List<Answer>
                            {
                                new Answer { Text = "In phones, games, and robots", IsCorrect = true },
                                new Answer { Text = "In books", IsCorrect = false },
                                new Answer { Text = "In shoes", IsCorrect = false }
                            }
                        },
                        new Question
                        {
                            Text = "How does Scratch help kids with programming?",
                            Answers = new List<Answer>
                            {
                                new Answer { Text = "By giving complex code", IsCorrect = false },
                                new Answer { Text = "By using simple blocks and commands", IsCorrect = true },
                                new Answer { Text = "By drawing pictures", IsCorrect = false }
                            }
                        },
                        new Question
                        {
                            Text = "What can you create with Scratch?",
                            Answers = new List<Answer>
                            {
                                new Answer { Text = "Music", IsCorrect = false },
                                new Answer { Text = "Games and programs", IsCorrect = true },
                                new Answer { Text = "Movies", IsCorrect = false }
                            }
                        },
                        new Question
                        {
                            Text = "What do you need to do before starting programming?",
                            Answers = new List<Answer>
                            {
                                new Answer { Text = "Read and watch videos about programming", IsCorrect = true },
                                new Answer { Text = "Play a game", IsCorrect = false },
                                new Answer { Text = "Go to sleep", IsCorrect = false }
                            }
                        },
                        new Question
                        {
                            Text = "Can children learn programming without any help?",
                            Answers = new List<Answer>
                            {
                                new Answer { Text = "Yes, always", IsCorrect = false },
                                new Answer { Text = "No, they may need help at first", IsCorrect = true },
                                new Answer { Text = "Never", IsCorrect = false }
                            }
                        },
                        new Question
                        {
                            Text = "In Scratch, what are the blocks used for?",
                            Answers = new List<Answer>
                            {
                                new Answer { Text = "To build houses", IsCorrect = false },
                                new Answer { Text = "To give commands to the computer", IsCorrect = true },
                                new Answer { Text = "To write stories", IsCorrect = false }
                            }
                        },
                        new Question
                        {
                            Text = "What kind of games can you make in Scratch?",
                            Answers = new List<Answer>
                            {
                                new Answer { Text = "Only math games", IsCorrect = false },
                                new Answer { Text = "Any kind of game you can imagine", IsCorrect = true },
                                new Answer { Text = "Only racing games", IsCorrect = false }
                            }
                        }
                    }
                };

                context.Quizzes.Add(quiz);
                context.SaveChanges();
            }
        }
    }
}
