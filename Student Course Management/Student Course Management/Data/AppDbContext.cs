using Microsoft.EntityFrameworkCore;
using Student_Course_Management.Models;

namespace Student_Course_Management.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithOne(c => c.Student)
                .HasForeignKey(c => c.StudentId);
        }
    }
}
