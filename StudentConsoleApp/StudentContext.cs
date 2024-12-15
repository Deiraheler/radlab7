using Microsoft.EntityFrameworkCore;
using StudentClassLibrary;

namespace StudentConsoleApp;

public class StudentContext : DbContext
{
    public DbSet<Students> Students { get; set; }
    public DbSet<Courses> Courses { get; set; }
    
    public DbSet<StudentCourse> StudentCourses { get; set; }
    
    public string DbPath { get; }

    public StudentContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "students.db");
        Console.WriteLine(DbPath);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
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
    }
}