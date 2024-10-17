using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Courses
    {
        [Key]
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public string? Category { get; set; }
        public int DurationInHours { get; set; }
        public int ProjectCount { get; set; }
        public double AverageRating { get; set; }
        public string ImageUrl { get; set; }
        public string YouTubeLink { get; set; }
    }
}

