using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Contactus
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [Phone]
        public string? Phone { get; set; }

        [Required]
        public string? Subject { get; set; }

        [Required]
        public string? Message { get; set; }
    }
}

