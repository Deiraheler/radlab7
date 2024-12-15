namespace StudentClassLibrary;

public class Courses
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string DepartmentName { get; set; }
    public string LecturerName { get; set; }
    public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
}