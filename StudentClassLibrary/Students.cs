namespace StudentClassLibrary;

public class Students
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string EmailAddress { get; set; }
    
    public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
}