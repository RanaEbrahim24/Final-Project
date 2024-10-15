using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public DbSet<Courses> Courses { get; set; } 
        public DbSet<UserCourses> userCourses { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
     
    }
}
