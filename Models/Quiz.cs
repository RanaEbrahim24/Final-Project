namespace FinalProject.Models
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public string QuizTitle { get; set; }
        public List<Question> Questions { get; set; }
    }
}
