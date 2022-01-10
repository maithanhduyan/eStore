using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{

    public class ApllicationContext : DbContext
    {

        public ApllicationContext(DbContextOptions<ApllicationContext> options) : base(options)
        {

        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Pizza>().ToTable("Pizza");
        }
    }
}