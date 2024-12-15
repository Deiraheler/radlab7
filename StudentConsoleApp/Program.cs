using Microsoft.EntityFrameworkCore;
using StudentClassLibrary;
using StudentConsoleApp;

using var db = new StudentContext();

if (!db.Database.EnsureCreated())
{
    Console.WriteLine("Database created successfully");
}

// Insert students
var student1 = new Students { Name = "John Doe", Age = 20, EmailAddress = "john@example.com" };
var student2 = new Students { Name = "Jane Smith", Age = 19, EmailAddress = "jsmith@example.com" };

db.Students.AddRange(student1, student2);
db.SaveChanges();

// Insert courses
var course1 = new Courses { Name = "Mathematics", DepartmentName = "Mathematics Department", LecturerName = "Dr. John Doe" };
var course2 = new Courses { Name = "Physics", DepartmentName = "Physics Department", LecturerName = "Dr. Jane Smith" };

db.Courses.AddRange(course1, course2);
db.SaveChanges();

// Assign courses to students
var studentCourse1 = new StudentCourse { StudentID = student1.ID, CourseID = course1.ID };
var studentCourse2 = new StudentCourse { StudentID = student1.ID, CourseID = course2.ID };
var studentCourse3 = new StudentCourse { StudentID = student2.ID, CourseID = course1.ID };

db.StudentCourses.AddRange(studentCourse1, studentCourse2, studentCourse3);
db.SaveChanges();

// Fetch data
var students = db.Students
    .Include(s => s.StudentCourses)
    .ThenInclude(sc => sc.Course)
    .ToList();

foreach (var student in students)
{
    Console.WriteLine($"ID: {student.ID}, Name: {student.Name}, Age: {student.Age}, Email: {student.EmailAddress}");
    Console.WriteLine("Enrolled Courses:");
    foreach (var studentCourse in student.StudentCourses)
    {
        Console.WriteLine($"- {studentCourse.Course.Name}");
    }
    Console.WriteLine();
}