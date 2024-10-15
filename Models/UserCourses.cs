using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class UserCourses
    {
        [Key]
        public int UserCourseId { get; set; }
            public int CourseId { get; set; }
            public string UserId { get; set; }
            public int Rating { get; set; } // التقييم
            public bool IsFavorite { get; set; } // مفضل أم لا

        public Courses Course { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get;  set; }
    }
}
