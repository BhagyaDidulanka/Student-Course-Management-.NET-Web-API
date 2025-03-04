namespace Student_Course_Management.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
