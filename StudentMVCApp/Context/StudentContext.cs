using Microsoft.EntityFrameworkCore;
using StudentClassLibrary;

namespace StudentMVCAppNew.Context;

public class StudentContext : DbContext
{
    public DbSet<Students> Students { get; set; }
    public DbSet<Courses> Courses { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }

    public StudentContext(DbContextOptions<StudentContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define many-to-many relationship
        modelBuilder.Entity<StudentCourse>()
            .HasKey(sc => new { sc.StudentID, sc.CourseID });

        modelBuilder.Entity<StudentCourse>()
            .HasOne(sc => sc.Student)
            .WithMany(s => s.StudentCourses)
            .HasForeignKey(sc => sc.StudentID);

        modelBuilder.Entity<StudentCourse>()
            .HasOne(sc => sc.Course)
            .WithMany(c => c.StudentCourses)
            .HasForeignKey(sc => sc.CourseID);

        modelBuilder.Entity<Students>()
            .Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<Courses>()
            .Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}