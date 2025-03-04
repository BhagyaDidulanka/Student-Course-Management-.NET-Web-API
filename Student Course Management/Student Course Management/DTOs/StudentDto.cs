namespace Student_Course_Management.DTOs
{
    public class StudentDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> Courses { get; set; } = new();
    }
}
